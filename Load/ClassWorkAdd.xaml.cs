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
using System.Windows.Shapes;

namespace Load
{
    /// <summary>
    /// Логика взаимодействия для ClassWorkAdd.xaml
    /// </summary>
    public partial class ClassWorkAdd : Window
    {
        public int id;
        MySqlConnection conn;
        public ClassWorkAdd()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SaveText.Text == "Сохранить")
                    INSERT();
                else if (SaveText.Text == "Изменить")
                    UPDATE();
                this.Close();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void INSERT()
        {
            try
            {
                var spec = Specialnost.SelectedItem as DataRowView;

                MySqlCommand comm = new MySqlCommand("INSERT INTO classwork(age, specialnost, date_save, kvalification) VALUES " +
                    $"('{Year.Text}', '{spec[0]}', '{Data_Save.Text}', '{Kvalif.Text}');", conn);
                MySqlDataReader read = comm.ExecuteReader();
                read.Close();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }
        private void UPDATE()
        {
            try
            {
                var spec = Specialnost.SelectedItem as DataRowView;

                MySqlCommand comm = new MySqlCommand($"UPDATE classwork SET age = '{Year.Text}', specialnost = '{spec[0]}', " +
                    $"date_save = '{Data_Save.Text}', kvalification = '{Kvalif.Text}' where id = {id}", conn);
                MySqlDataReader read = comm.ExecuteReader();
                read.Close();
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            try
            {
                conn.Open();
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }

        }
    }
}
