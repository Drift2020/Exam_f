   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 1&clr-namespace:System;assembly=mscorlibSystem  ? ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp clr-namespace:TimeTime %clr-namespace:Time.Code	Time.Code    Time.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .s&clr-namespace:System;assembly=mscorlib  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ntb_pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml     R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null[	 WMahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  	 LControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  	 2sys&clr-namespace:System;assembly=mscorlib  	 lclr-namespace:WpfApp  	  localclr-namespace:Time  	 &local1clr-namespace:Time.Code  	 c
 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 
 E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null
controlzexurn:controlzex  -     � Title$
  Time��$��524.49��$��782.571��$��524.49��$��782.571�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��Auto ��� .+��� $��5q�$��1��.@���    ToolTip_Events � ToolTip# �     Index_tab_event#���  .���  � ColumnDefinitions �� �� .+���   ToolTip_Events_Events# �  #���  $��5q�+  %MahApps.Metro.Controls.ControlsHelper   HeaderFontSize$ 16Q�.���  �� �� $
��auto �.+�&   System.Windows.Controls.DataGrid     CanUserSortColumns .     
IsReadOnly .    AutoGenerateColumns .  ���� *	My_list+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem �� *SelectedItemEvent+$	 TwoWay=�$
 PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn    Sites_list_time,  &System.Windows.Controls.DataGridColumn   Header# �     Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Time+$	 TwoWay=�$
 PropertyChanged=�    Sites_list_Summary# �  $	 150  �� *	Summary+$	 TwoWay=�$
 PropertyChanged=�    Sites_list_Location# �  $	 150  �� *
Location+$	 TwoWay=�$
 PropertyChanged=�    Sites_list_Description# �  $	 150  �� *Description+$	 TwoWay=�$
 PropertyChanged=�� $��1�� �� �� �� .+��� $��5,0,5,0q�$��2��  Events_Create#���  ���� *Button_click_add_event+�� $��5,0,5,0q�$��1��  Events_Edit#���  ���� *Button_click_edit_event+�� $��5,0,5,0q�$��0�� 	 Events_Delete#��� 	 ���� *Button_click_delete_event+� $��1��$��5q� �� �� $	��150 �.+���  
 ToolTip_Events_Date# � 
 $��0��  Events_Date#���  $ 16Q�.��� $��Center=�$��Center=�$	��200��.+�&   System.Windows.Controls.Calendar     SelectedDate �� *Selected_date+$	 TwoWay=�$
 PropertyChanged=���   ToolTip_Events_Login# �  $��0,10,0,0q�  Events_Login#���  $��1��$ 14Q�.���  �� ��  �� �� .+��� $��2�� �� Orientation$ 
Horizontal=�$��Center=�.+���   Events_Login_#���  $��14(�$��0,0,5,0q��� $��14(�$
��Wrap=����� *Logins+$	 TwoWay=�$
 PropertyChanged=���   ToolTip_Events_Login_button# �  $��1��$��1��$��10q�  Events_Sing_in#���  ���� *Button_clik_sing_in+��   ToolTip_Timer# �    Index_tab_timer#���  .���  �� �� .+�� $��1��.+���   ToolTip_Timer_sound# �  $��5q� �� HeaderStringFormat$
 30px��  Timer_combo_sound#���  $ 16Q�.���  �� $
��Auto ��� $��1* ��� $
��Auto ��� $
��Auto �.+�� $��5,5,5,5q�$��0�� �� �� .+���   Timer_combo_sounds#���  $��Center=�$��0���� -    ��Name$ ComboBox_sound��   ToolTip_Timer_sound_combobox# �  $��1�� �� SelectedIndex �� *Select_Index_Sound_type_timer+$	 TwoWay=�$
 PropertyChanged=�.@���   Timer_chec_big_break#���  ��   Timer_chec_short_break#���  ��   Timer_chec_one_time_break#���    -      CanUserAddRows .  $��1��   CanUserDeleteRows .   .  ���� *
List_sound+$	 TwoWay=�$
 PropertyChanged=� �� *Selected_Item_sound+$	 TwoWay=�$
 PropertyChanged=�      
IsReadOnly .   Timer_sound_name# �  $	 150  �� *Name+$	 TwoWay=�$
 PropertyChanged=�   .   Timer_sound_path# �  $	 150  �� *Path+$	 TwoWay=�$
 PropertyChanged=�� $��5,5,5,5q�$��2�� �� $
��auto ��� �� $
��auto �.+���   Timer_volum#���  �� $��5,0,5,0q�$��1�� � Value �� *Volum+�� $��2�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  ���� *Button_clik_Play_music+.��.  (MahApps.Metro.IconPacks.PackIconMaterial  �	  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]] 	  Kind �� *	Icon_Play+� $��5,5,5,5q�$��3�� �� �� .+���   ToolTip_Timer_sound_check# �    Timer_chec_sounds#���  $��0�� d� 	IsChecked �� *Is_Activ_sound+$	 TwoWay=�$
 PropertyChanged=���    ToolTip_Timer_sound_path# �    ! Timer_button_sounds#��� ! $��1������ *Button_clik_path+� $��0��.+��� $��5,0,5,0q�.+��� -    ��Name$ BigTime��$��5q����� -    ��Name$
 BigT�� " ToolTip_Timer_time_big# � " #���  
�������$��16(�
�������$��Segoe UI)� �� *Is_big_timer+$	 TwoWay=�$
 PropertyChanged=�.���� .+�� $��0,5,0,5q� �� �� $	��110 �.+���  "# Timer_combo_break_duration_big#��� # $��Center=��� -   $ BreeakT�� $ ToolTip_Timer_big_break# � $ $��1�� �� *Index_time_big+$	 TwoWay=�$
 PropertyChanged=�.@��� $ 
Horizontal=�$��90��.+��� $��20�� �� Padding$ 10,0,5,0q���  �� TextAlignment$ Right=� % Timer_minutes#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��25��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��30��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��35��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��40��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��45��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��50��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��60��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��90��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $	��120��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q�� $��0,5,0,5q� �� �� $	��110 �.+���  & Timer_combo_break_time_big#��� & $��Center=��� -   $ BreeakD�� ' ToolTip_Timer_big_duration# � ' $��1�� �� *Index_duration_big+$	 TwoWay=�$
 PropertyChanged=�.@��� $ 
Horizontal=�$��90��$��Center=�.+��� $��2��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��3��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��4��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��5��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��7��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��10��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��15��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��$��Center=�.+��� $��20��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� -   $ 
strictmode�� ( ToolTip_Timer_strict_mode# � (  ) Timer_chec_strict_regime#��� ) $��0,5,0,5q� �� *Is_strict_type+$	 TwoWay=�$
 PropertyChanged=��� -	   $ 	SmallTime��$��5q����� -
   $ Short�� * ToolTip_Timer_time_short# � * #���  $��16(�$
��Left=�$��0,0,0.333,0q�$	��335��
������� �� *Is_small_timer+$	 TwoWay=�$
 PropertyChanged=�.���� .+�� $��0,5,0,5q� �� �� $	��110 �.+���  $+  Timer_combo_break_duration_short#��� + $��Center=��� -   $ 	ShortTime�� , ToolTip_Timer_short_break# � , $��1�� �� *Index_time_short+$	 TwoWay=�$
 PropertyChanged=�.@��� $ 
Horizontal=�$��90��.+��� $��5��$ 10,0,5,0q��� $ Right=�#��� % �� $ 
Horizontal=�$��90��.+��� $��6��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��10��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��15��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��20��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��30��$ 10,0,5,0q��� $ Right=�#��� % $ 0,0,10,0q�� $��0,5,0,5q� �� �� $	��110 �.+���   - Timer_combo_break_time_short#��� - $��Center=��� -   $ ShortDuration��  . ToolTip_Timer_short_duration# � . $��1�� �� *Index_duration_short+$	 TwoWay=�$
 PropertyChanged=�.@��� $ 
Horizontal=�$��90��.+��� $��8��$ 10,0,5,0q��� $ Right=� / Timer_second#��� / $ 0,0,10,0q��� $ 
Horizontal=�$��90��.+��� $��20��$ 10,0,5,0q��� $ Right=�#��� / $ 0,0,10,0q��� -   $ OneTime��$��5q����� -   $ OneTimes�� 0 ToolTip_Timer_time_one# � 0 #���  $��16(�
������� �� *
Is_Small+$	 TwoWay=�$
 PropertyChanged=�.���� .+�� $��0,5,0,5q� �� �� $	��120 �.+���  -1 )Timer_combo_break_duration_one_time_break#��� 1 $��Center=�%
  Xceed.Wpf.Toolkit.MaskedTextBox
  -    
 Name$
 mask�� 2 ToolTip_Timer_one_break# � 2 $��3q�  �� TextAlignment$  Center=�! 
  Mask$! 00:00:00��4  .Xceed.Wpf.Toolkit.Primitives.ValueRangeTextBox"   ValueDataType"" ��$��1������ *Time_timer_textbox+$	 TwoWay=�$
 PropertyChanged=�� $��0,5,0,5q� �� �� $	��120 �.+���  )3 %Timer_combo_break_time_one_time_break#��� 3 $��Center=�
  -   $ mask1�� 4 ToolTip_Timer_one_duration# � 4 $��3q�$  Center=�$! 00:00:00��"" ��$��1������ *Time_duration_textbox+$	 TwoWay=�$
 PropertyChanged=���  5 ToolTip_Filters# � 5  6 Index_tab_filter#��� 6 .���� $��1��.@���  7 ToolTip_Filters_sites# � 7  8 Filter_button_sites#��� 8 $ 17Q�.���  �� �� .+���  9 ToolTip_Filters_sites_green# � 9 $��1��$��10q� : Filter_title_Gsite#��� : $��0��$ 16Q�.��  -   #  Name$
