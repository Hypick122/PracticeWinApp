using PracticeWinApp.Utils;
using System;
using System.Windows.Forms;

namespace PracticeWinApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsLogged)
            {
                string username = Properties.Settings.Default.Username;
                string password = Properties.Settings.Default.Password;
                if (Login.IsCredentialsValid(username, password))
                {
                    MenuForm redirectForm = new MenuForm();
                    redirectForm.Show();
                    this.Hide();
                }
                else
                {
                    Properties.Settings.Default.Username = null;
                    Properties.Settings.Default.Password = null;
                    Properties.Settings.Default.IsLogged = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Вы вышли из аккаунт, т.к. пароль был изменен");
                }
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = LoginText.Text;
            string password = PasswordText.Text;

            if (Login.IsCredentialsValid(username, password))
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.IsLogged = true;
                Properties.Settings.Default.Save();

                MenuForm redirectForm = new MenuForm();
                redirectForm.Show();
                Hide();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            PasswordText.PasswordChar = checkBoxShowPass.Checked ? '\0' : '*';
        }

        private void RegLabel_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            LoginText.Clear();
            PasswordText.Clear();
        }
    }
}
