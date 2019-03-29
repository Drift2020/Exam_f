using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface
{
   

    public delegate bool Popup_menu();
   


    interface IPopup_menu
    {
        event Popup_menu popup_menu;

    }
}
