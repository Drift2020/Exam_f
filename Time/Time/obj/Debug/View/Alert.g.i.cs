﻿#pragma checksum "..\..\..\View\Alert.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D86D7AD73B4A8C4588D923A1D543D9081E1BA360"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Time;
using Time.Code;
using WpfApp;


namespace Time.View {
    
    
    /// <summary>
    /// Alert
    /// </summary>
    public partial class Alert : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Time.View.Alert GWindow;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Info;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Time;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_cancel1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_ok;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_next;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_cancel;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_cancel2;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_ok2;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\Alert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Alert_button_ok1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Time;component/view/alert.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Alert.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GWindow = ((Time.View.Alert)(target));
            
            #line 15 "..\..\..\View\Alert.xaml"
            this.GWindow.Activated += new System.EventHandler(this.MetroWindow_Activated);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\View\Alert.xaml"
            this.GWindow.Loaded += new System.Windows.RoutedEventHandler(this.GWindow_Loaded);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\View\Alert.xaml"
            this.GWindow.KeyUp += new System.Windows.Input.KeyEventHandler(this.GWindow_KeyUp_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Info = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Alert_button_cancel1 = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Alert_button_ok = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.Alert_button_next = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.Alert_button_cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.Alert_button_cancel2 = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.Alert_button_ok2 = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.Alert_button_ok1 = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

