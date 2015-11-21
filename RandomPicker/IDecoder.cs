using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker
{
    interface IDecoder
    {
        CardName GetName(string jmeno);
    }
}
