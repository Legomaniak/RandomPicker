using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker
{
    class Decoder
    {
        public CardName GetName(string jmeno)
        {
            uint hodnota = 0;
            uint.TryParse(jmeno.Substring(Properties.Settings.Default.startIndex2, Properties.Settings.Default.endIndex2), out hodnota);
            return new CardName() { Trida = jmeno.Substring(Properties.Settings.Default.startIndex, Properties.Settings.Default.endIndex).ToUpper(), Cislo = hodnota };
        }
    }
}
