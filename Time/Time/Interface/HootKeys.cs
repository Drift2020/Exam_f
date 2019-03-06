using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public delegate void Hoot_Keys(string i);
    interface HootKeys
    {
        event Hoot_Keys hoot_Keys;
    }
}
