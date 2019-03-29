using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Interface.Alert
{
    public delegate void Key_Up();
    
    interface IKey_Enter_Up
    {
        event Key_Up key_Enter_Up;
        event Key_Up key_Esc_Up;
    }
}
