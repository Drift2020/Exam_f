using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;
namespace Time
{
    public class GreanSite: View_Model_Base
    {
        private string name;
        private string hootkey;
        private string url;
        public int Id { get; set; }
        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));

            }
            get
            {
                return name;
            }
        }
        public string Hootkey
        {
            set
            {
                hootkey = value;
                OnPropertyChanged("Hootkey");

            }
            get
            {
                return hootkey;
            }
        }
        public string URL
        {
            set
            {
                url = value;
                OnPropertyChanged("URL");

            }
            get
            {
                return url;
            }
        }
     



    }
}
