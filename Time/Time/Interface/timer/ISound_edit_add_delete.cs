using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.ModelSQLite;

namespace Time.Interface
{
    public delegate void _Sound_edit_add_delete(List<Sound> i);
    interface ISound_edit_add_delete
    {
        event _Sound_edit_add_delete sound_edit_add_delete;
    }
   
}
