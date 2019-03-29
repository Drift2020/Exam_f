using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{

    public delegate void _Send_title_window(string i);
    interface Send_title_window
    {
        event _Send_title_window send_title_window;
    }


}
