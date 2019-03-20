using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Code;

namespace Time.Interface
{
   
    public delegate bool Get_worc_alert();
    interface IGet_worc_alert
    {
        event Get_worc_alert get_worc_alert;
    }
}
