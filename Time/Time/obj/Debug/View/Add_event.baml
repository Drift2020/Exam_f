   M S B A M L   `   `   `  ����?  ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Time.View	Time.View  5   	       Time.View.Add_event   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Time.View     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   $��300.857��5	   S   $��288.287��6d     � 
ResizeMode$  NoResize=�6t    � WindowStartupLocation$ CenterScreen=�6�    � Title 6	   �� *Title+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   )  #MahApps.Metro.Controls.ToggleSwitch  -   5          Name$ IsCheck��5   2   $��5,10,5,0q�6    $��16(�6D      Events_Add_all_day#���   6�   $��Center=�6�      	IsChecked 6R   �� *	All_day+$ TwoWay=�$ PropertyChanged=�6�   +  %MahApps.Metro.Controls.DateTimePicker  5   
   -   5          Name$ 	StartDate��5   3   $��5,0,5,0q�6"   $��Center=�6�   $��1��6�    " Events_Add_Select_a_date_start*  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark#	 �  6�   
   SelectedDate
 6F   �� *
Start_date+$ TwoWay=�$ PropertyChanged=�6�     5   
   -   5        $ EndDate��5   3   $��5,0,5,0q�6"   $��Center=�6�   $��2��6�      Events_Add_Select_a_date_end#	 �  6�   
 6D   �� *
End_date+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��5,10,5,0q�6   $��Center=�6$   $��3��6�     Events_Add_Summary#	 �  6�   ��6?   �� *	Summary+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��5,0,5,0q�6   $��Center=�6#   $��4��6�     Events_Add_Location#	 �  6�   ��6>   �� *
Location+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��5,0,5,0q�6   $��Center=�6#   $��5��6�     Events_Add_Description#	 �  6�   ��6>   �� *Description+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ createB��5   "   $��5,0,5,0q�6   $��Center=�63   $��6��6v     Events_Add_Create#���  6�   ��6N   �� *Button_click_create+6�   �� 5   
   -   5        $ editB��5   "   $��5,0,5,0q�6   $��Center=�61   $��6��6r     Events_Add_edit#���  6   ��6L   �� *Button_click_edit+6   5      5      