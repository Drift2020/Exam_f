using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Time.Model;
using Time.View;
using Time.View_model;

namespace Time.Code
{
    public class Events_Timer
    {
        int count=0;
        void ShowMessage(string info)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                Alert message = new Alert();
                message.type = Type_alert.Message;
                Alert_View_Model message_model = new Alert_View_Model() { type = Type_alert.Message };
                message_model.Closenig = new Action(message.Close);
                message.Activated_message_style();
                message_model.Text_info = info;
                message.DataContext = message_model;
              
            });
            
        }
        public List<NowDate> _now_Date { get; set; }

        public void CheckEvent(Object source, ElapsedEventArgs e)
        {
           
            var elem = DateTime.Now;
            for (int i = 0; i < _now_Date.Count ; i++)
               



                {
                    count++;
                    if (_now_Date[i].TimeStart!=null &&
                    elem.Hour== _now_Date[i].TimeStart.Value.Hour && 
                    elem.Minute == _now_Date[i].TimeStart.Value.Minute)
                    {
                       
                        ShowMessage(_now_Date[i].Summary + "|" + _now_Date[i].Location + "|" + _now_Date[i].Description);
                        _now_Date.RemoveAt(i);
                     i--;
                    }
                }
        }
    }
}
