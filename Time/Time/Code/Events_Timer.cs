using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Model;
using Time.View;
using Time.View_model;

namespace Time.Code
{
    public class Events_Timer
    {
        void ShowMessage(string info)
        {
            Alert message = new Alert();
            message.type = Type_alert.Message;
            Alert_View_Model message_model = new Alert_View_Model() { type = Type_alert.Message };
            message_model.Closenig = new Action(message.Close);
            message.Activated_message_style();
            message_model.Text_info = info;
            message.DataContext = message_model;
            message.Show();
            
        }
        public List<NowDate> _now_Date { get; set; }

        public void CheckEvent(Object stateInfo)
        {

            _now_Date.ForEach(
                x =>
                {
                    var i = DateTime.Now;
                    if (x.TimeStart!=null && 
                    i.Hour== x.TimeStart.Value.Hour && i.Minute == x.TimeStart.Value.Minute)
                    {
                        ShowMessage(x.Summary + "|" + x.Location + "|" + x.Description);
                    }
                });
        }
    }
}
