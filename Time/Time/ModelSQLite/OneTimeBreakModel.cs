using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time.ModelSQLite
{
    class OneTimeBreakModel : View_Model_Base
    {
        private bool is_active_one;
        private string time_break_one;
        private string duration_break_one;
        private string old_time_at_break_one;
        private int? oneSoundId;
        private bool isSoundActive;
        int? soundVolume;

        public int Id { get; set; }
        public bool IsActiveOne
        {
            set
            {
                is_active_one = value;
                OnPropertyChanged(nameof(IsActiveOne));

            }
            get
            {
                return is_active_one;
            }
        }
        public string TimeBreakOne
        {
            set
            {
                time_break_one = value;
                OnPropertyChanged("TimeBreakOne");

            }
            get
            {
                return time_break_one;
            }
        }

        public string DurationBreakOne
        {
            set
            {
                duration_break_one = value;
                OnPropertyChanged("DurationBreakOne");

            }
            get
            {
                return duration_break_one;
            }
        }

        public string OldTimeAtBreakOne
        {
            set
            {
                old_time_at_break_one = value;
                OnPropertyChanged("OldTimeAtBreakOne");

            }
            get
            {
                return old_time_at_break_one;
            }
        }

        public int? OneSoundId
        {
            set
            {
                oneSoundId = value;
                OnPropertyChanged("OneSoundId");

            }
            get
            {
                return oneSoundId;
            }
        }

        public bool IsSoundActive
        {
            set
            {
                isSoundActive = value;
                OnPropertyChanged("IsSoundActive");

            }
            get
            {
                return isSoundActive;
            }
        }

        public int? SoundVolume
        {
            get { return soundVolume; }
            set
            {
                soundVolume = value;
                OnPropertyChanged(nameof(SoundVolume));
            }
        }
    }
}
