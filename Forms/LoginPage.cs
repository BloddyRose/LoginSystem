using LoginSystem.Database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LoginSystem.Forms
{
    public partial class LoginPage : Form
    {
        private readonly ModelUser model = new ModelUser();
        private readonly TableUser table = new TableUser();
        private static string username, password = string.Empty;

        public LoginPage()
        {
            InitializeComponent();
        }

        public string Username => username;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                username = txtUsername.Text;
                password = txtPassword.Text;

                if (model.TableUsers.Any(x => x.Username == username) && model.TableUsers.Any(x => x.Password == password))
                {
                    Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("User dosen't exists, Register!", "LoginSystem");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Error Message : {er.Message}", "LoginSystem");
            }
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
        }
    }
}