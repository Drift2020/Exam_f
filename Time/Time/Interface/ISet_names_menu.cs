using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Time.Interface
{

  
    public delegate void Set_names_menu(ResourceDictionary disk);
    interface ISet_names_menu
    {
        event Set_names_menu set_names_menu;
    }
}
