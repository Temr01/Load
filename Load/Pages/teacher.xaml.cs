using Load.PagesAdd;
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
    /// Логика взаимодействия для teacher.xaml
    /// </summary>
    public partial class teacher : Page
    {
        MySqlConnection conn;
        public teacher()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("select * from teacher", conn);
                MySqlDataReader read = comm.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(read);
                dataTeacher.ItemsSource = d.DefaultView;
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TeacherAdd add = new TeacherAdd();
            try
            {
                var select = dataTeacher.SelectedItem as DataRowView;

                add.firstname.Text = select["first_name"].ToString();
                add.middlename.Text = select["middle_name"].ToString();
                add.lastname.Text = select["last_name"].ToString();
                add.Categ.Text = select["categories"].ToString();
                add.SaveText.Text = "Изменить";
                add.id = (int)select["id"];
                add.ShowDialog();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }
    }
}
