   M S B A M L   `   `   `  ����F  BMachenicWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MachenicWpfMachenicWpf  5   	   &     MachenicWpf.Controls.CreateOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   %localclr-namespace:MachenicWpf  5   	     � Title$  Create/Edit Order��5   	   $	��601��6$   $	��900��61    � WindowState$ 	Maximized=�6=    � 	Resources 5      ��%    5	      .��5
      � $��5q�6    5   
    �� 
TargetType �� Property �� Value��%`   '��       �� 5      " ��6   .�5      ��  �@��Padding$	 5,2q�6,   6:   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $��10 �6   6,   �� 5      $��2* �6   6,   �� 5      $��10 �6   6,    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5       $
��Auto �6   6,   �� 5!      $��5 �6   6)   �� 5"      $
��Auto �6   6,   �� 5#      $��5 �6   6)   �� 5$      $
��Auto �6   6,   �� 5%      $
��Auto �6   6,   �� 5&      $
��Auto �6   6,   �� 5'      $��5 �6   6)   �� 5(      $��* �6   6)   �� 5)      $��10 �6   6*   �� 5*      $
��Auto �6   6,   .+�5,   
   �� 
Order No6   �� 5-   
   $��2��6    �� Orientation$ 
Horizontal=�6%   .+�5.      �� $	��150��6   ��6"   �� 	 �� Path$	 OrderNo�6B   �� 5/      $��10, 0q�6   
 d� 	IsChecked
 6&   �� $	 Finish�.��6H   Has Finished6W   50      �� 53   
   $��2��6   Customer Name60   �� 54   
   $��2��6   $��2��6   ��6/   �� $	 CustomerName�6T   �� 55   
   $��4��6   	Address6*   �� 56   
   $��4��6   $��2��6   ��6/   �� $	 Address�6O   �� 58   
   $��6��6   Drawing Type6/   �� 59   
   $��6��6   $��2��6"   $ 
Horizontal=�62   .+�5:      �� $��80��6    �� DisplayMemberPath$
 Text��6N    �� SelectedValuePath$ Value��6g   ��6"   �� $	 AvailableTypes� �� SelectedValue 6�   �� $	 SelectedType�6�   �� 5;      -   5        $��5,0,5,0q�5;      $
��10,2q�6&   .��6S   Drawing Values6c   5<      �� 5>   
   $��8��6   
Quantity6+   $  Xceed.Wpf.Toolkit.DoubleUpDown  5?   
   -   5          Name$ txtQuantity��5?   9   $��8��6   $��2��6)      AllowInputSpecialValues$	 Any=�5@      $	��150��6+   $
��Left=�67   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ClipValueToMinMax .  ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   
IsReadOnly .  �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�5C         Maximum$	 999X�5D         Minimum$ 1X�5E      %   DisplayDefaultValueOnEmptyText .  �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$	 Any=�5G         Value 5H      �� $	 Quantity��� 5I   
   $��10��6   	From Date6-   &   Xceed.Wpf.Toolkit.DateTimePicker  5J   
   -   5          Name$ 
dtFromDate��5J   <   $��10��6   $��2��6,   $
��Left=�5K   !   $	��150��6<    .  &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5N   "      FormatString$ 
MM/dd/yyyy��5O   "      	Watermark$ 
MM/dd/yyyy��5P   "      AutoCloseCalendar . �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5M      �� $	 FromDate�   Maximum 5Q      �� *Value+ �� ElementName$ dtToDate��5R   "   �� 5T   
   $��12��6   	To Date6+     5U   
   -   5        $ dtToDate��5U   <   $��12��6   $��2��6,   $
��Left=�5V   #   $	��150��6>    .  $ Custom=�5X   "   $ 
MM/dd/yyyy��5Y   "   $ 
MM/dd/yyyy��5Z   "    .  5[   !   �� $	 ToDate�    Minimum  5\   !   �� *Value+$ 
dtFromDate��5]   "   �� 5_   
   $��13��6   	Materials6-   	   MachenicWpf.BorderGrid	  5`   
   $��2��6   $��13��6+   $��2��69   $��0,5,0,0q�6M    5a      �� 5b      6"    5d      �� 5e      $��30 �6#   60   �� 5f      6%   �� 5g      $��90 �6#   60   �� 5h      $��90 �6#   60   �� 5i      $��90 �6#   60   �� 5j      $	��120 �6#   61   �� 5k      $��90 �6#   60   .+�5m      �� $��1��6   $��Center=�6%   $
��Bold"�6B   $��0��6T   No.6i   �� 5n      $��1��6   $��Center=�6%   $
��Bold"�6B   $��1��6T   Name6j   �� 5o      $��1��6   $��Center=�6%   $
��Bold"�6B   $��2��6T   Length (mm)6q   �� 5p      $��1��6   $��Center=�6%   $
��Bold"�6B   $��3��6T   
Quantity6n   �� 5q      $��1��6   $��Center=�6%   $
��Bold"�6B   $��4��6T   Weight (kg)6q   �� 5r      $��1��6   $��Center=�6%   $
��Bold"�6B   $��5��6T   	Unit cost6o   �� 5s      $��1��6   $��Center=�6%   $
��Bold"�6B   $��6��6T   
Cost ($)6n   5u      �� 5v   
   $��2��6   $��14��6"   $��3��61   $��Stretch=�6l   ��6E   �� $	 	Materials���5w      �� 5x      .R�5y      � $��1q�6    5z      �� 5{      $��24 �6/   6<   �� 5|      61   �� 5}      $��90 �6/   6<   �� 5~      $��90 �6/   6<   �� 5      $��90 �6/   6<   �� 5�      $	��120 �6/   6=   �� 5�      $��84 �6/   6<   .+�5�      �� $
��Left=�6$   ��6?   �� $	 Id�6Z   �� 5�      $��1��6$   ��64   �� $	 DisplayName�6X   �� 5�      $��Center=�6$   $��2��6A   ��6Q   �� $	 Length�6p   �� 5�      $��Center=�6$   $��3��6A   ��6Q   �� $	 Quantity�6r   �� 5�      $��Center=�6$   $��4��6A   ��6Q   �� $	 Weight�6p   �� 5�      $��0��6$   $��5��61     5�      $��80��6,   !   AllowTextInput! . "   MouseWheelActiveOnFocus" . $ 1X�5�      $ 99999X�5�      $ 1X�5�      #   ButtonSpinnerLocation$# Right=�5�      $	 Any=�5�      $ 
Enter Text��5�       5�      �� $	 UnitCost� /�� 6B   ��6L   �� $
	 Unit�6i   5�      �� 5�      $��Center=�6$   $��6��6A   ��6Q   �� $
	 Cost�6n   5�      5�      5�      �� 5�   
   $��16��6   Drawing Values62   �� 5�   
   $��16��6   $��2��6    $
��Auto=�60   $ �� AcceptsReturn$ . % �� 
IsReadOnly% . ��6�   �� $	 OrderDetail�6�   �� 5�   
   $��20��6   $��3��6#   $ 
Horizontal=�67   $��Right=�6P   .+�5�      �� -   5        $��5q�5�      $
��15,3q�60   .��6?   Close6F   �� 5�      -   5        $��5,5,0,5q�5�      $
��15,3q�6&   .��6D   Save6J   5�      5�      5�      