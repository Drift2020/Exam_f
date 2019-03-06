using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Code
{
    class Site_opening
    {
        
       static public void Open(string i)
        {
            System.Diagnostics.Process.Start(i);
        }
    }
}
