using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            casovac = new Timer(tick);
            //this.WindowState = WindowState.Maximized;
            //this.WindowStyle = WindowStyle.None;
            if (Directory.Exists(Properties.Settings.Default.cesta)) cesta = Properties.Settings.Default.cesta;

            if (Directory.Exists(cesta))
            {
                loader.Nacti(cesta);
                sorter.Roztrid(loader.Karty);
                showTyp.Init(sorter.GetTypy());
            }
            myRow.Height = new GridLength(0);
        }
        Loader loader = new Loader();
        Sorter sorter = new Sorter();
        string cesta;
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            WindowProperities wp = new WindowProperities();
            wp.ShowDialog();
            if (Directory.Exists(cesta))
            {
                loader.Nacti(cesta);
                sorter.Roztrid(loader.Karty);
                showTyp.Init(sorter.GetTypy());
            }
        }
        List<Card> Karty = new List<Card>();
        Random r = new Random();
        Timer casovac;

        private void tick(object state)
        {
            NextCard();
        }

        public void NextCard()
        {
            if (showTyp.Zmenatypu)
            {
                showTyp.Zmenatypu = false;
                Karty.Clear();
                foreach (string s in showTyp.VybranyTyp)
                {
                    foreach (Trida t in sorter.KartyTridene)
                    {
                        if (t.Typ == s) Karty.AddRange(t);
                    }
                }
            }
            Card k = null;
            if (Karty.Count > 0)
            {
                k = (Karty.Count == 1) ? Karty[0] : Karty[r.Next(1, Karty.Count)];
                if (Properties.Settings.Default.forgoting) Karty.Remove(k);
            }
            Show(k);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.timerEnabled)
            {
                casovac.Change(0, Properties.Settings.Default.timeVal);
            }
            else NextCard();
        }
        public void Show(Card karta)
        {
            if(Properties.Settings.Default.showText)
            {
                myRow.Height = new GridLength(20);
            }
            else myRow.Height = new GridLength(0);
            if (karta == null)
            {
                image.Obrazek = null;
                text.Text = "";
            }
            else
            {
                BitmapImage bs = new BitmapImage(new Uri(karta.Obrazek));
                bs.Freeze();
                image.Obrazek = bs;
                text.Text = karta.Text;
            }
        }
    }
}
