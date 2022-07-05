using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Consult
    {
        private MainWindow w;
        public ObservableCollection<Clients> client { get; set; }
        public Consult(MainWindow W) 
        {
            this.w = W;
            this.client = new ObservableCollection<Clients>();
            ReadData();
            
        }
        private void ReadData(string path = @"Data.txt")
        {
            string AllData = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    AllData += sr.ReadLine();
                    string[] splitData = AllData.Split(' ');
                    if(splitData.Length == 5)
                    {
                            Clients clientToAdd = new Clients(splitData[0], splitData[1], splitData[2], splitData[3], splitData[4]);
                            client.Add(clientToAdd);
                            w.logList.Items.Add(clientToAdd);
                        Array.Clear(splitData,0,splitData.Length);
                        AllData = "";
                    }
                }
            }
        }
    }
}
