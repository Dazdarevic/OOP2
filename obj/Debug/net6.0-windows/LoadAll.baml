   M S B A M L   `   `   `  ����N  JOneTimePadAlgorithm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OneTimePadAlgorithmOneTimePadAlgorithm  5      !    OneTimePadAlgorithm.LoadAll   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:OneTimePadAlgorithm     5      Y UFontAwesome.Sharp, Version=5.15.4.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5        N� 
Background
  �����$��Visible=�5
       N� Title$ LoadAll��5      .��5      �  � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      .+�5   
   �� $��0��6   
�������._�5      �  � ColumnDefinitions 5      �� 5      $	��766 �6'   �� 5      $��* �6'   .+�5      �� $��0��6   ._�5      �� .+�5      �� -   5         ��Name$ btnHome��5   !   $��70��5      $��0,15,0,0q�5      
������ 
������ $��Right=�5       $��60��5!      $��Center=�6%    � Cursor$
 Hand��5$      .��5&      �� $��Center=�6)   $��Right=�6D   .+�5'   "   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=5.15.4.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6/   $��20��6;      
Foreground
 ��+��5(   /   �� 5)   "   $
��Home��6,   $��Center=�5*   $   $��15(�5+   $   5,      5-      5.      5/      �� 50      $��1��6   ._�51      �� .+�52      �� -   5        $ 	btnLogout��52   !   $��15q�53      $��70��54      
������ 
������ $��Right=�57      $��60��58      $��Center=�6%   $
 Hand��5:      .��5<      �� $��Center=�6)   $��Right=�6D   .+�5=   "     $ PowerOff=�6/   $��20��6?   
 �����6J   �� 5>   "   $��Log out��6,   $��Center=�5?   $   $��15(�5@   $   5A      5B      5C      5D      5E      5F      �� 5G   
   $��1��6   
�������._�5H      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5H      	   
IsReadOnly$
	 True��6)   $
   HorizontalScrollBarVisibility$
 Hidden=�5I   #   "   VerticalScrollBarVisibility$ Visible=�5J   #      RowBackground
 �����   AlternatingRowBackground
 ��ح�$��56,46,56,33q�5M   #   $	��600��68      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 5N   #   $��Center=�5O   #   $��12(�5P   #   
���   �$��Normal$�5R   #   $��Medium&�5S   #   $��Regular"�5T   #   5V      5W      5X      