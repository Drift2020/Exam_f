using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void _GreanSite_edit_add_delete(List<GreanSite> element);
    public interface IGreanSite_edit_add_delete
    {
        event _GreanSite_edit_add_delete greanSite_edit_add_delete;
    }


   
}
