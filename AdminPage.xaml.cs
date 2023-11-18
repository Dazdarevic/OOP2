using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XAct;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            LoadGrid();
            LoadChart();
        }
        public static int ID { get; set; }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=projekatOOP2; Integrated Security=True;");

        private void LoadChart()
        {
            string[] words = null;

            SqlCommand command = new SqlCommand("SELECT ciphertext FROM EncrypTable", sqlCon);
            sqlCon.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> wordList = new List<string>();
            while (reader.Read())
            {
                string word = reader.GetString(0);
                wordList.Add(word);
            }
            words = wordList.ToArray();

            List<int> wordLengthsList = new List<int>();
            foreach (string word in words)
            {
                int length = word.Length;
                wordLengthsList.Add(length);
            }
            int[] wordLengths = wordLengthsList.ToArray();

            List<KeyValuePair<int, int>> chartValues = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < words.Length; i++)
            {
                chartValues.Add(new KeyValuePair<int, int>(i, wordLengths[i]));
            }
            lineChart.DataContext = chartValues;
        }
        private void LoadGrid()
        {

            int userId = AdminPage.ID;

            SqlCommand query = new SqlCommand("Select username as Username, plaintext  AS Plaintext, keyword AS Keyword, ciphertext as Ciphertext from EncrypTable INNER JOIN Persons ON EncrypTable.id_p = Persons.id", sqlCon);

            //query.CommandType = CommandType.Text;
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

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersPage up = new UsersPage();
            up.username.Content = username.Content;
            this.NavigationService.Navigate(up);

        }

        
    }
        
    }
    

