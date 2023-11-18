using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XSystem.Security.Cryptography;
using ICryptoTransform = System.Security.Cryptography.ICryptoTransform;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            errorUsername.Content = "";
            errorPassword.Content = "";

            if (txtUsername.Text == "" && txtPassword.Password.ToString() == "")
            {
                errorUsername.Content = "Username is required.";
                errorPassword.Content = "Password is required.";
                txtUsername.Focus();
                txtPassword.Focus();
            }
            else if (txtUsername.Text == "")
            {
                errorUsername.Content = "Username is required.";
                txtUsername.Focus();
            }
            else if (txtPassword.Password.ToString() == "")
            {
                errorPassword.Content = "Password is required.";
                txtPassword.Focus();
            }
            else
            {

                SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=projekatOOP2; Integrated Security=True;");

                string hash = "aksjaos";
                string pom = txtPassword.Password.ToString();
                //encrypt
                byte[] data = UTF8Encoding.UTF8.GetBytes(pom);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
                using (XSystem.Security.Cryptography.MD5CryptoServiceProvider md5 = new XSystem.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
#pragma warning disable SYSLIB0021 // Type or member is obsolete
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        pom = Convert.ToBase64String(results, 0, results.Length);
                    }
#pragma warning restore SYSLIB0021 // Type or member is obsolete
                }
#pragma warning restore SYSLIB0021 // Type or member is obsolete
                try
                {
                    if (sqlCon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        String query = "SELECT COUNT(1) from Persons WHERE username=@username  AND pass=@password";
                        SqlCommand cmd = new SqlCommand(query, sqlCon);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", pom);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());


                        if (count == 1)
                        {

                            SqlCommand command = new SqlCommand("SELECT roleu FROM Persons WHERE username = @username AND pass = @password", sqlCon);
                            command.Parameters.AddWithValue("@username", txtUsername.Text);
                            command.Parameters.AddWithValue("@password", pom);

                            try
                            {
                                string role = (string)command.ExecuteScalar();
                                SqlCommand command2 = new SqlCommand("SELECT id FROM Persons WHERE username = @username AND pass = @password", sqlCon);
                                command2.Parameters.AddWithValue("@username", txtUsername.Text);
                                command2.Parameters.AddWithValue("@password", pom);

                                int id = (int)command2.ExecuteScalar();

                                if (role == null)
                                {
                                    MessageBox.Show("Role is null");
                                }
                                else if (role.Trim().ToLower() == "student")
                                {
                                    StudentPage.ID = id;
                                    LoadAll.ID = id;
                                    StudentPage sp = new StudentPage();
                                    this.NavigationService.Navigate(sp);
                                }
                                else if (role.Trim().ToLower() == "admin")
                                {
                                    
                                        UsersPage.ID = id;
                                        AdminPage.ID = id;
                                        AdminPage ap = new AdminPage();
                                        ap.username.Content = txtUsername.Text;
                                        this.NavigationService.Navigate(ap);
                                        
                                }
                                else
                                {
                                    MessageBox.Show("Unexpected role value:" + role);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error while navigating to the new page: " + ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Username or password is incorrect.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    sqlCon.Close();
                }
            }
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignupPage());
        }
    }
}
