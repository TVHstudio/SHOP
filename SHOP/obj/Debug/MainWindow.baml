   M S B A M L   `   `   `  ����?  ;SHOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SHOPSHOP  5   	   1clr-namespace:SHOP.UltilitiesSHOP.Ultilities  5   	       SHOP.MainWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SHOP     5   	   +uclr-namespace:SHOP.Ultilities     5   	   -   5        $��wd��5   &     � WindowState$  	Maximized=�5	   	    � WindowStartupLocation$ CenterScreen=�5   	   $��778.35��5   	   $
��1300��6    � 	Resources 5         btnT �� 
TargetType �� 
StartPoint �� EndPoint � Offset � Color J� RenderTransformOrigin	 8� X
 8� Y �� ScaleX �� CenterY  btnS��%`  &	        &	 �    �� 5   
   " ��6'   .R�5      � .+�5      A� $��outerCircle��6   #��z��5      #��z��5      ��5      �� 5      $
  0,0&�6.   $	 0,1&�6@   .��5      � $ 0Q�6+   $
 Blue��66   � 5      $ 1Q�6+   $	 Red��66   5      5      A� 5      #��z��6   #��z��5       5      8� 5      $	 .5Q�6    $
 .5Q�6'   60   z�5!      �� 5"      $ .8Q�6)   $ .8Q�65   6D   ��5$      �� 5%      $
  0,0&�6.   $	 0,1&�6@   .��5&      � $ 0Q�6+   $ White��66   � 5'      $ 1Q�6+   $ Transparent��66   5)      5,      �� 5-      $��Center=�6#   $��Center=�6@   6]   5.      5/      �� 50   
   " ��6'   .R�51      � .+�52      A� $��outerCircle��6   #��z��53      #��z��54      ��55      �� 56      $
  0,0&�6.   $	 0,1&�6@   .��57      � $ 0Q�6+   $ Beige��66   � 58      $ 1Q�6+   $ Coral��66   5:      5<      A� 5=      #��z��6   #��z��5>       5?      8� 5@      $	 .5Q�6    $
 .5Q�6'   60   z�5B      �� 5C      $ .8Q�6)   $ .8Q�65   6D   ��5E      �� 5F      $
  0,0&�6.   $	 0,1&�6@   .��5G      � $ 0Q�6+   � 5H      $ 1Q�6+   $ Transparent��66   5J      5M      �� 5N      $��Center=�6#   $��Center=�6@   6]   5O      5P      5R       J� CommandBindings 5X      )  #System.Windows.Input.CommandBinding  5Y   
   -   5           Command$ local:CustomCommands.Exit��5Y      5[      .��5]      �� -   5        $��	stackmain��5]      .+�5^   
   � -   5        $	��mai��5^      ��5_      �� 5`       �� ImageSource$( "/SHOP;component/img/traitimbay.gif��6    j� Stretch$
 Fill=�5a       j� TileMode$
 Tile=�6$    j� ViewportUnits$ Absolute=�5b       j� Viewport$ 0,0,300,200�6.    � Triggers 5e      :� 5f       :� RoutedEvent$ Loaded��6   .[�5g      �� .��5h      �� .��5i      �  �� TargetProperty$ Background.Viewport�6,   	 � To$ -200,0,80,50X�5j   $    g� Duration$ 0:0:50D�66    g� RepeatBehavior$ Forever��5k   $   5l      5m      5n       � ColumnDefinitions 5p      �� 5q      $��6 �6#   �� 5r      $	��180 �6#   �� 5s      �� 5t      �� 5u      �� 5v      �� 5w      �� 5x      �� 5y      �� 5z       � RowDefinitions 5|      �� 5}      $��27 �6    �� 5~      $	��121 �6    �� 5      $��4 �6    �� 5�      $
��130* �6    �� 5�      $
��132* �6    �� 5�      �� 5�      $
��131* �6    .+�5�      �� ���#F5DEB3$��8��6*   $��2��6:   ._�5�      � .+�5�      �� 6"   �� 5�      -   5        $��btnDN��5�   P   #��[  6   $��10,0,0,0q�6>   
���**��$	��100��6�   
����  �$��Đăng Nhập��6�   $��27��6�   �� 5�      -   5        $��btndk��5�   P   #��[  6   $��20,0,0,0q�6>   
���**��$��9��6q   $	��100��6�   
����  �$��
Đăng Ký��6�   $��27��6�   6�   5�      5�      �� 5�      $	��200��6   $��1��6!   $��2��61   $��10��6>   $��img\nenmuc.png��6S   6m   o� 5�      $��7��6   ���#F5DEB3$��1��6<   $��
4,0,0.25,0q�6L   .@�5�      m� $
��File��6   .@�5�      m�  m� Command$ local:CustomCommands.Exit��6   5�      5�      � 5�      $��1��6   $��1��6$   $��9��61   $��0,0,-0.25,0q�6E   $	��120��6Z   $	��Top=�6g    5�      �� 5�      $	��121 �6'   �� 5�      $	��100 �6'   �� 5�      $	��100 �6'   �� 5�      $	��100 �6'   �� 5�      $
��118* �6'   �� 5�      $
��119* �6'   �� 5�      $
��118* �6'   �� 5�      $
��119* �6'   �� 5�      $
��118* �6'   �� 5�      $
��119* �6'    5�      �� 5�      $��93 �6$   �� 5�      $	��25* �6$   .+�5�      �� $��5��6   $	��600��6(   $��2��65   $��5��6F   $!��/SHOP;component/img/MT2.png��6Z   $��107,0,-48.463,0q�6   �� 5�      -   5        $��btnTC��5�   �   #��[ 6   $��2,0,2,0q�6;   
������
�������$��0q�6y   $��Center=�6�   $	��114��6�   .��5�      �� .+�5�      �� $#��/SHOP;component/img/home2.png��6!   $ .5,.5&�6I   $��90��6h   $	��100��6t   z�5�      �� 5�   "   -   5        RotateTransform�� �� Angle$ 1Q�5�   L    5�      :� 5�   "   $ 
MouseLeave��6/   .[�5�   &   �� .��5�   *   �� .��5�   .   W�  �� 
TargetName$ RotateTransform��6>   $ Angle�5�   Y   	 W� By$ 10X�6|   	  W� To$	  200X�6�   $ 0:0:0.5D�5�   Z   ! g� FillBehavior$
! Stop=�5�   Y   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      $��14(�6   
���**��$��2,0,2,0q�6>   " �� Padding$" 6q�6O   $��Times New Roman)�6\   $��1��6y   # �� TextAlignment$# Center=�6�   
�������$
��Bold"�6�   Trang Chủ6�   �� 5�      -	   5        $ ��Name$$ btnSP��5�   L   #��[ 6   $��2,0,2,0q�6;   
���k���$��0q�6r   
�������$��1��6�   .��5�      �� $��60��6   $��60��6)   $(��"/SHOP;component/img/phone-icon.png��64   ��5�      �� 5�      % �� Triggers% 5�   "   :� 5�   &   $ Mouse.MouseEnter��63   [�5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ 0:0:0.2D�6F   $ Height�6�   $  80X�6�   W� 5�   6   $ 0:0:0.2D�6F   $ Width�5�   F   $  80X�6h   5�   3   5�   /   5�   '   :� 5�   &   $ Mouse.MouseLeave��63   [�5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ 0:0:0.2D�6F   $ Height�5�      $  60X�6>   W� 5�   6   $ 0:0:0.2D�6F   $ Width�5�      $  60X�6=   5�   3   5�   /   5�   '   5�      5�      5�      �� 5�      $��14(�6   
���**��$��2,0,2,0q�6=   $" 6q�6N   $��Times New Roman)�6[   $��1��6x   $��1��6�   $# Center=�6�   
�������$
��Bold"�6�   Sản Phẩm6�   �� 5�      -
   5        $$ btnTK��5�   a   $y�Hidden=�6   #��[ 6-   $��2,0,2,0q�6O   ���#67BF7F$��2��6�   $��0q�6�   .��5�      �� $��60��6   $��60��6(   $%��/SHOP;component/img/timkiem.png��63   ��5�      �� 5�      % 5�   "   :� 5�   &   $ Mouse.MouseEnter��63   [�5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ 0:0:0.2D�6F   $ Height�6�   $  80X�6�   W� 5�   6   $ 0:0:0.2D�6F   $ Width�5�   F   $  90X�6h   5�   3   5�   /   5�   '   :� 5�   &   $ Mouse.MouseLeave��63   [�5�   *   �� 5�   .   .��5�   2   �� .��5�   6   W� $ 0:0:0.2D�6F   $ Height�5�      $  60X�6>   W� 5   6   $ 0:0:0.2D�6F   $ Width�5     $  90X�6=   5  3   5  /   5  '   5     5	     5
     �� 5     $y�Hidden=�6   $��2,0,2,0q�60   $" 6q�6A   $��Times New Roman)�6M   $��14(�6j   
���**��$��2��6�   $��1��6�   $# Center=�6�   
�������$
��Bold"�6�   Tìm Kiếm6�   �� 5     -   5        $$ btnDH��5  M   #��[ 6   $��2,0,2,0q�6;   
��� ���$��2��6o   $��0q�6   .��5     �� $��60��6   $��60��6(   $ ��/SHOP;component/img/gh.png��63   ��5     �� 5     % 5  "   :� 5  &   $ Mouse.MouseEnter��63   [�5  *   �� 5  .   .��5  2   �� .��5  6   W� $ 0:0:0.2D�6F   $ Height�6�   $  80X�6�   W� 5  6   $ 0:0:0.2D�6F   $ Width�5  F   $  90X�6h   5  3   5  /   5  '   :� 5  &   $ Mouse.MouseLeave��63   [�5  *   �� 5   .   .��5!  2   �� .��5"  6   W� $ 0:0:0.2D�6F   $ Height�5#     $  60X�6>   W� 5$  6   $ 0:0:0.2D�6F   $ Width�5%     $  90X�6=   5&  3   5'  /   5)  '   5+     5-     5.     �� 50     -   5        $��txtGH��50     $��2,0,2,0q�6)   $" 6q�6:   $��Times New Roman)�6F   $��14(�6c   
���**��$��2��6�   $��1��6�   $# Center=�6�   
�������$
��Bold"�6�   Giỏ Hàng6�   51     �� 52     
���P��$��16(�53  '   $	��567��66   $	��190��6C   $��Times New Roman)�6P   $��1��6m   $��4��6}   $
��Left=�6�   $��3��6�   $	��Top=�6�   $��2��6�   ��54     �� 55     -   5        $��txtThongTinNguoiDung��55      
�������$��Thông tin Người Dùng��6O   .��57     � $��Right=�6   $	��179��63   ��58     �� 59     $( "/SHOP;component/img/traitimbay.gif��6%   $
 Fill=�5:     $
 Tile=�6$   $ Absolute=�5;     $ 	0,0,80,50�6.    5=     :� 5>     $ Loaded��6'   .[�5?     �� .��5@  "   �� .��5A  &   � $ Background.Viewport�64   $ -100,0,80,50X�5B  $   $ 0:0:13D�66   $ Forever��5C  $   5D  #   5E     5F      5H      5J     �� 5K     $	��36* �6(   �� 5L     $	��36* �6(   �� 5M     $	��59* �6(   �� 5N     $	��11* �6(   �� 5O     $	��31* �6(   �� 5P     $	��19* �6(   �� 5Q     $	��28* �6(   �� 5R     $	��41* �6(   �� 5S     $	��41* �6(   �� 5T     $��7* �6(   �� 5U     $	��43* �6(   �� 5V     $��7* �6(   �� 5W     $	��44* �6(   �� 5X     $
��128* �6(   �� 5Y     $��6* �6(   .+�5[     �� $��3��6   ._�5\     �� -   5        $��imghdd��5\      $#��/SHOP;component/img/yahoo.gif��6.   6W   5]     �� 5^     -   5        $��imghau��5^     $��3��6*   �� 5`     -   5        $��txtTenDN��5`  !   $��Center=�61   
����  �$��18(�6`   $��4��6n   $
��16,0q�6|   $	��136��6�   6�   �� 5a     -   5        $��	txtvaitro��5a  K   $��5��6!   $��Center=�6.   $��	34,0,29,0q�6]   $	��105��6p   6~   �� 5c     -   5        $��	imgonline��5c     $��6��6-   $$��/SHOP;component/img/yahoo2.png��6;   6e   �� 5d     -   5        $��imgquangcao1��5d  -   $��4��6   $��3��6A   $!��/SHOP;component/img/pop.png��6O   �� 5f     -   5        $��imgquangcao��5f  .   $��11��6   $��3��6A   $&�� /SHOP;component/img/giamgia2.png��6O   $��0,0,0,33q�6y   �� 5h     -   5        $��btnttct��5h  f   ���#CC9999
���**��$��5q�6F   $��1q�6Q   $��8��6u   .��5j     � $	��148��6    5k     �� 5l  "   $	��29* �63   �� 5m  "   $
��119* �63    5o     �� 5p  "   �� 5q  "   .+�5s     �� $��2��6$   $
��Left=�66   $!��/SHOP;component/img/mat.png��6Q   $��55��6v   $��2��6�   �� 5t     $��Right=�6(   
����  �$��2��6V   $��15(�6g   $��Times New Roman)�6v   $# Center=�6�   $" 5q�6�   $��Thông Tin Chi Tiết��6�   $��2��6�   $��0,0,-8,0q�6�   $	��136��6�   5u     5v     �� 5w     -   5        $��btnUpadateTT��5w  f   ���#CC9999
���**��$��5q�6F   $��1q�6Q   $��10��6z   .��5y     � $	��148��6    5z     �� 5{  "   $	��29* �63   �� 5|  "   $
��119* �63    5~     �� 5  "   �� 5�  "   .+�5�     �� $��2��6$   $
��Left=�66   $$��/SHOP;component/img/Update.png��6Q   $��55��6y   $��2��6�   �� 5�     $��Right=�6(   
����  �$��2��6V   $��15(�6g   $��Times New Roman)�6v   $# Center=�6�   $" 5q�6�   $�� Sửa Thông Tin��6�   $��2��6�   $��0,0,-8,0q�6�   $	��136��6�   5�     5�     �� 5�     -   5        $��btnDX��5�  z   ���#CC9999
���**��$��5q�6G   $��1q�6R   $��12��6�   .��5�     � $	��148��6    5�     �� 5�  "   $	��29* �63   �� 5�  "   $
��119* �63    5�     �� 5�  "   �� 5�  "   .+�5�     �� $��2��6$   $
��Left=�66   $ ��/SHOP;component/img/dx.png��6Q   $��55��6u   $��2��6�   �� 5�     $��Right=�6(   
����  �$��2��6V   $��15(�6g   $��Californian FB)�6v   $# Center=�6�   $" 5q�6�   $��Đăng Xuất��6�   $��2��6�   $��0,0,-8,0q�6�   $	��136��6�   5�     5�     �� 5�     $��13��6!   $��0,0,0,10q�6/   ��5�     �� 5�     $  /SHOP;component/img/tv.png��6)   �� 5�     -   5        $��txtdh��5�  ^   
����  �$��
25,55,60,0q�66   $
��Wrap=�6J   $	��107��6k   $��43��6w   5�     �� 5�     -   5        $��txtMavt��5�  2   $y�Hidden=�6   $
��Left=�6A   $��69,5,0,0q�6]   $��7��6o   $	��Top=�6}   $��40��6�   $��24��6�   �� 5�     -   5        $
��MaTK��5�  �   $y�Hidden=�6   $
��Left=�63   $��23��6N   $��32,0,0,0q�6Z   $��7��6l   & �� TextWrapping$
& Wrap=�6y   $	��Top=�6�   $��32��6�   5�     5�     �� 5�     -   5        $��
tabcontrol��5�     $��2��6+   $
��Left=�6;   $	��569��6V   $��3��6c   $	��Top=�6p   $
��1162��6�   $��8��6�   $��4��6�   $��15,0,-71,-0.25q�6�   .@�5�     �� -   5        $
��hear��5�     ��5�     � 5�     $��96��6    5�     �� 5�  "   $	��71* �63   �� 5�  "   $	��19* �63   .+�5�     �� -   5        $��txtit��5�  (   $��2,3,0,3q�66   $��Center=�6G   $��16��6b   �� 5�     $��1��6%   $��20��65   $��20��6@   $��Center=�6L   .+�5�  "   A� ' �� Left$' 1��6*   
( �� Top$( 1��6:   $��16��6I   $��16��6T   
��� ���
���   �$ -5.17,-2.961&�6}   A� 5�  "   $	' 4.5��6*   $( 5��6<   $	��2.5��6K   $��3��6W   
���  ��6b   A� 5�  "   $' 11��6*   $( 5��6;   $	��2.5��6J   $��3��6V   
���  ��6a   F� 5�  "   )����@KL ��� �@]� ���  ��- ��- �J]	
���   �6H   5�     5�     .��5�     � -   5        $��gridtab��5�     ���	#FFE5E5E5$��0,0,-4,0q�6B   5�     5�     �� 5�     -   5        $��tabgioithieu��5�  T   $��	0,-2,-2,0q�6   $��Right=�6-   $��90��6I   .��5�     � -    5        $��	gtDonHang��5�     ���	#FFE5E5E55�     ��5�     � 5�     $��72��6    5�     �� 5�  "   $��0* �63   �� 5�  "   .+�5�     �� -!   5        $��txtDH��5�  7   $��DonHang��6(   $��Center=�6E   $��16��6`   $��0��6l   $��0q�6|   $��2��6�   �� 5�     -"   5        ���	#00000000$��15(�5�  R   
���  ��$��1��6r   $��X��6�   $��0q�6�   $��Center=�6�   $��22��6�   $��Right=�6�   $��18��6�   5�     5�     5�     5�     �� 5�  
   -#   5        $$ btnDXad��5�  G   #��[  6   $��1181,0,38,0q�62   
���**��
����  �$��Đăng Xuất��6   $��27��6�   6�   5�     5�     