using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Time.Command;

namespace Time.View_model
{
    class Add_Event_View_Model : View_Model_Base
    {
        #region Variables

        #region date start

        DateTime? start_date=null;

        public DateTime? Start_date
        {
            set
            {
                start_date = value;
                OnPropertyChanged(nameof(Start_date));
            }
            get
            {
                return start_date;
            }
        }

        #endregion date start


        #region date end

        DateTime? end_date = null;

        public DateTime? End_date
        {
            set
            {
                end_date = value;
                OnPropertyChanged(nameof(End_date));
            }
            get
            {
                return end_date;
            }
        }

        #endregion date end

        #region  Summary

        string summary = null;

        public string Summary
        {
            set
            {
                summary = value;
                OnPropertyChanged(nameof(Summary));
            }
            get
            {
                return summary;
            }
        }

        #endregion Summary

        #region Location

        string location = null;

        public string Location
        {
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
            get
            {
                return location;
            }
        }

        #endregion Location

        #region Description

        string description = null;

        public string Description
        {
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
            get
            {
                return description;
            }
        }

        #endregion Description

        #region All_day

        bool all_day = false;

        public bool All_day
        {
            set
            {
                all_day = value;
                OnPropertyChanged(nameof(All_day));


            }
            get
            {
                return all_day;
            }
        }

        #endregion All_day

        #region IsClose
        public bool is_close=true;
        #endregion IsClose

        #endregion Variables

        #region Command

        #region Button_click_create

        private DelegateCommand _Command_create;
        public ICommand Button_click_create
        {
            get
            {
                if (_Command_create == null)
                {
                    _Command_create = new DelegateCommand(Execute_create, CanExecute_create);
                }
                return _Command_create;
            }
        }
        private void Execute_create(object o)
        {
            is_close = false;
            close();

        }
        private bool CanExecute_create(object o)
        {
            if(Start_date!= null && End_date != null)
            return true;

            return false;
        }

        #endregion  Button_click_create

        #endregion Command

        #region action 

        public Action close;

        #endregion action 

     
    }
}
