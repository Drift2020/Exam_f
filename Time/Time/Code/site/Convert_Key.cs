using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Code
{
    public class Convert_Key
    {
        public void Clean()
        {
            my_Hootkey.Clear();
            hootkey = "";
        }

        List<string> my_Hootkey;
        string hootkey = "";
        public Convert_Key(){
            hootkey = "";
            my_Hootkey = new List<string>();
        }


        public string KeyDown(string key)

        {

            if (my_Hootkey.Find(x => x == key) == null)
            {
                my_Hootkey.Add(key);

                hootkey = "";
                my_Hootkey.ForEach(x => { hootkey += x + "+"; });
                hootkey = hootkey.Substring(0, hootkey.Length - 1);
            }
            return hootkey;
        }


        public void KeyUp(string key)
        {
            my_Hootkey.Remove(key);       
        }
    }
}
