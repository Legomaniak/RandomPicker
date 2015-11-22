using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker
{
    class Loader
    {
        public bool PodDirecory = Properties.Settings.Default.innerSearch;
        public List<Card> Karty = new List<Card>();
        Decoder decoder = new Decoder();
        int counter = 0;
        int maxCounter = 10;
        List<string> aviableExtension = new List<string>();
        Dictionary<string, string> Slovnik = new Dictionary<string, string>();
        public Loader()
        {
            aviableExtension.Add(".jpg");
            aviableExtension.Add(".jpeg");

            string cesta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Text.txt");
            if (!File.Exists(cesta)) File.Create(cesta).Close();
            StreamReader sr = new StreamReader(cesta);
            string radek = sr.ReadLine();
            while (radek != null)
            {
                if (radek.Substring(0, 1) != "#")
                {
                    //nameOfFile space textOfCard  (A-001 First card)
                    string[] s = radek.Split(' ');
                    Slovnik.Add(s[0], radek.Substring(s[0].Length + 1));
                }
                radek = sr.ReadLine();
            }
        }
        public void Nacti(string cesta)
        {
            Karty.Clear();
            if (!Directory.Exists(cesta)||counter>=maxCounter) return;
            counter++;
            string[] cesty = Directory.GetFiles(cesta);
            foreach(string s in cesty)
            {
                bool can = false;
                foreach (string e in aviableExtension) if (Path.GetExtension(s).ToLower() == e) can = true;
                if (can)
                {
                    string name = Path.GetFileNameWithoutExtension(s);
                    CardName cn = decoder.GetName(name);
                    string text = "";
                    if (Slovnik.ContainsKey(name)) text = Slovnik[name];
                    Karty.Add(new Card(text, s, cn));
                }
            }
            if(PodDirecory)
            {
                string[] slozky = Directory.GetDirectories(cesta);
                foreach (string s in slozky) Nacti(s);
            }

            
        }
    }
}
