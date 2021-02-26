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

namespace Load.Pages
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        DataTable student;
        MySqlConnection conn;
        public Student()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
            StudentDate();

            MySqlCommand command = new MySqlCommand("select id, name from gruppa", conn);
            MySqlDataReader read = command.ExecuteReader();
            DataTable group = new DataTable();
            group.Load(read);
            search.ItemsSource = group.DefaultView;
        }

        private void FilterGroup_Click(object sender, RoutedEventArgs e)
        {
            if (search.SelectedIndex != -1)
            {
                var group = search.SelectedItem as DataRowView;

                MySqlCommand command = new MySqlCommand($"select * from ont.student join " +
                   $"ont.gruppa on student.gruppa = gruppa.id where student.gruppa = {group[0].ToString()};", conn);

                MySqlDataReader read = command.ExecuteReader();
                DataTable student = new DataTable();
                student.Load(read);

                StudentData.ItemsSource = student.DefaultView;
                read.Close();
            }
        }
        public void StudentDate()
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
            MySqlCommand command = new MySqlCommand($"select *, gruppa.name from ont.student join " +
               $"ont.gruppa on student.gruppa = gruppa.id;", conn);

            MySqlDataReader read = command.ExecuteReader();
            student = new DataTable();
            student.Load(read);

            StudentData.ItemsSource = student.DefaultView;
            read.Close();
            conn.Close();
        }

        private void CancelFilter_Click(object sender, RoutedEventArgs e)
        {
            StudentDate();
            search.SelectedIndex = -1;
        }

        private void StudentSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                //var b = student.Select($"first_name = '{StudentSearch.Text}'");
                //StudentData.ItemsSource = b;
        }

        private void FilterStudent_Click(object sender, RoutedEventArgs e)
        {

            MySqlCommand command = new MySqlCommand($"select * from ont.student join " +
               $"ont.gruppa on student.gruppa = gruppa.id where student.first_name = '{StudentSelect.Text}';", conn);

            MySqlDataReader read = command.ExecuteReader();
            DataTable student = new DataTable();
            student.Load(read);

            StudentData.ItemsSource = student.DefaultView;
            read.Close();
        }

        private void CancelStudFilt_Click(object sender, RoutedEventArgs e)
        {
            StudentDate();
            StudentSelect.Clear();
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = new MySqlCommand("select * from gruppa", conn);
            MySqlDataReader read = command.ExecuteReader();
            DataTable group = new DataTable();
            group.Load(read);

            StudentWindow w = new StudentWindow();
            w.group.ItemsSource = group.DefaultView;
            w.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("select * from gruppa", conn);
                MySqlDataReader read = command.ExecuteReader();
                DataTable group = new DataTable();
                group.Load(read);

                var c = StudentData.SelectedItem as DataRowView;
                StudentWindow w = new StudentWindow();

                w.NameButton.Text = "Изменить";
                w.id = (int)c["id"];
                w.first_name.Text = c["first_name"].ToString();
                w.middle_name.Text = c["middle_name"].ToString();
                w.last_name.Text = c["last_name"].ToString();
                w.bithdate.Text = c["bithdate"].ToString();
                w.Mesto.Text = c["City"].ToString();
                w.pol.Text = c["pole"].ToString();
                w.group.ItemsSource = group.DefaultView;
                w.group.Text = c["name"].ToString();
                w.mother.Text = c["mother"].ToString();
                w.father.Text = c["father"].ToString();
                w.phone.Text = c["phone"].ToString();
                w.Seriya.Text = c["PasSeriya"].ToString();
                w.Number.Text = c["PasNumber"].ToString();
                w.WhoInput.Text = c["PasWho"].ToString();
                w.Kode.Text = c["CodePodrazd"].ToString();
                w.DateInput.Text = c["PasDate"].ToString();
                w.SeriyaPolus.Text = c["Polis"].ToString();
                w.NumberPolus.Text = c["Polis"].ToString();
                w.Oblast.Text = c["Oblast"].ToString();
                w.Raion.Text = c["Raion"].ToString();
                w.Counter.Text = c["Counter"].ToString();
                w.City.Text = c["City"].ToString();
                w.Street.Text = c["Street"].ToString();
                w.Home.Text = c["NumberHome"].ToString();
                w.kvartira.Text = c["NumberKvartira"].ToString();
                w.index.Text = c["Yandex"].ToString();
                w.NumberStydent.Text = c["number_student"].ToString();

                w.ShowDialog();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }
    }
}
