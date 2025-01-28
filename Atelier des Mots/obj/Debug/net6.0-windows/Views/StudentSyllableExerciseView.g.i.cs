﻿#pragma checksum "..\..\..\..\Views\StudentSyllableExerciseView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "338B275A244A3DCADF98331696107A03C405BC0A"
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
    /// StudentSyllableExerciseView
    /// </summary>
    public partial class StudentSyllableExerciseView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement BackgroundMusic;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel SyllableContainer;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SyllableWordAssemblyDisplay;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SyllableAssembledWordText;
        
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
            System.Uri resourceLocater = new System.Uri("/Atelier des Mots;V1.0.0.0;component/views/studentsyllableexerciseview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
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
            this.BackgroundMusic = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 2:
            this.SyllableContainer = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            
            #line 28 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AssembleSyllable_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 29 "..\..\..\..\Views\StudentSyllableExerciseView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextWord_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SyllableWordAssemblyDisplay = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.SyllableAssembledWordText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

