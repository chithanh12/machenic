   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  5	       MachenicWpf$   MachenicWpf.Controls.StockPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      @d2http://schemas.microsoft.com/expression/blend/2008      5      X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Y UXceed.Wpf.DataGrid, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5      H	compModel8clr-namespace:System.ComponentModel;assembly=WindowsBase  5	      
���   �$��1q�5
   "   .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��5 �6   6)   �� 5      $��2* �6   6*   .+�5   
   �� $��80��6   $��Filter��6    � DataContext 6/   ��  �� Path$ 	.Criteria�.��5      �   5      �� 5      $
��Auto �6$   64   �� 5      $��5 �6$   61   �� 5      $��* �6$   61    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5       $��* �6'   63   �� 5!      $
��Auto �6'   66   �� 5"      $
��Auto �6'   66   .+�5$      �� $��5q�6    �� Padding$ 
10, 5,10,5q�6'   	StockName6G   �� 5%      $��1��6   $��3q�6*   $��5q�66    �� AcceptsReturn .  ��6A   �� $ OrderNo�6w   �� 5'      $��5q�6   $��2��6'   $ 
10, 5,10,5q�67   
Quantity6V   $  Xceed.Wpf.Toolkit.DoubleUpDown  5(      -   5          Name$ txtQuantity��5(   5   $��3��6%      AllowInputSpecialValues$	 Any=�5)      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ClipValueToMinMax .  	   ShowButtonSpinner	 . 
   	AllowSpin
 . ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .    
IsReadOnly .     MouseWheelActiveOnFocus . �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�50         Maximum$	 999X�51         Minimum$ 1X�52      %   DisplayDefaultValueOnEmptyText .     ButtonSpinnerLocation$ Right=�54      �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$	 Any=�55         	Watermark$ 
Enter Text��56         Value 57      �� $ Quantity��� 58      -   5        $��
10, 5,10,5q�58      $��5q�6.   $��6��6L   .��6\   Search6d   5:      5;      �� 5<   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5=      �� -   5        $��5q�5=      $
��10,3q�6    .��6I   Create New Material6^   5>      (  "Xceed.Wpf.DataGrid.DataGridControl  5?   
   -   5          Name$ 	_dataGrid��5?   F   $��4��6      AutoCreateColumns .     ReadOnly . ��5@      �� $ .Orders� � 	Resources 5A         ActionButton  
DateFormat �� StringFormat��%�  &	        &	 +    �� 5B      .R�5C      �� $ 
Horizontal=�6!   $��Right=�6:   .+�5D      �� -   5        $
��10,2q�5D   !   $��2q�60   ��6R   �� $ .�.��6v   Edit6|   �� 5E      -   5        $
��10,2q�5E   !   $��2q�60   ��6T   �� $ .�.��6x   Delete6�   5F      5G      �� 5H      .R�5I      �� ��6    �� $ .�$ 
MM/dd/yyyy��6S   5J      5K         Columns 5L        Xceed.Wpf.DataGrid.Column  5N      #  Xceed.Wpf.DataGrid.ColumnBase   	FieldName$ Material��6      Width8	  2Xceed.Wpf.DataGrid.Converters.ColumnWidthConverter$ 60	 63      Title$ Order No��6>   6Q     5O      $
 Unit��6   $
 Unit��6/   6>     5P      $
 Size��6   $ Size/Length��6/   6E     5Q      $ Quantity��6   $ Quantity��63   6F     5R      $ ID��6   $ Modify��6-       CellContentTemplate#  [  6<   6s   5U      5W      5X      