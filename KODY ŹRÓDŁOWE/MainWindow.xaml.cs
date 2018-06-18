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
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace PROJEKT
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }




        public int X = 0;
        public int D = 0;

        public int Y = 0;
        public int E = 0;

        public int C = 0;

        


        private void BT_DODAJ_Click(object sender, RoutedEventArgs e)                          // DODAWANIE CZUJNIKOW
        {
            int liczbaPokoi = Int32.Parse(TB_POKOJE.Text);
            int pokoj = Int32.Parse(CB_POKOJ.Text);



            switch (CB_NAZWA.Text)
            {
                case "Termometr":
                    if (X < liczbaPokoi)
                    {
                        if (D == pokoj)
                        {
                            MessageBox.Show("W TYM POKOJU JUZ JEST CZUJNIK");
                        }
                        else
                        {                            
                            MojeZmienne.mojeCzujniki[X] = new Czujnik
                            {
                                Numer = pokoj,
                                Nazwa = CB_NAZWA.Text,
                            };
                            MojeZmienne.mojeCzujniki[X].UstalWartosc(X + 1);
                            
                            LISTA.Items.Add(new Czujnik() { Nazwa = MojeZmienne.mojeCzujniki[X].Nazwa, Numer = MojeZmienne.mojeCzujniki[X].Numer, Wartosc = MojeZmienne.mojeCzujniki[X].Wartosc });
                            D = pokoj;
                            X++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("BRAK WOLNYCH POKOI");
                    }
                    break;

                case "Wentylator":
                    if (Y < liczbaPokoi)
                    {
                        if (E == pokoj)
                        {
                            MessageBox.Show("W TYM POKOJU JUZ JEST URZADZENIE");
                        }
                        else
                        {
                            MojeZmienne.mojeUrzadzenia[Y] = new Urzadzenie()
                            {
                                Numer = pokoj,
                                Nazwa = CB_NAZWA.Text,
                                Wartosc = 0,
                            };

                            //MojeZmienne.mojeUrzadzenia[Y].ustalWartosc();

                            LISTA.Items.Add(new Urzadzenie() { Nazwa = MojeZmienne.mojeUrzadzenia[Y].Nazwa, Numer = MojeZmienne.mojeUrzadzenia[Y].Numer, Wartosc = MojeZmienne.mojeUrzadzenia[Y].Wartosc });
                            E = pokoj;
                            Y++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("BRAK WOLNYCH POKOI");
                    }
                    break;
            }
        }




        private void BT_USUN_Click(object sender, RoutedEventArgs e) // USUWANIE CZUJNIKA
        {
            LISTA.Items.RemoveAt(LISTA.Items.IndexOf(LISTA.SelectedItem));
            X--;
            Y--;
        }




        private void BT_POKOJE_Click(object sender, RoutedEventArgs e) // ZATWIERDZANIE POKOI
        {
            int iloscPokoi = Int32.Parse(TB_POKOJE.Text);

            

            if (C == iloscPokoi)
            {
                MessageBox.Show("JUZ ZATWIERDZONE");
            }
            else
            {
                LISTA.Items.Clear();
                CB_POKOJ.Items.Clear();          
                
                X = 0;
                D = 0;
                Y = 0;
                E = 0;

                for (int i = 1; i <= iloscPokoi; i++)
                {
                    MojeZmienne.mojeCzujniki[i] = new Czujnik();
                    MojeZmienne.mojeUrzadzenia[i] = new Urzadzenie();
                    CB_POKOJ.Items.Add(i);
                    C++;
                }
            }
        }




        public void BT_USTAW_Click(object sender, RoutedEventArgs e) // WYSYLANIE NA SERWER
        {
            try
            {
                int iloscPokoi = Int32.Parse(TB_POKOJE.Text);
                for (int i = 0; i < iloscPokoi; i++)
                {
                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.Connect("192.168.43.161", 8001);

                    String str = MojeZmienne.mojeCzujniki[i].Nazwa + " " + MojeZmienne.mojeCzujniki[i].Numer.ToString() + " " + MojeZmienne.mojeCzujniki[i].Wartosc;
                    String str1 = MojeZmienne.mojeUrzadzenia[i].Nazwa + " " + MojeZmienne.mojeUrzadzenia[i].Numer.ToString() + " " + MojeZmienne.mojeUrzadzenia[i].Wartosc;

                    Stream stm = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str + " | " + str1);

                    stm.Write(ba, 0, ba.Length);

                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);

                    tcpclnt.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("BLAD");
            }
        }
    }
}