# LIST�� .   .  ���� *Grean+$	 TwoWay=�$
 PropertyChanged=� �� *Selected_Grean+$	 TwoWay=�$
 PropertyChanged=�    ; Filter_title_Gsite_name# � ; $	 100  �� *Name+$	 TwoWay=�$
 PropertyChanged=�$   	CellStyle$ �� % �� 
TargetType*  $System.Windows.Controls.DataGridCell"%  .��� & �� Property& �@�ToolTip $<  ToolTip_Filters_sites_green_name' �� Value#' � <    = Filter_title_Gsite_hotKey# � = $	 100  �� *	Hootkey+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip &> "ToolTip_Filters_sites_green_macros#' � > 5  /System.Windows.Controls.DataGridHyperlinkColumn   ? Filter_title_Gsite_url# � ? $	 100  �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip #@ ToolTip_Filters_sites_green_URL#' � @ ��  A ToolTip_Filters_sites_red# � A $��10q� B Filter_title_Rsite#��� B $��1��$ 16Q�.��  -    .   .  ���� *Red+$	 TwoWay=�$
 PropertyChanged=�    C Filter_title_Rsite_name# � C $	 100  �� *Name+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip "D ToolTip_Filters_sites_red_name#' � D    E Filter_title_Rsite_url# � E $	 100  �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip !F ToolTip_Filters_sites_red_URL#' � F ��  G ToolTip_Filters_stasis# � G  H Filter_button_statistic#��� H $ 17Q�$��27��$	��Top=�.���  �� $	��180 ��� $	��150 ���  �� $
