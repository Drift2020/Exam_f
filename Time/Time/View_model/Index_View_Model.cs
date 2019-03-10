﻿#define test
//#define test_1
//#define test_relise_1
//#define test_relise
//#define relise
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Time.Code;
using Time.Command;

using WindowsFormsApplication1;
using System.Globalization;
using System.Windows.Forms;
using Time.ModelSQLite;
using System.Threading;
using Time.View;
using System.Runtime.InteropServices;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3.Data;
using Time.Model;
using Microsoft.Win32;

namespace Time.View_model
{
    class Index_View_Model : View_Model_Base
    {
        Search_ID _search_ID;
        ApplicationContext db;
        ResourceDictionary dict = new ResourceDictionary();
        My_form _my_form;

        public Index_View_Model()
        {

        }
        public Index_View_Model(ApplicationContext temp)
        {


            _search_ID = new Search_ID();
            db = temp;
            db.GreanSites.Load();
            db.RedSites.Load();
            db.StatisticSites.Load();
            db.OneTimeBreakModels.Load();
            db.ShortBreakModels.Load();
            db.BigBreakModels.Load();
            db.Sounds.Load();

            //list_GSite = db.GreanSites.ToList();
            // list_RSite = db.RedSites.ToList();
            list_StatisticSite = db.StatisticSites.ToList();
            // list_sounds = db.Sounds.ToList();


            list_Test_list = new List<Test_Element>();

            _my_form = new My_form();
            my_big_model = new ObservableCollection<BigBreakModel>(db.BigBreakModels.ToList());
            my_short_model = new ObservableCollection<ShortBreakModel>(db.ShortBreakModels.ToList());
            my_ome_model = new ObservableCollection<OneTimeBreakModel>(db.OneTimeBreakModels.ToList());
            List_sound = new ObservableCollection<Sound>(db.Sounds.ToList());
            Test_list = new ObservableCollection<Test_Element>(list_Test_list);
            Grean = new ObservableCollection<GreanSite>(db.GreanSites.ToList());
            Red = new ObservableCollection<RedSite>(db.RedSites.ToList());
            StatisticSite = new ObservableCollection<Time.StatisticSite>(list_StatisticSite);
            My_list = new ObservableCollection<NowDate>();
            Select_Index_Sound_type_timer = -1;
            //   MouseHook.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseHook_MouseDown);
            MouseHook.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseHook_MouseUp);

            MouseHook.InstallHook();
            Check_Path();


            if (Time_timer_textbox == "0")
            {
                Time_timer_textbox = "__:__:__";
            }
            if (Time_duration_textbox == "0")
            {
                Time_duration_textbox = "__:__:__";
            }
        }

        public void View_model_up()
        {
            Is_Small = Is_Small;
            Is_small_timer = Is_small_timer;
            Is_big_timer = Is_big_timer;
            Auto_start = Auto_start;
            Volum = Volum;
            Icon_Play = "PlayCircleOutline";
        }

        public void Set_Language(string _language)
        {

            switch (_language)
            {
                case "ru-RU":
                    dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", _language), UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                    break;
            }
        }

        void MouseHook_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {


            Statistic_procces();


        }
        #region Saves

        void SaveGrean()
        {
            Grean.ToList().ForEach(y =>
            {
                if (y.Name == null)
                    y.Name = "None";
                if (y.Hootkey == null)
                    y.Hootkey = "None";
                if (y.URL == null)
                    y.URL = "None";

                bool isAdd = true;
                db.GreanSites.ToList().ForEach(x =>
                {
                    try
                    {


                        if (y.Id == x.Id)
                        {
                            isAdd = false;
                        }
                    }
                    catch
                    {
                        isAdd = false;
                    }

                });

                if (isAdd)
                    db.GreanSites.Add(y);

            });

            db.SaveChanges();
        }


        void SaveRed()
        {
            Red.ToList().ForEach(y =>
            {
                if (y.Name == null)
                    y.Name = "None";

                if (y.URL == null)
                    y.URL = "None";

                bool isAdd = true;
                db.RedSites.ToList().ForEach(x =>
                {
                    try
                    {
                        if (y.Id == x.Id)
                        {
                            isAdd = false;
                        }
                    }
                    catch
                    {
                        isAdd = false;
                    }

                });

                if (isAdd)
                    db.RedSites.Add(y);

            });

            db.SaveChanges();
        }


        void SaveStatisticSite()
        {
            StatisticSite.ToList().ForEach(y =>
            {
                bool isAdd = true;
                db.StatisticSites.ToList().ForEach(x =>
                {
                    try
                    {
                        if (y.Id == x.Id)
                        {
                            isAdd = false;
                        }
                    }
                    catch
                    {
                        isAdd = false;
                    }

                });

                if (isAdd)
                    db.StatisticSites.Add(y);

            });

            db.SaveChanges();
        }
        void SaveSoundTimer()
        {
            List_sound.ToList().ForEach(y =>
            {
                bool isAdd = true;
                db.Sounds.ToList().ForEach(x =>
                {
                    try
                    {
                        if (y.Id == x.Id)
                        {
                            isAdd = false;
                        }
                    }
                    catch
                    {
                        isAdd = false;
                    }

                });

                if (isAdd)
                    db.Sounds.Add(y);

            });

            db.SaveChanges();
        }
        void SaveTime()
        {


        }

        public void Closing()
        {

            SaveGrean();
            SaveRed();
            SaveStatisticSite();
            SaveSoundTimer();
            MouseHook.UnInstallHook();



            db.Dispose();

        }

        #endregion Saves


        #region Timer

