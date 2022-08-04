using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
    
    internal class Manager : Consult, IClientDataMonitor
    {
        private MainWindow w;
       
        public Manager(MainWindow W) : base(W)
        {
            this.w = W;
            
        }
        public void ReadData(string path = "path")
        {
            
            string AllData = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    AllData += sr.ReadLine();
                    string[] splitData = AllData.Split(' ');
                    if (splitData.Length == 5)
                    {
                        Clients clientToAdd = new Clients(splitData[0], splitData[1], splitData[2], splitData[3], splitData[4]);
                        client.Add(clientToAdd);
                        Array.Clear(splitData, 0, splitData.Length);
                        AllData = "";
                    }
                }
            }
        }

        public void ViewClientData()
        {
            foreach (var cl in client)
            {
                Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, cl.PhoneNumber, cl.PassportData);
                w.logList.Items.Add(temp);
            }
        }

        public void ChangeData()
        {
            int i = w.ComboBox.SelectedIndex; 
            foreach (var cl in client)
            {

                try
                {

                    if (w.TextBox1.Text != null)
                    {
                        if (w.ChangerSelect.SelectedIndex == 0)
                        {
                            Clients temp = new Clients(w.TextBox1.Text, cl.MidleName, cl.LastName, cl.PhoneNumber, (i == 0) ? "****" : cl.PassportData);
                            client.Add(temp);
                            w.logList.Items[w.logList.SelectedIndex] = temp;
                        }
                        else if (w.ChangerSelect.SelectedIndex == 1)
                        {
                            Clients temp = new Clients(cl.FirstName, w.TextBox1.Text, cl.LastName, cl.PhoneNumber,(i == 0) ? "****" : cl.PassportData);
                            client.Add(temp);
                            w.logList.Items[w.logList.SelectedIndex] = temp;
                        }
                        else if (w.ChangerSelect.SelectedIndex == 2)
                        {
                            Clients temp = new Clients(cl.FirstName, cl.MidleName, w.TextBox1.Text, cl.PhoneNumber, (i == 0) ? "****" : cl.PassportData);
                            client.Add(temp);
                            w.logList.Items[w.logList.SelectedIndex] = temp;
                        }
                        else if (w.ChangerSelect.SelectedIndex == 3)
                        {
                            if (w.ComboBox.SelectedIndex == 0)
                            {
                                MessageBox.Show("not enough rights", "Warning!", MessageBoxButton.OK);
                            }
                            else
                            {

                                Clients temp = new Clients(cl.FirstName, cl.MidleName, cl.LastName, w.TextBox1.Text, (i == 0) ? "****" : cl.PassportData);
                                client.Add(temp);
                                w.logList.Items[w.logList.SelectedIndex] = temp;

                            }


                        }
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK);
                }

            }
        }

        public void ChangePhoneNumber()
        {
            foreach (var cl in client)
            {
                if (w.ComboBox.SelectedIndex == 0)
                {
                    Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, cl.PhoneNumber, cl.PassportData);
                    client.Add(temp);
                    w.logList.Items[w.logList.SelectedIndex] = temp;
                    break;
                }
                else
                {
                    if (w.TextBox1.Text != null)
                    {
                        Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, w.TextBox1.Text, cl.PassportData);
                        client.Add(temp);
                        w.logList.Items[w.logList.SelectedIndex] = temp;
                    }
                    break;
                }

            }
        }

        
    }
}
