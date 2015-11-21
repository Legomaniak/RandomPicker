using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace RandomPicker
{
    public class Sorter
    {
        public List<Trida> KartyTridene = new List<Trida>();
        public void Roztrid(List<Card> karty)
        {
            KartyTridene.Clear();
            foreach (Card c in karty)
            {
                Trida trida = null;
                foreach (Trida t in KartyTridene) if (t.Typ == c.Jmeno.Trida) trida = t;
                if (trida == null)
                {
                    Trida t = new Trida() { Typ = c.Jmeno.Trida };
                    KartyTridene.Add(t);
                    trida = t;
                }

                trida.Add(c);
            }
            GetMissing();
        }
        public string[] GetTypy()
        {
            string[] s = new string[KartyTridene.Count];
            for (int i = 0; i < KartyTridene.Count; i++) s[i] = KartyTridene[i].Typ;
            return s;
        }
        public void GetMissing()
        {
            string vys = "Missing cards:\n";
            foreach (Trida t in KartyTridene)
            {
                vys += t.Typ + " ";
                int i = 1, combo = 0;
                while(combo<10)
                {
                    bool found = false;
                    foreach (Card c in t)
                    {
                        if (c.Jmeno.Cislo == i)
                        {
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        combo++;
                        vys += i + ", ";
                    }
                    else combo = 0;
                    i++;
                }
                vys += "\n";
            }
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\missing.txt");
            sw.WriteLine(vys);
            sw.Close();
        }         
    }
}
