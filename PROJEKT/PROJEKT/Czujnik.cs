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

namespace PROJEKT
{
    public class Czujnik
    {
        int war;

        //public event EventHandler SomethingHappened;
        public int Numer { get; set; }
        public string Nazwa { get; set; }
        public int Wartosc { get { return war; } set { this.war = value; } }

        public void UstalWartosc(int z)
        {
            Random rnd = new Random();
            war = rnd.Next(1, 15) * z;
        }
    
        /*
        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        */
    }
}
