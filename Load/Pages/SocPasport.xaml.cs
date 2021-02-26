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
using Excel = Microsoft.Office.Interop.Excel;

namespace Load.Pages
{
    /// <summary>
    /// Логика взаимодействия для SocPasport.xaml
    /// </summary>
    public partial class SocPasport : Page
    {
        private MySqlConnection conn;

        public SocPasport()
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

            MySqlCommand command = new MySqlCommand("select id, name from gruppa", conn);
            MySqlDataReader read = command.ExecuteReader();
            DataTable group = new DataTable();
            group.Load(read);
            Group.ItemsSource = group.DefaultView;
        }

        private DataTable studentData(int gruppa)
        {
            MySqlCommand command = new MySqlCommand("select student.id, CONCAT(first_name, ' ', middle_name, ' ', last_name) as FIO, bithdate, " +
                "CONCAT(Counter, ', ', Oblast, ', ', Raion, ', ', City, ', ', Street, ', ', NumberHome, ', ', NumberKvartira) as address," +
                " mother, father from student JOIN gruppa ON student.gruppa = gruppa.id where gruppa.id = " + gruppa, conn);
            MySqlDataReader read = command.ExecuteReader();
            DataTable group = new DataTable();
            group.Load(read);
            return group;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (Group.SelectedItem != null)
            {
                var select = Group.SelectedItem as DataRowView;

                var application = new Excel.Application();
                application.SheetsInNewWorkbook = 1;
                var workbook = application.Workbooks.Add(Type.Missing);
                var sheet = application.Worksheets.Item[1];
                int row = 2;
                DataTable table = studentData((int)select["id"]);

                try
                {
                    Excel.Range group = sheet.Range[sheet.Cells[1][row], sheet.Cells[4][row]];
                    group.Merge();
                    group.Value = "Паспорт группы " + select["name"];
                    group.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    group.Font.Italic = true;
                    group.Font.Bold = true;
                    group.Font.Size = 18;
                    row+=2;

                    sheet.Cells[1][row] = "ФИО";
                    sheet.Cells[2][row] = "Дата рождения";
                    sheet.Cells[3][row] = "Адрес";
                    sheet.Cells[4][row] = "Родители";
                    row++;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        sheet.Cells[1][row] = table.Rows[i][1].ToString();
                        sheet.Cells[2][row] = table.Rows[i][2].ToString();
                        sheet.Cells[3][row] = table.Rows[i][3].ToString();
                        sheet.Cells[4][row] = "Мать: " + table.Rows[i][4].ToString() + ", Отец: " + table.Rows[i][5].ToString();
                        row++;
                    }
                    Excel.Range Boldtable = sheet.Range[sheet.Cells[1][4], sheet.Cells[4][row - 1]];
                    Boldtable.Borders.LineStyle = true;

                    sheet.Columns.AutoFit();
                    application.Visible = true;
                }
                catch (Exception c)
                { MessageBox.Show(c.Message); }
            }
        }
    }
}
