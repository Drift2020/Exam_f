#define test
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Time.Code;
using Time.Interface;


using Time.View_model;

namespace Time
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISet_Language
    {
        static App my_this;

        private static List<CultureInfo> m_Languages = new List<CultureInfo>();
        public event Set_Language set_Language_;
        public static List<CultureInfo> Languages
        {
            get
            {
                return m_Languages;
            }
        }

        public App()
        {
            try
            {

          
            my_this = this;
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;

            App.LanguageChanged += App_LanguageChanged;
            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en-US")); //Нейтральная культура для этого проекта
            m_Languages.Add(new CultureInfo("ru-RU"));
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        #region language
        public static event EventHandler LanguageChanged;

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                try { 
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                //1. Меняем язык приложения:
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //2. Создаём ResourceDictionary для новой культуры
                ResourceDictionary dict = new ResourceDictionary();

                my_this.set_Language_.Invoke(value.Name);

                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                //3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                                              select d).First();

                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
                LanguageChanged(Application.Current, new EventArgs());
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                }
            }
        }

        private void App_LanguageChanged(Object sender, EventArgs e)
        {
            try { 
            Time.Properties.Settings.Default.DefaultLanguage = Language;
            Time.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            } 
        }
        #endregion language


        globalKeyboardHook KListener;
        //  My_form _my_fomr;


        private void Application_Startup(object sender, StartupEventArgs e)
        {
                        

            try
            {
                MainWindow view = new MainWindow();
                ApplicationContext myLite = new ApplicationContext();

                Index_View_Model viewModel = new Index_View_Model(myLite);



                view.DataContext = viewModel;

                view.closing = new Action(viewModel.Closing);

                KListener = new globalKeyboardHook();


                view.Is_enter_hootkey += new Is_Enter_hootkey(KListener.Is_edit_Cell);

                view.Update_select_dates += new Interface.Update_Select_Dates(viewModel.Update_range_date);
                view.statistic_site_edit_add_delete += new _Statistic_site_edit_add_delete(viewModel.Delete_Statistic);

                view.sound_edit_add_delete += new _Sound_edit_add_delete(viewModel.Delete_Sound);

                view.greanSite_edit_add_delete += new _GreanSite_edit_add_delete(viewModel.Delete_Grean);
                view.Grean_add += new _Grean_add(viewModel.Add_Grean);

                view.red_site_add_or_edit += new Red_site_add_or_edit(viewModel.Set_Edit_Site);
                view.red_site_delete += new _RedSite_delete(viewModel.Delete_Red);



                view.index_cell += new Index_Cell(KListener.Set_index_cell);
                KListener.hoot_Keys += new Hoot_Keys(viewModel.Hoot_keys);
                KListener._Modifine_string += new Modifine_String(viewModel.Modefine_string);


                viewModel.BigT_A = new Action(view.BigT_A);
                viewModel.BigT_D = new Action(view.BigT_D);

                viewModel.Short_A = new Action(view.Short_A);
                viewModel.Short_D = new Action(view.Short_D);

                viewModel.OneTimes_A = new Action(view.OneTimes_A);
                viewModel.OneTimes_D = new Action(view.OneTimes_D);
                view.view_model_up = new Action(viewModel.View_model_up);

                set_Language_ += new Set_Language(viewModel.Set_Language);

                set_Language_.Invoke("en-US");
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
#if test



                System.Windows.MessageBox.Show(ex.Message);
#endif
            }

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                KListener.unhook();
                m_Languages.Clear();
                PresentationTraceSources.DataBindingSource.Listeners.Clear();
            }catch(Exception ex)
            {
                Log.Write(ex);
            }
        }
    }
}
