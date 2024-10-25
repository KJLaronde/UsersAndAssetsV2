using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace SharedMethods
{
    public static class ADMethods
    {
        public static bool IsUserInIT()
        {
            // Determine if the user is a member of IT 
            try
            {
                string currentUser = WindowsIdentity.GetCurrent().Name;
                string domain = "DC=nation,DC=ho-chunk,DC=com";
                string[] groupNames = new string[2];

                // List the Role Groups (by SID) which contain users that will have management-level access
                string[] permissionGroups = {
                     "S-1-5-21-3050526138-983222676-3468507785-1133"    // DEJAdmins-R
                    //,"S-1-5-21-3050526138-983222676-3468507785-512"      // Domain Admins
                };

                // Remove the "NATION\" prefix from the username
                currentUser = currentUser.Remove(0, @"NATION\".Length);

                List<string> groups = GetUserGroups(domain, currentUser);
                foreach (string group in groups)
                {
                    // Split the group's friendly name from its SID
                    groupNames = group.Split(':');

                    for (int i = 0; i < permissionGroups.Length; i++)
                    {
                        if (groupNames[1].Trim() == permissionGroups[i])
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                CommonMethods.DisplayError(e.Message);
                return false;
            }
        }
        public static List<string> GetEmailAddresses(string accountStatus, string[] ouList = null)
        {
            List<string> emailList = new List<string>();

            try
            {
                string domain = "DC=nation,DC=ho-chunk,DC=com";
                
                if (ouList == null)
                { 
                    ouList = ["DEJ", "MCB", "MIL"];
                }

                DirectoryEntry entry;
                foreach (string ouName in ouList)
                {
                    entry = new DirectoryEntry("LDAP://OU=" + ouName + ',' + domain);
                    DirectorySearcher searcher = new DirectorySearcher(entry)
                    {
                        SizeLimit = int.MaxValue,
                        PageSize = int.MaxValue,
                        Filter = "(&(objectClass=user)(mail=*))"  // Filter to include only users with an email
                    };

                    // Modify the filter based on account status
                    switch (accountStatus.ToLower())
                    {
                        case "enabled":
                            searcher.Filter = "(&(objectClass=user)(mail=*)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))"; // Only enabled accounts
                            break;
                        case "disabled":
                            searcher.Filter = "(&(objectClass=user)(mail=*)(userAccountControl:1.2.840.113556.1.4.803:=2))"; // Only disabled accounts
                            break;
                        case "all":
                        default:
                            // No additional filter needed, use the default filter
                            break;
                    }

                    foreach (SearchResult result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetDirectoryEntry();
                        if (de.Properties.Contains("mail"))
                        {
                            string email = de.Properties["mail"].Value.ToString();
                            emailList.Add(email);
                        }
                    }

                    searcher.Dispose();
                    entry.Dispose();
                }

                emailList.Sort();
                return emailList;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
                return null;
            }
        }
        public static bool SearchGroup(GroupPrincipal group, string currentUser)
        {
            /* Search through an AD group to see if the current user is listed */
            try
            {
                // If the Group is found
                if (group != null)
                {
                    // Loop through each user within the Group
                    foreach (Principal p in group.GetMembers())
                    {
                        // If any user is found
                        if (p is UserPrincipal theUser)
                        {
                            // Include the domain name with the SAM Account Name
                            string groupUser = @"NATION\" + theUser.SamAccountName;
                            // If the current machine user matches a user in the Group
                            if (currentUser == groupUser)
                                // Success (user found)
                                return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception err)
            {
                CommonMethods.DisplayError("An error occurred when searching the AD group.\n\n" + err.Message);
                return false;
            }
        }
        public static List<string> GetAdObjectNames(string objectType)
        {
            try
            {
                string domain = "DC=nation,DC=ho-chunk,DC=com";
                string[] ouList = { "OU=DEJ", "OU=MCB", "OU=MIL" };
                List<string> objectList = new List<string>();
                DirectoryEntry entry;

                foreach (string ouName in ouList)
                {
                    entry = new DirectoryEntry("LDAP://" + ouName + ',' + domain);
                    DirectorySearcher searcher = new DirectorySearcher(entry)
                    {
                        SizeLimit = int.MaxValue,
                        PageSize = int.MaxValue,
                    };

                    if (objectType.ToLower() == "user")
                    {
                        searcher.Filter = "(objectClass=user)";
                    }
                    else if (objectType.ToLower() == "computer")
                    {
                        searcher.Filter = "(objectClass=computer)";
                    }
                    else
                    {
                        CommonMethods.DisplayError("There is a problem with the AD object type.");
                        return null;
                    }


                    foreach (SearchResult result in searcher.FindAll())
                    {
                        string objectName = result.GetDirectoryEntry().Name;
                        if (objectName.StartsWith("CN="))
                        {
                            objectName = objectName.Remove(0, "CN=".Length);
                            objectList.Add(objectName);
                        }
                    }

                    searcher.Dispose();
                    entry.Dispose();
                }

                objectList.Sort();
                return objectList;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
                return null;
            }
        }
        public static List<string> GetUserGroups(string domainDN, string samAccountName)
        {
            List<string> lGroups = new List<string>();
            try
            {
                //Create the DirectoryEntry object to bind the distingusihedName of the domain 
                using (DirectoryEntry rootDE = new DirectoryEntry("LDAP://" + domainDN))
                {
                    //Create a DirectorySearcher for performing a search on abiove created DirectoryEntry 
                    using (DirectorySearcher dSearcher = new DirectorySearcher(rootDE))
                    {
                        //Create the sAMAccountName as filter 
                        dSearcher.Filter = "(&(sAMAccountName=" + samAccountName + ")(objectClass=User)(objectCategory=Person))";
                        dSearcher.PropertiesToLoad.Add("memberOf");
                        dSearcher.ClientTimeout.Add(new TimeSpan(0, 20, 0));
                        dSearcher.ServerTimeLimit.Add(new TimeSpan(0, 20, 0));

                        //Search the user in AD 
                        SearchResult sResult = dSearcher.FindOne();
                        if (sResult == null)
                        {
                            throw new ApplicationException("No user with username " + samAccountName + " could be found in the domain");
                        }
                        else
                        {
                            //Once we get the user, let us get all the memberOF attibute's value 
                            foreach (var grp in sResult.Properties["memberOf"])
                            {
                                string sGrpName = Convert.ToString(grp).Remove(0, 3);
                                //Bind to this group 
                                DirectoryEntry deTempForSID = new DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\\/"));
                                try
                                {
                                    deTempForSID.RefreshCache();

                                    //Get the objectSID which is Byte array 
                                    byte[] objectSid = (byte[])deTempForSID.Properties["objectSid"].Value;

                                    //Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
                                    //byte array to SDDL format 
                                    SecurityIdentifier SID = new SecurityIdentifier(objectSid, 0);

                                    if (sGrpName.Contains(",CN"))
                                    {
                                        sGrpName = sGrpName.Remove(sGrpName.IndexOf(",CN"));
                                    }
                                    else if (sGrpName.Contains(",OU"))
                                    {
                                        sGrpName = sGrpName.Remove(sGrpName.IndexOf(",OU"));
                                    }

                                    //Perform a recursive search on these groups. 
                                    RecursivelyGetGroups(dSearcher, lGroups, sGrpName, SID.ToString());
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error while binding to path : " + grp.ToString());
                                    Console.WriteLine(ex.Message.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the distinguishedName of the domain if it is as per your domain or not?");
                Console.WriteLine(ex.Message.ToString());
                System.Environment.Exit(0);
            }
            return lGroups;

        }
        public static void RecursivelyGetGroups(DirectorySearcher dSearcher, List<string> lGroups, string sGrpName, string SID)
        {
            //Check if the group has already not found 
            if (!lGroups.Contains(sGrpName))
            {
                lGroups.Add(sGrpName + " : " + SID);

                //Now perform the search based on this group 
                dSearcher.Filter = "(&(objectClass=grp)(CN=" + sGrpName + "))".Replace("\\", "\\\\");
                dSearcher.ClientTimeout.Add(new TimeSpan(0, 2, 0));
                dSearcher.ServerTimeLimit.Add(new TimeSpan(0, 2, 0));

                //Search this group 
                SearchResult GroupSearchResult = dSearcher.FindOne();
                if ((GroupSearchResult != null))
                {
                    foreach (var grp in GroupSearchResult.Properties["memberOf"])
                    {
                        string ParentGroupName = Convert.ToString(grp).Remove(0, 3);

                        //Bind to this group 
                        DirectoryEntry deTempForSID = new DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\\/"));
                        try
                        {
                            //Get the objectSID which is Byte array 
                            byte[] objectSid = (byte[])deTempForSID.Properties["objectSid"].Value;

                            //Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
                            //byte array to SDDL format 
                            System.Security.Principal.SecurityIdentifier ParentSID = new System.Security.Principal.SecurityIdentifier(objectSid, 0);

                            if (ParentGroupName.Contains(",CN"))
                            {
                                ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",CN"));
                            }
                            else if (ParentGroupName.Contains(",OU"))
                            {
                                ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",OU"));
                            }
                            RecursivelyGetGroups(dSearcher, lGroups, ParentGroupName, ParentSID.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error while binding to path : " + grp.ToString());
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }
            }
        }
    }
}
