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
    public class Urzadzenie
    {
        int war;

        public int Numer { get; set; }
        public string Nazwa { get; set; }

        //public int Wartosc { get { return war; } set { this.war = value; } }

        public int Wartosc { get; set;  }

    /*
        public void ustalWartosc(int z)
        {
            Random rnd1 = new Random();
            war = rnd1.Next(1, 15) * z;
        }
        */


        /*
        public void HandleEvent(object sender, EventArgs args)
        {
            MessageBox.Show("WYSOKA TEMPERATURA " + sender);
        }
        */
    }
}
