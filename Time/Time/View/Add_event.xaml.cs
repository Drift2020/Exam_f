using System;
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

       

      public void SelectDate(DateTime? i)
        {
            
           


            EndDate.DisplayDateStart = i;

            EndDate.SelectedDate = i;
        }
       
    }
}
