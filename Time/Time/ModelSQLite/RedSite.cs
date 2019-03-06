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
    public class RedSite : View_Model_Base
    {
        private string name;
     
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
