using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public delegate void Index_Cell(int? i);
    public interface Index_cell
    {
        event Index_Cell index_cell;
    }

}
