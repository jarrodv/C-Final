﻿#pragma checksum "..\..\Appointments.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "810123EDA33ED548B88F15D9364E34B936CBDCCB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CTUCare;
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


namespace CTUCare {
    
    
    /// <summary>
    /// Appointments
    /// </summary>
    public partial class Appointments : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Appointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewAppointment;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Appointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseAppointment;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Appointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/CTUCare;component/appointments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Appointments.xaml"
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
            this.btnNewAppointment = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Appointments.xaml"
            this.btnNewAppointment.Click += new System.Windows.RoutedEventHandler(this.btnNewAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCloseAppointment = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Appointments.xaml"
            this.btnCloseAppointment.Click += new System.Windows.RoutedEventHandler(this.btnCloseAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Appointments.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
