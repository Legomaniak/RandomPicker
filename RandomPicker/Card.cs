using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker
{
    public class Card
    {
        public string Text, Obrazek;
        public CardName Jmeno;
        public Card(string text, string obrazek, CardName jmeno)
        {
            Text = text;
            Obrazek = obrazek;
            Jmeno = jmeno;
        }
    }
}
