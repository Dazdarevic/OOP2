using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OneTimePadAlgorithm
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        DispatcherTimer timer3 = new DispatcherTimer();
        DispatcherTimer timer4 = new DispatcherTimer();
        DispatcherTimer timer5 = new DispatcherTimer();
        DispatcherTimer timer6 = new DispatcherTimer();
        DispatcherTimer timer7 = new DispatcherTimer();
        public StudentPage()
        {
            InitializeComponent();
        }
        public static int ID { get; set; }
        public static string KeyText { get; set; }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=projekatOOP2; Integrated Security=True;");
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }


        private void GetText(string pom)
        {
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);

            char[] ch = new char[pom.Length];
            for(int i=0; i<pom.Length; i++)
            {
                ch[i] = pom[i];
                
            }
            // Printing content of array 
            int j = 0;
            foreach (char c in ch)
            {

                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(40);
                text.RowDefinitions.Add(gridRow1);

                // Create first Row for letters 
                TextBlock letter = new TextBlock();
                letter.Text = c.ToString().ToUpper();
                letter.FontSize = 20;
                letter.FontWeight = FontWeights.Bold;
                letter.Foreground = new SolidColorBrush(Colors.Blue);
                letter.Background = new SolidColorBrush(Colors.White);
                letter.Padding = new Thickness(7);
                Grid.SetRow(letter, j);
                Grid.SetColumn(letter, 0);
                text.Children.Add(letter);
                j++;
            }

            // Display grid into a StudentPage    
            postupak.Children.Add(text);
        }
        private void GetKeyword(string keyword,string pom)
        {
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);

            int duzinaTeksta = pom.Length;
            int duzinaKljuca = keyword.Length;

            //imamo dva slucaja kada kada je duzina kljuca u pitanju
            if(duzinaKljuca>duzinaTeksta)
            {
                int d1 = duzinaKljuca - duzinaTeksta;
                keyword = keyword.Remove(keyword.Length-d1, d1);
            } 
            else if(duzinaKljuca < duzinaTeksta)
            {
                int d2 = duzinaTeksta - duzinaKljuca;
                for (int i = 0; i < d2; i++)
                {
                    keyword += "a";
                }
            }


            char[] ch = new char[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                ch[i] = keyword[i];

            }
            // Printing content of array 
            int j = 0;
            foreach (char c in ch)
            {

                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(40);
                text.RowDefinitions.Add(gridRow1);

                // Create first Row for letters 
                TextBlock letter = new TextBlock();
                letter.Text = c.ToString().ToUpper();
                letter.FontSize = 20;
                letter.FontWeight = FontWeights.Bold;
                letter.Foreground = new SolidColorBrush(Colors.Red);
                letter.Background = new SolidColorBrush(Colors.White);
                letter.Padding = new Thickness(7);
                Grid.SetRow(letter, j);
                Grid.SetColumn(letter, 0);
                text.Children.Add(letter);
                j++;
            }

            // Display grid into a StudentPage    
            postupak2.Children.Add(text);
        }
        private void CreatePus(string pom)
        {
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);


            for (int i = 0; i < pom.Length; i++)

            {
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(40);
                text.RowDefinitions.Add(gridRow1);

                // Create first Row for letters 
                TextBlock letter = new TextBlock();
                letter.Text = "+";
                letter.FontSize = 20;
                letter.FontWeight = FontWeights.Bold;
                letter.Foreground = new SolidColorBrush(Colors.Black);
                letter.Background = new SolidColorBrush(Colors.White);
                letter.Padding = new Thickness(7);
                Grid.SetRow(letter, i);
                Grid.SetColumn(letter, 0);
                text.Children.Add(letter);
            }

            // Display grid into a StudentPage    
            plus.Children.Add(text);
        }
        private void CreateEqual(string pom)
        {
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);


            for (int i = 0; i < pom.Length; i++)

            {
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(40);
                text.RowDefinitions.Add(gridRow1);

                // Create first Row for letters 
                TextBlock letter = new TextBlock();
                letter.Text = "=";
                letter.FontSize = 20;
                letter.FontWeight = FontWeights.Bold;
                letter.Foreground = new SolidColorBrush(Colors.Black);
                letter.Background = new SolidColorBrush(Colors.White);
                letter.Padding = new Thickness(7);
                Grid.SetRow(letter, i);
                Grid.SetColumn(letter, 0);
                text.Children.Add(letter);
            }

            // Display grid into a StudentPage    
            jednako.Children.Add(text);
        }
        private void CreateDynamicWPFGrid()
        {
            // Create the Grid    
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = 800;
            DynamicGrid.Height = 80;
           

            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.SkyBlue);

            // Create Columns    
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            ColumnDefinition gridCol5 = new ColumnDefinition();
            ColumnDefinition gridCol6 = new ColumnDefinition();
            ColumnDefinition gridCol7 = new ColumnDefinition();
            ColumnDefinition gridCol8 = new ColumnDefinition();
            ColumnDefinition gridCol9 = new ColumnDefinition();
            ColumnDefinition gridCol10 = new ColumnDefinition();
            ColumnDefinition gridCol11 = new ColumnDefinition();
            ColumnDefinition gridCol12 = new ColumnDefinition();
            ColumnDefinition gridCol13 = new ColumnDefinition();
            ColumnDefinition gridCol14 = new ColumnDefinition();
            ColumnDefinition gridCol15 = new ColumnDefinition();
            ColumnDefinition gridCol16 = new ColumnDefinition();
            ColumnDefinition gridCol17 = new ColumnDefinition();
            ColumnDefinition gridCol18 = new ColumnDefinition();
            ColumnDefinition gridCol19 = new ColumnDefinition();
            ColumnDefinition gridCol20 = new ColumnDefinition();
            ColumnDefinition gridCol21 = new ColumnDefinition();
            ColumnDefinition gridCol22 = new ColumnDefinition();
            ColumnDefinition gridCol23 = new ColumnDefinition();
            ColumnDefinition gridCol24 = new ColumnDefinition();
            ColumnDefinition gridCol25 = new ColumnDefinition();
            ColumnDefinition gridCol26 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            gridCol2.Width = new GridLength(30);
            gridCol3.Width = new GridLength(30);
            gridCol4.Width = new GridLength(30);
            gridCol5.Width = new GridLength(30);
            gridCol6.Width = new GridLength(30);
            gridCol7.Width = new GridLength(30);
            gridCol8.Width = new GridLength(30);
            gridCol9.Width = new GridLength(30);
            gridCol10.Width = new GridLength(30);
            gridCol11.Width = new GridLength(30);
            gridCol12.Width = new GridLength(30);
            gridCol13.Width = new GridLength(30);
            gridCol14.Width = new GridLength(30);
            gridCol15.Width = new GridLength(30);
            gridCol16.Width = new GridLength(30);
            gridCol17.Width = new GridLength(30);
            gridCol18.Width = new GridLength(30);
            gridCol19.Width = new GridLength(30);


            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);
            DynamicGrid.ColumnDefinitions.Add(gridCol4);
            DynamicGrid.ColumnDefinitions.Add(gridCol5);
            DynamicGrid.ColumnDefinitions.Add(gridCol6);
            DynamicGrid.ColumnDefinitions.Add(gridCol7);
            DynamicGrid.ColumnDefinitions.Add(gridCol8);
            DynamicGrid.ColumnDefinitions.Add(gridCol9);
            DynamicGrid.ColumnDefinitions.Add(gridCol10);
            DynamicGrid.ColumnDefinitions.Add(gridCol11);
            DynamicGrid.ColumnDefinitions.Add(gridCol12);
            DynamicGrid.ColumnDefinitions.Add(gridCol13);
            DynamicGrid.ColumnDefinitions.Add(gridCol14);
            DynamicGrid.ColumnDefinitions.Add(gridCol15);
            DynamicGrid.ColumnDefinitions.Add(gridCol16);
            DynamicGrid.ColumnDefinitions.Add(gridCol17);
            DynamicGrid.ColumnDefinitions.Add(gridCol18);
            DynamicGrid.ColumnDefinitions.Add(gridCol19);
            DynamicGrid.ColumnDefinitions.Add(gridCol20);
            DynamicGrid.ColumnDefinitions.Add(gridCol21);
            DynamicGrid.ColumnDefinitions.Add(gridCol22);
            DynamicGrid.ColumnDefinitions.Add(gridCol23);
            DynamicGrid.ColumnDefinitions.Add(gridCol24);
            DynamicGrid.ColumnDefinitions.Add(gridCol25);
            DynamicGrid.ColumnDefinitions.Add(gridCol26);

            // Create Rows    
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(40);
            RowDefinition gridRow2 = new RowDefinition();
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);


            // Create first Row for letters 
            TextBlock letter1 = new TextBlock();
            letter1.Text = "A";
            letter1.FontSize = 12;
            letter1.FontWeight = FontWeights.Bold;
            letter1.Foreground = new SolidColorBrush(Colors.White);
            letter1.Background = new SolidColorBrush(Colors.Teal);
            letter1.Padding = new Thickness(10);
            Grid.SetRow(letter1, 0);
            Grid.SetColumn(letter1, 0);

            TextBlock letter2 = new TextBlock();
            letter2.Text = "B";
            letter2.FontSize = 12;
            letter2.FontWeight = FontWeights.Bold;
            letter2.Foreground = new SolidColorBrush(Colors.White);
            letter2.Background = new SolidColorBrush(Colors.Teal);
            letter2.Padding = new Thickness(10);
            Grid.SetRow(letter2, 0);
            Grid.SetColumn(letter2, 1);

            TextBlock letter3 = new TextBlock();
            letter3.Text = "C";
            letter3.FontSize = 12;
            letter3.FontWeight = FontWeights.Bold;
            letter3.Foreground = new SolidColorBrush(Colors.White);
            letter3.Background = new SolidColorBrush(Colors.Teal);
            letter3.Padding = new Thickness(10);
            Grid.SetRow(letter3, 0);
            Grid.SetColumn(letter3, 2);

            TextBlock letter4 = new TextBlock();
            letter4.Text = "D";
            letter4.FontSize = 12;
            letter4.FontWeight = FontWeights.Bold;
            letter4.Foreground = new SolidColorBrush(Colors.White);
            letter4.Background = new SolidColorBrush(Colors.Teal);
            letter4.Padding = new Thickness(10);
            Grid.SetRow(letter4, 0);
            Grid.SetColumn(letter4, 3);

            TextBlock letter5 = new TextBlock();
            letter5.Text = "E";
            letter5.FontSize = 12;
            letter5.FontWeight = FontWeights.Bold;
            letter5.Foreground = new SolidColorBrush(Colors.White);
            letter5.Background = new SolidColorBrush(Colors.Teal);
            letter5.Padding = new Thickness(10);
            Grid.SetRow(letter5, 0);
            Grid.SetColumn(letter5, 4);

            TextBlock letter6 = new TextBlock();
            letter6.Text = "F";
            letter6.FontSize = 12;
            letter6.FontWeight = FontWeights.Bold;
            letter6.Foreground = new SolidColorBrush(Colors.White);
            letter6.Background = new SolidColorBrush(Colors.Teal);
            letter6.Padding = new Thickness(10);
            Grid.SetRow(letter6, 0);
            Grid.SetColumn(letter6, 5);

            TextBlock letter7 = new TextBlock();
            letter7.Text = "G";
            letter7.FontSize = 12;
            letter7.FontWeight = FontWeights.Bold;
            letter7.Foreground = new SolidColorBrush(Colors.White);
            letter7.Background = new SolidColorBrush(Colors.Teal);
            letter7.Padding = new Thickness(10);
            Grid.SetRow(letter7, 0);
            Grid.SetColumn(letter7, 6);

            TextBlock letter8 = new TextBlock();
            letter8.Text = "H";
            letter8.FontSize = 12;
            letter8.FontWeight = FontWeights.Bold;
            letter8.Foreground = new SolidColorBrush(Colors.White);
            letter8.Background = new SolidColorBrush(Colors.Teal);
            letter8.Padding = new Thickness(10);
            Grid.SetRow(letter8, 0);
            Grid.SetColumn(letter8, 7);

            TextBlock letter9 = new TextBlock();
            letter9.Text = "I";
            letter9.FontSize = 12;
            letter9.FontWeight = FontWeights.Bold;
            letter9.Foreground = new SolidColorBrush(Colors.White);
            letter9.Background = new SolidColorBrush(Colors.Teal);
            letter9.Padding = new Thickness(10);
            Grid.SetRow(letter9, 0);
            Grid.SetColumn(letter9, 8);

            TextBlock letter10 = new TextBlock();
            letter10.Text = "J";
            letter10.FontSize = 12;
            letter10.FontWeight = FontWeights.Bold;
            letter10.Foreground = new SolidColorBrush(Colors.White);
            letter10.Background = new SolidColorBrush(Colors.Teal);
            letter10.Padding = new Thickness(10);
            Grid.SetRow(letter10, 0);
            Grid.SetColumn(letter10, 9);

            TextBlock letter11 = new TextBlock();
            letter11.Text = "K";
            letter11.FontSize = 12;
            letter11.FontWeight = FontWeights.Bold;
            letter11.Foreground = new SolidColorBrush(Colors.White);
            letter11.Background = new SolidColorBrush(Colors.Teal);
            letter11.Padding = new Thickness(10);
            Grid.SetRow(letter11, 0);
            Grid.SetColumn(letter11, 10);

            TextBlock letter13 = new TextBlock();
            letter13.Text = "L";
            letter13.FontSize = 12;
            letter13.FontWeight = FontWeights.Bold;
            letter13.Foreground = new SolidColorBrush(Colors.White);
            letter13.Background = new SolidColorBrush(Colors.Teal);
            letter13.Padding = new Thickness(10);
            Grid.SetRow(letter13, 0);
            Grid.SetColumn(letter13, 11);

            TextBlock letter14 = new TextBlock();
            letter14.Text = "M";
            letter14.FontSize = 12;
            letter14.FontWeight = FontWeights.Bold;
            letter14.Foreground = new SolidColorBrush(Colors.White);
            letter14.Background = new SolidColorBrush(Colors.Teal);
            letter14.Padding = new Thickness(10);
            Grid.SetRow(letter14, 0);
            Grid.SetColumn(letter14, 12);

            TextBlock letter15 = new TextBlock();
            letter15.Text = "N";
            letter15.FontSize = 12;
            letter15.FontWeight = FontWeights.Bold;
            letter15.Foreground = new SolidColorBrush(Colors.White);
            letter15.Background = new SolidColorBrush(Colors.Teal);
            letter15.Padding = new Thickness(10);
            Grid.SetRow(letter15, 0);
            Grid.SetColumn(letter15, 13);

            TextBlock letter16 = new TextBlock();
            letter16.Text = "O";
            letter16.FontSize = 12;
            letter16.FontWeight = FontWeights.Bold;
            letter16.Foreground = new SolidColorBrush(Colors.White);
            letter16.Background = new SolidColorBrush(Colors.Teal);
            letter16.Padding = new Thickness(10);
            Grid.SetRow(letter16, 0);
            Grid.SetColumn(letter16, 14);

            TextBlock letter17 = new TextBlock();
            letter17.Text = "P";
            letter17.FontSize = 12;
            letter17.FontWeight = FontWeights.Bold;
            letter17.Foreground = new SolidColorBrush(Colors.White);
            letter17.Background = new SolidColorBrush(Colors.Teal);
            letter17.Padding = new Thickness(10);
            Grid.SetRow(letter17, 0);
            Grid.SetColumn(letter17, 15);

            TextBlock letter18 = new TextBlock();
            letter18.Text = "Q";
            letter18.FontSize = 12;
            letter18.FontWeight = FontWeights.Bold;
            letter18.Foreground = new SolidColorBrush(Colors.White);
            letter18.Background = new SolidColorBrush(Colors.Teal);
            letter18.Padding = new Thickness(10);
            Grid.SetRow(letter18, 0);
            Grid.SetColumn(letter18, 16);

            TextBlock letter19 = new TextBlock();
            letter19.Text = "R";
            letter19.FontSize = 12;
            letter19.FontWeight = FontWeights.Bold;
            letter19.Foreground = new SolidColorBrush(Colors.White);
            letter19.Background = new SolidColorBrush(Colors.Teal);
            letter19.Padding = new Thickness(10);
            Grid.SetRow(letter19, 0);
            Grid.SetColumn(letter19, 17);

            TextBlock letter20 = new TextBlock();
            letter20.Text = "S";
            letter20.FontSize = 12;
            letter20.FontWeight = FontWeights.Bold;
            letter20.Foreground = new SolidColorBrush(Colors.White);
            letter20.Background = new SolidColorBrush(Colors.Teal);
            letter20.Padding = new Thickness(10);
            Grid.SetRow(letter20, 0);
            Grid.SetColumn(letter20, 18);

            TextBlock letter21 = new TextBlock();
            letter21.Text = "T";
            letter21.FontSize = 12;
            letter21.FontWeight = FontWeights.Bold;
            letter21.Foreground = new SolidColorBrush(Colors.White);
            letter21.Background = new SolidColorBrush(Colors.Teal);
            letter21.Padding = new Thickness(10);
            Grid.SetRow(letter21, 0);
            Grid.SetColumn(letter21, 19);

            TextBlock letter22 = new TextBlock();
            letter22.Text = "U";
            letter22.FontSize = 12;
            letter22.FontWeight = FontWeights.Bold;
            letter22.Foreground = new SolidColorBrush(Colors.White);
            letter22.Background = new SolidColorBrush(Colors.Teal);
            letter22.Padding = new Thickness(10);
            Grid.SetRow(letter22, 0);
            Grid.SetColumn(letter22, 20);

            TextBlock letter23 = new TextBlock();
            letter23.Text = "V";
            letter23.FontSize = 12;
            letter23.FontWeight = FontWeights.Bold;
            letter23.Foreground = new SolidColorBrush(Colors.White);
            letter23.Background = new SolidColorBrush(Colors.Teal);
            letter23.Padding = new Thickness(10);
            Grid.SetRow(letter23, 0);
            Grid.SetColumn(letter23, 21);

            TextBlock letter24 = new TextBlock();
            letter24.Text = "W";
            letter24.FontSize = 12;
            letter24.FontWeight = FontWeights.Bold;
            letter24.Foreground = new SolidColorBrush(Colors.White);
            letter24.Background = new SolidColorBrush(Colors.Teal);
            letter24.Padding = new Thickness(10);
            Grid.SetRow(letter24, 0);
            Grid.SetColumn(letter24, 22);

            TextBlock letter25 = new TextBlock();
            letter25.Text = "X";
            letter25.FontSize = 12;
            letter25.FontWeight = FontWeights.Bold;
            letter25.Foreground = new SolidColorBrush(Colors.White);
            letter25.Background = new SolidColorBrush(Colors.Teal);
            letter25.Padding = new Thickness(10);
            Grid.SetRow(letter25, 0);
            Grid.SetColumn(letter25, 23);

            TextBlock letter26 = new TextBlock();
            letter26.Text = "Y";
            letter26.FontSize = 12;
            letter26.FontWeight = FontWeights.Bold;
            letter26.Foreground = new SolidColorBrush(Colors.White);
            letter26.Background = new SolidColorBrush(Colors.Teal);
            letter26.Padding = new Thickness(10);
            Grid.SetRow(letter26, 0);
            Grid.SetColumn(letter26, 24);

            TextBlock letter27 = new TextBlock();
            letter27.Text = "Z";
            letter27.FontSize = 12;
            letter27.FontWeight = FontWeights.Bold;
            letter27.Foreground = new SolidColorBrush(Colors.White);
            letter27.Background = new SolidColorBrush(Colors.Teal);
            letter27.Padding = new Thickness(10);
            Grid.SetRow(letter27, 0);
            Grid.SetColumn(letter27, 25);

            // Add first row to Grid    
            DynamicGrid.Children.Add(letter1);
            DynamicGrid.Children.Add(letter2);
            DynamicGrid.Children.Add(letter3);
            DynamicGrid.Children.Add(letter4);
            DynamicGrid.Children.Add(letter5);
            DynamicGrid.Children.Add(letter6);
            DynamicGrid.Children.Add(letter7);
            DynamicGrid.Children.Add(letter8);
            DynamicGrid.Children.Add(letter9);
            DynamicGrid.Children.Add(letter10);
            DynamicGrid.Children.Add(letter11);
            DynamicGrid.Children.Add(letter13);
            DynamicGrid.Children.Add(letter14);
            DynamicGrid.Children.Add(letter15);
            DynamicGrid.Children.Add(letter16);
            DynamicGrid.Children.Add(letter17);
            DynamicGrid.Children.Add(letter18);
            DynamicGrid.Children.Add(letter19);
            DynamicGrid.Children.Add(letter20);
            DynamicGrid.Children.Add(letter21);
            DynamicGrid.Children.Add(letter22);
            DynamicGrid.Children.Add(letter23);
            DynamicGrid.Children.Add(letter24);
            DynamicGrid.Children.Add(letter25);
            DynamicGrid.Children.Add(letter26);
            DynamicGrid.Children.Add(letter27);


            // Create second Row for numbers 
            letter1 = new TextBlock();
            letter1.Text = "0";
            letter1.FontSize = 12;
            letter1.FontWeight = FontWeights.Bold;
            letter1.Padding = new Thickness(10);
            Grid.SetRow(letter1, 1);
            Grid.SetColumn(letter1, 0);

            letter2 = new TextBlock();
            letter2.Text = "1";
            letter2.FontSize = 12;
            letter2.FontWeight = FontWeights.Bold;
            letter2.Padding = new Thickness(10);
            Grid.SetRow(letter2, 1);
            Grid.SetColumn(letter2, 1);

            letter3 = new TextBlock();
            letter3.Text = "2";
            letter3.FontSize = 12;
            letter3.FontWeight = FontWeights.Bold;
            letter3.Padding = new Thickness(10);
            Grid.SetRow(letter3, 1);
            Grid.SetColumn(letter3, 2);

            letter4 = new TextBlock();
            letter4.Text = "3";
            letter4.FontSize = 12;
            letter4.FontWeight = FontWeights.Bold;
            letter4.Padding = new Thickness(10);
            Grid.SetRow(letter4, 1);
            Grid.SetColumn(letter4, 3);

            letter5 = new TextBlock();
            letter5.Text = "4";
            letter5.FontSize = 12;
            letter5.FontWeight = FontWeights.Bold;
            letter5.Padding = new Thickness(10);
            Grid.SetRow(letter5, 1);
            Grid.SetColumn(letter5, 4);

            letter6 = new TextBlock();
            letter6.Text = "5";
            letter6.FontSize = 12;
            letter6.FontWeight = FontWeights.Bold;
            letter6.Padding = new Thickness(10);
            Grid.SetRow(letter6, 1);
            Grid.SetColumn(letter6, 5);

            letter7 = new TextBlock();
            letter7.Text = "6";
            letter7.FontSize = 12;
            letter7.FontWeight = FontWeights.Bold;
            letter7.Padding = new Thickness(10);
            Grid.SetRow(letter7, 1);
            Grid.SetColumn(letter7, 6);

            letter8 = new TextBlock();
            letter8.Text = "7";
            letter8.FontSize = 12;
            letter8.FontWeight = FontWeights.Bold;
            letter8.Padding = new Thickness(10);
            Grid.SetRow(letter8, 1);
            Grid.SetColumn(letter8, 7);

            letter9 = new TextBlock();
            letter9.Text = "8";
            letter9.FontSize = 12;
            letter9.FontWeight = FontWeights.Bold;
            letter9.Padding = new Thickness(10);
            Grid.SetRow(letter9, 1);
            Grid.SetColumn(letter9, 8);

            letter10 = new TextBlock();
            letter10.Text = "9";
            letter10.FontSize = 12;
            letter10.FontWeight = FontWeights.Bold;
            letter10.Padding = new Thickness(10);
            Grid.SetRow(letter10, 1);
            Grid.SetColumn(letter10, 9);

            letter11 = new TextBlock();
            letter11.Text = "10";
            letter11.FontSize = 12;
            letter11.FontWeight = FontWeights.Bold;
            letter11.Padding = new Thickness(10);
            Grid.SetRow(letter11, 1);
            Grid.SetColumn(letter11, 10);

            letter13 = new TextBlock();
            letter13.Text = "11";
            letter13.FontSize = 12;
            letter13.FontWeight = FontWeights.Bold;
            letter13.Padding = new Thickness(10);
            Grid.SetRow(letter13, 1);
            Grid.SetColumn(letter13, 11);

            letter14 = new TextBlock();
            letter14.Text = "12";
            letter14.FontSize = 12;
            letter14.FontWeight = FontWeights.Bold;
            letter14.Padding = new Thickness(10);
            Grid.SetRow(letter14, 1);
            Grid.SetColumn(letter14, 12);

            letter15 = new TextBlock();
            letter15.Text = "13";
            letter15.FontSize = 12;
            letter15.FontWeight = FontWeights.Bold;
            letter15.Padding = new Thickness(10);
            Grid.SetRow(letter15, 1);
            Grid.SetColumn(letter15, 13);

            letter16 = new TextBlock();
            letter16.Text = "14";
            letter16.FontSize = 12;
            letter16.FontWeight = FontWeights.Bold;
            letter16.Padding = new Thickness(10);
            Grid.SetRow(letter16, 1);
            Grid.SetColumn(letter16, 14);

            letter17 = new TextBlock();
            letter17.Text = "15";
            letter17.FontSize = 12;
            letter17.FontWeight = FontWeights.Bold;
            letter17.Padding = new Thickness(10);
            Grid.SetRow(letter17, 1);
            Grid.SetColumn(letter17, 15);

            letter18 = new TextBlock();
            letter18.Text = "16";
            letter18.FontSize = 12;
            letter18.FontWeight = FontWeights.Bold;
            letter18.Padding = new Thickness(10);
            Grid.SetRow(letter18, 1);
            Grid.SetColumn(letter18, 16);

            letter19 = new TextBlock();
            letter19.Text = "17";
            letter19.FontSize = 12;
            letter19.FontWeight = FontWeights.Bold;
            letter19.Padding = new Thickness(10);
            Grid.SetRow(letter19, 1);
            Grid.SetColumn(letter19, 17);

            letter20 = new TextBlock();
            letter20.Text = "18";
            letter20.FontSize = 12;
            letter20.FontWeight = FontWeights.Bold;
            letter20.Padding = new Thickness(10);
            Grid.SetRow(letter20, 1);
            Grid.SetColumn(letter20, 18);

            letter21 = new TextBlock();
            letter21.Text = "19";
            letter21.FontSize = 12;
            letter21.FontWeight = FontWeights.Bold;
            letter21.Padding = new Thickness(10);
            Grid.SetRow(letter21, 1);
            Grid.SetColumn(letter21, 19);

            letter22 = new TextBlock();
            letter22.Text = "20";
            letter22.FontSize = 12;
            letter22.FontWeight = FontWeights.Bold;
            letter22.Padding = new Thickness(10);
            Grid.SetRow(letter22, 1);
            Grid.SetColumn(letter22, 20);

            letter23 = new TextBlock();
            letter23.Text = "21";
            letter23.FontSize = 12;
            letter23.FontWeight = FontWeights.Bold;
            letter23.Padding = new Thickness(10);
            Grid.SetRow(letter23, 1);
            Grid.SetColumn(letter23, 21);

            letter24 = new TextBlock();
            letter24.Text = "22";
            letter24.FontSize = 12;
            letter24.FontWeight = FontWeights.Bold;
            letter24.Padding = new Thickness(10);
            Grid.SetRow(letter24, 1);
            Grid.SetColumn(letter24, 22);

            letter25 = new TextBlock();
            letter25.Text = "23";
            letter25.FontSize = 12;
            letter25.FontWeight = FontWeights.Bold;
            letter25.Padding = new Thickness(10);
            Grid.SetRow(letter25, 1);
            Grid.SetColumn(letter25, 23);

            letter26 = new TextBlock();
            letter26.Text = "24";
            letter26.FontSize = 12;
            letter26.FontWeight = FontWeights.Bold;
            letter26.Padding = new Thickness(10);
            Grid.SetRow(letter26, 1);
            Grid.SetColumn(letter26, 24);

            letter27 = new TextBlock();
            letter27.Text = "25";
            letter27.FontSize = 12;
            letter27.FontWeight = FontWeights.Bold;
            letter27.Padding = new Thickness(10);
            Grid.SetRow(letter27, 1);
            Grid.SetColumn(letter27, 25);

            // Add first row to Grid    
            DynamicGrid.Children.Add(letter1);
            DynamicGrid.Children.Add(letter2);
            DynamicGrid.Children.Add(letter3);
            DynamicGrid.Children.Add(letter4);
            DynamicGrid.Children.Add(letter5);
            DynamicGrid.Children.Add(letter6);
            DynamicGrid.Children.Add(letter7);
            DynamicGrid.Children.Add(letter8);
            DynamicGrid.Children.Add(letter9);
            DynamicGrid.Children.Add(letter10);
            DynamicGrid.Children.Add(letter11);
            DynamicGrid.Children.Add(letter13);
            DynamicGrid.Children.Add(letter14);
            DynamicGrid.Children.Add(letter15);
            DynamicGrid.Children.Add(letter16);
            DynamicGrid.Children.Add(letter17);
            DynamicGrid.Children.Add(letter18);
            DynamicGrid.Children.Add(letter19);
            DynamicGrid.Children.Add(letter20);
            DynamicGrid.Children.Add(letter21);
            DynamicGrid.Children.Add(letter22);
            DynamicGrid.Children.Add(letter23);
            DynamicGrid.Children.Add(letter24);
            DynamicGrid.Children.Add(letter25);
            DynamicGrid.Children.Add(letter26);
            DynamicGrid.Children.Add(letter27);

            // Display grid into a StudentPage    
            root.Children.Add(DynamicGrid);
        }

        private void ZamenaKljuca(string pom, string keyword)
        {
            // Create the Grid for process
            pom = pom.ToLower();
            keyword = keyword.ToLower();
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);
            int duzinaTeksta = pom.Length;
            int duzinaKljuca = keyword.Length;

            //imamo dva slucaja kada kada je duzina kljuca u pitanju
            if (duzinaKljuca > duzinaTeksta)
            {
                int d1 = duzinaKljuca - duzinaTeksta;
                keyword = keyword.Remove(keyword.Length - d1, d1);
            }
            else if (duzinaKljuca < duzinaTeksta)
            {
                int d2 = duzinaTeksta - duzinaKljuca;
                for (int i = 0; i < d2; i++)
                {
                    keyword += "a";
                }
            }


            char[] ch = new char[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                ch[i] = keyword[i];

            }
            //niz = ['B', 'E', 'N', 'K', 'A'];
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // Printing content of array 
            int j = 0;
            foreach (char c in ch)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        RowDefinition gridRow1 = new RowDefinition();
                        gridRow1.Height = new GridLength(40);
                        text.RowDefinitions.Add(gridRow1);

                        // Create first Row for letters 
                        TextBlock letter = new TextBlock();
                        letter.Text = i.ToString();
                        letter.FontSize = 20;
                        letter.FontWeight = FontWeights.Bold;
                        letter.Foreground = new SolidColorBrush(Colors.SkyBlue);
                        letter.Background = new SolidColorBrush(Colors.White);
                        letter.Padding = new Thickness(7);
                        Grid.SetRow(letter, j);
                        Grid.SetColumn(letter, 0);
                        text.Children.Add(letter);
                        j++;
                    }
                }

            }

            // Display grid into a StudentPage    
            zamena2.Children.Add(text);
        }
        private void ZamenaTeksta(string pom)
        {
            pom = pom.ToLower();
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);

            char[] ch = new char[pom.Length];
            for (int i = 0; i < pom.Length; i++)
            {
                ch[i] = pom[i];

            }
            //niz = ['B', 'E', 'N', 'K', 'A'];
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // Printing content of array 
            int j = 0;
            foreach (char c in ch)
            {
                for(int i= 0; i < alphabet.Length; i++)
                {
                    if(alphabet[i] == c)
                    {
                        RowDefinition gridRow1 = new RowDefinition();
                        gridRow1.Height = new GridLength(40);
                        text.RowDefinitions.Add(gridRow1);

                        // Create first Row for letters 
                        TextBlock letter = new TextBlock();
                        letter.Text = i.ToString();
                        letter.FontSize = 20;
                        letter.FontWeight = FontWeights.Bold;
                        letter.Foreground = new SolidColorBrush(Colors.SkyBlue);
                        letter.Background = new SolidColorBrush(Colors.White);
                        letter.Padding = new Thickness(7);
                        Grid.SetRow(letter, j);
                        Grid.SetColumn(letter, 0);
                        text.Children.Add(letter);
                        j++;
                    }
                }
                
            }

            // Display grid into a StudentPage    
            zamena.Children.Add(text);
        }

        private void RezultatSabiranja(string pom, string keyword)
        {
            pom = pom.ToLower();
            keyword = keyword.ToLower();
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);
            int duzinaTeksta = pom.Length;
            int duzinaKljuca = keyword.Length;

            //imamo dva slucaja kada kada je duzina kljuca u pitanju
            if (duzinaKljuca > duzinaTeksta)
            {
                int d1 = duzinaKljuca - duzinaTeksta;
                keyword = keyword.Remove(keyword.Length - d1, d1);
            }
            else if (duzinaKljuca < duzinaTeksta)
            {
                int d2 = duzinaTeksta - duzinaKljuca;
                for (int i = 0; i < d2; i++)
                {
                    keyword += "a";
                }
            }


            char[] array1 = new char[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                array1[i] = keyword[i];

            }

            char[] array2 = new char[pom.Length];
            for (int i = 0; i < pom.Length; i++)
            {
                array2[i] = pom[i];

            }

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int[] niz1 = new int[array1.Length];

            // Printing content of array 
            int j = 0;
            foreach (char c in array1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz1[j] = i;
                        j++;
                    }
                }

            }

            int p = 0; 
            int[] niz2 = new int[array1.Length];
            foreach (char c in array2)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz2[p] = i;
                        p++;
                    }
                }

            }

            int[] niz3 = new int[array1.Length];
            for (int i = 0; i < niz1.Length; i++)
            {
                niz3[i] = niz1[i] + niz2[i];
                if(niz3[i] > 25)
                {
                    niz3[i] = (niz3[i] - 25) - 1;
                }
            }

            int t = 0;
            foreach(int i in niz3)
            {
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(40);
                text.RowDefinitions.Add(gridRow1);

                // Create first Row for letters 
                TextBlock letter = new TextBlock();
                letter.Text = i.ToString();
                letter.FontSize = 20;
                letter.FontWeight = FontWeights.Bold;
                letter.Foreground = new SolidColorBrush(Colors.Orange);
                letter.Background = new SolidColorBrush(Colors.White);
                letter.Padding = new Thickness(7);
                Grid.SetRow(letter, t);
                Grid.SetColumn(letter, 0);
                text.Children.Add(letter);
                t++;
            }

            // Display grid into a StudentPage    
            rezultatSabiranja.Children.Add(text);
        }

        private void ZamenaRezultata(string pom, string keyword)
        {
            pom = pom.ToLower();
            keyword = keyword.ToLower();
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 30;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            text.ColumnDefinitions.Add(gridCol1);
            int duzinaTeksta = pom.Length;
            int duzinaKljuca = keyword.Length;

            //imamo dva slucaja kada kada je duzina kljuca u pitanju
            if (duzinaKljuca > duzinaTeksta)
            {
                int d1 = duzinaKljuca - duzinaTeksta;
                keyword = keyword.Remove(keyword.Length - d1, d1);
            }
            else if (duzinaKljuca < duzinaTeksta)
            {
                int d2 = duzinaTeksta - duzinaKljuca;
                for (int i = 0; i < d2; i++)
                {
                    keyword += "a";
                }
            }


            char[] array1 = new char[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                array1[i] = keyword[i];

            }

            char[] array2 = new char[pom.Length];
            for (int i = 0; i < pom.Length; i++)
            {
                array2[i] = pom[i];

            }

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int[] niz1 = new int[array1.Length];

            // Printing content of array 
            int j = 0;
            foreach (char c in array1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz1[j] = i;
                        j++;
                    }
                }

            }

            int p = 0;
            int[] niz2 = new int[array1.Length];
            foreach (char c in array2)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz2[p] = i;
                        p++;
                    }
                }

            }

            int[] niz3 = new int[array1.Length];
            for (int i = 0; i < niz1.Length; i++)
            {
                niz3[i] = niz1[i] + niz2[i];
                if (niz3[i] > 25)
                {
                    niz3[i] = (niz3[i] - 25) - 1;
                }
            }

            int m = 0;
            foreach (int c in niz3)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (i == c)
                    {
                        RowDefinition gridRow1 = new RowDefinition();
                        gridRow1.Height = new GridLength(40);
                        text.RowDefinitions.Add(gridRow1);

                        // Create first Row for letters 
                        TextBlock letter = new TextBlock();
                        letter.Text = alphabet[i].ToString().ToUpper();
                        letter.FontSize = 20;
                        letter.FontWeight = FontWeights.Bold;
                        letter.Foreground = new SolidColorBrush(Colors.BlueViolet);
                        letter.Background = new SolidColorBrush(Colors.White);
                        letter.Padding = new Thickness(7);
                        Grid.SetRow(letter, m);
                        Grid.SetColumn(letter, 0);
                        text.Children.Add(letter);
                        m++;
                    }
                }

            }

            // Display grid into a StudentPage    
            zamena3.Children.Add(text);
        }
        private void nameOfAlgorithm()
        {
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 800;
            text.MinHeight = 40;

            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.White);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(800);
            text.ColumnDefinitions.Add(gridCol1);

            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(40);
            text.RowDefinitions.Add(gridRow1);

            // Create first Row for letters 
            TextBlock letter = new TextBlock();
            letter.Text = "One-Time Pad cipher";
            letter.FontSize = 30;
            letter.FontWeight = FontWeights.Bold;
            letter.Foreground = new SolidColorBrush(Colors.Teal);
            letter.Background = new SolidColorBrush(Colors.White);
            letter.Padding = new Thickness(7);
            letter.HorizontalAlignment = HorizontalAlignment.Center;
            letter.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(letter, 0);
            Grid.SetColumn(letter, 0);

            text.Children.Add(letter);

            name.Children.Add(text);
        }


        private void ispisiPoruku(string pom, string keyword)
        {
            pom = pom.ToLower();
            keyword = keyword.ToLower();
            // Create the Grid for process
            Grid text = new Grid();
            text.Width = 300;
            text.MinHeight = 300;

            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.ShowGridLines = false;
            text.Background = new SolidColorBrush(Colors.LightYellow);
            text.Margin = new Thickness(0,0,0,0);

            // Create 1 Column
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(300);
            text.ColumnDefinitions.Add(gridCol1);

            // Create 3 Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(100);
            text.RowDefinitions.Add(gridRow1);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(100);
            text.RowDefinitions.Add(gridRow2);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(100);
            text.RowDefinitions.Add(gridRow3);


            // Create first Row for plaintext 
            TextBlock letter = new TextBlock();
            letter.Text = "Plaintext: " + pom.ToUpper();
            letter.FontSize = 20;
            letter.FontWeight = FontWeights.Bold;
            letter.Foreground = new SolidColorBrush(Colors.Blue);
            letter.Padding = new Thickness(10);
            letter.HorizontalAlignment = HorizontalAlignment.Center;
            letter.TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(letter, 0);
            Grid.SetColumn(letter, 0);
            text.Children.Add(letter);

            // Create second Row for keyword 
            TextBlock key = new TextBlock();
            key.Text = "Keyword: " + keyword.ToUpper();
            key.FontSize = 20;
            key.FontWeight = FontWeights.Bold;
            key.Foreground = new SolidColorBrush(Colors.Red);
            key.Padding = new Thickness(10);
            key.HorizontalAlignment = HorizontalAlignment.Center;
            key.TextWrapping = TextWrapping.Wrap;   
            Grid.SetRow(key, 1);
            Grid.SetColumn(key, 0);
            text.Children.Add(key);

            int duzinaTeksta = pom.Length;
            int duzinaKljuca = keyword.Length;

            //imamo dva slucaja kada kada je duzina kljuca u pitanju
            if (duzinaKljuca > duzinaTeksta)
            {
                int d1 = duzinaKljuca - duzinaTeksta;
                keyword = keyword.Remove(keyword.Length - d1, d1);
            }
            else if (duzinaKljuca < duzinaTeksta)
            {
                int d2 = duzinaTeksta - duzinaKljuca;
                for (int i = 0; i < d2; i++)
                {
                    keyword += "a";
                }
            }


            char[] array1 = new char[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                array1[i] = keyword[i];

            }

            char[] array2 = new char[pom.Length];
            for (int i = 0; i < pom.Length; i++)
            {
                array2[i] = pom[i];

            }

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int[] niz1 = new int[array1.Length];

            // Printing content of array 
            int j = 0;
            foreach (char c in array1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz1[j] = i;
                        j++;
                    }
                }

            }

            int p = 0;
            int[] niz2 = new int[array1.Length];
            foreach (char c in array2)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == c)
                    {
                        niz2[p] = i;
                        p++;
                    }
                }

            }

            int[] niz3 = new int[array1.Length];
            for (int i = 0; i < niz1.Length; i++)
            {
                niz3[i] = niz1[i] + niz2[i];
                if (niz3[i] > 25)
                {
                    niz3[i] = (niz3[i] - 25) - 1;
                }
            }

            int q = 0;
            char[] niz4 = new char[array1.Length];
            foreach (char c in niz3)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (i == c)
                    {
                        niz4[q] = alphabet[i];
                        q++;
                    }
                }

            }
            string str = string.Join("", niz4);

            // Create third Row for keyword 
            TextBlock cipher = new TextBlock();
            cipher.Text = "Ciphertext: " + str.ToUpper();
            cipher.FontSize = 20;
            cipher.FontWeight = FontWeights.Bold;
            cipher.Foreground = new SolidColorBrush(Colors.BlueViolet);
            cipher.Padding = new Thickness(10);
            cipher.HorizontalAlignment = HorizontalAlignment.Center;
            cipher.TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(cipher, 2);
            Grid.SetColumn(cipher, 0);
            text.Children.Add(cipher);


            
            //Add Grid to Student Page
            ispisPoruke.Children.Add(text);
        }
       
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            if (text.Text == "")
            {
                error.Content = "Text is required.";
            }
            else
            {
                // every time clear previous Grids?
                error.Content = "";
                name.Children.Clear();
                root.Children.Clear();
                postupak.Children.Clear();
                postupak2.Children.Clear();
                zamena.Children.Clear();
                zamena2.Children.Clear();
                zamena3.Children.Clear();
                plus.Children.Clear();
                jednako.Children.Clear();
                rezultatSabiranja.Children.Clear();
                ispisPoruke.Children.Clear();

                string getText = RemoveWhitespace(text.Text);

                string randomString = RandomString(getText.Length);
                KeyText = randomString;

                RunAlgorithm();
            }

        }
        private void RunAlgorithm()
        {
            nameOfAlgorithm();
            CreateDynamicWPFGrid();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer2.Tick += new EventHandler(TextTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Start();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer2.Tick += new EventHandler(KeywordTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer2.Interval = new TimeSpan(0, 0, 2);
            timer2.Start();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer3.Tick += new EventHandler(ZamenaTekstaTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer3.Interval = new TimeSpan(0, 0, 3);
            timer3.Start();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer4.Tick += new EventHandler(ZamenaKljucaTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer4.Interval = new TimeSpan(0, 0, 4);
            timer4.Start();


#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer5.Tick += new EventHandler(PlusJednakoTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer5.Interval = new TimeSpan(0, 0, 5);
            timer5.Start();


#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer6.Tick += new EventHandler(RezultatSabiranjaTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer6.Interval = new TimeSpan(0, 0, 6);
            timer6.Start();

            //ISPIS KONACNOG REZULTATA
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer.Tick += new EventHandler(WaitForName);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer.Interval = new TimeSpan(0, 0, 7);
            timer.Start();

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer7.Tick += new EventHandler(PorukaTimer);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer7.Interval = new TimeSpan(0, 0, 8);
            timer7.Start();


        }

        public void PorukaTimer(object Source, EventArgs e)
        {
            ispisiPoruku(RemoveWhitespace(text.Text), RemoveWhitespace(KeyText));
            timer7.Stop();
        }
        public void RezultatSabiranjaTimer(object Source, EventArgs e)
        {
            RezultatSabiranja(RemoveWhitespace(text.Text), KeyText);
            timer6.Stop();
        }
        public void PlusJednakoTimer(object Source, EventArgs e)
        {
            CreatePus(RemoveWhitespace(text.Text));
            CreateEqual(RemoveWhitespace(text.Text));
            timer5.Stop();
        }
        public void ZamenaKljucaTimer(object Source, EventArgs e)
        {
            ZamenaKljuca(RemoveWhitespace(text.Text), KeyText);
            ZamenaTeksta(RemoveWhitespace(text.Text));
            timer4.Stop();
        }
        public void ZamenaTekstaTimer(object Source, EventArgs e)
        {
            ZamenaTeksta(RemoveWhitespace(text.Text));
            timer3.Stop();
        }
        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
        public void TextTimer(object Source, EventArgs e)
        {
            GetText(RemoveWhitespace(text.Text));
            timer2.Stop();
        }
        public void KeywordTimer(object Source, EventArgs e)
        {
            GetKeyword(KeyText, RemoveWhitespace(text.Text));
            timer3.Stop();
        }
        public void WaitForName(object Source, EventArgs e)
        {
            ZamenaRezultata(RemoveWhitespace(text.Text), KeyText);
            timer.Stop();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // every time clear previous Grids?
            text.Text = "";
            error.Content = "";
            name.Children.Clear ();
            root.Children.Clear();
            postupak.Children.Clear();
            postupak2.Children.Clear();
            zamena.Children.Clear();
            zamena2.Children.Clear();
            zamena3.Children.Clear();
            plus.Children.Clear();
            jednako.Children.Clear();
            rezultatSabiranja.Children.Clear();
            ispisPoruke.Children.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text == "")
            {
                error.Content = "Text is required.";
            }
            else
            {
                // every time clear previous Grids?
                error.Content = "";
                name.Children.Clear();
                root.Children.Clear();
                postupak.Children.Clear();
                postupak2.Children.Clear();
                zamena.Children.Clear();
                zamena2.Children.Clear();
                zamena3.Children.Clear();
                plus.Children.Clear();
                jednako.Children.Clear();
                rezultatSabiranja.Children.Clear();
                ispisPoruke.Children.Clear();

                string pom = text.Text.ToLower();
                string keyword = KeyText.ToLower();
                int duzinaTeksta = text.Text.Length;
                int duzinaKljuca = keyword.Length;

                //imamo dva slucaja kada kada je duzina kljuca u pitanju
                if (duzinaKljuca > duzinaTeksta)
                {
                    int d1 = duzinaKljuca - duzinaTeksta;
                    keyword = keyword.Remove(KeyText.Length - d1, d1);
                }
                else if (duzinaKljuca < duzinaTeksta)
                {
                    int d2 = duzinaTeksta - duzinaKljuca;
                    for (int i = 0; i < d2; i++)
                    {
                        keyword += "a";
                    }
                }

                string pom2 = RemoveWhitespace(text.Text.ToLower());

                char[] array1 = new char[keyword.Length];
                for (int i = 0; i < keyword.Length; i++)
                {
                    array1[i] = keyword[i];

                }

                char[] array2 = new char[pom2.Length];
                for (int i = 0; i < pom2.Length; i++)
                {
                    array2[i] = pom2[i];

                }

                // RESULT

                char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                int[] niz1 = new int[array1.Length];

                // Printing content of array 
                int j = 0;
                foreach (char c in array1)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (alphabet[i] == c)
                        {
                            niz1[j] = i;
                            j++;
                        }
                    }

                }

                int p = 0;
                int[] niz2 = new int[array1.Length];
                foreach (char c in array2)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (alphabet[i] == c)
                        {
                            niz2[p] = i;
                            p++;
                        }
                    }

                }

                int[] niz3 = new int[array1.Length];
                for (int i = 0; i < niz1.Length; i++)
                {
                    niz3[i] = niz1[i] + niz2[i];
                    if (niz3[i] > 25)
                    {
                        niz3[i] = (niz3[i] - 25) - 1;
                    }
                }
                char[] niz4 = new char[array1.Length];
                int m = 0;
                //prebaci brojeve u slova i smesti ih u niz
                foreach (int c in niz3)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (i == c)
                        {
                            niz4[m] = alphabet[i];
                            m++;
                        }
                    }

                }
                string cipher = string.Join("", niz4);

                int userId = StudentPage.ID;
                LoadAll.ID = userId;
                sqlCon.Open();
                String query2 = "INSERT INTO EncrypTable (plaintext, keyword, ciphertext, id_p) VALUES(@plaintext, @keyword, @ciphertext, @userId)";
                SqlCommand cmd = new SqlCommand(query2, sqlCon);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@plaintext", text.Text.Trim());
                cmd.Parameters.AddWithValue("@keyword", keyword.Trim());
                cmd.Parameters.AddWithValue("@ciphertext", cipher);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Encryption has been successfully inserted into database.");

            }
        }
        //kreiraj random kljuc od niza velikih i malih slova
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
        private void text_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Text must contain only letter.", "Warning...");
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Keyword must contain only letter.", "Warning...");
            }
        }

        private void Border_PreviewKeyUp(object sender, KeyEventArgs e)
        {
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadAll.ID = StudentPage.ID;
            this.NavigationService.Navigate(new LoadAll());
        }
    }
}
