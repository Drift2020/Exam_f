﻿//#define test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Time.Code;
using Time.Command;

namespace Time.View_model
{
   
    class Alert_View_Model : View_Model_Base
    {
        #region Actions
        public Action Activate_OK;
        public Action Activate_NEXT;
        public Action Activate_CANCEL;
        public Action Activate_CANCEL1;
        public Action Activate_Info_small;
        public Action Activate_Info_big;

        public Action Deactivate_OK;
        public Action Deactivate_NEXT;
        public Action Deactivate_CANCEL;
        public Action Deactivate_CANCEL1;
        public Action Deactivate_Info_small;
        public Action Deactivate_Info_big;

        public Action StopMainMusic;

        public Action StartMemberTimer;
        public Action Closenig;
        public Action Disposes;
        #endregion Actions

        #region Variables


        bool is_closing = true;

        string text_info;
        public string Text_info { get { return text_info; } set { text_info = value; OnPropertyChanged(nameof(Text_info)); } }

        public Type_alert type { set; get; }
      
        string times;
        public string Times { get { return times; }  set { times = value; OnPropertyChanged(nameof(Times)); } }

       public double time_s { set; get; }
       public bool Message_result=false;

        TimerCallback big_Callback;
        Timer big_timer;

        public MusicPath my_music { set; get; }
        bool work_stop = true;

        public bool Get_Work()
        {
                return work_stop;
        }
        #endregion Variables

        #region Function 


        public void Ok_key()
        {

            switch(type)
            {
                case Type_alert.Message:
                    Message_result = true;
                    is_closing = false;
                    Closenig();
                    break;
            }
        }

        public void Esc_key()
        {

            switch (type)
            {
                case Type_alert.Message:
                    Message_result = false;
                    is_closing = false;
                    Closenig();
                    break;
            }
        }

        void TickBreak(object o)
        {
            try
            {
                if (work_stop)
                {
                    work_stop = false;
                    StopMainMusic();
                }
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {


                    int x = (int)o;
                    time_s = (time_s - x);
                    int temp_my_s = (int)time_s;

                    int temp_second = 0;
                    int temp_mitutes = 0;


                    for (; temp_my_s >= 60; temp_my_s -= 60)
                    {
                        temp_mitutes++;
                    }



                    temp_second = temp_my_s;

                    if (type == Type_alert.Big || type == Type_alert.BigOne)
                    {
                        if (temp_second < 10)
                            Times = String.Format("{0}:{1}{2}", temp_mitutes, 0, temp_second);
                        else
                            Times = String.Format("{0}:{1}", temp_mitutes, temp_second);


                    
                    }

                    else if (type == Type_alert.Short || type == Type_alert.ShortOne)
                    {
                        Times = String.Format("{0}", temp_second);

                    }

                    else if (type == Type_alert.One)
                    {



                        if (temp_second < 10)
                            Times = String.Format("{0}:{1}{2}", temp_mitutes, 0, temp_second);
                        else
                            Times = String.Format("{0}:{1}", temp_mitutes, temp_second);
                        if (time_s < 1)
                        {
                            work_stop = true;
                            my_music.Stop(false);
                            is_closing = false;
                            Closenig();
                            Disposes();
                            big_timer.Change(System.Threading.Timeout.Infinite, 0);
                        }

                    }

             

                    if (time_s < 1)
                    {
                        work_stop = true;
                        my_music.Stop(false);
                        is_closing = false;
                        Closenig();

                        if (type == Type_alert.BigOne || type == Type_alert.ShortOne)
                        {
                            Disposes();
                            StartMemberTimer();
                        }

                        big_timer.Change(System.Threading.Timeout.Infinite, 0);
                       
                    }
                //Times = Time;
            });
            }
            catch (Exception ex)
            {
                my_music.Stop(false);

#if test
                MessageBox.Show(ex.Message, "TickBreak");
#endif
            }
        }
        public void  ActiveteTime()
        {


           big_Callback = new TimerCallback(TickBreak);

            // создаем таймер
           big_timer = new System.Threading.Timer(big_Callback, 1, 0, 1000);


        }


        public void Closing(object sender,System.ComponentModel.CancelEventArgs elem)
        {
            work_stop = true;
            my_music.Stop(false);
            if (is_closing)
            {

               
              


                if (type == Type_alert.BigOne || type == Type_alert.ShortOne)
                {
                    Disposes();
                    StartMemberTimer();
                }
                else if (type == Type_alert.One || type == Type_alert.OneOne)
                {
                    Disposes();
                }

                    
            }
            big_timer.Change(System.Threading.Timeout.Infinite, 0);
        }

        #endregion Function 

        #region Command

        #region cancel
        private DelegateCommand _Command_button_cancel;
        public ICommand Button_clik_button_cancel
        {
            get
            {
                if (_Command_button_cancel == null)
                {
                    _Command_button_cancel = new DelegateCommand(Execute_button_cancel, CanExecute_button_cancel);
                }
                return _Command_button_cancel;
            }
        }
        private void Execute_button_cancel(object o)
        {
            if (type == Type_alert.Big || type == Type_alert.One || type == Type_alert.Short ||
                type == Type_alert.ShortOne || type == Type_alert.BigOne || type == Type_alert.OneOne)
            {
                work_stop = true;
                my_music.Stop(false);
                is_closing = false;
                Closenig();
                if (type == Type_alert.One)
                    Disposes();

                big_timer.Change(System.Threading.Timeout.Infinite, 0);
            }
            else
            {
                Message_result = false;
                is_closing = false;
                Closenig();
            }
        }
        private bool CanExecute_button_cancel(object o)
        {
            return true;
        }
#endregion cancel

        #region OK

                private DelegateCommand _Command_button_ok;
                public ICommand Button_clik_button_ok1
                {
                    get
                    {
                        if (_Command_button_ok == null)
                        {
                            _Command_button_ok = new DelegateCommand(Execute_button_ok, CanExecute_button_ok);
                        }
                        return _Command_button_ok;
                    }
                }
                private void Execute_button_ok(object o)
                {

                    Message_result = true;
                    is_closing = false;
                    Closenig();

                }
                private bool CanExecute_button_ok(object o)
                {
                    return true;
                }
        #endregion OK

        #region next

                private DelegateCommand _Command_button_next;
                public ICommand Button_clik_button_next
                {
                    get
                    {
                        if (_Command_button_next == null)
                        {
                            _Command_button_next = new DelegateCommand(Execute_button_next, CanExecute_button_next);
                        }
                        return _Command_button_next;
                    }
                }
                private void Execute_button_next(object o)
                {


                    var i = 0;
                }
                private bool CanExecute_button_next(object o)
                {
                    return true;
                }
        #endregion next

    


#endregion Command
    }
}
