using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    internal class Manager : Consult
    {
        private MainWindow w;

        public Manager(MainWindow W) : base(W)
        {
            this.w = W;
            
        }

        public void ChangePhoneNumber()
        {
            foreach (var cl in client)
            {
                if (w.ComboBox.SelectedIndex == 0)
                {
                    Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, cl.PhoneNumber, cl.PassportData);
                    w.logList.Items[w.logList.SelectedIndex] = temp;
                    break;
                }
                else
                {
                    if (w.TextBox1.Text != null)
                    {
                        Clients temp = new Clients(cl.MidleName, cl.FirstName, cl.LastName, w.TextBox1.Text, cl.PassportData);
                        w.logList.Items[w.logList.SelectedIndex] = temp;
                    }
                    break;
                }

            }
        }
    }
}
