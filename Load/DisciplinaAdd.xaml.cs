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

namespace Load
{
    /// <summary>
    /// Логика взаимодействия для DisciplinaAdd.xaml
    /// </summary>
    public partial class DisciplinaAdd : Window
    {
        MySqlConnection conn;
        public int id;

        public DisciplinaAdd()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (SaveText.Text == "Сохранить")
                INSERT();
            else if (SaveText.Text == "Изменить")
                UPDATE();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void INSERT()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand("INSERT INTO disciplina(name, max_hours, stud_hours, learn_max_hours, classwork, _index, " +
                    "count_exam, count_kurs_work, count_zachet, learn_classwork_hours, learn_lab_hours, learn_kurs_project_hours, one_semestr," +
                    $" two_semestr, three_semestr, four_semestr, five_semestr, six_semestr, seven_semestr, eigth_semestr) VALUES ('{Name.Text}', '{MaxStud.Text}'," +
                    $" '{SamoStud.Text}', '{All.Text}', '{id}', '{Index.Text}', '{Exam.Text}', '{Project.Text}', '{Zachet.Text}', '{OnClasswork.Text}'," +
                    $" '{LabPract.Text}', '{CursProj.Text}', '{Sem1.Text}', '{Sem2.Text}', '{Sem3.Text}', '{Sem4.Text}', '{Sem5.Text}', '{Sem6.Text}', '{Sem7.Text}', '{Sem8.Text}')", conn);
                MySqlDataReader read = comm.ExecuteReader();
                read.Close();
                this.Close();
            }
            catch(Exception c)
            { MessageBox.Show(c.Message); }
        }

        private void UPDATE()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand($"UPDATE disciplina SET name = '{Name.Text}', max_hours = '{MaxStud.Text}', stud_hours = '{SamoStud.Text}', " +
                    $"learn_max_hours = '{All.Text}', _index = '{Index.Text}', count_exam = '{Exam.Text}', count_kurs_work = '{Project.Text}'," +
                    $" count_zachet = '{Zachet.Text}', learn_classwork_hours = '{OnClasswork.Text}', learn_lab_hours = '{LabPract.Text}', " +
                    $"learn_kurs_project_hours = '{CursProj.Text}', one_semestr = '{Sem1.Text}', two_semestr = '{Sem2.Text}', three_semestr = '{Sem3.Text}'" +
                    $", four_semestr = '{Sem4.Text}', five_semestr = '{Sem5.Text}', six_semestr = '{Sem6.Text}', seven_semestr = '{Sem7.Text}', eigth_semestr = '{Sem8.Text}'" +
                    " where id = " + id, conn);
                MySqlDataReader read = comm.ExecuteReader();
                read.Close();
                this.Close();
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
            { MessageBox.Show(c.Message); }
        }
    }
}
