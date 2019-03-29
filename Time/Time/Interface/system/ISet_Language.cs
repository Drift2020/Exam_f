using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void Set_Language(string i);
    public interface ISet_Language
    {
        event  Set_Language set_Language_;
    }

   
}
