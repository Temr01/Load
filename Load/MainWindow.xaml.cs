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
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace Load
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            try
            {
                conn.Open();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
            MySqlCommand command = new MySqlCommand($"select * from teacher where login = '{login.Text}' " +
                $"and password = '{password.Password}' or password = '{passwordVisible.Text}'", conn);
            MySqlDataReader read = command.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(read);

            if (d.Rows.Count <= 0)
                MessageBox.Show("Shut up!!!");
            else
            {
                Menu m = new Menu();
                this.Close();
                m.ShowDialog();
            }    
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (passwordVisible.Visibility == Visibility.Hidden)
            {
                eye.Source = new BitmapImage(new Uri("image/eyec.png", UriKind.Relative));
                password.Visibility = Visibility.Hidden;
                passwordVisible.Visibility = Visibility.Visible;
                passwordVisible.Text = password.Password;
            }
            else if (password.Visibility == Visibility.Hidden)
            {
                eye.Source = new BitmapImage(new Uri("image/eye.png", UriKind.Relative));
                password.Visibility = Visibility.Visible;
                passwordVisible.Visibility = Visibility.Hidden;
                password.Password = passwordVisible.Text;
            }
        }
    }
}