        #region type time
        int Get_minutes_type_big(int i)
        {
            switch (i)
            {
                case 0:
#if test
                    return 1;//20
#endif
                    return 20;//20

                case 1:
                    return 25;

                case 2:
                    return 30;

                case 3:
                    return 35;

                case 4:
                    return 40;

                case 5:
                    return 45;

                case 6:
                    return 50;

                case 7:
                    return 60;

                case 8:
                    return 90;

                case 9:
                    return 120;

            }

            return -1;
        }
        int Get_minutes_duration_big(int i)
        {
            switch (i)
            {
                case 0:
#if test
                    return 1;//20
#endif
                    return 2;//20

                case 1:
                    return 3;

                case 2:
                    return 4;

                case 3:
                    return 5;

                case 4:
                    return 7;

                case 5:
                    return 10;

                case 6:
                    return 15;

                case 7:
                    return 20;



            }

            return -1;
        }

        int Get_minutes_type_short(int i)
        {
            switch (i)
            {
                case 0:
#if test
                    return 1;//20
#endif
                    return 5;//20

                case 1:
                    return 6;

                case 2:
                    return 10;

                case 3:
                    return 15;

                case 4:
                    return 20;

                case 5:
                    return 30;

            }

            return -1;
        }
        int Get_seconds_duration_short(int i)
        {
            switch (i)
            {
                case 0:
                    return 8;

                case 1:
                    return 20;







            }

            return -1;
        }
        #endregion type time

        #region Variables

        #region is activ big timer
        Alert viewBig;
        Alert_View_Model view_modelBig;


        TimerCallback big_Callback;
        System.Threading.Timer big_timer;


        public bool Is_big_timer
        {
            get
            {
                return my_big_model[0].IsActiveBig;
            }
            set
            {
                try
                {
                    if (value)
                        BigT_D();
                    else
                        BigT_A();

                }
                catch (Exception ex)
                {
#if test
                    System.Windows.MessageBox.Show(ex.Message, "Ups...Is_Small");
#endif
                }
                my_big_model[0].IsActiveBig = value;
                my_big_model[0].IsActiveBig = Set_Timer_big(my_big_model[0].IsActiveBig);
                OnPropertyChanged(nameof(Is_big_timer));
            }
        }



        public int Index_time_big
        {
            get
            {
                return my_big_model[0].NumberTimeBig;
            }
            set
            {
                my_big_model[0].NumberTimeBig = value;
                OnPropertyChanged(nameof(Index_time_big));
            }
        }


        public int Index_duration_big
        {
            get
            {
                return my_big_model[0].NumberDurationBig;
            }
            set
            {
                my_big_model[0].NumberDurationBig = value;
                OnPropertyChanged(nameof(Index_duration_big));
            }
        }

        #endregion is activ big timer

        #region is activ small timer
        Alert viewShort;
        Alert_View_Model view_modelShort;


        TimerCallback short_Callback;
        System.Threading.Timer short_timer;

        public bool Is_small_timer
        {
            get
            {
                return my_short_model[0].IsActiveShort;
            }
            set
            {
                try
                {
                    if (value)
                        Short_D();
                    else
                        Short_A();

                }
                catch (Exception ex)
                {
#if test
                    System.Windows.MessageBox.Show(ex.Message, "Ups...Is_Small");
#endif
                }

                my_short_model[0].IsActiveShort = Set_Timer_short(value);
                OnPropertyChanged(nameof(Is_small_timer));
            }
        }



        public int Index_time_short
        {
            get
            {
                return my_short_model[0].NumberTimeShort;
            }
            set
            {
                my_short_model[0].NumberTimeShort = value;
                OnPropertyChanged(nameof(Index_time_short));
            }
        }


        public int Index_duration_short
        {
            get
            {
                return my_short_model[0].NumberDurationShort;
            }
            set
            {
                my_short_model[0].NumberDurationShort = value;
                OnPropertyChanged(nameof(Index_duration_short));
            }
        }

        #endregion is activ small timer

        #region is activ strict type

        public bool Is_strict_type
        {
            get
            {
                return my_big_model[0].StrictMode;
            }
            set
            {
                my_big_model[0].StrictMode = value;
                OnPropertyChanged(nameof(Is_strict_type));
            }
        }
        #endregion is activ strict type

        

        #region small timer
        Alert viewOne;
        Alert_View_Model view_modelOne;


        TimerCallback One_Callback;
        System.Threading.Timer One_timer;


        public string Time_timer_textbox
        {
            get
            {
                return my_ome_model[0].TimeBreakOne;
            }
            set
            {
                if (value.Length < 9)
                    my_ome_model[0].TimeBreakOne = Converts(value);
                OnPropertyChanged(nameof(Time_timer_textbox));
            }
        }


        public string Time_duration_textbox
        {
            get
            {
                return my_ome_model[0].DurationBreakOne;
            }
            set
            {
                if (value.Length < 9)
                    my_ome_model[0].DurationBreakOne = Converts(value);
                OnPropertyChanged(nameof(Time_duration_textbox));
            }
        }


        string Converts(string str)
        {
            int second = 0;

            int minutes = 0;

            int hours = 0;
            var list = str.Split(':');

            if (list[2][0] != '_')
            {

                var i = Convert.ToInt32(list[2][0].ToString()) * 10;

                if (i > 59)
                {
                    i = i - 60;
                    minutes++;

                }
                second += i;
            }

            if (list[2][1] != '_')
            {
                var i = Convert.ToInt32(list[2][1].ToString());
                second += i;

            }

            if (list[1][0] != '_')
            {
                var temp_m = Convert.ToInt32(list[1][0].ToString()) * 10;
                if (temp_m > 59)
                {
                    hours++;
                    temp_m = temp_m - 60;

                }
                minutes += temp_m;
            }

            if (list[1][1] != '_')
            {
                var temp_m = Convert.ToInt32(list[1][1].ToString());
                minutes += temp_m;
            }

            if (list[0][0] != '_')

                hours += Convert.ToInt32(list[0][0].ToString()) * 10;


            if (list[0][1] != '_')
                hours += Convert.ToInt32(list[0][1].ToString());
            if (hours > 24)
                hours = 24;


            var end_s = (second >= 10 ? second.ToString() : "_" + (second == 0 ? "_" : second.ToString()));
            var end_m = (minutes >= 10 ? minutes.ToString() : "_" + (minutes == 0 ? "_" : minutes.ToString()));
            var end_h = (hours >= 10 ? hours.ToString() : "_" + (hours == 0 ? "_" : hours.ToString()));

            return String.Format("{0}:{1}:{2}", end_h, end_m, end_s);
        }

