﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Code
{
   public enum Type_alert { Big,Short,One,Message}
    public class AlertType
    {

        public int time { set; get; }
        public Type_alert type { set; get; }
    }
}
