using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{

    public delegate void Red_site_add_or_edit(bool _is);
    public interface IRed_site_add_or_edit
    {
        event Red_site_add_or_edit red_site_add_or_edit;
    }

   
}