        #endregion small timer

        #region is one timer


        public bool Is_Small
        {
            get
            {
                return my_ome_model[0].IsActiveOne;
            }
            set
            {
                try
                {
                    if (value)
                        OneTimes_D();
                    else

                        OneTimes_A();
                }
                catch (Exception ex)
                {
#if test
                    System.Windows.MessageBox.Show(ex.Message, "Ups...Is_Small");
#endif
                }

                my_ome_model[0].IsActiveOne = Set_Timer_one(value);
                OnPropertyChanged(nameof(Is_Small));
            }
        }

        #endregion is one timer

        #region Select_Index_Sound_type_timer
        int select_Index_Sound_type_timer = -1;
        public int Select_Index_Sound_type_timer
        {
            get
            {
                return select_Index_Sound_type_timer;
            }
            set
            {
                select_Index_Sound_type_timer = value;

                OnPropertyChanged(nameof(Select_Index_Sound_type_timer));
                OnPropertyChanged(nameof(Is_Activ_sound));
                OnPropertyChanged(nameof(Selected_Item_sound));
                OnPropertyChanged(nameof(Volum));
            }
        }

        #endregion Select_Index_Sound_type_timer

        #region is activ sound
        public bool Is_Activ_sound
        {
            get
            {
                if (select_Index_Sound_type_timer == 0)
                {
                    return my_big_model[0].IsActiveSound;
                }
                else if (select_Index_Sound_type_timer == 1)
                {
                    return my_short_model[0].IsSoundActive;
                }
                else if (select_Index_Sound_type_timer == 2)
                {
                    return my_ome_model[0].IsSoundActive;
                }


                return false;
            }
            set
            {
                if (select_Index_Sound_type_timer == 0)
                {
                    my_big_model[0].IsActiveSound = value;
                }
                else if (select_Index_Sound_type_timer == 1)
                {
                    my_short_model[0].IsSoundActive = value;
                }
                else if (select_Index_Sound_type_timer == 2)
                {
                    my_ome_model[0].IsSoundActive = value;
                }
                OnPropertyChanged(nameof(Is_Activ_sound));
            }
        }

        #endregion is activ sound

        #region Icon_Play

        string icon_play;

        public string Icon_Play
        {
            set
            {
                icon_play = value;
                OnPropertyChanged(nameof(Icon_Play));
            }
            get
            {
                return icon_play;
            }
        }

        #endregion Icon_Play


        #region Volum



        public int? Volum
        {
            set
            {

                if (select_Index_Sound_type_timer == 0)
                {
                   my_big_model[0].SoundVolume=value;
                  
                }
                else if (select_Index_Sound_type_timer == 1)
                {
                     my_short_model[0].SoundVolume = value;
                   
                }
                else if (select_Index_Sound_type_timer == 2)
                {
                     my_ome_model[0].SoundVolume = value;
                   
                }
              

                db.SaveChanges();
               
                OnPropertyChanged(nameof(Volum));
            }
            get
            {
                if (select_Index_Sound_type_timer == 0)
                {
                  
                    return my_big_model[0].SoundVolume;
                }
                else if (select_Index_Sound_type_timer == 1)
                {
                   
                    return my_short_model[0].SoundVolume;
                }
                else if (select_Index_Sound_type_timer == 2)
                {
                   
                    return my_ome_model[0].SoundVolume;
                }
               
                return 0;
            }
        }

        #endregion Volum

        #endregion Variables

        #region Function

        bool Set_Timer_big(bool i)
        {
            try
            {
                if (Index_time_big != -1 && Index_duration_big != -1 && i)
                {

                    if (big_timer != null)
                        big_timer.Change(System.Threading.Timeout.Infinite, 0);

                    int mitute_time = Get_minutes_type_big(Index_time_big);
                    int mitute_duration = Get_minutes_duration_big(Index_duration_big);


                    long mil = mitute_time * 60000;

                    AlertType my_alert = new AlertType() { time = mitute_duration, type = Type_alert.Big };


                    big_Callback = new TimerCallback(Alert_box);


#if test
                    big_timer = new System.Threading.Timer(big_Callback, my_alert, 0, mil);
#elif test_relise
                     big_timer = new System.Threading.Timer(big_Callback, my_alert, 0, mil);

#elif relise
                    big_timer = new System.Threading.Timer(big_Callback, my_alert, mil, mil);
#endif
                    return true;

                }
                else
                {
                    if (!i && big_timer != null)
                        big_timer.Change(System.Threading.Timeout.Infinite, 0);
                    return false;
                }
            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Set_Timer_big");
#endif
                return false;
            }

        }


        bool Set_Timer_short(bool i)
        {
            try
            {
                if (Index_time_short != -1 && Index_duration_short != -1 && i)
                {

                    if (short_timer != null)
                        short_timer.Dispose();

                    int mitute_time = Get_minutes_type_short(Index_time_short);
                    int seconde_duration = Get_seconds_duration_short(Index_duration_short);


                    long mil = mitute_time * 60000;

                    AlertType my_alert = new AlertType() { time = seconde_duration, type = Type_alert.Short };


                    short_Callback = new TimerCallback(Alert_box);

                    // создаем таймер
#if test
                    short_timer = new System.Threading.Timer(short_Callback, my_alert, 0, mil);
#elif test_relise
                      short_timer = new System.Threading.Timer(short_Callback, my_alert, 0, mil);
#elif relise
                    short_timer = new System.Threading.Timer(short_Callback, my_alert, mil, mil);
#endif
                    return true;

                }
                else
                {
                    if (!i && short_timer != null)
                        short_timer.Dispose();
                    return false;
                }
            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Set_Timer_short");
#endif
                return false;
            }
        }


