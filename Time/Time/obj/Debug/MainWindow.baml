   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   1&clr-namespace:System;assembly=mscorlibSystem  5   	   ? ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp 5   	   clr-namespace:TimeTime 5   	   %clr-namespace:Time.Code	Time.Code 5   	      Time.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   .s&clr-namespace:System;assembly=mscorlib  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   ntb_pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml     5
   	   R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null[	 WMahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  	 5   	   LControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  	 5   	   2sys&clr-namespace:System;assembly=mscorlib  	 5   	   lclr-namespace:WpfApp  	 5   	    localclr-namespace:Time  	 5   	   &local1clr-namespace:Time.Code  	 5   	   c
 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 
 5   	   E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null
controlzexurn:controlzex  5   	   -   5          � Title$
  Time��5   	   $��524.49��6   $��782.571��6&   $��524.49��5      $��782.571��6    � WindowStartupLocation$ CenterScreen=�6i   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��5q�6   $��1��6    .@�5"      ��    ToolTip_Events � ToolTip# �   6     Index_tab_event#���  6B   .��5#      �  � ColumnDefinitions 5$      �� 5%      �� 5&      .+�5)      ��   ToolTip_Events_Events# �  6   #���  6Q   $��5q�6|   +  %MahApps.Metro.Controls.ControlsHelper   HeaderFontSize$ 16Q�6�   .��5+      �  5,      �� 5-   "   �� 5.   "   $
��auto �60   .+�50      &   System.Windows.Controls.DataGrid     CanUserSortColumns .     
IsReadOnly .    AutoGenerateColumns .  ��51   !   �� *	My_list+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem 52   *   �� *SelectedItemEvent+$	 TwoWay=�$
 PropertyChanged=�   Columns 56   "   0  *System.Windows.Controls.DataGridTextColumn  57   &     Sites_list_time,  &System.Windows.Controls.DataGridColumn   Header# �  6;      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6s   �� *Time+$	 TwoWay=�$
 PropertyChanged=�  58   &     Sites_list_Summary# �  6:   $	 150 6i    6u   �� *	Summary+$	 TwoWay=�$
 PropertyChanged=�  59   &     Sites_list_Location# �  6:   $	 150 6j    6v   �� *
Location+$	 TwoWay=�$
 PropertyChanged=�  5:   &     Sites_list_Description# �  6:   $	 150 6m    6y   �� *Description+$	 TwoWay=�$
 PropertyChanged=�5B      � 5C      $��1��6#    5D   "   �� 5E   &   �� 5F   &   �� 5G   &   .+�5I   "   �� $��5,0,5,0q�6)   $��2��6:     Events_Create#���  6u   ��6J   �� *Button_click_add_event+6u   �� 5J   "   $��5,0,5,0q�6)   $��1��6:     Events_Edit#���  6v   ��6J   �� *Button_click_edit_event+6v   �� 5K   "   $��5,0,5,0q�6)   $��0��6:    	 Events_Delete#��� 	 6x   ��6J   �� *Button_click_delete_event+6x   5L      5N      5R      � 5T      $��1��6   $��5q�6,    5V      �� 5W      �� 5X      $	��150 �6,   .+�5\      ��  
 ToolTip_Events_Date# � 
 6#   $��0��6U     Events_Date#���  5]   #   $ 16Q�6J   .��5^      � $��Center=�6#   $��Center=�6?   $	��200��6\   .+�5_   "   &   System.Windows.Controls.Calendar     SelectedDate 6,   �� *Selected_date+$	 TwoWay=�$
 PropertyChanged=�5`      5c      �� 5d        ToolTip_Events_Login# �  6#   $��0,10,0,0q�5e   #     Events_Login#���  65   $��1��5f   #   $ 14Q�60   .��5g      �  5h   "   �� 5i   &   �� 5j   &    5m   "   �� 5n   &   �� 5o   &   .+�5r   "   �� $��2��6-    �� Orientation$ 
Horizontal=�6A   $��Center=�6Z   .+�5s   &   ��   Events_Login_#���  60   $��14(�6W   $��0,0,5,0q�6e   �� 5t   &   $��14(�60   $
��Wrap=�6�   ��6>   �� *Logins+$	 TwoWay=�$
 PropertyChanged=�6�   5w   #   �� 5z   "     ToolTip_Events_Login_button# �  6)   $��1��6�   $��1��6�   $��10q�6�     Events_Sing_in#���  6�   ��6a   �� *Button_clik_sing_in+6�   5|      5}      5~      5�      5�      �� 5�        ToolTip_Timer# �  6     Index_tab_timer#���  6@   .��5�      �  5�      �� 5�      �� 5�      .+�5�      � $��1��6   .+�5�      ��   ToolTip_Timer_sound# �  6#   $��5q�6S    �� HeaderStringFormat$
 30px��6^     Timer_combo_sound#���  6x   $ 16Q�6�   .��5�      �  5�   "   �� 5�   &   $
��156* �67   �� 5�   &   $
��203* �67    5�   "   �� 5�   &   $
��Auto �64   �� 5�   &   $��1* �64   �� 5�   &   $
��Auto �64   �� 5�   &   $
��Auto �64   .+�5�   "   � $��5,5,5,5q�6'   $��0��68   $��2��6E    5�   &   �� 5�   *   �� 5�   *   .+�5�   &   ��   Timer_combo_sounds#���  60   $��Center=�6\   $��0��6w   �� 5�   &   -   5         ��Name$ ComboBox_sound��5�   /      ToolTip_Timer_sound_combobox# �  6G   $��1��6�    �� SelectedIndex 6�   �� *Select_Index_Sound_type_timer+$	 TwoWay=�$
 PropertyChanged=�.@�5�   *   ��   Timer_chec_big_break#���  64   �� 5�   *     Timer_chec_short_break#���  64   �� 5�   *     Timer_chec_one_time_break#���  64   5�   '   5�   #     5�   "   -   5           CanUserAddRows .  $��1��5�   C      CanUserDeleteRows .   .  $��2��5�   A   ��5�   !   �� *
List_sound+$	 TwoWay=�$
 PropertyChanged=� 5�   .   �� *Selected_Item_sound+$	 TwoWay=�$
 PropertyChanged=� 5�   &     5�   *      
IsReadOnly .   Timer_sound_name# �  6P   $	 150 6}    6�   �� *Name+$	 TwoWay=�$
 PropertyChanged=�  5�   *    .   Timer_sound_path# �  6Q   $	 150 6~    6�   �� *Path+$	 TwoWay=�$
 PropertyChanged=�5�   #   � 5�   "   $��5,5,5,5q�6'   $��2��68   $��2��6E    5�   &   �� 5�   *   $
��auto �6;   �� 5�   *   �� 5�   *   $
��auto �6;   .+�5�   &   ��   Timer_volum#���  60   �� 5�   &   $��5,0,5,0q�6E   $��1��6V    � Value 6-   �� *Volum+6h   �� 5�   &   $��2��6-    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  5�   &   ��5�   =   �� *Button_clik_Play_music+.��5�   *   .  (MahApps.Metro.IconPacks.PackIconMaterial  �	  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]] 	  Kind 6E   �� *	Icon_Play+5�   '   5�   #   � 5�   "   $��5,5,5,5q�6'   $��3��68   $��2��6E    5�   &   �� 5�   *   �� 5�   *   .+�5�   &   ��   ToolTip_Timer_sound_check# �  6/     Timer_chec_sounds#���  6�   $��0��6�    d� 	IsChecked 6e   �� *Is_Activ_sound+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5�   &      ToolTip_Timer_sound_path# �   6-    ! Timer_button_sounds#��� ! 6b   $��1��6�   ��6�   �� *Button_clik_path+6�   5�   #   5�      5�      5�      � 5�      $��0��6   .+�5�      �� $��5,0,5,0q�6%   .+�5�      �� -   5         ��Name$ BigTime��5�   '   $��5q�68   ��5�   "   � 5�   &    5�   *   �� 5�   .   �� 5�   .   .+�5�   *   �� -   5         ��Name$
 BigT��5�   w   $��0��63    " ToolTip_Timer_time_big# � " 6C   #���  5�   3   
�������$��16(�6w   
�������$��Segoe UI)�5�   Y    5�   3   �� *Is_big_timer+$	 TwoWay=�$
 PropertyChanged=�5�   Y   5�   '   .��5�   "   �� .+�5�   &   � $��0,5,0,5q�6+    5�   *   �� 5�   .   �� 5�   .   $
��auto �6?   �� 5�   .   $	��110 �6?   .+�5�   *   ��  "# Timer_combo_break_duration_big#��� # 64   $��Center=�6l     5�   *   $ Clock=�6E   $��1��6S   $��Center=�6c   $��Center=�6~   $��5,0,5,0q�6�   �� 5�   *   -   5        $ BreeakT��5�   3    $ ToolTip_Timer_big_break# � $ 5�   3   $��2��5�   3    5�   D   �� *Index_time_big+$	 TwoWay=�$
 PropertyChanged=�.@�5�   .   �� $ 
Horizontal=�6;   $��90��6T   .+�5�   2   �� $��20��6>    �� Padding$ 10,0,5,0q�6H   �� 5�   2    �� TextAlignment$ Right=�6<    % Timer_minutes#��� % 6R   $ 0,0,10,0q�6z   5�   /   �� 5�   .   $ 
Horizontal=�6:   $��90��6S   .+�5�   2   �� $��25��6>   $ 10,0,5,0q�6H   �� 5�   2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5�   /   �� 5�   .   $ 
Horizontal=�6:   $��90��6S   .+�5�   2   �� $��30��6>   $ 10,0,5,0q�6I   �� 5�   2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5�   /   �� 5   .   $ 
Horizontal=�6:   $��90��6S   .+�5  2   �� $��35��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   .+�5  2   �� $��40��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   .+�5	  2   �� $��45��6>   $ 10,0,5,0q�6I   �� 5
  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   .+�5  2   �� $��50��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   .+�5  2   �� $��60��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   .+�5  2   �� $��90��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   �� 5  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5  2   �� $	��120��6>   $ 10,0,5,0q�6I   �� 5  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5  /   5  +   5  '   � 5  &   $��0,5,0,5q�6+    5   *   �� 5!  .   �� 5"  .   $
��auto �6?   �� 5#  .   $	��110 �6?   .+�5%  *   ��  & Timer_combo_break_time_big#��� & 65   $��Center=�6j     5&  *   $ 
ClockAlert=�6E   $��1��6X   $��Center=�6h   $��Center=�6�   $��5,0,5,0q�6�   �� 5'  *   -   5        $ BreeakD��5'  j    ' ToolTip_Timer_big_duration# � ' 63   $��2��5(  �    63   �� *Index_duration_big+$	 TwoWay=�$
 PropertyChanged=�.@�5)  .   �� $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5*  2   �� $��2��6>   $ 10,0,5,0q�6G   �� 5+  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5,  /   �� 5-  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5.  2   �� $��3��6>   $ 10,0,5,0q�6G   �� 5/  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   50  /   �� 51  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�52  2   �� $��4��6>   $ 10,0,5,0q�6G   �� 53  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   54  /   �� 55  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�56  2   �� $��5��6>   $ 10,0,5,0q�6G   �� 57  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   58  /   �� 59  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5:  2   �� $��7��6>   $ 10,0,5,0q�6G   �� 5;  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5<  /   �� 5=  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5>  2   �� $��10��6>   $ 10,0,5,0q�6H   �� 5?  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5@  /   �� 5A  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5B  2   �� $��15��6>   $ 10,0,5,0q�6H   �� 5C  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5D  /   �� 5E  .   $ 
Horizontal=�6:   $��90��6S   $��Center=�6^   .+�5F  2   �� $��20��6>   $ 10,0,5,0q�6H   �� 5G  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6y   5H  /   5I  +   5J  '   �� 5K  &   -   5        $ 
strictmode��5K  f    ( ToolTip_Timer_strict_mode# � ( 60    ) Timer_chec_strict_regime#��� ) 6�   $��0,5,0,5q�6   6z   �� *Is_strict_type+$	 TwoWay=�$
 PropertyChanged=�6  5L  #   5M     �� 5N     -	   5        $ 	SmallTime��5N  '   $��5q�6:   ��5O  "   �� 5P  &   -
   5        $ Short��5P  �    * ToolTip_Timer_time_short# � * 6/   #���  6�   $��16(�6�   $
��Left=�6&  $��0,0,0.333,0q�6A  $	��335��6V  
������� 6d   �� *Is_small_timer+$	 TwoWay=�$
 PropertyChanged=�6v  .��5R  "   �� .+�5S  &   � $��0,5,0,5q�6+    5T  *   �� 5U  .   �� 5V  .   $
��auto �6?   �� 5W  .   $	��110 �6?   .+�5Y  *   ��  $+  Timer_combo_break_duration_short#��� + 64   $��Center=�6n     5Z  *   $ Clock=�6E   $��1��6S   $��Center=�6c   $��Center=�6~   $��5,0,5,0q�6�   �� 5[  *   -   5        $ 	ShortTime��5[  j    , ToolTip_Timer_short_break# � , 64   $��2��5]  4    5\  4   �� *Index_time_short+$	 TwoWay=�$
 PropertyChanged=�.@�5^  .   �� $ 
Horizontal=�6:   $��90��6U   .+�5_  2   �� $��5��6>   $ 10,0,5,0q�6G   �� 5`  2   $ Right=�6<   #��� % 6R   5a  /   �� 5b  .   $ 
Horizontal=�6;   $��90��6U   .+�5c  2   �� $��6��6>   $ 10,0,5,0q�6G   �� 5d  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6z   5e  /   �� 5f  .   $ 
Horizontal=�6:   $��90��6T   .+�5g  2   �� $��10��6>   $ 10,0,5,0q�6H   �� 5h  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6z   5i  /   �� 5j  .   $ 
Horizontal=�6:   $��90��6T   .+�5k  2   �� $��15��6>   $ 10,0,5,0q�6H   �� 5l  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6z   5m  /   �� 5n  .   $ 
Horizontal=�6:   $��90��6S   .+�5o  2   �� $��20��6>   $ 10,0,5,0q�6H   �� 5p  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6z   5q  /   �� 5r  .   $ 
Horizontal=�6:   $��90��6S   .+�5s  2   �� $��30��6>   $ 10,0,5,0q�6H   �� 5t  2   $ Right=�6<   #��� % 6R   $ 0,0,10,0q�6z   5u  /   5w  +   5x  '   � 5y  &   $��0,5,0,5q�6+    5z  *   �� 5{  .   �� 5|  .   $
��auto �6?   �� 5}  .   $	��110 �6?   .+�5  *   ��   - Timer_combo_break_time_short#��� - 64   $��Center=�6j     5�  *   $ 
ClockAlert=�6E   $��1��6X   $��Center=�6h   $��Center=�6�   $��5,0,5,0q�6�   �� 5�  *   -   5        $ ShortDuration��5�  3     . ToolTip_Timer_short_duration# � . 5�  3   $��2��5�  3    5�  3   �� *Index_duration_short+$	 TwoWay=�$
 PropertyChanged=�.@�5�  .   �� $ 
