using PracticeWinApp.Database;
using PracticeWinApp.Utils;
using System;
using System.Windows.Forms;

namespace PracticeWinApp
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            var username = LoginText.Text;
            var password = PasswordText.Text;
            var confirmPassword = ConfirmPasswordText.Text;

            const string requirements = "Пароль не соответсвует требованиям:" +
                                        "\n- Как минимум 6 символов" +
                                        "\n- Спепиальный символ" +
                                        "\n- Цифру" +
                                        "\n- Заглавную букву" +
                                        "\n- Прописную букву";

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Поле имени пользователя или пароля пусты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Registration.IsPasswordValid(password))
            {
                MessageBox.Show(requirements, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Registration.IsUsernameAvailable(username))
            {
                MessageBox.Show("Такой логин уже занят.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (DbAppContext context = new DbAppContext())
            {
                var newUser = new User { Username = username, Password = password };
                context.Set<User>().Add(newUser);
                context.SaveChanges();
            }

            MessageBox.Show("Аккаунт успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MenuForm redirectForm = new MenuForm();
            redirectForm.Show();
            Hide();
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                PasswordText.PasswordChar = '\0';
                ConfirmPasswordText.PasswordChar = '\0';
            }
            else
            {
                PasswordText.PasswordChar = '*';
                ConfirmPasswordText.PasswordChar = '*';

            }
        }

        private void LoginLabel_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            LoginText.Clear();
            PasswordText.Clear();
            ConfirmPasswordText.Clear();
        }
    }
}
