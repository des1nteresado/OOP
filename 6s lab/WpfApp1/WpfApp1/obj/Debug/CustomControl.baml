   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.CustomControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        � 	Resources  5         CheckBoxStyle1 �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty	 O� KeyTime
 O� Value p� KeyTime p� Value ]�Name J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat ��Name �� CornerRadius J� RenderTransformOrigin �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y �� EndPoint �� 
StartPoint � Color � Offset �� Triggers  P� Property! P� Value" N� ExitActions# ��Name  OnUnchecking$ N� EnterActions  
OnChecking��%�  &	        7  7  �� 5	   
   " ��6'   .�5
      ��  � ��# � ��6+   �� 5       � ��# � ��6+   �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      
OnChecking .��5   "   U� $ 00:00:00X�6@   $ slider��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6t   .\�5   &   �� $	 00:00:00.3000000��6;   $
 25Q�6V   5   #   5      �� 5      OnUnchecking .��5   "   U� $ 00:00:00X�6@   $ slider��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6t   .\�5   &   �� $	 00:00:00.3000000��6;   $
 0Q�6V   5   #   r� 5   "   $ 00:00:00X�6C   $ slider��6X   $ (FrameworkElement.Margin)�6w   .	�5   &   �� $ 00:00:00.3000000��6>   $ 1,1,1,1q�6Y   5   #   5      5      .R�5      ]� $ 	dockPanel��6$   .+�5       �� # z 6/   #��z��6k   # z 6�   #��z��6�   ��. $��Center=�6  � 5!      $��5,5,0,5q�6#   $��50��64   ���	#FFC0CCD9.+�5"   "   �� $��ON��6,   $
��Wrap=�66   $
��Bold"�6J   $��12(�6\   $��Right=�6j   $��0,0,3,0q�6�   �� 5#   "   $
��Left=�6,   $��2,0,0,0q�6G   $��12(�6X   $
��Bold"�6f   $	��OFF��6x   $
��Wrap=�6�   �� 5$   "   $ slider��6D   $
��Left=�6)   $��23��6T   $��1,1,1,1q�6_   $ 3,3,3,3��6y   $ 0.5,0.5&�6�   $��1,1,1,1q�6�   z�5%   &   V� 5&   *   .~�5'   .   �� $ 1Q�6=   $ 1Q�6H   �� 5(   .   $ 0Q�6<   $ 0Q�6G   �� 5)   .   $ 0Q�6>   T� 5*   .   $ 0Q�6A   $ 0Q�6G   5+   +   ��5-   &   �� 5.   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5/   .   � $ 	#FFFFFFFF��6;   $ 0Q�6M   � 50   .   $ 	#FF4490FF��6;   $ 1Q�6M   51   +   ��53   &   �� 54   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��55   .   � $ 	#FF8AB4FF��6;   $ 1Q�6M   � 56   .   $ 	#FFD1E2FF��6;   $ 0Q�6M   57   +   59   #   5:      5;       5=      P� 5>        �@d�	IsChecked$
! TrueY�6;   " 5?   "   �� 5@   &   $"# OnUnchecking_BeginStoryboard��6a   8��  $ 5B   "   �� 5C   &   $ # OnChecking_BeginStoryboard��6_   8�� 5E      P� 5F        � {�! .  . �5G   "   �� # � ��6?    � ��5H      5J      5L      5M      5N      .��5O      � .+�5P   
   �� -   5        % ��Name$% 
styleCheck��5P      #���   6'   5R      5S      