        bool Set_Timer_one(bool i)
        {
            try
            {
                var times = DateTime.Parse(Time_timer_textbox.Replace('_', '0')).TimeOfDay;
                var duration = DateTime.Parse(Time_duration_textbox.Replace('_', '0')).TimeOfDay;

                if ((duration.Hours > 0 || duration.Minutes > 0 || duration.Seconds > 0) &&
                    (times.Hours > 0 || times.Minutes > 0 || times.Seconds > 0) && i)
                {

                    if (One_timer != null)
                        One_timer.Dispose();


                    int seconde_duration = duration.Hours * 60 * 60 + duration.Minutes * 60 + duration.Seconds;


                    long mil = times.Hours * 60 * 60000 + times.Minutes * 60000 + times.Seconds * 1000;

                    AlertType my_alert = new AlertType() { time = seconde_duration, type = Type_alert.One };


                    One_Callback = new TimerCallback(Alert_box);

                    // создаем таймер
#if test
                    One_timer = new System.Threading.Timer(One_Callback, my_alert, 0, mil);
#elif test_relise
                    One_timer = new System.Threading.Timer(One_Callback, my_alert, 0, mil);
#elif relise
                       One_timer = new System.Threading.Timer(One_Callback, my_alert, mil, mil);
#endif
                    return true;

                }
                else
                {
                    if (!i && One_timer != null)
                    {
                        One_timer.Dispose();

                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Ups...Set_Timer_one");
#endif
                return false;
            }
        }

        void DisposesOne()
        {
            One_timer.Dispose();
            Is_Small = false;

        }


        void Alert_box(object obj)
        {

            var temp = (AlertType)obj;

            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                if (temp.type == Type_alert.Big)
                {
                    viewBig = new Alert();
                    view_modelBig = new Alert_View_Model() { time_s = temp.time * 60, type = Type_alert.Big };

                    viewBig.StartBreakBig = new Action(view_modelBig.ActiveteTime);

                    viewBig.Deactiv_Style();
                    viewBig.Transareds();
                    viewBig.Center();


                    view_modelBig.Activate_OK = new Action(viewBig.Activ_OK);
                    view_modelBig.Deactivate_OK = new Action(viewBig.Deactiv_OK);
                    view_modelBig.Deactivate_OK();

                    view_modelBig.Activate_NEXT = new Action(viewBig.Activ_NEXT);
                    view_modelBig.Deactivate_NEXT = new Action(viewBig.Deactiv_NEXT);
                    view_modelBig.Deactivate_NEXT();

                    view_modelBig.Activate_CANCEL = new Action(viewBig.Activ_CANCEL);
                    view_modelBig.Deactivate_CANCEL = new Action(viewBig.Deactiv_CANCEL);
                    view_modelBig.Deactivate_CANCEL();

                    view_modelBig.Activate_CANCEL1 = new Action(viewBig.Activate_CANCEL_1);
                    view_modelBig.Deactivate_CANCEL1 = new Action(viewBig.Deactivate_CANCEL_1);
                    view_modelBig.Activate_CANCEL1();



                    view_modelBig.Activate_Info_small = new Action(viewBig.Activated_Small_info);
                    view_modelBig.Deactivate_Info_small = new Action(viewBig.Deactivated_Small_info);
                    view_modelBig.Text_info = dict["Alert_message_1_big"].ToString();


                    if (Is_strict_type)
                    {
                        view_modelBig.Deactivate_CANCEL1();
                    }


                    view_modelBig.Closenig = new Action(viewBig.Close);

                    viewBig.DataContext = view_modelBig;


                    viewBig.Show();

                    try
                    {
                        if (my_big_model[0].IsActiveSound && my_big_model[0].BigSoundId != -1)

                            MusicPath.Play(List_sound.Where(x => x.Id == my_big_model[0].BigSoundId).First().Path, my_big_model[0].SoundVolume);
                    }
                    catch (Exception ex)
                    {
#if test
                        System.Windows.MessageBox.Show(ex.Message, "Alert_box - my_big_model");
#endif
                    }
                }
                else if (temp.type == Type_alert.Short)
                {
                    viewShort = new Alert();
                    view_modelShort = new Alert_View_Model() { time_s = temp.time, type = Type_alert.Short };

                    viewShort.StartBreakBig = new Action(view_modelShort.ActiveteTime);

                    viewShort.Deactiv_Style();
                    viewShort.Center();

                    view_modelShort.Activate_OK = new Action(viewShort.Activ_OK);
                    view_modelShort.Deactivate_OK = new Action(viewShort.Deactiv_OK);
                    view_modelShort.Deactivate_OK();

                    view_modelShort.Activate_NEXT = new Action(viewShort.Activ_NEXT);
                    view_modelShort.Deactivate_NEXT = new Action(viewShort.Deactiv_NEXT);
                    view_modelShort.Deactivate_NEXT();

                    view_modelShort.Activate_CANCEL = new Action(viewShort.Activ_CANCEL);
                    view_modelShort.Deactivate_CANCEL = new Action(viewShort.Deactiv_CANCEL);
                    view_modelShort.Deactivate_CANCEL();

                    view_modelShort.Closenig = new Action(viewShort.Close);
                    view_modelShort.Text_info = dict["Alert_message_1"].ToString();

                    viewShort.DataContext = view_modelShort;
                    viewShort.Show();

                    try
                    {
                        if (my_short_model[0].IsSoundActive && my_short_model[0].ShortSoundId != -1)

                            MusicPath.Play(List_sound.Where(x => x.Id == my_short_model[0].ShortSoundId).First().Path, my_short_model[0].SoundVolume);
                    }
                    catch (Exception ex)
                    {
#if test
                        System.Windows.MessageBox.Show(ex.Message, "Alert_box - my_big_model");
#endif
                    }
                }
                if (temp.type == Type_alert.One)
                {
                    viewOne = new Alert();
                    view_modelOne = new Alert_View_Model() { time_s = temp.time, type = Type_alert.One };

                    viewOne.StartBreakBig = new Action(view_modelOne.ActiveteTime);

                    viewOne.Deactiv_Style();
                    viewOne.Center();


                    view_modelOne.Activate_OK = new Action(viewOne.Activ_OK);
                    view_modelOne.Deactivate_OK = new Action(viewOne.Deactiv_OK);
                    view_modelOne.Deactivate_OK();

                    view_modelOne.Activate_NEXT = new Action(viewOne.Activ_NEXT);
                    view_modelOne.Deactivate_NEXT = new Action(viewOne.Deactiv_NEXT);
                    view_modelOne.Deactivate_NEXT();

                    view_modelOne.Activate_CANCEL = new Action(viewOne.Activ_CANCEL);
                    view_modelOne.Deactivate_CANCEL = new Action(viewOne.Deactiv_CANCEL);


                    view_modelOne.Closenig = new Action(viewOne.Close);
                    view_modelOne.Disposes = new Action(DisposesOne);
                    view_modelOne.Text_info = dict["Alert_message_1"].ToString();
                    viewOne.DataContext = view_modelOne;
                    try
                    {
                        if (my_ome_model[0].IsSoundActive && my_ome_model[0].OneSoundId != -1)
                            if (Selected_Item_sound != null)
                                MusicPath.Play(List_sound.Where(x => x.Id == my_ome_model[0].OneSoundId).First().Path, my_ome_model[0].SoundVolume);
                    }
                    catch (Exception ex)
                    {
#if test
                        System.Windows.MessageBox.Show(ex.Message, "Alert_box - my_big_model");
#endif
                    }
                    One_timer.Change(System.Threading.Timeout.Infinite, 0);
                    Is_Small = false;
                    viewOne.Show();


                }



            });
        }