Horizontal=�6:   $��90��6S   .+�5�  2   �� $��8��6>   $ 10,0,5,0q�6G   �� 5�  2   $ Right=�6<    / Timer_second#��� / 6R   $ 0,0,10,0q�6y   5�  /   �� 5�  .   $ 
Horizontal=�6:   $��90��6S   .+�5�  2   �� $��20��6>   $ 10,0,5,0q�6H   �� 5�  2   $ Right=�6<   #��� / 6R   $ 0,0,10,0q�6y   5�  /   5�  +   5�  '   5�  #   5�     �� 5�     -   5        $ OneTime��5�  '   $��5q�68   ��5�  "   �� 5�  &   -   5        $ OneTimes��5�  b    0 ToolTip_Timer_time_one# � 0 6/   #���  6�   $��16(�6�   
������� 6t   �� *
Is_Small+$	 TwoWay=�$
 PropertyChanged=�6  .��5�  "   �� .+�5�  &   � $��0,5,0,5q�6+    5�  *   �� 5�  .   �� 5�  .   $
��auto �6?   �� 5�  .   $	��110 �6?   .+�5�  *   ��  -1 )Timer_combo_break_duration_one_time_break#��� 1 64   $��Center=�6w     5�  *   $ Clock=�6E   $��1��6S   $��Center=�6c   $��Center=�6~   $��5,0,5,0q�6�   %
  Xceed.Wpf.Toolkit.MaskedTextBox
  5�  *   -   5         
 Name$
 mask��5�  }    2 ToolTip_Timer_one_break# � 2 6=   $��3q�6q     �� TextAlignment$  Center=�5�  =   ! 
  Mask$! 00:00:00��6T   4  .Xceed.Wpf.Toolkit.Primitives.ValueRangeTextBox"   ValueDataType"" ��6d   $��2��5�     ��5�  �   �� *Time_timer_textbox+$	 TwoWay=�$
 PropertyChanged=�5�  /   5�  '   � 5�  &   $��0,5,0,5q�6+    5�  *   �� 5�  .   �� 5�  .   $
