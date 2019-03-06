using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public delegate void Modifine_String(string i);
    interface Modifine_string
    {
        event Modifine_String _Modifine_string;
    }
}