        #endregion Function

        #region List

        #region sesion

        ObservableCollection<OneTimeBreakModel> my_ome_model { set; get; }

        ObservableCollection<ShortBreakModel> my_short_model { set; get; }

        ObservableCollection<BigBreakModel> my_big_model { set; get; }

        #endregion sesion

        #region Sound list

        //List<Sound> list_sounds;



        public ObservableCollection<Sound> List_sound
        {
            get;
            set;
        }


        public Sound Selected_Item_sound
        {
            get
            {
                if (select_Index_Sound_type_timer == 0)
                {
                    var i = List_sound.Where(x => x.Id == my_big_model[0].BigSoundId);
                    if (i != null && i.Count() > 0)
                    {
                        return i.First();
                    }


                }
                else if (select_Index_Sound_type_timer == 1)
                {
                    var i = List_sound.Where(x => x.Id == my_short_model[0].ShortSoundId);
                    if (i != null && i.Count() > 0)
                    {
                        return i.First();
                    }


                }
                else if (select_Index_Sound_type_timer == 2)
                {
                    var i = List_sound.Where(x => x.Id == my_ome_model[0].OneSoundId);
                    if (i != null && i.Count() > 0)
                    {
                        return i.First();
                    }


                }
                if(List_sound.Count>0)
                return List_sound[0];
                return null;
               // return new Sound();
            }
            set
            {

                if (select_Index_Sound_type_timer == 0)
                {
                    if (value != null)
                        my_big_model[0].BigSoundId = value.Id;
                    else
                        my_big_model[0].BigSoundId = -1;



                }
                else if (select_Index_Sound_type_timer == 1)
                {
                    if (value != null)
                        my_short_model[0].ShortSoundId = value.Id;
                    else
                        my_short_model[0].ShortSoundId = -1;

                }
                else if (select_Index_Sound_type_timer == 2)
                {
                    if (value != null)
                        my_ome_model[0].OneSoundId = value.Id;
                    else
                        my_ome_model[0].OneSoundId = -1;

                }
                db.SaveChanges();

                OnPropertyChanged(nameof(Selected_Item_sound));
            }
        }

        void Check_Path()
        {
            List_sound.ToList().ForEach(
              x =>
              {
                  string path = x.Path;
                  FileInfo fileInf = new FileInfo(path);
                  if (!fileInf.Exists)
                  {
                      List_sound.Remove(x);
                      db.Sounds.Remove(x);


                      if (my_big_model[0].BigSoundId == x.Id)
                          my_big_model[0].BigSoundId = -1;
                      if (my_short_model[0].ShortSoundId == x.Id)
                          my_short_model[0].ShortSoundId = -1;
                      if (my_ome_model[0].OneSoundId == x.Id)
                          my_ome_model[0].OneSoundId = -1;

                  }
              }
              );
            db.SaveChanges();
        }

        #endregion Sound list


        #endregion List

        #region Command

        #region path
        private DelegateCommand _Command_path;
        public ICommand Button_clik_path
        {
            get
            {
                if (_Command_path == null)
                {
                    _Command_path = new DelegateCommand(Execute_path, CanExecute_path);
                }
                return _Command_path;
            }
        }
        private void Execute_path(object o)
        {

            var list_sound_temp = MusicPath.Get_Paths();
            if (list_sound_temp != null && list_sound_temp.Count > 0)
                list_sound_temp.ForEach(x => List_sound.Add(new Sound() { Path = x, Name = Path.GetFileName(x) }));

            SaveSoundTimer();
        }
        private bool CanExecute_path(object o)
        {


            return true;
        }
        #endregion path



        #region Play_music
        bool is_play = true;




