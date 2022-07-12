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

        public MainWindow()
        {
            InitializeComponent();
            Fclient = new Consult(this);
            ComboBox.SelectedIndex = 0;

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
            logList.Items.Clear();
            foreach (var cl in Fclient.client)
            {
                Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, cl.PhoneNumber, (ComboBox.SelectedIndex == 0) ? "********" : cl.PassportData);
                logList.Items.Add(temp);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Text = TextBox1.Text;
                foreach (var cl in Fclient.client)
                {
                    if (ComboBox.SelectedIndex == 0)
                    {
                        Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, cl.PhoneNumber, cl.PassportData);
                        logList.Items[logList.SelectedIndex] = temp;
                        break;
                    }
                    else
                    {
                        if (TextBox1.Text != null)
                        {
                            Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, TextBox1.Text, cl.PassportData);
                            logList.Items[logList.SelectedIndex] = temp;
                        }
                        break;
                    }

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
