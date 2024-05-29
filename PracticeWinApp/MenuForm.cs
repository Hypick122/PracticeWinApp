using System;
using System.Windows.Forms;

namespace PracticeWinApp
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.IsLogged = false;
            Properties.Settings.Default.Save();

            LoginForm redirectForm = new LoginForm();
            redirectForm.Show();
            Hide();
        }
    }
}
