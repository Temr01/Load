using Load.Pages;
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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public int id;
        MySqlConnection conn;
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlCommand comm;
                MySqlDataReader read;
                var groupSelect = group.SelectedItem as DataRowView;

                if (NameButton.Text == "Изменить")
                {

                    comm = new MySqlCommand($"Update ont.student set first_name = '{first_name.Text}', middle_name = '{middle_name.Text}', last_name  = '{last_name.Text}', " +
                        $"bithdate = '{Convert.ToDateTime(bithdate.Text).ToString("yyyy-MM-dd")}', pole = '{pol.Text}', gruppa = '{groupSelect[0].ToString()}', " +
                        $"Counter = '{Counter.Text}', Oblast = '{Oblast.Text}', Raion = '{Raion.Text}', City = '{City.Text}', Street = '{Street.Text}', NumberHome = '{Home.Text}', " +
                        $"NumberKvartira = '{kvartira.Text}', Yandex = '{index.Text}', number_student = '{NumberStydent.Text}', phone = '{phone.Text}', PasSeriya = '{Seriya.Text}'," +
                        $" PasNumber = '{Number.Text}', CodePodrazd = '{Kode.Text}', PasDate = '{DateInput.Text}', PasWho = '{WhoInput.Text}', Polis = '{NumberPolus.Text}'," +
                        $" mother = '{mother.Text}', father = '{father.Text}' where id = " + id, conn);
                    read = comm.ExecuteReader();
                    read.Close();
                    CloseWindow();
                }
                else if (NameButton.Text == "Сохранить")
                {
                    comm = new MySqlCommand("Insert into ont.student( first_name, middle_name, last_name, bithdate, pole, gruppa, Counter, Oblast, Raion, City, Street, NumberHome, " +
                      "NumberKvartira, Yandex, number_student, phone, PasSeriya, PasNumber, CodePodrazd, PasDate, PasWho, Polis, mother, father) values " +
                      $"('{first_name.Text}', '{middle_name.Text}', '{last_name.Text}', '{Convert.ToDateTime(bithdate.Text).ToString("yyyy-MM-dd")}', '{pol.Text}', '{groupSelect[0].ToString()}', '{Counter.Text}'," +
                      $" '{Oblast.Text}', '{Raion.Text}', '{City.Text}', '{Street.Text}', '{Home.Text}', '{kvartira.Text}', '{index.Text}', '{NumberStydent.Text}', '{phone.Text}', '{Seriya.Text}', " +
                      $"'{Number.Text}', '{Kode.Text}', '{Convert.ToDateTime(DateInput.Text).ToString("yyyy-MM-dd")}', '{WhoInput.Text}', '{NumberPolus.Text}', '{mother.Text}', '{father.Text}')", conn);
                    read = comm.ExecuteReader();
                    read.Close();
                    CloseWindow();
                }
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            try
            {
                conn.Open();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }
        public void CloseWindow()
        {
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
