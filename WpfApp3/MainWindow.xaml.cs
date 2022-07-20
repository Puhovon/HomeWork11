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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Consult Fclient;
        Manager man;
        public MainWindow()
        {
            InitializeComponent();
            Fclient = new Consult(this);
            ComboBox.SelectedIndex = 0;
            man = new Manager(this);

        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {

        }



        private void MenuItem_Click_Clear(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "TeleBot by Puhovon(Arkady)",
                this.Title,
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fclient.CheckWhoUse();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ComboBox.SelectedIndex == 1)
                {
                    man.ChangePhoneNumber();
                }
                else
                {
                    MessageBox.Show("not enough rights", "Warning!", MessageBoxButton.OK);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK);
            }



        }


        private void logList_Selected(string text, object sender, RoutedEventArgs e)
        {
        }
    }
}
