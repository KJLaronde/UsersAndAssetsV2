using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedMethods
{
    public static class CommonMethods
    {
        public static string CreateTempFile(string fileExtension)
        {
            try
            {
                Directory.CreateDirectory(@"C:\Temp\");
                return Path.Combine(@"C:\Temp\", Path.GetTempFileName() + fileExtension);
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                return null;
            }
        }
        public static void DisplayError(string errorMessage, string title = "Error")
        {
            MessageBox.Show("An error has occurred. Please contact your administrator.\n\n" + errorMessage, title);
        }
        public static bool IsValidIP(string addr)
        {
            // Create the match pattern.
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

            // Create the Regular Expression object.
            Regex check = new Regex(pattern);

            // Boolean variable to hold the status.
            bool valid = false;

            // Check to make sure an ip address was provided.
            if (addr == "")
            {
                // No address provided so return false.
                valid = false;
            }
            else
            {
                // Address provided so use the IsMatch Method of the Regular Expression object.
                valid = check.IsMatch(addr, 0);
            }

            // Return the results.
            return valid;
        }
        public static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
        public static class WinObjFunctions
        {
            /// <summary>
            /// Counts up the accumulative widths of all of a datagrid's columns
            /// EXAMPLE:
            ///     grdOutputData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ///     grdOutputData.DataSource = dataTable;
            ///     int width = WinObjFunctions.CountGridWidth(grdOutputData) + 25;
            ///     ClientSize = new Size(width, ClientSize.Height);
            /// </summary>
            /// <param name="dgv"></param>
            /// <returns></returns>
            public static int CountGridWidth(DataGridView dgv)
            {
                int width = 0;
                foreach (DataGridViewColumn column in dgv.Columns)
                    if (column.Visible == true)
                        width += column.Width;
                return width += 20;
            }
        }
    }
}
