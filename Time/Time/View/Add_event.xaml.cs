﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Time.View
{
    public enum Add_Event_View_Model_type { Create = 0, Edit }
    /// <summary>
    /// Interaction logic for Add_event.xaml
    /// </summary>
    public partial class Add_event : Window
    {
     
        public Add_event()
        {
            InitializeComponent();
        }

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if(IsCheck.IsChecked==true)
            {
                EndDate.IsEnabled = false;
            }
          else
            {
                EndDate.IsEnabled = true;
            }
        }

        public void EditWindow(Add_Event_View_Model_type i)
        {


            switch (i)
            {
                case Add_Event_View_Model_type.Create:
                    {
                        editB.Visibility = Visibility.Collapsed;
                    }
                    break;
                case Add_Event_View_Model_type.Edit:
                    {
                        createB.Visibility = Visibility.Collapsed;
                    }
                    break;
            }


         
        }

        public void SelectDate(DateTime? i)
        {
            
           


            EndDate.DisplayDateStart = i;

            EndDate.SelectedDate = i;
        }
       
    }
}
