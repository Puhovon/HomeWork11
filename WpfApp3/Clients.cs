using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Clients
    {
        MainWindow w;

        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get;set; }
       

        public Clients(string firstName, string midleName, string lastName, string phoneNumber, string passportData)
        {
            FirstName = firstName;
            MidleName = midleName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            PassportData = passportData;
        }

        

        public void CheckToSecur()
        {
            if (w.ComboBox.SelectedIndex == 0)
            {
                PassportData = "*";
            }
        }
    }
}
