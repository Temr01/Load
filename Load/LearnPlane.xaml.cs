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
    /// Логика взаимодействия для Learn_Planxaml.xaml
    /// </summary>
    public partial class LearnPlane : Page
    {
        DataTable tableSelect;
        DataTable tableSelect1;
        MySqlConnection conn;
        public LearnPlane()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new MySqlConnection("server = 192.168.40.95; user = temirlan; pwd = 123; database = ont");

            try
            {
                conn.Open();
                Start();
                ComboBoxStart();
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void SelectSpec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var select = SelectSpec.SelectedItem as DataRowView;
                if (select != null)
                {
                    MySqlCommand command = new MySqlCommand($"select *, specialnost.code from ont.classwork JOIN specialnost ON classwork.specialnost = specialnost.id where classwork.specialnost = '{select[0]}'", conn);
                    MySqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    dataClasswork.ItemsSource = table.DefaultView;
                }
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }
        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }
        private void Start()
        {
            MySqlCommand command = new MySqlCommand("select *, specialnost.code from classwork JOIN specialnost ON classwork.specialnost = specialnost.id", conn);
            MySqlDataReader read = command.ExecuteReader();
            tableSelect = new DataTable();
            tableSelect.Load(read);
            dataClasswork.ItemsSource = tableSelect.DefaultView;


            MySqlCommand commandD = new MySqlCommand("select * from disciplina JOIN classwork ON classwork.id = disciplina.classwork where classwork.id = " + tableSelect.Rows[0][0], conn);
            MySqlDataReader readD = commandD.ExecuteReader();
            DataTable tableD = new DataTable();
            tableD.Load(readD);
            DataDisciplina.ItemsSource = tableD.DefaultView;
        }
        private void ComboBoxStart()
        {

            MySqlCommand command = new MySqlCommand("select * from specialnost", conn);
            MySqlDataReader read = command.ExecuteReader();
            tableSelect1 = new DataTable();
            tableSelect1.Load(read);
            SelectSpec.ItemsSource = tableSelect1.DefaultView;
        }

        private void DeleteClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = dataClasswork.SelectedItem as DataRowView;
                if (select != null)
                {
                    MySqlCommand command = new MySqlCommand($"delete from classwork where id = {select[0]}", conn);
                    MySqlDataReader read = command.ExecuteReader();
                    read.Close();
                    Start();
                }
                else MessageBox.Show("Выберите специальность");
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void dataClasswork_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectTable();
        }

        private void LookingClass_Click(object sender, RoutedEventArgs e)
        {
            SelectAdd();
        }

        private void SelectTable()
        {
            ClassWorkAdd add = new ClassWorkAdd();
            if (dataClasswork.SelectedItem != null)
            {
                var select = dataClasswork.SelectedItem as DataRowView;

                add.Year.Text = select["age"].ToString();
                add.Specialnost.ItemsSource = tableSelect1.DefaultView;
                add.Specialnost.Text = select["code"].ToString();
                add.Data_Save.Text = select["date_save"].ToString();
                add.Kvalif.Text = select["kvalification"].ToString();
                add.SaveText.Text = "Изменить";
                add.id = Convert.ToInt32(select["id"]);
                add.ShowDialog();
            }
        }
        private void SelectAdd()
        {
            SelectTable();
        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            ClassWorkAdd add = new ClassWorkAdd();
            add.Specialnost.ItemsSource = tableSelect1.DefaultView;
            add.ShowDialog();
        }

        private void dataClasswork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var select = dataClasswork.SelectedItem as DataRowView;

                MySqlCommand commandD = new MySqlCommand("select * from disciplina JOIN classwork ON classwork.id = disciplina.classwork where classwork.id = " + select[0], conn);
                MySqlDataReader readD = commandD.ExecuteReader();
                DataTable tableD = new DataTable();
                tableD.Load(readD);
                DataDisciplina.ItemsSource = tableD.DefaultView;
            }
            catch
            { MessageBox.Show("Выберите специальность"); }
        }

        private void Look_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = DataDisciplina.SelectedItem as DataRowView;
                DisciplinaAdd add = new DisciplinaAdd();

                add.Name.Text = select["name"].ToString();
                add.MaxStud.Text = select["max_hours"].ToString();
                add.SamoStud.Text = select["stud_hours"].ToString();
                add.All.Text = select["learn_max_hours"].ToString();
                add.Index.Text = select["_index"].ToString();
                add.Exam.Text = select["count_exam"].ToString();
                add.Project.Text = select["count_kurs_work"].ToString();
                add.Zachet.Text = select["count_zachet"].ToString();
                add.OnClasswork.Text = select["learn_classwork_hours"].ToString();
                add.LabPract.Text = select["learn_lab_hours"].ToString();
                add.CursProj.Text = select["learn_kurs_project_hours"].ToString();
                add.Sem1.Text = select["one_semestr"].ToString();
                add.Sem2.Text = select["two_semestr"].ToString();
                add.Sem3.Text = select["three_semestr"].ToString();
                add.Sem4.Text = select["four_semestr"].ToString();
                add.Sem5.Text = select["five_semestr"].ToString();
                add.Sem6.Text = select["six_semestr"].ToString();
                add.Sem7.Text = select["seven_semestr"].ToString();
                add.Sem8.Text = select["eigth_semestr"].ToString();
                add.id = (int)select["id"];

                add.SaveText.Text = "Изменить";
                add.ShowDialog();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void DeleteDisc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = DataDisciplina.SelectedItem as DataRowView;
                if (select != null)
                {
                    MySqlCommand command = new MySqlCommand($"delete from disciplina where id = {select[0]}", conn);
                    MySqlDataReader read = command.ExecuteReader();
                    read.Close();
                    Start();
                }
                else MessageBox.Show("Выберите дисциплину");
            }
            catch (Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void AddDisc_Click(object sender, RoutedEventArgs e)
        {
            DisciplinaAdd add = new DisciplinaAdd();
            var select = dataClasswork.SelectedItem as DataRowView;
            if (select == null)
                add.id = (int)tableSelect.Rows[0][0];
            else
            {
                add.id = (int)select["id"];
            }
            add.ShowDialog();
        }
    }
}
