using MahApps.Metro.Controls;
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
using Time.Code;

namespace Time.View
{
    /// <summary>
    /// Interaction logic for Alert.xaml
    /// </summary>
    public partial class Alert : Window
    {
        TopWindow _top_windows = new TopWindow();
        public Alert()
        {
            InitializeComponent();
        }

      public  Action StartBreakBig;
        public Type_alert type;
        private void MetroWindow_Activated(object sender, EventArgs e)
        {
         
        }

        #region CANCEL_1
        public void Activate_CANCEL_1()
        {
            Alert_button_cancel1.Visibility = Visibility.Visible;
        }
        public void Deactivate_CANCEL_1()
        {
            Alert_button_cancel1.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region OK
        public void Activ_OK()
        {
            Alert_button_ok.Visibility = Visibility.Visible;
        }
        public void Deactiv_OK()
        {
            Alert_button_ok.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region NEXT
        public void Activ_NEXT()
        {
            Alert_button_next.Visibility = Visibility.Visible;
        }
        public void Deactiv_NEXT()
        {
            Alert_button_next.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Cancel
        public void Activ_CANCEL()
        {
            Alert_button_cancel.Visibility = Visibility.Visible;
        }
        public void Deactiv_CANCEL()
        {
            Alert_button_cancel.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Style window
        public void Activ_Style()
        {
            GWindow.WindowStyle = WindowStyle.ToolWindow;
        }

        public void Deactiv_Style()
        {
            GWindow.WindowStyle = WindowStyle.None;
        }
        #endregion


        #region Info small
        public void Activated_Small_info()
        {
            Info.Visibility = Visibility.Visible;
        }
        public void Deactivated_Small_info()
        {
            Info.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region  window
        public void Center()
        {
            double screenHeight = SystemParameters.FullPrimaryScreenHeight + 70;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
        }

        public void Transareds()
        {
            GWindow.AllowsTransparency = true;
           // GWindow.Background = new SolidColorBrush(Colors.Transparent);
            this.Height = SystemParameters.FullPrimaryScreenHeight + 70;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Opacity = 0.8;
            this.Info.FontSize = 48;
            this.Time.FontSize = 48;
            this.title.FontSize = 28;
            this.Alert_button_cancel1.Opacity = 2.0;
        }


        public void Activated_message_style()
        {
            Alert_button_next.Visibility = Visibility.Collapsed;
          
            Time.Visibility = Visibility.Collapsed;
            Alert_button_cancel.Visibility = Visibility.Collapsed;
            Alert_button_ok.Visibility = Visibility.Collapsed;
            
            Alert_button_ok1.Visibility = Visibility.Visible;
        }
        #endregion

        private void GWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (type != Type_alert.Message)
            {
                _top_windows.Top_Window("Alert");
                _top_windows.Top_All_Window("Alert");
                StartBreakBig();
            }
           
        }
    }
}
