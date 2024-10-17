using System;
using System.Reflection;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormAbout : Form
    {
        private readonly FormMain mainForm;

        public FormAbout(FormMain form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            // Get the version of the current assembly
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            // Display the version in a Label
            lblVersion.Text = $"Version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
