   M S B A M L   `   `   `  ����   Atelier des Mots6    0Atelier_des_Mots.Views.StudentPhraseExerciseView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Phrase Exercise��$	��600��$	��800������  �� ImageSource$= 7pack://siteoforigin:,,,/Views/Resources/Images/Kid2.jpg�� j� Stretch$ UniformToFill=� � 	Resources    FunButtonStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth �� 
TargetType �� CornerRadius �� Padding J� RenderTransformOrigin J� Opacity �� Triggers P� Property P� Value �� ScaleX �� ScaleY��%�  &	        �� " ��.���  � ��$	 400����  � ��$	 100����  � ��$ 30(���  � ��$
 Bold"���  � ��$ Comic Sans MS)���  � ��
 �������  � �� �� $	 0,0&�$	 1,1&�.��� $	 	#FFFB8C00��$
 0Q�� $	 	#FFFFC107��$
 1Q���  � ��$ 0q���  � ��$ 15q���  �@J�Effect   $ Black��$ 15Q�$ 7Q���  � �� �� " ��.R��� #��z��$ 40��# z��$��0q�._�� $ 0.5,0.5&�.+��� 
���   �$ 40��$	 0.2Q�$
��Auto��$
��Auto��$��Bottom=�$��0,8,0,0q��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � z� �� $	 1.1Q�$	 1.1Q�P�  �@J�IsMouseOver$ False��. ���  � z� �� $ 1Q�$ 1Q�.���� $
��Auto=�$��Disabled=�.���� -   $��PhraseExercisePanel��$��Center=�$��Center=�$��10q�$y�Visible=�.+��� -   $��40��$��40��$
��Left=�$��5q�
����  �
�������$
��Bold"�$��0q�.���� $	��←��$��30(�$
��Bold"�$��Center=�$��Center=� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To	 White g� Duration$ 0:0:0.2D� g� AutoReverse$
 True���� $��Disabled=�$
��Auto=�$	��500��.��� -   $��PhraseContainer��$��Center=�$��0,0,0,10q��� -   $��ShowCorrectPhraseButton��$��Voici La Phrase��#��[  $��0,0,0,15q�$��40(��� -   $��NextPhraseButton��$��Phrase suivante��#��[  $��0,0,0,10q�$��40(��� -   $��PhraseAssemblyDisplay��
�������
���   �$��2q�$	��950��$	��650��$��0q�$y�	Collapsed=�._��� $��Center=�$��Center=�.+��� $Y��Spack://application:,,,/Atelier des Mots;component/Views/Resources/Images/Bravo.jpeg��$	��170��$	��170���� $��Bravo!��$��60(�$��Italic$�$
��Bold"�
��� � �$��Center=��� -   $��PhraseAssembledText��$��75(�$
��Bold"�$
��Wrap=� �� TextAlignment$ Center=�$��Segoe UI)