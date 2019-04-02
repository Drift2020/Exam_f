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

        void ShowMessage(string name, string description, string location)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                Event_show message = new Event_show();
               
                Event_Alert_View_Model message_model = new Event_Alert_View_Model();          
              
                message_model.Location = location;
                message_model.Name = name;
                message_model.Description = description;
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

                    //ShowMessage(dict["Sites_list_Summary"].ToString(),
                    //    _now_Date[i].Summary,
                    //    dict["Sites_list_Location"].ToString(),
                    //    _now_Date[i].Location,
                    //    dict["Sites_list_Description"].ToString(), 
                    //    _now_Date[i].Description));



                    ShowMessage(
                        _now_Date[i].Summary,
                     
                        _now_Date[i].Location,
                        
                        _now_Date[i].Description);
            _now_Date.RemoveAt(i);
                     i--;
                    }
                }
        }
    }
}
