using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Time.Model;
using Time.View;
using Time.View_model;

namespace Time.Code
{
    public class Events_Timer
    {
       public ResourceDictionary dict { set; get; }
        public Events_Timer(ResourceDictionary _dict)
        {
            dict = _dict;
        }

        void ShowMessage(string info)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                Alert message = new Alert();
                message.type = Type_alert.Message;
                Alert_View_Model message_model = new Alert_View_Model() { type = Type_alert.Message };
                message_model.Closenig = new Action(message.Close);
                message.Activated_message_style_2();
                message_model.Text_info = info;
                message.DataContext = message_model;
                message.Show();
            });
            
        }
        public List<NowDate> _now_Date { get; set; }

        public void CheckEvent(Object source, ElapsedEventArgs e)
        {
           
            var elem = DateTime.Now;
            for (int i = 0; i < _now_Date.Count ; i++)
                {                  
                    if (_now_Date[i].TimeStart!=null &&
                    elem.Hour== _now_Date[i].TimeStart.Value.Hour && 
                    elem.Minute == _now_Date[i].TimeStart.Value.Minute)
                    {
                   
                        ShowMessage(String.Format("{0}: {1}\n{2}: {3}\n{4}: {5}", dict["Sites_list_Summary"].ToString(),
                            _now_Date[i].Summary,
                            dict["Sites_list_Location"].ToString(),
                            _now_Date[i].Location,
                            dict["Sites_list_Description"].ToString(), 
                            _now_Date[i].Description));
                        _now_Date.RemoveAt(i);
                     i--;
                    }
                }
        }
    }
}
