   M S B A M L   `   `   `  ����F  BMachenicWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MachenicWpfMachenicWpf  5	      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5
      $    MachenicWpf.Controls.PageOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Y UXceed.Wpf.DataGrid, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5      %localclr-namespace:MachenicWpf  5	      H	compModel8clr-namespace:System.ComponentModel;assembly=WindowsBase  5
      
���   �$��1q�5   "   .��5      � $��5q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�52   
   �� $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�53      �� -   5        $��5q�53      $
��10,3q�6    .��6F   Create a new order6Z   54      (  "Xceed.Wpf.DataGrid.DataGridControl  55   
   -   5          Name$ 	OrderGrid��56   B   $��4��55         AutoCreateColumns .     ReadOnly . ��56      ��  �� Path$ .Orders� � 	Resources 57         ActionButton  
DateFormat �� StringFormat��%�  &	        &	 �    �� 58      .R�59      �� $ 
Horizontal=�6!   $��Right=�6:   .+�5:      �� -   5        $
��10,0q�5:   !   $��2q�60   ��6O   �� $ .�.��6s   Edit6y   �� 5;      -   5        $
��10,0q�5;   !   $��2q�60   ��6Q   �� $ .�.��6u   Delete6}   �� 5<      -   5        $
��10,0q�5<   !   $��2q�60   ��6U   �� $ .�.��6y   	Drawing6�   5=      5>      �� 5?      .R�5@      �� ��6    �� $ .�$ 
MM/dd/yyyy��6S   5A      5B         Columns 5C        Xceed.Wpf.DataGrid.Column  5E      #  Xceed.Wpf.DataGrid.ColumnBase	   	FieldName$	 OrderNo��6   
   Width8  2Xceed.Wpf.DataGrid.Converters.ColumnWidthConverter$
 60 62      Title$ Order No��6=   6P     5F      $	 CustomerName��6   $ Customer��67   6J     5G      $	 Address��6   $ Address��62   6D     5H      $	 DrawingTypeDisplay��6   $
 Type��6=   6L     5I      $	 Quantity��6   $
 80 63   $ Quantity��6>   6Q     5J      $	 FromDate��6   $	
 100 63      CellContentTemplate# [ 6?   $ 	From Date��6q   6�     5K      $	 ToDate��6   $	
 100 61   # [ 6=   $ To Date��6o   6�     5L      $	 RemainingDate��6   $	
 100 68   $ Remaining Day��6D   6\     5N      $	 Finish��6   $ Finish��61   6B     5O      $	 ID��6   $	
 200 6-   $ Modify��69   # [  6H   6   5R      �� 5S   
   $��5��6   $��0, 10q�6!   $
��Bold"�60   Specification of Material5U      � 5V   
   $��6��6    � DataContext 6   �� $ SelectedOrder�  5W      �� 5X      $
��Auto �6    60   �� 5Y      $��* �6    6-   .+�5[         MachenicWpf.BorderGrid  $��0,5,0,0q�6     5\      �� 5]      6&    � ColumnDefinitions 5_      �� 5`      $��30 �6'   64   �� 5a      6)   �� 5b      $��90 �6'   64   �� 5c      $��90 �6'   64   �� 5d      $��90 �6'   64   �� 5e      $��90 �6'   64   �� 5f      $��90 �6'   64   .+�5h      �� $��1��6   $��Center=�6)   $
��Bold"�6F   $��0��6X   No.6m   �� 5i      $��1��6   $��Center=�6)   $
��Bold"�6F   $��1��6X   Name6n   �� 5j      $��1��6   $��Center=�6)   $
��Bold"�6F   $��2��6X   Length (mm)6u   �� 5k      $��1��6   $��Center=�6)   $
��Bold"�6F   $��3��6X   
Quantity6r   �� 5l      $��1��6   $��Center=�6)   $
��Bold"�6F   $��4��6X   Weight (kg)6u   �� 5m      $��1��6   $��Center=�6)   $
��Bold"�6F   $��5��6X   Unit cost ($)6w   �� 5n      $��1��6   $��Center=�6)   $
��Bold"�6F   $��6��6X   Cost6n   5p      �� 5q      $��1��6   $��Stretch=�6J   ��6#   �� $ 	Materials���5r      �� 5s      .R�5t      � $��1q�6    5u      �� 5v   "   $��24 �63   6@   �� 5w   "   65   �� 5x   "   $��90 �63   6@   �� 5y   "   $��90 �63   6@   �� 5z   "   $��90 �63   6@   �� 5{   "   $��90 �63   6@   �� 5|   "   $��84 �63   6@   .+�5~      �� $
��Left=�6(   ��6C   �� $ Id�6^   �� 5      $��1��6(   ��68   �� $ DisplayName�6\   �� 5�      $��Center=�6(   $��2��6E   ��6U   �� $ Length�6t   �� 5�      $��Center=�6(   $��3��6E   ��6U   �� $ Quantity�6v   �� 5�      $��Center=�6(   $��4��6E   ��6U   �� $ Weight�6t   �� 5�      $��Center=�6(   $��5��6E   �� 5�   "   ��6,   �� $ UnitCost�6M   /�� 6Y   ��6c   �� $
 Unit�6�   5�      �� 5�      $��Center=�6(   $��6��6E   ��6U   �� $
 Cost�6r   5�      5�      5�      5�      �� 5�   
   $��7��6?   $��5q�6L    6   �� $ SelectedOrder�TOTAL COST OF A ROLLER: �� 6q   ��6{   �� $ Total�6�   $6�   �� 5�   
   $��8��6?   $��5q�6L    6   �� $ SelectedOrder�TOTAL COST OF ORDER �� 6m   ��6w   �� $ OrderNo�6�   : �� 6�   ��6�   �� $ 
TotalOrder�6�   $6�   5�      5�      