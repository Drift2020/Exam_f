using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
  
    public delegate void Update_Select_Dates(List<DateTime> i);
    interface IUpdate_Select_Dates
    {
        event Update_Select_Dates Update_select_dates;
    }

}
