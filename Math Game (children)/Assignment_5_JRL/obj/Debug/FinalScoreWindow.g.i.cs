﻿#pragma checksum "..\..\FinalScoreWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4DB3B9332BF0EB3A2BA8E4F8805F8A01A83D843E0108D86EF6FCB64F7674FABE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment_5_JRL;
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


namespace Assignment_5_JRL {
    
    
    /// <summary>
    /// FinalScoreWindow
    /// </summary>
    public partial class FinalScoreWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNameScores;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAgeScores;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCorrect;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIncorrect;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTime;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFinalScore_Image3;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFinalScore_Image2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFinalScore_Image4;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFinalScore_Image1;
        
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
            System.Uri resourceLocater = new System.Uri("/Assignment_5_JRL;component/finalscorewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FinalScoreWindow.xaml"
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
            this.lblNameScores = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblAgeScores = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblCorrect = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblIncorrect = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblTime = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblFinalScore_Image3 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblFinalScore_Image2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblFinalScore_Image4 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblFinalScore_Image1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            
            #line 46 "..\..\FinalScoreWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

