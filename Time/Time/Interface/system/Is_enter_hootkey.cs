using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
   public delegate void Is_Enter_hootkey(bool i);
    public interface Is_enter_hootkey
    {
        event Is_Enter_hootkey Is_enter_hootkey;
    }



}