��auto �6?   �� 5�  .   $	��110 �6?   .+�5�  *   ��  )3 %Timer_combo_break_time_one_time_break#��� 3 64   $��Center=�6u     5�  *   $ 
ClockAlert=�6E   $��1��6X   $��Center=�6h   $��Center=�6�   $��5,0,5,0q�6�   
  5�  *   -   5        $ mask1��5�  �    4 ToolTip_Timer_one_duration# � 4 6=   $��3q�6t   $  Center=�5�  =   $! 00:00:00��6T   "" ��6d   $��2��5�     ��5�  =   �� *Time_duration_textbox+$	 TwoWay=�$
 PropertyChanged=�5�  /   5�  '   5�  #   5�     5�     5�     5�     5�     �� 5�      5 ToolTip_Filters# � 5 6    6 Index_tab_filter#��� 6 6B   .��5�     �� $��1��6   .@�5�     ��  7 ToolTip_Filters_sites# � 7 6    8 Filter_button_sites#��� 8 6P   $ 17Q�6   .��5�     �  5�     �� 5�  "   �� 5�  "   .+�5�     ��  9 ToolTip_Filters_sites_green# � 9 6'   $��1��6_   $��10q�6o    : Filter_title_Gsite#��� : 6{   $��0��6�   $ 16Q�5�  '   .��5�  "     -   5        #  Name$
