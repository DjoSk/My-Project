   M S B A M L   `   `   `  ����   Atelier des Mots8    2Atelier_des_Mots.Views.StudentSyllableExerciseView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$'  !Exercice sur les mots syllabiques��$	��600��$	��800������  �� ImageSource$= 7pack://siteoforigin:,,,/Views/Resources/Images/Kid1.jpg�� j� Stretch$ UniformToFill=� � 	Resources    FunButtonStyle �� 
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
 True��. ���  � z� �� $	 1.1Q�$	 1.1Q�P�  �@J�IsMouseOver$ False��. ���  � z� �� $ 1Q�$ 1Q�.��� .+�r� -    r�Name$ BackgroundMusic�� r� Source$X Rpack://application:,,,/Atelier_des_Mots;component/Views/Resources/Sounds/Music.mp3?� r� LoadedBehavior$ Manual=� r� UnloadedBehavior$
 Stop=�$y�	Collapsed=��� -   $��OuterScrollViewer��$
��Auto=�$��Disabled=�.���� $��Center=�$��Center=�$��20q�.+��� -   $��40��$��40��$
��Left=�$��5q�
����  �
�������$
��Bold"�$��0q�.���� $	��←��$��30(�$
��Bold"�$��Center=�$��Center=� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To	 White  g� Duration$  0:0:0.2D�! g� AutoReverse$
! True���� $��Disabled=�$
��Auto=�$	��439��.��� -   $��SyllableContainer��$��Center=�$��0,0,0,20q��� -   $��Verifier��#��[  $��0,0,0,20q�$��40(��� -   $��Mot suivant��#��[  $��0,0,0,20q�$��40(��� -   $!��SyllableWordAssemblyDisplay��
�������
���   �$��5q�$
��1200��$	��220��$��5q�$y�	Collapsed=�._��� -   $��SyllableAssembledWordText��$	��135(�$
��Bold"�$��Center=�$��Center=�$��Arial)����� *AssembledWord+