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
using System.IO;

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for ShowTyp.xaml
    /// </summary>
    public partial class ShowTyp : UserControl
    {
        public ShowTyp()
        {
            InitializeComponent();
            string cesta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Type.txt");
            if (!File.Exists(cesta)) File.Create(cesta).Close();
            StreamReader sr = new StreamReader(cesta);
            string radek = sr.ReadLine();
            while(radek!=null)
            {
                string[] s = radek.Split(' ');
                Slovnik.Add(s[0], radek.Substring(s[0].Length+1));
                SlovnikR.Add(radek.Substring(s[0].Length + 1), s[0]);
                radek = sr.ReadLine();
            }
        }
        Dictionary<string, string> Slovnik = new Dictionary<string, string>();
        Dictionary<string, string> SlovnikR = new Dictionary<string, string>();
        public List<string> VybranyTyp = new List<string>();
        public bool Zmenatypu = false;
        public void Init(string[] typy)
        {
            stackPanel.Children.Clear();
            VybranyTyp.Clear();
            foreach (string s in typy)
            {
                //Viewbox wb = new Viewbox();
                CheckBox cb = new CheckBox();
                //wb.Child = cb;
                if (Slovnik.ContainsKey(s)) cb.Content = Slovnik[s];
                else cb.Content = s;
                cb.Click += Cb_Click;
                stackPanel.Children.Add(cb);
            }
        }

        private void Cb_Click(object sender, RoutedEventArgs e)
        {
            Zmenatypu = true;
            CheckBox cb = sender as CheckBox;
            string text = cb.Content.ToString();
            if (SlovnikR.ContainsKey(text)) text = SlovnikR[text];
            if (cb.IsChecked.Value) { if (!VybranyTyp.Contains(text)) VybranyTyp.Add(text); }
                else { if (VybranyTyp.Contains(text)) VybranyTyp.Remove(text); }
        }
    }
}
