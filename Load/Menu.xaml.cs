using Load.Pages;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Navigate(new Student());

            //Main.Content = new Student();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Navigate(new Groups());
           // Main.Content = new Groups();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new Specialnosts());
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new LearnPlane());
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new teacher());
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new SocPasport());
        }
    }
}
