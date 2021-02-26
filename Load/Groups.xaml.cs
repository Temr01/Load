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
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        MySqlConnection conn;
        public Groups()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("select gruppa.id, specialnost.code, specialnost.name, gruppa.name, cours, CONCAT(teacher.first_name, ' ', teacher.middle_name, ' ', teacher.last_name)" +
                    " as FIO, year_learn, form_learn.form, learn_plan FROM ont.gruppa JOIN ont.teacher ON gruppa.teacher = teacher.id JOIN ont.form_learn " +
                    "ON gruppa.form_learn = form_learn.id JOIN ont.specialnost ON specialnost.id = gruppa.specialnost;", conn);
                MySqlDataReader read = comm.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                DataGroup.ItemsSource = table.DefaultView;
            }
            catch (Exception p)
            { MessageBox.Show(p.Message); }
        }
        private DataTable GroupData()
        {
            MySqlCommand comm = new MySqlCommand("select * from specialnost;", conn);
            MySqlDataReader read = comm.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            return dataTable;
        }
        private DataTable TeacherData()
        {
            MySqlCommand comm = new MySqlCommand("select id, CONCAT(teacher.first_name, ' ', teacher.middle_name, ' ', teacher.last_name) as FIO from teacher;", conn);
            MySqlDataReader read = comm.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            return dataTable;
        }
        private DataTable LearnData()
        {
            MySqlCommand comm = new MySqlCommand("select * from form_learn;", conn);
            MySqlDataReader read = comm.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            return dataTable;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupEdit group = new GroupEdit();
                var Edit = DataGroup.SelectedItem as DataRowView;
                group.Group.Text = Edit["name1"].ToString();

                group.Spec.ItemsSource = GroupData().DefaultView;
                group.Spec.Text = Edit["name"].ToString();

                group.Techear.ItemsSource = TeacherData().DefaultView;
                group.Techear.Text = Edit["FIO"].ToString();

                group.FormLearn.ItemsSource = LearnData().DefaultView;
                group.FormLearn.Text = Edit["form"].ToString();

                group.Cours.Text = Edit["cours"].ToString();
                group.Year.Text = Edit["year_learn"].ToString();
                group.Plan.Text = Edit["learn_plan"].ToString();
                group.id = (int)Edit["id"];

                group.ShowDialog();
            }
            catch (Exception c) { MessageBox.Show(c.Message); }
        }
    }
}