        private DelegateCommand _Command_Play_music;
        public ICommand Button_clik_Play_music
        {
            get
            {
                if (_Command_Play_music == null)
                {
                    _Command_Play_music = new DelegateCommand(Execute_Play_music, CanExecute_Play_music);
                }
                return _Command_Play_music;
            }
        }
        private void Execute_Play_music(object o)
        {
            if(is_play)
            {
                is_play = !is_play;
                Icon_Play = "PlayCircle";




                MusicPath.Play(Selected_Item_sound.Path, Volum);
            }
            else
            {
                is_play = !is_play;
                Icon_Play = "PlayCircleOutline";
                MusicPath.Stop();
            }


        }
        private bool CanExecute_Play_music(object o)
        {
            if(Selected_Item_sound != null)
            {
                return true;
            }
            return false;

        }
        #endregion Play_music

        #endregion Command

        #region Action

        public Action Short_A;
        public Action Short_D;

        public Action OneTimes_A;
        public Action OneTimes_D;

        public Action BigT_A;
        public Action BigT_D;


        #endregion Action

        #endregion Timer


        #region filter

        #region List
        #region Red
        public ObservableCollection<RedSite> Red
        { get; set; }
        //public List<RedSite> list_RSite
        //{ get; set; }
        #endregion Red


        #region grean
        public ObservableCollection<GreanSite> Grean
        { get; set; }
        //public List<GreanSite> list_GSite
        //{ get; set; }


        GreanSite _Selected_Grean = null;

        public GreanSite Selected_Grean
        {
            get { return _Selected_Grean; }
            set
            {
                _Selected_Grean = value;
                OnPropertyChanged(nameof(Selected_Grean));
            }
        }
        #endregion grean


        #region statistic
        public ObservableCollection<StatisticSite> StatisticSite
        { get; set; }
        public List<StatisticSite> list_StatisticSite
        { get; set; }

        #endregion statistic


        #region Test
        public ObservableCollection<Test_Element> Test_list
        { get; set; }
        public List<Test_Element> list_Test_list
        { get; set; }

        #endregion Test

        #endregion List

        #region pole

        string _last_url = "";

        string _name_title;
        public string name_title
        {
            set
            {
                _name_title = value;
                OnPropertyChanged(nameof(name_title));
            }
            get
            {
                return _name_title;
            }
        }

        string _temp_url;

        #region Date

        List<DateTime> my_dates = new List<DateTime>();

        string date_statistic_title = "";
        public string Date_statistic_title
        {
            set
            {


                date_statistic_title = value;

                OnPropertyChanged(nameof(Date_statistic_title));
            }
            get
            {
                return date_statistic_title;
            }
        }


        DateTime date_statistic = DateTime.Now;
        public DateTime Date_statistic
        {
            set
            {


                date_statistic = value;


                OnPropertyChanged(nameof(Date_statistic));
            }
            get
            {
                return date_statistic;
            }
        }
        #endregion Date

        #endregion

        #region site
        #region Hoot
        public void Modefine_string(string i)
        {
            if (Selected_Grean != null)
            {
                Selected_Grean.Hootkey = i;
                OnPropertyChanged(nameof(Selected_Grean));
            }

        }

        public void Hoot_keys(string i)
        {
            if (i != null)
            {

                Grean.ToList().ForEach(x =>
                {
                    if (x.Hootkey.CompareTo(i) == 0)
                    {
                        Site_opening.Open(x.URL);
                    }

                });
            }


        }
        #endregion Hoot

        #region statistic

        public void Update_range_date(List<DateTime> i)
        {
            try { 
            my_dates = i;

            Date_statistic_title = my_dates.First() != null ?
               (my_dates.First().ToString().Split(' ')[0] + (
               my_dates.Count > 1 ?
              "-" + my_dates[my_dates.Count - 1].ToString().Split(' ')[0]
               : " "))
               : " ";

            Set_List_Statistic();
            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Update_range_date");
#endif
            }
        }

        private void Set_List_Statistic()
        {
            try
            {
                var lits_temp = db.StatisticSites.ToList();
            List<StatisticSite> list = new List<Time.StatisticSite>();
            var start = (my_dates.First());

            if (start != null)
            {



                var end = (my_dates[my_dates.Count - 1]);


                if (end != start)
                {

                    if (start > end)
                    {
                        var temp = DateTime.Parse(start.ToString());
                        start = end;
                        end = temp;
                    }

                    for (var i = 0; i < lits_temp.Count; i++)
                    {
                        if (DateTime.Parse(lits_temp[i].Time.Split(' ')[0]) >= DateTime.Parse(start.ToString().Split(' ')[0])
                            && DateTime.Parse(lits_temp[i].Time.Split(' ')[0]) <= DateTime.Parse(end.ToString().Split(' ')[0]))
                        {
                            list.Add(lits_temp[i]);
                        }
                    }


                }
                else
                {
                    for (var i = 0; i < lits_temp.Count; i++)
                    {
                        if (DateTime.Parse(lits_temp[i].Time.Split(' ')[0]) <= DateTime.Parse(end.ToString().Split(' ')[0]))
                        {
                            list.Add(lits_temp[i]);
                        }
                    }
                }

            }


            if (list.ToList().Count > 0)
            {
                list_StatisticSite = list.ToList();
                StatisticSite = new ObservableCollection<Time.StatisticSite>(list_StatisticSite);

            }
            else
            {
                list_StatisticSite = new List<StatisticSite>();
                StatisticSite = new ObservableCollection<Time.StatisticSite>(list_StatisticSite);

            }
            OnPropertyChanged(nameof(StatisticSite));
            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Set_List_Statistic");
#endif
            }
        }

        private async void Statistic_procces()
        {
            await Task.Run(() => {
                try
                {
                  
                    name_title = _my_form.GetActiveWindowTitle();

              
                    _temp_url = SiteBloc.GetURL(name_title);
                    if (_temp_url != null && _last_url != _temp_url)
                    {
                        _last_url = _temp_url;
                        Add_statistic(_temp_url);
                    }
                }
                catch (Exception ex)
                {
#if test_1
                    System.Windows.MessageBox.Show(ex.Message , "Statistic_procces");
#endif
                }
            });

        }

