using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time
{
   public class StatisticSite : View_Model_Base
    {
        private string name;
        private string time;
        private string status;
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

        public string Time
        {
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));

            }
            get
            {
                return time;
            }
        }

        public string Status
        {
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));

            }
            get
            {
                return status;
            }
        }

        public string URL
        {
            set
            {
                url = value;
                OnPropertyChanged(nameof(URL));

            }
            get
            {
                return url;
            }
        }
    }
}
