using LoginSystem.Database;
using System;
using System.Windows.Forms;

namespace LoginSystem.Forms
{
    public partial class RegisterPage : Form
    {
        private readonly TableUser table = new TableUser();
        private readonly ModelUser model = new ModelUser();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;

                    table.Username = username;
                    table.Password = password;

                    model.TableUsers.Add(table);

                    if (model.SaveChanges() > 0)
                    {
                        MessageBox.Show("User added now you can use the credential to login!", "LoginSystem");
                    }
                    else
                    {
                        MessageBox.Show("Error to register user!", "LoginSystem");
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty!", "LoginSystem");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Error : Message is {er.Message}", "LoginSystem");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void RegisterPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}