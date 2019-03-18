#define test
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Globalization;
using Time.Interface;
using Time.View_model;
using System.Data;
using System.Collections;
using Time.ModelSQLite;
using Time.Code;
using System.Drawing;

namespace Time
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>




    public partial class MainWindow : MetroWindow, Index_cell, Is_enter_hootkey,
        IUpdate_Select_Dates, IRed_site_add_or_edit, IStatistic_site_edit_add_delete,
        ISound_edit_add_delete, IGrean_add, IGreanSite_edit_add_delete, IRedSite_delete
    {
        public Action closing;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        public event Index_Cell index_cell;

        public event Is_Enter_hootkey Is_enter_hootkey;
        public event Update_Select_Dates Update_select_dates;
        public event Red_site_add_or_edit red_site_add_or_edit;
        public event _Statistic_site_edit_add_delete statistic_site_edit_add_delete;
        public event _Sound_edit_add_delete sound_edit_add_delete;
        public event _Grean_add Grean_add;
        public event _GreanSite_edit_add_delete greanSite_edit_add_delete;
        public event _RedSite_delete red_site_delete;

        
      
        private System.Windows.Forms.ContextMenu contextMenu1;//это само контекстное меню
        private System.Windows.Forms.MenuItem menuItem1;//это строки в контекстном меню


        public MainWindow()
        {
            try
            {
                InitializeComponent();

                // initialise code here
                m_notifyIcon = new System.Windows.Forms.NotifyIcon();
                m_notifyIcon.BalloonTipText = "The app has been minimised. Click the tray icon to show.";
                m_notifyIcon.BalloonTipTitle = "The App";
                m_notifyIcon.Text = "The App";
                m_notifyIcon.Icon = new System.Drawing.Icon("ic_timer_128_28821.ico");
                m_notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(m_notifyIcon_Click);

       


                contextMenu1 = new System.Windows.Forms.ContextMenu();
                menuItem1 = new System.Windows.Forms.MenuItem();
                
                //инициируем контекстное меню
                contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1 });
               
                menuItem1.Index = 0;
                menuItem1.Text = сюда нужно из ловаря надпись;
                menuItem1.Click += new EventHandler(menuItem1_Click);
      


                m_notifyIcon.ContextMenu = contextMenu1; //
                
                App.LanguageChanged += LanguageChanged;

                CultureInfo currLang = App.Languages[0];

                //Заполняем меню смены языка:
                menuLanguage.Items.Clear();
                foreach (var lang in App.Languages)
                {
                    MenuItem menuLang = new MenuItem();
                    menuLang.Header = lang.DisplayName;
                    menuLang.Tag = lang;
                    menuLang.IsChecked = lang.Equals(currLang);
                    menuLang.Click += ChangeLanguageClick;
                    menuLanguage.Items.Add(menuLang);
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }

        }




        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // закрываем форму
            Close();
        }
        

        #region trey
        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            try
            {
                if (WindowState == WindowState.Minimized)
                {
                    Hide();
                    if (m_notifyIcon != null)
                        m_notifyIcon.ShowBalloonTip(2000);
                }
                else if (WindowState == WindowState.Maximized)
                    m_storedWindowState = WindowState;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            try
            {
                CheckTrayIcon();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        void m_notifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Show();
                    WindowState = m_storedWindowState;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        void CheckTrayIcon()
        {
            try
            {
                ShowTrayIcon(!IsVisible);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        void ShowTrayIcon(bool show)
        {
            try
            {
                if (m_notifyIcon != null)
                    m_notifyIcon.Visible = show;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        #endregion


        #region Language
        private void LanguageChanged(Object sender, EventArgs e)
        {
            try
            {
                CultureInfo currLang = App.Language;

                //Отмечаем нужный пункт смены языка как выбранный язык
                foreach (MenuItem i in menuLanguage.Items)
                {
                    CultureInfo ci = i.Tag as CultureInfo;
                    i.IsChecked = ci != null && ci.Equals(currLang);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            try
            {
                MenuItem mi = sender as MenuItem;
                if (mi != null)
                {
                    CultureInfo lang = mi.Tag as CultureInfo;
                    if (lang != null)
                    {
                        App.Language = lang;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        #endregion Language

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                m_notifyIcon.Dispose();
                m_notifyIcon = null;

                closing();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }


        #region List grean
        private void LIST_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

            try
            {
                Is_enter_hootkey.Invoke(false);
                Grean_add.Invoke();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void LIST_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                Is_enter_hootkey.Invoke(true);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void LIST_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                index_cell.Invoke(LIST.CurrentCell.Column.DisplayIndex);
            }


            catch (Exception ex)
            {
                Log.Write(ex);
            }

        }
        #endregion List grean

        #region List red
        private void LIST_R_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                red_site_add_or_edit.Invoke(true);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        #endregion  List red

        #region Date
        private void DateTimePicker_SelectedDateChanged(object sender, TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {

        }

        private void PickerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            Comboboxes.SelectedIndex = -1;
        }



        private void DropCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Update_select_dates.Invoke(DropCalendar.SelectedDates.ToList());
            }
            catch (Exception ex)
            {


                Log.Write(ex);
#if test
                MessageBox.Show(ex.Message, "Ups...DropCalendar_SelectedDatesChanged");
#endif
            }
        }


#endregion Date

#region delegete
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Short_Click(object sender, RoutedEventArgs e)
        {
            if (Short.IsChecked != null && Short.IsChecked == true)
            {
                ShortTime.IsEnabled = false;
                ShortDuration.IsEnabled = false;

            }
            else
            {
                ShortTime.IsEnabled = true;
                ShortDuration.IsEnabled = true;
            }
        }
        public void Short_A()
        {
            ShortTime.IsEnabled = true;
            ShortDuration.IsEnabled = true;
        }
        public void Short_D()
        {
            ShortTime.IsEnabled = false;
            ShortDuration.IsEnabled = false;
        }

        private void OneTimes_Click(object sender, RoutedEventArgs e)
        {
            if (OneTimes.IsChecked != null && OneTimes.IsChecked == true)
            {
                mask.IsEnabled = false;
                mask1.IsEnabled = false;

            }
            else
            {
                mask.IsEnabled = true;
                mask1.IsEnabled = true;
            }
        }


        public void OneTimes_A()
        {
            mask.IsEnabled = true;
            mask1.IsEnabled = true;
        }
        public void OneTimes_D()
        {
            mask.IsEnabled = false;
            mask1.IsEnabled = false;
        }


        private void BigT_Click(object sender, RoutedEventArgs e)
        {
            if (BigT.IsChecked != null && BigT.IsChecked == true)
            {
                BreeakT.IsEnabled = false;
                BreeakD.IsEnabled = false;
                strictmode.IsEnabled = false;
            }
            else
            {
                BreeakT.IsEnabled = true;
                BreeakD.IsEnabled = true;
                strictmode.IsEnabled = true;
            }
        }

        public void BigT_A()
        {
            BreeakT.IsEnabled = true;
            BreeakD.IsEnabled = true;
            strictmode.IsEnabled = true;
        }
        public void BigT_D()
        {
            BreeakT.IsEnabled = false;
            BreeakD.IsEnabled = false;
            strictmode.IsEnabled = false;
        }
#endregion

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    DataGrid dg = sender as DataGrid;
                    List<StatisticSite> my_stat = new List<StatisticSite>();

                    IList rows = dg.SelectedItems;

                    for (int i = 0; i < dg.SelectedItems.Count; i++)
                    {
                        my_stat.Add((dg.SelectedItems[i]) as StatisticSite);
                    }


                    statistic_site_edit_add_delete.Invoke(my_stat);

                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }

        }

        private void DataGrid_Sound_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    DataGrid dg = sender as DataGrid;
                    List<Sound> my_stat = new List<Sound>();

                    IList rows = dg.SelectedItems;

                    for (int i = 0; i < dg.SelectedItems.Count; i++)
                    {
                        my_stat.Add((dg.SelectedItems[i]) as Sound);
                    }


                    sound_edit_add_delete.Invoke(my_stat);

                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }


        private void DataGrid_Grean_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    DataGrid dg = sender as DataGrid;
                    List<GreanSite> my_stat = new List<GreanSite>();

                    IList rows = dg.SelectedItems;

                    for (int i = 0; i < dg.SelectedItems.Count; i++)
                    {
                        my_stat.Add((dg.SelectedItems[i]) as GreanSite);
                    }


                    greanSite_edit_add_delete.Invoke(my_stat);

                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void DataGrid_Red_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    DataGrid dg = sender as DataGrid;
                    List<RedSite> my_stat = new List<RedSite>();

                    IList rows = dg.SelectedItems;

                    for (int i = 0; i < dg.SelectedItems.Count; i++)
                    {
                        my_stat.Add((dg.SelectedItems[i]) as RedSite);
                    }


                    red_site_delete.Invoke(my_stat);

                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }
        bool is_check = true;
        public Action view_model_up;
        private void MetroWindow_Activated(object sender, EventArgs e)
        {
            if (is_check)
            {
                view_model_up();
                is_check = false;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
