using Load.Pages;
using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Load.PagesAdd
{
    /// <summary>
    /// Логика взаимодействия для TeacherAdd.xaml
    /// </summary>
    public partial class TeacherAdd : Window
    {
        public int id;
        public Menu m;
        public TeacherAdd()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            MySqlCommand comm;
            MySqlDataReader read;
            try
            {
                conn.Open();
                if (SaveText.Text == "Изменить")
                {
                    comm = new MySqlCommand($"Update teacher SET first_name = '{firstname.Text}', middle_name = '{middlename.Text}', last_name = '{lastname.Text}'," +
                        $" categories = '{Categ.Text}' where id = {id}", conn);
                    read = comm.ExecuteReader();
                    read.Close();

                    
                    m.Main.Refresh();

                    this.Close();
                }
                else if (SaveText.Text == "Добавить")
                {

                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
