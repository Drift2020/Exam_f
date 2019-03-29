using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
   
    public delegate void _Time_select(DateTime? start, DateTime? end);
    public interface ITime_select
    {
        event _Time_select Time_select;
    }
}
