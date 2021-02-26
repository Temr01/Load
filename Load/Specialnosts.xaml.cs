using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Load
{
    /// <summary>
    /// Логика взаимодействия для Specialnosts.xaml
    /// </summary>
    public partial class Specialnosts : Page
    {
        public Specialnosts()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
                conn.Open();
                MySqlCommand comm = new MySqlCommand($"select * from specialnost", conn);
                MySqlDataReader read = comm.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(read);

                dataSpec.ItemsSource = t.DefaultView;
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }
    }
}
