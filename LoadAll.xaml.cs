using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for LoadAll.xaml
    /// </summary>
    public partial class LoadAll : Page
    {
        

        public LoadAll()
        {
            InitializeComponent();
            LoadGrid();
        }
        public static int ID { get; set; }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=projekatOOP2; Integrated Security=True;");
        
        

        public void LoadGrid()
        {

            int userId = LoadAll.ID;

            SqlCommand query = new SqlCommand("Select id_p as ID, plaintext  AS Plaintext, keyword AS Keyword, ciphertext as Ciphertext from EncrypTable WHERE id_p = @id", sqlCon);

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
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentPage());
        }

        


    }

}
