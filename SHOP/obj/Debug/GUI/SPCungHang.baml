   M S B A M L   `   `   `  ����?  ;SHOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SHOP.GUISHOP.GUI  5          SHOP.GUI.SPCungHang   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:SHOP.GUI     5      .��5      � 
�������.+�5   
   9�   9� ExpandDirection$
  Down=�6    9� 
IsExpanded . 
�������
���**��$��2q�6c   ��5      � 5      .+�5      ��  �� Padding$ 5q�6!   
���**��$��DemiBold"�6A   $��20(�6W   $��.VnUniverse)�6e   $ ��5 SẢN PHẨM CÙNG HÃNG��6~   
���������5      �� 5       �� 
TargetType" ��6%    �� 	Resources 5   "      FadeStoryboard �� TargetProperty W� From	 W� To g� Duration	 g� RepeatBehavior
 g� AutoReverse��%�   &	        �� 5   &   .��5   *   W� $ (TextBlock.Opacity)�6:   $ 0X�5   !   $ 1X�6*   $ 0:0:0.5D�61   $	 Forever��5   !   
 . 6:   5   '   5   #    �� Triggers 5   "   P� 5   &    P� Property � y� P� Value$ Visible=�6D    N� EnterActions 5   *   �� 5   .   #��[  6>   5   '   5!      5#      5%      .��5'      �� -   5         ��Name$ stpanel��5'   2   $��5��6   $��5��6$   $
��Auto=�5(   )   
������ $��0q�5*   (   ��6<   ��  � ContextMenu 5-      �� 5.      $	��200��6"   
����� �$
��Bold"�6@   .@�5/      m� -   5        $��Đặt Hàng��5/   #   65   m� 50      -   5        $��Refresh��50   #   64   �� 51      m� 52      $��
Chi tiết��6$   53      ��58      �� 59      .R�5:      �� 
�������
����  �$��2q�6K    �� CornerRadius$ 5��5;   -   $��8q�6?    � ToolTip 6J   Z� ._�5<      �� $	��160��6*   $	��200��66    �� Orientation$ Vertical=�6C   
�������.+�5@   "   � .+�5A   &   ��  ��Name$ txtbloc��6D   $y�Hidden=�60   $��3q�6~   ��6V   ��  �� Path$
 MaSP� �� Mode$ OneWay=�6~   �� 5B   &   -   5        $��91��5B   -   
�������.��5C   *   �� $(��"/SHOP;component/img/buttonoder.png��60   5D   '   5E   #   �� 5F   "   $��0,1,0,0q�6F   $	��200��6W   $	��100��6c   ��6)   �� $
 Hinh� 5G   &   _� 5H   *   .��5I   .   ��  �� TextAlignment$
 Left=�6V   $	��250��6l   $	��300��6{   $��WrapWithOverflow=�6�   ��68   �� $ ChiTiet�6�   5J   +   5L   #   �� 5M   "   $
��Wrap=�6,   
����  �$��14(�6R   $ Center=�6}   $	��150��6�   $��45��6�   ��6a   �� $ TenSP�6�   �� 5N   "   
���  ��$ Center=�6v   $	��150��6�   $��30��6�   ��6=   �� $ GiaSP� �� StringFormat$ {0:0,0 VNĐ}��6�   5P      5Q      5R       � 	Resources 5V       ]� 
Conditions �� Property �� Value �� Property �� Value��%�  '��       '�� �     �� 5W      " ��6    5X      ]� 5Y       5Z   "   �� 5[   &    �@J�IsMouseOver . 6N   �� 5\   &    �@��
IsSelected .  6F   ./�5^   "   ��  � ��
 � ���6?   5_      5a      �� 5b      " ��6    5c      P� 5d       �@��HasItems .  . �5e   "   ��  � �� 5f   &   �� 5g   *   .R�5h   .   �� 
����  �$��22(�6K   $��SimSun)�6Y   KHÔNG CÓ SẢN PHẨM6�   5i   +   5k   #   5l      5n      5o      ��5p      �� 5q      .R�5r      � ��6$   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��   �� AncestorType$  ScrollContentPresenterL�! � 	ItemWidth! 5s      �� *(ListView.View).ItemWidth+ �� $  ListViewL���5t      �� *	ItemWidth+ �� *Self+" � 
ItemHeight" 5u      �� *(ListView.View).ItemHeight+ �� $  ListViewL�5v      5x      5y      5z      5{      