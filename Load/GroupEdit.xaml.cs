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
    /// Логика взаимодействия для GroupEdit.xaml
    /// </summary>
    public partial class GroupEdit : Window
    {
        public int id;
        public GroupEdit()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var spec = Spec.SelectedItem as DataRowView;
                var teacherBOX = Techear.SelectedItem as DataRowView;
                var formBox = FormLearn.SelectedItem as DataRowView;

                MySqlConnection conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");
                conn.Open();
                MySqlCommand comm = new MySqlCommand($"update gruppa set specialnost = {spec[0]}, cours = {Cours.Text}, teacher = {teacherBOX[0]}, " +
                    $"year_learn = {Year.Text}, form_learn = {formBox[0]}, learn_plan = '{Convert.ToDateTime(Plan.Text).ToString("yyyy-MM-dd")}' where id = " + id, conn);

                MySqlDataReader read = comm.ExecuteReader();
                this.Close();
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
