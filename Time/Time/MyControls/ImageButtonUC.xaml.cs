using Time.Code;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ImageButtonUC.xaml
    /// </summary>
    public partial class ImageButtonUC : UserControl
    {
        public event RoutedEventHandler Click;


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ImageButtonUC));

        public ImageButtonUC()
        {
            InitializeComponent();

        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(ImageButtonUC), new UIPropertyMetadata(""));



        public object Image
        {
            get { return (object)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
           DependencyProperty.Register("Image", typeof(object), typeof(ImageButtonUC), new UIPropertyMetadata(""));




        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (null != Click)

                Click(sender, e);

        }


   

      

    }
}
