   M S B A M L   `   `   `  ����?  ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Time.View	Time.View  5   	       Time.View.Event_show   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Time.View     5   	      Events_Alert_title  � Title#  �   5   	   $	��315��66   $	��260��6C    � 
ResizeMode$ NoResize=�6O    � Topmost .  � WindowStartupLocation$ CenterScreen=�6t   .��5	      � $��5q�6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   � $��3��6   $��Center=�6#   $��Center=�6>    5      �� 5      �� 5      .+�5       ��   Events_Alert_Summary#���  6   $��0��6E   �� 5!      $��1��6R   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6R   5"      � 5$   
   $��0��6   $��1��6   $��3��6,    5%      �� 5&      �� 5'      .+�5*      �� ��5+      �� 5,      $��Center=�6     Events_Alert_Description#���  69   .��5/      ��  �� 
IsReadOnly . $	��120��6,    �� TextWrapping$
 Wrap=�6{   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   ��69   �� *Description+$ PropertyChanged=�6�   50      52      � 54   
   $��0��6   $��2��6   $��3��6,    55      �� 56      �� 57      .+�5:      �� ��5;      �� 5<      $��Center=�6     Events_Alert_Location#���  69   .��5?      ��  . $��5��6,   $
 Wrap=�6v   $
	 Auto=�6�   ��67   �� *
Location+$ PropertyChanged=�6�   5@      5B      5C      5D      