# LIST��5�  ,    .   .  ��6:   �� *Grean+$	 TwoWay=�$
 PropertyChanged=� 5�  !   �� *Selected_Grean+$	 TwoWay=�$
 PropertyChanged=� 5�  &     5�  *    ; Filter_title_Gsite_name# � ; 6?   $	 100 6s    6   �� *Name+$	 TwoWay=�$
 PropertyChanged=�$   	CellStyle$ 5�  .   �� 5�  2   % �� 
TargetType*  $System.Windows.Controls.DataGridCell"%  68   .�5�  6   �� & �� Property& �@�ToolTip $<  ToolTip_Filters_sites_green_name' �� Value#' � < 6P   5�  3   5�  +     5�  *    = Filter_title_Gsite_hotKey# � = 6>   $	 100 6s    6   �� *	Hootkey+$	 TwoWay=�$
 PropertyChanged=�$ 5�  .   �� 5�  2   "%  68   .�5�  6   �� & �@�ToolTip &> "ToolTip_Filters_sites_green_macros#' � > 6P   5�  3   5�  +   5  /System.Windows.Controls.DataGridHyperlinkColumn  5�  *    ? Filter_title_Gsite_url# � ? 6D   $	 100 6v    6�   �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ 5�  .   �� 5�  2   "%  68   .�5�  6   �� & �@�ToolTip #@ ToolTip_Filters_sites_green_URL#' � @ 6P   5�  3   5�  +   5  #   5     �� 5      A ToolTip_Filters_sites_red# � A 6'   $��10q�6]    B Filter_title_Rsite#��� B 6i   $��1��6�   $ 16Q�6�   .��5  "     -   5         .   .  ��5  +   �� *Red+$	 TwoWay=�$
 PropertyChanged=� 5  &     5  *    C Filter_title_Rsite_name# � C 6?   $	 100 6s    6   �� *Name+$	 TwoWay=�$
 PropertyChanged=�$ 5  .   �� 5  2   "%  68   .�5  6   �� & �@�ToolTip "D ToolTip_Filters_sites_red_name#' � D 6P   5  3   5  +     5  *    E Filter_title_Rsite_url# � E 6C   $	 100 6u    6�   �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ 5  .   �� 5  2   "%  68   .�5  6   �� & �@�ToolTip !F ToolTip_Filters_sites_red_URL#' � F 6P   5  3   5  +   5#  #   5$     5&     5'     �� 5(      G ToolTip_Filters_stasis# � G 6    H Filter_button_statistic#��� H 6Q   $ 17Q�6�   $��27��6�   $	��Top=�6�   .��5*     �  5+     �� 5,  "   $	��220 �63   �� 5-  "   $	��140 �63   �� 5.  "    52     �� 53  "   $
