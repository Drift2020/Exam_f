using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void _Date_select(DateTime? i);
    public interface IDate_select
    {
        event _Date_select Date_select;
    }
  
}
