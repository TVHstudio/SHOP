   M S B A M L   `   `   `  ����?  ;SHOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SHOP.GUISHOP.GUI  5          SHOP.GUI.SPBanChay   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:SHOP.GUI     5      .��5      �� ���#E6E6FA
���**��$��2q�68   ��5   
   � 5      .+�5      ��   �� Padding$  5q�6   
���**��$��DemiBold"�6=   $��20(�6S   $��.VnUniverse)�6a   $!��10 SẢN PHẨM BÁN CHẠY��6z   $��44��6�   ��5      �� 5       �� 
TargetType" ��6!    �� 	Resources 5         FadeStoryboard �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior g� AutoReverse��%�   &	        �� 5   "   .��5   &   W� $ (TextBlock.Opacity)�66   $ 0X�5   !   $ 1X�6*   $ 0:0:0.5D�61   $ Forever��5   !    . 6:   5   #   5      	 �� Triggers	 5      P� 5   "   
 P� Property
 � y� P� Value$ Visible=�6@    N� EnterActions 5   &   �� 5   *   #��[  6:   5   #   5       5"      �� 5#      $"��/SHOP;component/img/hot2.gif��6   5$      .��5&   
   �� -   5         ��Name$ stpanel��5&   .   $��5��6   $��5��6    $
��Auto=�5'   )   
������ $��0q�5)   '   $��0,0,8,0q�6S   ��6;   ��  � ContextMenu 5,      �� 5-      $	��200��6   
����� �$
��Bold"�6<   .@�5.      m� -   5        $��Đặt Hàng��5.      61   m� 5/      -   5        $��Refresh��5/      60   �� 50      m� 51      $��
Chi tiết��6    52      ��57      �� 58      .R�59      �� 
�������
����  �$��1q�6G    �� CornerRadius$ 5��5:   -   $��1q�6?    � ToolTip 6J   Z� ._�5;      �� $	��130��6%   $	��200��61    �� Orientation$ Vertical=�6>   
�������.+�5?      � .+�5@   "   ��  ��Name$ txtbloc��6@   $y�Hidden=�6,   $��3q�6z   ��6R   ��  �� Path$
 MaSP� �� Mode$ OneWay=�6z   �� 5A   "   -   5        $��91��5A   )   
�������.��5B   &   �� $(��"/SHOP;component/img/buttonoder.png��6,   5C   #   5D      �� 5E      $��0,1,0,0q�6B   $	��200��6S   $	��100��6_   ��6%   �� $
 Hinh� 5F   "   _� 5G   &   .��5H   *   ��  �� TextAlignment$
 Left=�6R   $	��250��6h   $	��300��6w   $��WrapWithOverflow=�6�   ��64   �� $ ChiTiet�6�   5I   '   5K      �� 5L      $
��Wrap=�6(   
����  �$��14(�6N   $ Center=�6y   $	��150��6�   $��45��6�   ��6]   �� $ TenSP�6�   �� 5M      
���  ��$ Center=�6r   $	��150��6�   $��30��6�   ��69   �� $ GiaSP� �� StringFormat$ {0:0,0 VNĐ}��6�   5O      5P      5Q       � 	Resources 5U       ]� 
Conditions �� Property �� Value �� Property �� Value��%�  '��       '�� �     �� 5V      " ��6   	 5W      ]� 5X       5Y      �� 5Z   "    �@J�IsMouseOver . 6J   �� 5[   "    �@��
IsSelected .  6B   ./�5]      ��  � ��
 � ���6;   5^      5`      �� 5a      " ��6   	 5b      P� 5c      
 �@��HasItems .  . �5d      ��  � �� 5e   "   �� 5f   &   .R�5g   *   �� 
����  �$��22(�6G   $��SimSun)�6U   KHÔNG CÓ SẢN PHẨM6|   5h   '   5j      5k      5m      5n      ��5o      �� 5p      .R�5q      � ��6    �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5r      �� *(ListView.View).ItemWidth+ �� $ ListViewL���5s      �� *	ItemWidth+ �� *Self+  � 
ItemHeight  5t      �� *(ListView.View).ItemHeight+ �� $ ListViewL�5u      5w      5x      5z      