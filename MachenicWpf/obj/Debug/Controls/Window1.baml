   M S B A M L   `   `   `  ����F  BMachenicWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MachenicWpfMachenicWpf  5   	   ;"clr-namespace:MachenicWpf.ControlsMachenicWpf.Controls  5   	   "    MachenicWpf.Controls.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   )localclr-namespace:MachenicWpf    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   
   ,con"clr-namespace:MachenicWpf.Controls  5   	     � Title$  Type 1��5   	   $	��601��6   $
��1012��6%    � 	Resources 5      )   #MachenicWpf.Controls.NumericTextBox �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path��%�   '        �� 5	   
   "  6    5
      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��10 �6   6*   �� 5      $��* �6   6)   �� 5      $��10 �6   6*   �� 5      $
��Auto �6   6,   .+�5   
   �� $��10q�6   $��
Parameters��6    .��5         MachenicWpf.BorderGrid   5      �� 5      $
��Auto �6$   64   �� 5      6&    � ColumnDefinitions 5!      �� 5"      $
��Auto �6'   66   �� 5#      6)   �� 5$      6)   �� 5%      6)   �� 5&      6)   �� 5'      6)   �� 5(      6)   �� 5)      6)   �� 5*      6)   �� 5+      6)   .+�5-      ��  �� TextAlignment$ Justify=�6   $��Center=�64   $��3q�6Q   Roller Diameter, D(mm)6t   �� 5.      $ Justify=�6   $��Center=�64   $��3q�6Q   $��1��6\   	Bearing6u   �� 5/      $ Justify=�6   $��Center=�64   $��3q�6Q   $��2��6\   	d1 (mm)6u   �� 50      $ Justify=�6   $��Center=�64   $��3q�6Q   $��3��6\   	D1 (mm)6u   �� 51      $ Justify=�6   $��Center=�64   $��3q�6Q   $��4��6\   B (mm)6t   �� 52      $ Justify=�6   $��Center=�64   $��3q�6Q   $��5��6\   L (mm)6t   �� 53      $ Justify=�6   $��Center=�64   $��3q�6Q   $��6��6\   	A1 (mm)6u   �� 54      $ Justify=�6   $��Center=�64   $��3q�6Q   $��7��6\   	A2 (mm)6u   �� 55      $ Justify=�6   $��Center=�64   $��3q�6Q   $��8��6\   	A3 (mm)6u   �� 56      $ Justify=�6   $��Center=�64   $��3q�6Q   $��9��6\   	A4 (mm)6u   �� 57      $��3q�6   $��1��6&   $��0��63   ��6C   �� $
 DiameterList� �� SelectedItem 6m   �� $
 D�6�   �� 58      $��3q�6   $��1��6&   $��1��63   ��6C   �� $
 BearingList� 6l   �� $
 Bearing�6�   �� 59      $��2��6   $��2q�6)   $��1��64   ���#E0E0E0._�5:      �� $��3q�6!   $��Center=�6,   $��Center=�6G   ��6d   �� *d1+6z   5;      �� 5<      $��3��6   $��2q�6)   $��1��64   ���#E0E0E0._�5=      �� $��3q�6!   $��Center=�6,   $��Center=�6G   ��6d   �� *D1+6z   5>      �� 5?      $��4��6   $��2q�6)   $��1��64   ���#E0E0E0._�5@      �� $��3q�6!   $��Center=�6,   $��Center=�6G   ��6d   �� *B+6y   5A        5B      $��1��6%   $��5��62      MinValue$ 0X�6�   $��3q�6�   ��6B   �� $
 L� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�     5C      $��1��6%   $��6��62   $ 0X�6�   $��3q�6�   ��6B   �� $
 A1�$ PropertyChanged=� . 6�     5D      $��1��6%   $��7��62   $ 0X�6�   $��3q�6�   ��6B   �� $
 A2�$ PropertyChanged=� . 6�   �� 5F      $��2q�6   $��8��6%   $��1��65   ���#E0E0E0._�5G      �� $��3q�6!   $��Center=�6,   $��Center=�6G   ��6d   �� *A3+6z   5H        5I      $��1��6%   $��9��62   $ 0X�6�   $��3q�6�   ��6B   �� $
 A4�$ PropertyChanged=� . 6�   5J      5K      �� 5L   
   $��2��6   $��/Data/1.PNG��6   5N      �� 5O   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5P      �� -   5        $��3q�5P      $
��20,2q�6    {�6/   �� $
 IsValid�.��6g   OK6k   5Q      5R      5S      