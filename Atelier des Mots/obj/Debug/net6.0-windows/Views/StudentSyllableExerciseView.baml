   M S B A M L   `   `   `  ����  Atelier des Mots8    2Atelier_des_Mots.Views.StudentSyllableExerciseView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$'  !Exercice sur les mots syllabiques��5   	   $	��600��63   $	��800��6@   ��5      �� 5   
    �� ImageSource$= 7pack://siteoforigin:,,,/Views/Resources/Images/Kid1.jpg��6    j� Stretch$ UniformToFill=�6[    � 	Resources 5         FunButtonStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth �� 
TargetType �� CornerRadius �� Padding J� RenderTransformOrigin J� Opacity �� Triggers P� Property P� Value �� ScaleX �� ScaleY��%H  &	        �� 5   
   " ��6'   .�5      ��  � ��$	 400��6&   �� 5       � ��$	 100��6'   �� 5       � ��$ 30(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Comic Sans MS)�6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $	 	#FFFB8C00��6'   $
 0Q�69   � 5      $	 	#FFFFC107��6'   $
 1Q�69   5      5      �� 5       � ��$ 0q�60   �� 5       � ��$ 15q�6(   �� 5       �@J�Effect 5        5       $ Black��6'   $ 15Q�65   $ 7Q�6E   5"      �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� #��z��6!   $ 40��6K   # z��5)   !   $��0q�6E   ._�5*      � $ 0.5,0.5&�6#   .+�5,   "   �� 
���   �$ 40��6<   $	 0.2Q�5-   )   $
��Auto��67   $
��Auto��6E   $��Bottom=�5.   )   $��0,8,0,0q�6D   �� 5/   "   $��Center=�63   $��Center=�6P   50      51      52      54       57      P� 59       �@J�IsMouseOver$
 True��61   . �5:      ��  � z� 5;      �� 5<      $	 1.1Q�6-   $	 1.1Q�6:   5>      5?      P� 5B       �@J�IsMouseOver$ False��61   . �5C      ��  � z� 5D      �� 5E      $ 1Q�6-   $ 1Q�68   5G      5H      5J      5K      .��5M      � .+�5O   
   r� -   5         r�Name$ BackgroundMusic��5O       r� Source$X Rpack://application:,,,/Atelier_des_Mots;component/Views/Resources/Sounds/Music.mp3?�5P       r� LoadedBehavior$ Manual=�5Q       r� UnloadedBehavior$
 Stop=�5R      $y�	Collapsed=�5S      �� 5V   
   -   5        $��OuterScrollViewer��5V      $
��Auto=�60   $��Disabled=�6S   .��5W      �� $��Center=�6   $��Center=�66   $��20q�6Q   .+�5Y      �� -   5        $��40��5Y      $��40��6$   $
��Left=�5Z   	   $��5q�6$   
����  �
�������$
��Bold"�5\   	   $��0q�6   .��5_      �� $	��←��6    $��30(�6)   $
��Bold"�67   $��Center=�6I   $��Center=�6f    � Triggers 5a      :� 5c       :� RoutedEvent$ 
MouseEnter��6'   .[�5d      �� .��5e   "   �� .��5g   &   ��  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�65   	 �� To	 White5h   %     g� Duration$  0:0:0.2D�60   ! g� AutoReverse$
! True��6C   5i   #   5j      5k      5m      �� 5o      $��Disabled=�6   $
��Auto=�6H   $	��439��6k   .��5p      � -   5        $��SyllableContainer��5p       $��Center=�69   $��0,0,0,20q�6V   5r      5s      �� 5v      -   5        $��Verifier��5v      #��[  6K   $��0,0,0,20q�6s   $��40(�6�   �� 5w      -   5        $��Mot suivant��5w      #��[  6F   $��0,0,0,20q�6n   $��40(�6�   �� 5y      -   5        $!��SyllableWordAssemblyDisplay��5y      
�������
���   �$��5q�6i   $
��1200��6}   $	��220��6�   $��5q�6�   $y�	Collapsed=�6�   ._�5z      �� -   5        $��SyllableAssembledWordText��5z       $	��135(�6A   $
��Bold"�6P   $��Center=�6b   $��Center=�6}   $��Arial)�6�   ��6�   �� *AssembledWord+6�   5{      5|      5}      5      5�      