using System;
using System.Reflection;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    /// <summary>
    /// Represents the "About" form that displays application version information.
    /// </summary>
    public partial class FormAbout : Form
    {
        private readonly FormMain mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAbout"/> class.
        /// </summary>
        /// <param name="form">The main form that launched this form.</param>
        public FormAbout(FormMain form)
        {
            mainForm = form;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Handles the load event of the form. Retrieves the current application version
        /// and displays it in the version label.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments associated with the load event.</param>
        private void FormAbout_Load(object sender, EventArgs e)
        {
            // Get the version of the current assembly
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            // Display the version in a Label
            lblVersion.Text = $"Version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";

            // Get the Copyright information from the assembly attributes
            AssemblyCopyrightAttribute copyright = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(
                Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));

            if (copyright != null)
            {
                // Display the copyright in a label
                lblYears.Text = copyright.Copyright;
            }
        }

        /// <summary>
        /// Handles the click event of the Close button. Closes the "About" form and 
        /// returns focus to the main form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments associated with the click event.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
