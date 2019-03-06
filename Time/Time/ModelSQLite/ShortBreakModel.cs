using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time.ModelSQLite
{
    class ShortBreakModel : View_Model_Base
    {
  
        public int Id { get; set; }
        private bool isActiveShort;
        private int numberTimeShort;
        private int numberDurationShort;
        private string oldTimeAtBreakShort;
        private int? shortSoundId;
        private bool isSoundActive;
        int? soundVolume;

        public bool IsActiveShort
        {
            get
            {
                return isActiveShort;
            }
            set
            {
                isActiveShort = value;
                OnPropertyChanged(nameof(IsActiveShort));
            }
        }

        public int NumberTimeShort
        {
            get
            {
                return numberTimeShort;
            }
            set
            {
                numberTimeShort = value;
                OnPropertyChanged(nameof(NumberTimeShort));
            }
        }

        public int NumberDurationShort
        {
            get
            {
                return numberDurationShort;
            }
            set
            {
                numberDurationShort = value;
                OnPropertyChanged(nameof(NumberDurationShort));
            }
        }

        public string OldTimeAtBreakShort
        {
            get
            {
                return oldTimeAtBreakShort;
            }
            set
            {
                oldTimeAtBreakShort = value;
                OnPropertyChanged(nameof(OldTimeAtBreakShort));
            }
        }

        public int? ShortSoundId
        {
            get
            {
                return shortSoundId;
            }
            set
            {
                shortSoundId = value;
                OnPropertyChanged(nameof(ShortSoundId));
            }
        }

        public bool IsSoundActive
        {
            get
            {
                return isSoundActive;
            }
            set
            {
                isSoundActive = value;
                OnPropertyChanged(nameof(IsSoundActive));
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
