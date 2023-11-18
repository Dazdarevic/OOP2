using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using XSystem.Security.Cryptography;
using System.Security.Cryptography;
using MD5CryptoServiceProvider = System.Security.Cryptography.MD5CryptoServiceProvider;
using OneTimePadAlgorithm;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            
            LoadGrid();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=projekatOOP2; Integrated Security=True;");
        public static int ID { get; set; }

        public void LoadGrid()
        {

            int userId = UsersPage.ID;
 
            SqlCommand query = new SqlCommand("Select id as ID, username  AS Username, roleu AS Role from Persons WHERE id != @id", sqlCon);

            //query.CommandType = CommandType.Text;
            query.Parameters.AddWithValue("@id", userId);
            DataTable dt = new DataTable();
            sqlCon.Open();

            SqlDataReader sdr = query.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();
            dataGrid.ItemsSource = dt.DefaultView;


        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPage ap = new AdminPage();
            this.NavigationService.Navigate(ap);
            ap.username.Content = username.Content;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string pattern = "^[a-zA-Z]+$";
            string pattern2 = "^[a-zA-Z0-9]{8,}$";

            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                errorUsername.Content = "Username is required.";
                errorPassword.Content = "Password is required.";
                txtUsername.Focus();
                txtPassword.Focus();
            }
            else if (!Regex.IsMatch(txtUsername.Text, pattern))
            {
                errorUsername.Content = "Username must contain only letters.";
                txtUsername.Focus();
            }
            else if (!Regex.IsMatch(txtPassword.Text, pattern2))
            {
                errorPassword.Content = "Password must be at least 8 characters.";
                txtPassword.Focus();
            }
            else if (txtUsername.Text == "")
            {
                errorPassword.Content = "";
                errorUsername.Content = "Username is required.";
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                errorUsername.Content = "";
                errorPassword.Content = "Password is required.";
                txtPassword.Focus();
            }
            else
            {
                string hash = "aksjaos";
                string pom = txtPassword.Text;
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

                        
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        errorUsername.Content = "";
                        errorPassword.Content = "";
                        MessageBox.Show("Account has been successfully created.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                    LoadGrid();
                }
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("ID and Username are required.");
            }
            else
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Persons set username=@username, roleu=@role WHERE Id=@id", sqlCon);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                if (btnRadio1.IsChecked == true)
                    cmd.Parameters.AddWithValue("@role", "student");
                else if (btnRadio2.IsChecked == true)
                    cmd.Parameters.AddWithValue("@role", "admin");

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                    sqlCon.Close();
                    txtId.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    LoadGrid();
                    sqlCon.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(txtId.Text=="")
            {
                MessageBox.Show("ID is required.");
            }
            else
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Persons WHERE Id=" + txtId.Text, sqlCon);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    sqlCon.Close();
                    txtId.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    LoadGrid();
                    sqlCon.Close(); 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            
        }

        private void txtId_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("ID must be number.", "Warning...");
            }
        }
    }
}