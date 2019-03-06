using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void _IBig_c();
    public interface IBig_c
    {
        event _IBig_c big_c;
    }
   
}
