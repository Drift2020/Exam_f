using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void _RedSite_delete(List<RedSite> element);
    public interface IRedSite_delete
    {
        event _RedSite_delete red_site_delete;
    }
    
}
