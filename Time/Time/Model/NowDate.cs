using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time.Model
{
    public class NowDate : View_Model_Base
    {



        string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        string time;
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        DateTime? timestart;
        public DateTime? TimeStart
        {
            get
            {
                return timestart;
            }
            set
            {
                timestart = value;
                OnPropertyChanged(nameof(TimeStart));
            }
        }

        DateTime? timeend;
        public DateTime? TimeEnd
        {
            get
            {
                return timeend;
            }
            set
            {
                timeend = value;
                OnPropertyChanged(nameof(TimeEnd));
            }
        }


        string summary;
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }

        string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        bool isAll;
        public bool IsAll
        {
            get
            {
                return isAll;
            }
            set
            {
                isAll = value;
                OnPropertyChanged(nameof(IsAll));
            }
        }
    }
}
