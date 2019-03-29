using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
    public delegate void _Statistic_site_edit_add_delete(List<StatisticSite> i);
    interface IStatistic_site_edit_add_delete
    {
        event _Statistic_site_edit_add_delete statistic_site_edit_add_delete;
    }
 
}
