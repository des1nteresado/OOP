   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $��816.33��6)   .��5	      � 
����ح� � ColumnDefinitions 5
   
   �� 5      $
��882* �6   �� 5      $
��145* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      .+�5   
   o� $��0��6   
�������$��12(�6.   $��2��6<   $��0,0,0.4,295.8q�6P   $��2��6g   .@�5#      m� -   5        $��О программе��5#      6,   5$      �� 5&   
   -   5         ��Name$ deleteButton��5&      $
��Left=�6(   $	��Top=�6C   $��Удалить��6[   $��75��6�   $��169,48.2,0,0q�6�   $��1��6�   �� 5'   
   -   5        $ updateButton��5'      $��Обновить��6'   $��492,34.2,101.2,214.8q�6U   $��1��6s   �� 5(   
   -   5        $��button4��5(      $��
назад��6    $
��Left=�60   $��285,48.2,0,0q�6K   $��1��6a   $	��Top=�6n   $��75��6�   6�   �� 5)   
   -   5        $��button5��5)      $��вперед��6    $
��Left=�61   $��400,48.2,0,0q�6L   $��1��6b   $	��Top=�6o   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ 	BooksGrid��5,   /      AutoGenerateColumns .  $��33,100.2,39.6,9.8q�6B   $��1��6]   $��2��6j      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ УДК��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6J   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *UDK+6J     5/      $ Название��6>   $ 80 6P   	 6%   �� *Name+6P     50      $ 
Автор��6@   $ 80 6O   	 6%   �� *Author+6O     51      $ Кол. страниц��6?   $ 90 6U   	 6%   �� *Pages+6U     52      $ Год издания��6>   $ 80 6S   	 6%   �� *Year+6S     53      $	 DVD��6=   $ 50 6J   	 6%   �� *DVD+6J     54      $ CD��6<   $ 50 6H   	 6%   �� *CD+6H     55      $ Издательство��6B   $	 100 6X   	 6%   �� *
Pubhouse+6X     56      $% Дата поступления��6>   $	 120 6X   	 6%   �� *Date+6X   5@      5C      5D      