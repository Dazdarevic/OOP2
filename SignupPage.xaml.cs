using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
using MD5CryptoServiceProvider = System.Security.Cryptography.MD5CryptoServiceProvider;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void btnSingup_Click(object sender, RoutedEventArgs e)
        {
            //VALIDACIJA UNETIH VREDNOSTI
            errorUsername.Content = "";
            errorPassword.Content = "";

            string pattern = "^[a-zA-Z]{5,}$";
            string pattern2 = "^[a-zA-Z0-9]{8,}$";

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
            else if (!Regex.IsMatch(txtUsername.Text, pattern))
            {
                errorUsername.Content = "Username must contain only letters and be at least 5 characters.";
                txtUsername.Focus();
            }
            else if (!Regex.IsMatch(txtPassword.Password.ToString(), pattern2))
            {
                errorPassword.Content = "Password must be at least 8 characters.";
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
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
#pragma warning disable SYSLIB0021 // Type or member is obsolete
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateEncryptor();
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
                        String query2 = "INSERT INTO Persons (username, pass, roleu) VALUES(@username,@password, @value)";
                        SqlCommand cmd = new SqlCommand(query2, sqlCon);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", pom);
                        if (btnRadio1.IsChecked == true)
                            cmd.Parameters.AddWithValue("@value", "student");
                        else if (btnRadio2.IsChecked == true)
                            cmd.Parameters.AddWithValue("@value", "admin");

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Account has been successfully created.");
                        this.NavigationService.Navigate(new LoginPage());

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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
