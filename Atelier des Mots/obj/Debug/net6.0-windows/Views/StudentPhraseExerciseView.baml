   M S B A M L   `   `   `  ����  Atelier des Mots6    0Atelier_des_Mots.Views.StudentPhraseExerciseView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  Phrase Exercise��5      $	��600��6    $	��800��6-   ��5      �� 5   
    �� ImageSource$= 7pack://siteoforigin:,,,/Views/Resources/Images/Kid2.jpg��6    j� Stretch$ UniformToFill=�6[    � 	Resources 5         FunButtonStyle �� 
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
 True��61   . �5:      ��  � z� 5;      �� 5<      $	 1.1Q�6-   $	 1.1Q�6:   5>      5?      P� 5B       �@J�IsMouseOver$ False��61   . �5C      ��  � z� 5D      �� 5E      $ 1Q�6-   $ 1Q�68   5G      5H      5J      5K      .��5M      �� $
��Auto=�6   $��Disabled=�66   .��5N   
   �� -   5        $��PhraseExercisePanel��5N      $��Center=�60   $��Center=�6M   $��10q�6h   $y�Visible=�6t   .+�5Q      �� -   5        $��40��5Q      $��40��6    $
��Left=�5R   	   $��5q�6$   
����  �
�������$
��Bold"�5T   	   $��0q�6   .��5W      �� $	��←��6   $��30(�6%   $
��Bold"�63   $��Center=�6E   $��Center=�6b    � Triggers 5Y      :� 5[       :� RoutedEvent$ 
MouseEnter��6#   .[�5\      �� .��5]      �� .��5_   "   ��  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�61   	 �� To	 White5`   %    g� Duration$ 0:0:0.2D�60    g� AutoReverse$
 True��6C   5a      5b      5c      5e      �� 5h      $��Disabled=�6   $
��Auto=�6D   $	��500��6g   .��5i      � -   5        $��PhraseContainer��5i      $��Center=�63   $��0,0,0,10q�6P   5k      5l      �� 5o      -   5        $��ShowCorrectPhraseButton��5o      $��Voici La Phrase��64   #��[  6n   $��0,0,0,15q�6�   $��40(�6�   �� 5p      -   5        $��NextPhraseButton��5p      $��Phrase suivante��6-   #��[  6`   $��0,0,0,10q�6�   $��40(�6�   �� 5s      -   5        $��PhraseAssemblyDisplay��5s      
�������
���   �$��2q�6_   $	��950��6s   $	��650��6   $��0q�6�   $y�	Collapsed=�6�   ._�5t      �� $��Center=�6   $��Center=�6:   .+�5u      �� $Y��Spack://application:,,,/Atelier des Mots;component/Views/Resources/Images/Bravo.jpeg��6   $	��170��6y   $	��170��6�   �� 5v      $��Bravo!��6    $��60(�6.   $��Italic$�6<   $
��Bold"�6O   
��� � �$��Center=�6t   �� 5x      -   5        $��PhraseAssembledText��5x       $��75(�6;   $
��Bold"�6I   $
��Wrap=�6[    �� TextAlignment$ Center=�6o   $��Segoe UI)�6�   5y      5z      5{      5|      5}      