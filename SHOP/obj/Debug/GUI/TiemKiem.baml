   M S B A M L   `   `   `  ����?  ;SHOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SHOP.GUISHOP.GUI  5      #clr-namespace:SHOP.BUSSHOP.BUS  5          SHOP.GUI.TiemKiem   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:SHOP.GUI     5      $mclr-namespace:SHOP.BUS     5      -   5          � 	Resources  5        SHOP.BUS.Pages   dbForWd  	ProductDT �� CornerRadius �� Path �� RelativeSource �� Mode �� AncestorType � RowDefinitions �� TextAlignment �� StringFormat��%�  &	        &	        5   
   6$   �� 5   
   .R�5      � 
�������.+�5      �� $	��250��6   $��2q�6%   $��1q�60   
���  ��$ 4��6V   ��6g   �� $ 
Background� �� $ FindAncestor=�" ��._�5      � $��3q�6    5      �� 5      �� 5      �� 5      .+�5      �� $	��200��6    $	��100��6,   ��69   �� $
 Hinh��� 5      $��16(�6$   
����  �$��Center=�6D   $ Center=�6a   $��1��6x   $
��Bold"�6�   ��6�   �� $ TenSP��� 5      
���  ��$��Center=�65   $ Center=�6R   $��2��6j   ��6w   �� $ GiaSP�$ Giá :{0:0,0 VNĐ}��5      5      5      5      5      .��5      � 
�������	 � ColumnDefinitions	 5   
   �� 5       $	��71* �6   �� 5!      $	��29* �6    5#   
   �� 5$      �� 5%      $	��100 �6   .+�5'   
   �� 
������ $��3��60   $��0,8,0,0q�6@   $��Hidden=�6Q   .��5(      �� -   5        $��hidden4��5(      
���W�.�$��1q�6<   
 �� Padding$
 5q�6P   ._�5)      �� .+�5+      ��  K� ZIndex$ 3��6"   $��3��63   .+�5,      � $��0,10,0,0q�6$   .+�5-      �� -   5        $��
txtTimKiem��5-   s   $��0q�6&   $��Center=�6�   $��18(�6�   $��Tekton Pro Cond)�6�   $
��Bold"�6�   $
��Left=�6�   $��30��6�   $	��200��6  6  �� 5.      -   5        $��	btnSearch��5.   9   $��0q�6%    � ToolTip$ Tìm Kiếm��6b   $��30��6v   $��30��6�   .��5/   "   �� $��30��6)   $��30��64   $%��/SHOP;component/img/timkiem.png��6@   6k   50      51      52      9� 55       9� ExpandDirection$
 Down=�6    9� 
IsExpanded . $
��auto��6H   ��56      �� 57      $��19(�6)    �� Padding$ 4q�67   $��.VnUniverse)�6C   
���**��$	��178��6o   $��22��6{   LOẠI SẢN PHẨM6�   .��59      �� $��10,4,0,0q�6%   .+�5:      �� -   5         ��Name$ 	ListDSLSP��5:   p   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6?   $��2q�6d   $��Disabled=�6�   ��6'   �� ��5;   "   �� 5<   &   .R�5=   *   �� $��checkLoaiSP��63    d� 	IsChecked$
 TrueY�6F   $��4q�6W   
���2�2�
 � Tag 6y   �� $ MaLoaiSP���6�   �� $ 	TenLoaiSP�6�   5>   '   5@      �� 5A      -   5        $��btnLocDSLSP��5A   Q   
����� �$
��auto��6d   $
��auto��6r   .��5B   "   �� $
��Bold"�6,   
����  �$ Center=�6T   $
��Left=�6k   $��Center=�6�   $��Lọc Danh Sách��6�   6�   5C      5D      5E      9� 5G      $
 Down=�6    . $
��auto��6H   ��5H      �� 5I      $��19(�6)   $ 4q�67   $��.VnUniverse)�6C   
���**��$	��143��6o   $��22��6{   HÃNG SẢN XUẤT6�   .��5K      �� $��10,4,0,0q�6%   .+�5L      �� -   5        $ 	ListDSNSX��5L   p   $
 TrueY�6?   $��2q�6d   $��Disabled=�6�   ��6'   �� ��5M   "   �� 5N   &   .R�5O   *   �� $��checkHangSX��6D   $
 TrueY�63   $��Center=�6z   $��4q�6�   
���2�2� 6W   �� $ 	TenHangSX� 6�   �� $ MaHangSX�.��5P   .   � .+�5Q   2   �� $��0,-5,0,0q�68   $��80��6J   $��30��6U   ��6a   �� $
 Logo�6�   �� 5R   2   $ Center=�6>   ��6U   �� $ 	TenHangSX�6w   5S   /   5T   +   5U   '   5W      �� 5X      -   5        $��btnLocDSHSX��5X   Q   
����� �$
��auto��6d   $
��auto��6r   .��5Y   "   �� $
��Bold"�6,   
����  �$ Center=�6T   $
��Left=�6k   $��Center=�6�   $��Lọc Danh Sách��6�   6�   5Z      5[      5\      5]      5^      5_      �� 5a   
   -	   5        $	��lst��5a      $��Stretch=�65   #��[ 6Z   $��0,0,1,0q�6�   ��6   �� ��5c      �� 5d      .R�5e      A�  A� Columns$ 3��6"   5f       �� 
GroupStyle 5h      (  "System.Windows.Controls.GroupStyle  5i         HeaderTemplate 5j      �� 5k      .R�5l      �� $
��Bold"�6C   
�������
������$��0,5,0,0q�6�   $ 3q�6�   ��6(   �� $
 Name�6�   5m      5o      5z      � 5{   
   $��1��6   $��2��6   	 5|      �� 5}      �� 5~      .+�5�      � $	��200��6   $��Center=�6(   $	��Top=�6E   $��10,-23,10,0q�6]   $	��430��6r   .+�5�      �� $	��200��6   $	��373��6,   $��78��68   .+�5�      � $y�Hidden=�6    $��Center=�64   .+�5�      �� $
��Bold"�6$   $��20(�67   
����  �$��30��6W   �� 6d   $�Trang��6h   6x   �� 5�      -
   5         ��Name$ 	btnInPage��5�   �   
����+��$��1q�6;   
����  �$
��Bold"�6e   $��15(�6w   
������  �� TextAlignment$ Center=�6�   $��5,0,3,0q�6  $��25��6/  $��22��6:  ��6�   �� *	CurPage+ �� Source# [  6:  �� 5�      $ -1��6!   
���  ��$��10q�6G    J� RenderTransformOrigin$ 0.5,0.5&�6\   $��34��6|   $��1��6�   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &    �� Angle$ 11.829Q�66   T� 5�   &   5�   #   5�      �� 5�      -   5        $ txtTotal��5�   "   
��� d �$
��Bold"�6K   $��15(�6^   
������ $��0q�6�    �� 
IsReadOnly . $��0,0,0,0q�6�   $��12��6�   $��20��6  ��6�   �� *	TotalPage+# [  6  5�      � 5�      $��	0,10,0,50q�6!   $��Center=�64   $��Center=�6O   .+�5�      �� -   5         ��Name$ btnPrev��5�   !   $��30��6H   $��30��6T   $
��Prev��6_   $��0,0,3,0q�6n   �� 5�      -   5        $ 
ListButton��5�   �   $��0q�6#   $��Disabled=�67   $
 TrueY�6�   
������ ��6k   �� ��5�      �� 5�   "   .R�5�   &   � $	��400��60   5�   #   ��5�      �� 5�   "   .R�5�   &   �� $ 	btnNumber��6e   -   5        $��Center=�5�   -   $��Center=�6H   $��0,0,3,0q�6�   $��25��6�   $��25��6�   ��6�   �� *I+6�   5�   #   5�      �� 5�      -   5        $ btnNext��5�   !   $��30��6H   $��30��6T   $
��Next��6`   5�      5�      5�      � 5�      $��1��6   .+�5�      �� -   5        $��btnSort��5�   $   $��5q�6   .��6I   
Sort Price6U   �� 5�      -   5        $��btnGroup��5�   $   $��5q�6   .��6K   Group6R   5�      5�      5�      5�      