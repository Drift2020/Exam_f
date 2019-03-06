using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using NDde.Client;
using System.Web;
using System.IO;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Net;
using System.Web.UI.WebControls;

namespace Time.Code
{
    class SiteBloc
    {
        #region Chrome
        public static string GetURL(string i)
        {
           
            if (i != null)
            {
                string my_browser = Parse_str(i);
                if (my_browser.CompareTo(" Google Chrome") == 0)
                {
                    try
                    {

                        AutomationElement root = null;

                        AutomationElement textP = null;
                        object vpi = null;

                        try
                        {
                            root = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));
                            textP = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                            vpi = textP.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);
                        }
                        catch (Exception ex)
                        {
#if test
                                System.Windows.MessageBox.Show(ex.Message + " || " + "GetURL Chrome " + i + "//");
#endif
                        }

                        return vpi.ToString();
                    }
                    catch (Exception ex)
                    {
#if test
                        System.Windows.MessageBox.Show(ex.Message + " || " + "GetURL Chrome "+ i+"//");
#endif
                    }
                }
                else if (my_browser.CompareTo(" Internet Explorer") == 0)
                {
                    try
                    {
                        string myLocalLink = null;

                        SHDocVw.InternetExplorer browser;

                        mshtml.IHTMLDocument2 myDoc;
                        SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
                        string filename;
                        foreach (SHDocVw.InternetExplorer ie in shellWindows)
                        {
                            filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                            if ((filename == "iexplore"))
                            {
                                browser = ie;
                                myDoc = browser.Document;
                                myLocalLink = myDoc.url;
                                break;
                            }
                        }



                        return myLocalLink;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message + " || " + "GetURL iexplore " + i);
                    }
                }
                else if (my_browser.CompareTo(" Mozilla Firefox") == 0)
                {
                   
                        try
                        {
                           return GetBrowserURL("firefox");
                          

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message + " || " + "GetURL Firefox " + i);
                        }




                    
                }
                else if (my_browser.CompareTo(" Microsoft Edge") == 0)
                {
                    foreach (Process process in Process.GetProcessesByName("MicrosoftEdge"))
                    {



                        try
                        {
                            if (process == null)
                                throw new ArgumentNullException("process");

                            if (process.MainWindowHandle == IntPtr.Zero)
                                return null;

                            AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
                            if (elm == null)
                                return null;
                            string nameProperty = "";

                            var elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(
                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                                new PropertyCondition(AutomationElement.NameProperty, "Microsoft Edge")));

                                var elmUrlBar = elm2.FindFirst(TreeScope.Children,
                                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                                var url = ((TextPattern)elmUrlBar.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(int.MaxValue);
                                return url;
                            
                           

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message + " || " + "Microsoft Edge " + i);
                        }




                    }
                }
            
            }
            return null;
            
        }


        private static string GetBrowserURL(string browser)
        {

            WebControl webControl1 =new WebControl(System.Web.UI.HtmlTextWriterTag.Address);
            return null;
        //    string mysite = webControl1.ExecuteJavascriptWithResult("document.documentElement.outerHTML").ToString();
        }


        //private string GetURLFromProcess1(Process process, BrowserType browser)
        //{
        //    if (process == null)
        //        throw new ArgumentNullException("process");

        //    if (process.MainWindowHandle == IntPtr.Zero)
        //        return null;

        //    AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
        //    if (elm == null)
        //        return null;
        //    string nameProperty = "";

        //    if (browser.Equals(BrowserType.GOOGLE_CHROME))
        //        nameProperty = "Address and search bar";
        //    else if (browser.Equals(BrowserType.FIREFOX))
        //        nameProperty = "Search or enter address";
        //    else if (browser.Equals(BrowserType.INTERNET_EXPLORER))
        //        nameProperty = "Address and search using Bing";
        //    else if (browser.Equals(BrowserType.MICROSOFT_EDGE))
        //        nameProperty = "Search or enter web address";

        //    AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Subtree, new AndCondition(
        //        new PropertyCondition(AutomationElement.NameProperty, nameProperty, PropertyConditionFlags.IgnoreCase),
        //        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));

        //    if (elmUrlBar != null)
        //    {
        //        return ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        //    }

        //    return null;
        //}


        private string GetURLFromProcess(string i)
        {
            string my_browser = Parse_str(i);

            var many_process = Process.GetProcesses();

            Process process=null;

            for (int num = 0; num < many_process.Length - 1; num++)
            {
                try
                {
                   
                    if (my_browser.CompareTo(" Mozilla Firefox") == 0 
                        && many_process[num].ProcessName == "firefox")
                    {
                        process = many_process[num];
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message + " || " + "GetURL Firefox " + i);
                }
            }

            if (process == null)
                throw new ArgumentNullException("process");

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
            if (elm == null)
                return null;
            string nameProperty = "";

            //if (browser.Equals(BrowserType.GOOGLE_CHROME))
            //{
            //    var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
            //    if (elm1 == null) { return null; } // not the right chrome.exe
            //    var elm2 = elm1.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
            //    var elm3 = elm2.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
            //    var elm4 = elm3.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
            //    var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
            //    var elmUrlBar = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            //    var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            //    return url;
            //}
            //else 
            if (my_browser.CompareTo(" Mozilla Firefox") == 0)
            {
                AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar),
                       new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, false)));
                if (elm2 == null)
                    return null;
                var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox));
                if (elm3 == null)
                    return null;
                var elmUrlBar = elm3.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                if (elmUrlBar != null)
                {
                    var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                    return url;
                }
            }
            //else if (browser.Equals(BrowserType.INTERNET_EXPLORER))
            //{
            //    AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
            //    if (elm2 == null)
            //        return null;
            //    AutomationElement elmUrlBar = elm2.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            //    var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            //    return url;
            //}
            //else if (browser.Equals(BrowserType.MICROSOFT_EDGE))
            //{
            //    var elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(
            //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
            //    new PropertyCondition(AutomationElement.NameProperty, "Microsoft Edge")));

            //    var elmUrlBar = elm2.FindFirst(TreeScope.Children,
            //        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

            //    var url = ((TextPattern)elmUrlBar.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(int.MaxValue);
            //    return url;
            //}

            return null;
        }

        #endregion chrome

        static string Parse_str(string i)
        {
            string temp = null;


            string[] words = i.Split(new char[] { '-' });

            temp = words[words.Length-1];

            return temp;
        }

     
    }
}