��auto ��� �� $
��auto �.+�� $��0��$��5q�$��2�� �� �� .+��� -   $ 
Comboboxes�� #I ToolTip_Filters_stasis_calendar# � I $��0��$��5q�( �� 
IsEditable( .  *  $MahApps.Metro.Controls.TextBoxHelper)   	Watermark) �� *Date_statistic_title+$	 TwoWay=�$
 PropertyChanged=�.@��� .��  -   *  Name$* DropCalendar��+   SelectionMode$+ SingleRange=� �� *Date_statistic+$	 TwoWay=�$
 PropertyChanged=���   J ToolTip_Filters_stasis_sites# � J $��5q�$��1��#��� 8 $��3��$ 16Q�.��  -    .   .  ���� *StatisticSite+$	 TwoWay=�$
 PropertyChanged=�    K Statistic_list_name# � K $	 150  �� *Name+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip L ToolTip_Filters_stasis_name#' � L    M Statistic_list_time# � M $	 150  �� *Time+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip N ToolTip_Filters_stasis_time#' � N    O Statistic_list_status# � O $	 125  �� *Status+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip !P ToolTip_Filters_stasis_status#' � P    Q Statistic_list_url# � Q $	 300  �� *URL+$	 TwoWay=�$
 PropertyChanged=�$ �� "%  .��� & �@�ToolTip R ToolTip_Filters_stasis_url#' � R ��  S ToolTip_Settings# � S  T Index_tab_seting#��� T .���� .���  �� �� �� ��  �� �� �� �� .+��� $��2��$��1��$��Center=����	#FF210404, J� OpacityMask, �	#FF5F0E0E$��0,0,0,2q�._��� $ 
Horizontal=�$��Center=�$��Center=�.+���  U ToolTip_Settings_Language# � U $��Center=� V Settings_lang#��� V $��16(�o� ��Z� .@�m� -   - m�Name$- menuLanguage�� W m_menu_Language#��� W �� $��2��$��1��$��1��$��Center=����	#FF210404, �	#FF5F0E0E$��0,0,0,2q�._��� $��5q�$ 
Horizontal=�$��Center=�$��Center=�.+�)  #MahApps.Metro.Controls.ToggleSwitch  $��16(� X Settings_auto#��� X $��Center=� Y ToolTip_Settings_Auto_start# � Y .   	IsChecked. �� *
Auto_start+$	 TwoWay=�$
 PropertyChanged=��� $��1��$��2��$��2��$��2��$��Center=����	#FF210404, �	#FF5F0E0E$��0,0,0,2q�._��  �� $
��auto ��� .+��� $��0�� Z ToolTip_Settings_info# � Z $��Center=� [ Settings_info_title#��� [ $��20(��� $	��150��$��1��$��Center=�$��Center=�$
��Wrap=� \ Settings_info#��� \ $��14(�$	��374��