        string Get_status(string url)
        {

            int len = Grean.ToList().Count;
            for (int i = 0; i < len; i++)
            {

                if (url.IndexOf(Grean[i].URL) != -1)
                {
                    return "Green";
                }
            }

            len = Red.ToList().Count;
            for (int i = 0; i < len; i++)
            {
                if (url.IndexOf(Red[i].URL) != -1)
                {
                    return "Red";
                }
            }

            return "Yellow";
        }

        void Add_statistic(string url)
        {
           


                var temp = new StatisticSite();
                temp.Status = Get_status(url);

                temp.URL = url;
                temp.Time = DateTime.Now.ToString();

                if (temp.Status.CompareTo("Grean") == 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                    {
                        int numb = Grean.ToList().FindIndex(x => url.IndexOf(x.URL) != -1);
                        temp.Name = Grean.ToList()[numb].Name;
                    });
                }
                else if (temp.Status.CompareTo("Red") == 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                    {
                        int numb = Red.ToList().FindIndex(x => url.IndexOf(x.URL) != -1);

                        Alert_Red_Site(Red.ToList()[numb].Name);

                        temp.Name = Red.ToList()[numb].Name;
                    });
                }
                else
                {
                    temp.Name = name_title;
                }
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    StatisticSite.Add(temp);
                    Test_list.Add(new Test_Element() { Name = name_title });
                    OnPropertyChanged(nameof(StatisticSite));
                    SaveStatisticSite();
                });
            
        }


        #endregion statistic



        async void Alert_Red_Site(string name)
        {

            await Task.Run(() => {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    ShowMessage(name + " " + dict["Message_text"].ToString());
                });
            });
            /*MessageBox.Show( dict["Message_text"].ToString()+name, dict["Message_title"].ToString())*/
        }

        public void Set_Edit_Site(bool i)
        {

            SaveRed();
        }

        #endregion site

        #region Command

        #region _Command_print
        private DelegateCommand _Command_print;
        public ICommand Button_clik_print
        {
            get
            {
                if (_Command_print == null)
                {
                    _Command_print = new DelegateCommand(Execute_print, CanExecute_print);
                }
                return _Command_print;
            }
        }
        private void Execute_print(object o)
        {

            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Вспомогательные действия для извлечения таблицы
                // из XML-файла, используя ADO.NET


                StoreDataSetPaginator paginator = new StoreDataSetPaginator(StatisticSite.ToList(),
                    new Typeface("Calibri"), 24, 96 * 0.75,
                    new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));

                printDialog.PrintDocument(paginator, "Печать с помощью классов визуального уровня");
            }
        }
        private bool CanExecute_print(object o)
        {
            return true;
        }
        #endregion _Command_print


        #region Delete_Statistic

        public void Delete_Statistic(List<StatisticSite> element)
        {
            //    db.StatisticSites.ToList().ForEach(x => db.StatisticSites.Remove(x));


            if (ShowMessage(dict["Alert_message_delete"].ToString()))
            {
                Delete_elements_statistic(element);
            }

        }


        void Delete_elements_statistic(List<StatisticSite> element)
        {
            element.ForEach(x =>
            {
                StatisticSite.Remove(x);
                db.StatisticSites.Remove(x);
                OnPropertyChanged(nameof(StatisticSite));
            });
            db.SaveChanges();
        }
        #endregion Delete_Statistic

        #region Delete_Sound

        public void Delete_Sound(List<Sound> element)
        {
            //    db.StatisticSites.ToList().ForEach(x => db.StatisticSites.Remove(x));


            if (ShowMessage(dict["Alert_message_delete"].ToString()))
            {
                Delete_elements_sound(element);
            }

        }


        void Delete_elements_sound(List<Sound> element)
        {
            element.ForEach(x =>
            {
                try
                {
                    List_sound.Remove(x);
                    db.Sounds.Remove(x);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Delete_elements_sound");
                }
                OnPropertyChanged(nameof(List_sound));
            });
            db.SaveChanges();
        }
        #endregion Delete_Sound

        #region Delete_Grean

        public void Delete_Grean(List<GreanSite> element)
        {
            //    db.StatisticSites.ToList().ForEach(x => db.StatisticSites.Remove(x));


            if (ShowMessage(dict["Alert_message_delete"].ToString()))
            {
                Delete_elements_grean(element);
            }

        }


        void Delete_elements_grean(List<GreanSite> element)
        {
            element.ForEach(x =>
            {
                Grean.Remove(x);
                db.GreanSites.Remove(x);
                OnPropertyChanged(nameof(Grean));
            });
            db.SaveChanges();
        }
        #endregion Delete_Grean

        #region Delete_Red

        public void Delete_Red(List<RedSite> element)
        {
            //    db.StatisticSites.ToList().ForEach(x => db.StatisticSites.Remove(x));



            if (ShowMessage(dict["Alert_message_delete"].ToString()))
            {
                Delete_elements_red(element);
            }

        }


        bool ShowMessage(string info)
        {
            Alert message = new Alert();
            message.type = Type_alert.Message;
            Alert_View_Model message_model = new Alert_View_Model() { type = Type_alert.Message };
            message_model.Closenig = new Action(message.Close);
            message.Activated_message_style();
            message_model.Text_info = info;
            message.DataContext = message_model;
            message.ShowDialog();
            return message_model.Message_result;
        }

        void Delete_elements_red(List<RedSite> element)
        {
            element.ForEach(x =>
            {
                Red.Remove(x);
                db.RedSites.Remove(x);
                OnPropertyChanged(nameof(Grean));
            });
            db.SaveChanges();
        }
        #endregion Delete_Red


        #region Add_Grean

        public void Add_Grean()
        {



            Add_elements_Grean();


        }


        void Add_elements_Grean()
        {
            var i = Grean;

            SaveGrean();
        }
        #endregion Add_Grean



        #endregion Command


        #endregion filter 

        #region Settings

        bool auto_start;
        public bool Auto_start
        {
            get
            {
                return auto_start;
            }
            set
            {

                RegistryKey saveKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);


                if (value || (value == false && saveKey.GetValue("Time") != null))
                {

                    saveKey.SetValue("Time", System.Windows.Forms.Application.ExecutablePath);
                    saveKey.Close();


                    //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    //string i = System.Windows.Forms.Application.ExecutablePath;
                    //key.SetValue("Time", System.Windows.Forms.Application.ExecutablePath);
                    auto_start = true;
                }
                else
                {

                    // var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    if (saveKey.GetValue("Time") != null)
                    {
                        saveKey.DeleteValue("Time");
                        auto_start = value;
                    }


                }





                OnPropertyChanged(nameof(Auto_start));
            }
        }

        #endregion

        #region Event 



        #region Login
        GoogleAPI my_google=new GoogleAPI();
        #endregion Login

        #region Calendar event
      

        string login = "";
        public string Logins
        {
            get { return login; }
            set { login = value; OnPropertyChanged(nameof(Logins)); }
        }
        #endregion Calendar event

        #region function

        private void Open_window_add_event()
        {
          
                try
                {
                   
                        Add_event view_add = new Add_event();

                        Add_Event_View_Model view_model = new Add_Event_View_Model();

                        view_add.DataContext = view_model;

                        view_model.close = new Action(view_add.Close);
                        view_model.Date_select += new Interface._Date_select(view_add.SelectDate);
                        view_model.dict = dict;



                        view_add.ShowDialog();
                    
                        if (!view_model.is_close)
                            my_google.Add_event(view_model.All_day, view_model.Summary, view_model.Location, view_model.Description, view_model.Start_date, view_model.End_date);
                  
                }
                catch (Exception ex)
                {
#if test
                    System.Windows.MessageBox.Show(ex.Message , "Open_window_add_event");
#endif
                }
           

        }


        private void Open_window_edit_event()
        {

            try
            {

                Add_event view_add = new Add_event();

                Add_Event_View_Model view_model = new Add_Event_View_Model();

                view_add.EditWindow(Add_Event_View_Model_type.Edit);
                view_model.my_type = Add_Event_View_Model_type.Edit;
                view_model.End_date = my_google.GetEvent(selectedItemEvent.Id).End.DateTime;
                view_model.Start_date = my_google.GetEvent(selectedItemEvent.Id).Start.DateTime;
                view_model.Summary = selectedItemEvent.Summary;
                view_model.Description =selectedItemEvent.Description;
                view_model.Location = selectedItemEvent.Location;
                view_model.All_day = selectedItemEvent.IsAll;

                view_add.DataContext = view_model;

                view_model.close = new Action(view_add.Close);
                view_model.Date_select += new Interface._Date_select(view_add.SelectDate);
                view_model.dict = dict;



                view_add.ShowDialog();

                if (!view_model.is_close)
                    my_google.Add_event(view_model.All_day, view_model.Summary, view_model.Location, view_model.Description, view_model.Start_date, view_model.End_date);

            }
            catch (Exception ex)
            {
#if test
                System.Windows.MessageBox.Show(ex.Message, "Open_window_add_event");
#endif
            }


        }
        #endregion function 


        #region list event


        public ObservableCollection<NowDate> My_list { get; set; }

        NowDate selectedItemEvent = null;
        public NowDate SelectedItemEvent
        {
            set
            {
                selectedItemEvent = value;
                OnPropertyChanged(nameof(SelectedItemEvent));
            }
            get
            {
                return selectedItemEvent;
            }
        }

        DateTime selected_date = DateTime.Now;
        public DateTime Selected_date
        {
            get
            {
                return selected_date;
            }
            set
            {
                My_list.Clear();
                selected_date = value;           
                My_list = my_google.Set_events(10.ToString(), selected_date, out login);
                OnPropertyChanged(nameof(Logins));
                OnPropertyChanged(nameof(My_list));
                OnPropertyChanged(nameof(Selected_date));
            }
        }
        #endregion list event

        #region Button_click_add_event

        private DelegateCommand _Command_add_event;
        public ICommand Button_click_add_event
        {
            get
            {
                if (_Command_add_event == null)
                {
                    _Command_add_event = new DelegateCommand(Execute_add_event, CanExecute_add_event);
                }
                return _Command_add_event;
            }
        }
        private void Execute_add_event(object o)
        {

            Open_window_add_event();

        }
        private bool CanExecute_add_event(object o)
        {
            return true;
        }

        #endregion  Button_click_add_event
        #region Button_click_edit_event

        private DelegateCommand _Command_edit_event;
        public ICommand Button_click_edit_event
        {
            get
            {
                if (_Command_edit_event == null)
                {
                    _Command_edit_event = new DelegateCommand(Execute_edit_event, CanExecute_edit_event);
                }
                return _Command_edit_event;
            }
        }
        private void Execute_edit_event(object o)
        {

            Open_window_edit_event();

        }
        private bool CanExecute_edit_event(object o)
        {
            return true;
        }

        #endregion  Button_click_edit_event
        #region _Command_sing_in


        private DelegateCommand _Command_sing_in;
        public ICommand Button_clik_sing_in
        {
            get
            {
                if (_Command_sing_in == null)
                {
                    _Command_sing_in = new DelegateCommand(Execute_sing_in, CanExecute_sing_in);
                }
                return _Command_sing_in;
            }
        }
        private void Execute_sing_in(object o)
        {
            my_google.Login();

            My_list = my_google.Set_events(10.ToString(), DateTime.Now,out login);
            OnPropertyChanged(nameof(Logins));
            OnPropertyChanged(nameof(My_list));
        }
        private bool CanExecute_sing_in(object o)
        {
            return true;
        }
        #endregion _Command_sing_in
        #endregion Event

    }
}
