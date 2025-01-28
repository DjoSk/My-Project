﻿#pragma checksum "..\..\..\..\Views\StudentPhraseExerciseView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "852D86BFE766CA56ACD594BDE750E65D4981731E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Atelier_des_Mots.Views {
    
    
    /// <summary>
    /// StudentPhraseExerciseView
    /// </summary>
    public partial class StudentPhraseExerciseView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PhraseExercisePanel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel PhraseContainer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowCorrectPhraseButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextPhraseButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PhraseAssemblyDisplay;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PhraseAssembledText;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BravoPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Atelier des Mots;component/views/studentphraseexerciseview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
            ((Atelier_des_Mots.Views.StudentPhraseExerciseView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PhraseExercisePanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.PhraseContainer = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            this.ShowCorrectPhraseButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
            this.ShowCorrectPhraseButton.Click += new System.Windows.RoutedEventHandler(this.ShowCorrectPhrase_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NextPhraseButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Views\StudentPhraseExerciseView.xaml"
            this.NextPhraseButton.Click += new System.Windows.RoutedEventHandler(this.NextPhrase_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PhraseAssemblyDisplay = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.PhraseAssembledText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.BravoPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

