   M S B A M L   `   `   `  ����?  ;SHOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SHOP.GUISHOP.GUI  5          SHOP.GUI.SPCungLoai   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:SHOP.GUI     5      .��5	      � 
�������.+�5
   
   9�   9� ExpandDirection$
  Down=�6    9� 
IsExpanded . 
���**��$��2q�6P   
���������5      � 5      .+�5      ��  �� Padding$ 5q�6!   
����  �$��DemiBold"�6@   $��20(�6V   $��.VnUniverse)�6d   $!��5 SẢN PHẨM CÙNG LOẠI��6}   ��5      �� 5       �� 
TargetType" ��6%    �� 	Resources 5   "      FadeStoryboard �� TargetProperty W� From	 W� To g� Duration	 g� RepeatBehavior
 g� AutoReverse��%�   &	        �� 5   &   .��5   *   W� $ (TextBlock.Opacity)�6:   $ 0X�5   !   $ 1X�6*   $ 0:0:0.5D�61   $	 Forever��5   !   
 . 6:   5   '   5   #    �� Triggers 5   "   P� 5   &    P� Property � y� P� Value$ Visible=�6D    N� EnterActions 5   *   �� 5   .   #��[  6>   5   '   5      5       5"      .��5$      �� -   5         ��Name$ stpanel��5$   2   $��5��6   $��5��6$   $
��Auto=�5%   )   
������ $��0q�5'   '   $��
0,-2,-2,-5q�6S   ��6;   ��  � ContextMenu 5*      �� 5+      $	��200��6"   
����� �$
��Bold"�6@   .@�5,      m� -   5        $��Đặt Hàng��5,   #   65   m� 5-      -   5        $��Refresh��5-   #   64   �� 5.      m� 5/      $��
Chi tiết��6$   50      ��55      �� 56      .R�57      �� 
�������
����  �$��2q�6K    �� CornerRadius$ 5��58   -   $��8q�6?    � ToolTip 6J   Z� ._�59      �� $	��160��6*   $	��200��66    �� Orientation$ Vertical=�6C   
�������.+�5=   "   � .+�5>   &   ��  ��Name$ txtbloc��6D   $y�Hidden=�60   $��3q�6~   ��6V   ��  �� Path$
 MaSP� �� Mode$ OneWay=�6~   �� 5?   &   -   5        $��91��5?   -   
�������.��5@   *   �� $(��"/SHOP;component/img/buttonoder.png��60   5A   '   5B   #   �� 5C   "   $��0,1,0,0q�6F   $	��200��6W   $	��100��6c   ��6)   �� $
 Hinh� 5D   &   _� 5E   *   .��5F   .   ��  �� TextAlignment$
 Left=�6V   $	��250��6l   $	��300��6{   $��WrapWithOverflow=�6�   ��68   �� $ ChiTiet�6�   5G   +   5I   #   �� 5J   "   $
��Wrap=�6,   
����  �$��14(�6R   $ Center=�6}   $	��150��6�   $��45��6�   ��6a   �� $ TenSP�6�   �� 5K   "   
���  ��$ Center=�6v   $	��150��6�   $��30��6�   ��6=   �� $ GiaSP� �� StringFormat$ {0:0,0 VNĐ}��6�   5M      5N      5O       � 	Resources 5S       ]� 
Conditions �� Property �� Value �� Property �� Value��%�  '��       '�� �     �� 5T      " ��6    5U      ]� 5V       5W   "   �� 5X   &    �@J�IsMouseOver . 6N   �� 5Y   &    �@��
IsSelected .  6F   ./�5[   "   ��  � ��
 � ���6?   5\      5^      �� 5_      " ��6    5`      P� 5a       �@��HasItems .  . �5b   "   ��  � �� 5c   &   �� 5d   *   .R�5e   .   �� 
����  �$��22(�6K   $��SimSun)�6Y   KHÔNG CÓ SẢN PHẨM6�   5f   +   5h   #   5i      5k      5l      ��5m      �� 5n      .R�5o      � ��6$   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��   �� AncestorType$  ScrollContentPresenterL�! � 	ItemWidth! 5p      �� *(ListView.View).ItemWidth+ �� $  ListViewL���5q      �� *	ItemWidth+ �� *Self+" � 
ItemHeight" 5r      �� *(ListView.View).ItemHeight+ �� $  ListViewL�5s      5u      5v      5w      5x      