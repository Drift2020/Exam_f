using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time.ModelSQLite
{
    class BigBreakModel : View_Model_Base
    {

        public int Id { get; set; }

        bool isActiveBig;
        int numberTimeBig;
        int numberDurationBig;
        string oldTimeAtBreakBig;
        int? bigSoundId;
        bool isActiveSound;
        bool strictMode;
        int? soundVolume;


        public bool IsActiveBig
        {
            get { return isActiveBig; }
            set
            {
                isActiveBig = value;
                OnPropertyChanged(nameof(IsActiveBig));
            }
        }
        public int NumberTimeBig
        {
            get { return numberTimeBig; }
            set
            {
                numberTimeBig = value;
                OnPropertyChanged(nameof(NumberTimeBig));
            }
        }
        public int NumberDurationBig
        {
            get { return numberDurationBig; }
            set
            {
                numberDurationBig = value;
                OnPropertyChanged(nameof(NumberDurationBig));
            }
        }
        public string OldTimeAtBreakBig
        {
            get { return oldTimeAtBreakBig; }
            set
            {
                oldTimeAtBreakBig = value;
                OnPropertyChanged(nameof(OldTimeAtBreakBig));
            }
        }
        public int? BigSoundId
        {
            get { return bigSoundId; }
            set
            {
                bigSoundId = value;
                OnPropertyChanged(nameof(BigSoundId));
            }
        }
        public bool IsActiveSound
        {
            get { return isActiveSound; }
            set
            {
                isActiveSound = value;
                OnPropertyChanged(nameof(IsActiveSound));
            }
        }
        public bool StrictMode
        {
            get { return strictMode; }
            set
            {
                strictMode = value;
                OnPropertyChanged(nameof(StrictMode));
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