��auto �60   �� 54  "   �� 55  "   $
��auto �60   .+�5?     � $��0��6#   $��5q�63   $��2��6>    5B  "   �� 5C  &   $
��auto �67   �� 5D  &   $	��175 �67   .+�5H  "     $ Calendar=�6=   $��Center=�6M   $��Center=�6h   $��16��6�   $��0��6�   $��24��6�   $��	0,10,4,10q�6�   �� 5I  "   -   5        $ 
Comboboxes��5I  �    #I ToolTip_Filters_stasis_calendar# � I 6+   $��1��6g   $��5q�6w   ( �� 
IsEditable( .  *  $MahApps.Metro.Controls.TextBoxHelper)   	Watermark) 5J  +   �� *Date_statistic_title+$	 TwoWay=�$
 PropertyChanged=�.@�5L  &   �� .��5M  *     -   5        *  Name$* DropCalendar��5M  3   +   SelectionMode$+ SingleRange=�6K    5N  3   �� *Date_statistic+$	 TwoWay=�$
 PropertyChanged=�6�   5P  '   5Q  #   5W     �� 5]       J ToolTip_Filters_stasis_sites# � J 6'   $��5q�6`   $��1��6k   #��� 8 6x   $��3��6�   $ 16Q�6�   .��5^  "     -   5         .   .  ��5_  !   �� *StatisticSite+$	 TwoWay=�$
 PropertyChanged=� 5c  &     5d  *    K Statistic_list_name# � K 6?   $	 150 6o    6{   �� *Name+$	 TwoWay=�$
 PropertyChanged=�$ 5e  .   �� 5f  2   "%  68   .�5g  6   �� & �@�ToolTip L ToolTip_Filters_stasis_name#' � L 6P   5h  3   5j  +     5k  *    M Statistic_list_time# � M 6>   $	 150 6m    6y   �� *Time+$	 TwoWay=�$
 PropertyChanged=�$ 5l  .   �� 5m  2   "%  68   .�5n  6   �� & �@�ToolTip N ToolTip_Filters_stasis_time#' � N 6P   5o  3   5q  +     5r  *    O Statistic_list_status# � O 6C   $	 125 6t    6�   �� *Status+$	 TwoWay=�$
 PropertyChanged=�$ 5s  .   �� 5t  2   "%  68   .�5u  6   �� & �@�ToolTip !P ToolTip_Filters_stasis_status#' � P 6P   5v  3   5x  +     5y  *    Q Statistic_list_url# � Q 6C   $	 300 6q    6}   �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ 5z  .   �� 5{  2   "%  68   .�5|  6   �� & �@�ToolTip R ToolTip_Filters_stasis_url#' � R 6P   5}  3   5  +   5�  #   5�     5�     5�     5�     5�     �� 5�      S ToolTip_Settings# � S 6    T Index_tab_seting#��� T 6C   .��5�     �� .��5�     �  5�     �� 5�     �� 5�     �� 5�     �� 5�      5�     �� 5�     �� 5�     �� 5�     �� 5�     .+�5�     �� $��2��6"   $��1��67   $��Center=�6G   ���	#FF210404, J� OpacityMask, �	#FF5F0E0E$��0,0,0,2q�6�   ._�5�     �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5�  "   ��  U ToolTip_Settings_Language# � U 6(   $��Center=�6^    V Settings_lang#��� V 6y   $��16(�6�   o� 5�  "   ��6(   Z� .@�5�  &   m� -   5        - m�Name$- menuLanguage��5�  /    W m_menu_Language#��� W 6E   5�  #   5�     5�     �� 5�     $��2��6!   $��1��65   $��1��6B   $��Center=�6R   ���	#FF210404, �	#FF5F0E0E$��0,0,0,2q�6�   ._�5�     �� $��5q�6)   $ 
Horizontal=�64   $��Center=�6M   $��Center=�6h   .+�5�  "   )  #MahApps.Metro.Controls.ToggleSwitch  $��16(�69    X Settings_auto#��� X 6�   $��Center=�6�    Y ToolTip_Settings_Auto_start# � Y 6�   .   	IsChecked. 6G   �� *
Auto_start+$	 TwoWay=�$
 PropertyChanged=�6�   5�     5�     �� 5�     $��1��6!   $��2��61   $��2��5�     $��2��6*   $��Center=�5�  !   ���	#FF210404, �	#FF5F0E0E$��0,0,0,2q�5�  !   ._�5�     �  5�  "   �� 5�  &   $
��auto �64   �� 5�  &   .+�5�  "   �� $��0��6,    Z ToolTip_Settings_info# � Z 69   $��Center=�6k    [ Settings_info_title#��� [ 6�   $��20(�6�   �� 5�  "   $	��150��6,   $��1��69   $��Center=�6G   $��Center=�6b   $
��Wrap=�5�      \ Settings_info#��� \ 5�     $��14(�6D   $	��374��6R   5�     5�     5�     5�     5�     5�     5�     5�     