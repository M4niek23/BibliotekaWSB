   M S B A M L   `   `   `  ����  BibliotekaWSB0    *BibliotekaWSB.ViewsWPFModel.BookSearchView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Wyszukiwarka książek��5   	   $	��900��6&   $	��960��63    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5	   	   .��5
      ��  �� CornerRadius$ 12��6   ._�5   
   �� $ 10��6   $��2q�5       J� Opacity$
 0.95Q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #462AD8��6#   
 � Offset$
 0Q�63   � 5      $	 #DA34AE��6#   $

 0.75Q�63   � 5      $	 #8A16C1��6#   $
 1Q�63   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $	 #060531��6#   $
 0Q�63   � 5      $	 #1B1448��6#   $
 1Q�63   5      ._�5      �  � RowDefinitions 5      �� 5      $��30 �6$   �� 5      .+�5"      � $��0��6    � ColumnDefinitions 5#      �� 5$      �� 5%      $��25 �6+   �� 5&      $��25 �6+   .+�5(      �� -   5         ��Name$ btnMinimize��5(      $��0q�5)      $��-��5*      
�������$��16(�5,      $��
Montserrat)�5-       � Cursor$
 Hand��5.      $��1��5/      ��51      �� 52       �� 
TargetType" ��6$   .�53   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 54   "   P� 55   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �56   *   ��  � �� �#278BEF6G   57   '   59      ��5;      �� 5<       �� 
TargetType" ��6.   .R�5=   "   �� $��18��6)   $��18��64   $ 9��5>   )   #��z��5?   )   ._�5@   &   �� $��Center=�67   $��Center=�5A   7   5B   #   5C      5E      �� 5F      -   5        $ btnClose��5F      $��0q�5G      $��X��5H      
�������$��12(�5J      $��
Montserrat)�5K      $
 Hand��5L      $��2��5M      ��5O      �� 5P      " ��6$   .�5Q   "   ��  � �� �#DA34AE6?    5R   "   P� 5S   &    �@J�IsMouseOver$
 True��6E   . �5T   *   ��  � �� �#C62DAE6G   5U   '   5W      ��5Y      �� 5Z      " ��6.   .R�5[   "   �� $��18��6)   $��18��64   $ 9��5\   )   #��z��5]   )   ._�5^   &   �� $��Center=�67   $��Center=�5_   7   5`   #   5a      5c      5d      � 5g      $��1��6   $��20q�6$    5h      �� 5i      $	��12* �6+   �� 5j      $��7* �6+   �� 5k      $
��409* �6+    5m      �� 5n      $
��Auto �6(   �� 5o      .+�5s      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�5t   !   $��Center=�5u   !   $��3��5v   !   .+�5w      �� -   5         ��Name$ 	SearchBox��5w   "   $	��532��5x   "   $��30��6.   $��0,0,10,0q�5y   "   $��
Montserrat)�5z   "   $��13(�5{   "   $��Medium"�5|   "   
���   � �� 
CaretBrush
 �����
�������$��0,0,0,2q�5�   "   $��Center=�5�   "   $��20,0,0,0q�5�   "   $��Center=�5�   "   �� 5�      -   5        $��Szukaj��5�   !   $	��100��5�   !   $��30��6-   ���#462AD8
�������$
 Hand��5�   I   $��
Montserrat)�5�   !   $��13(�69   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� �#462AD86C    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   ��  � �� �#28AEED6K   5�   +   5�   #   ��5�      �� 5�   "   " ��62   .R�5�   &   �� $ 15��6-   #��z��5�   -   ._�5�   *   �� $��Center=�6;   $��Center=�5�   ;   5�   '   5�   #   5�      �� 5�      -   5         ��Name$ SortBox��5�   #   $	��200��5�   #   $��30��6/   $��10,0,0,0q�5�   #   $��
Montserrat)�5�   #   $��13(�5�   #   $��Medium"�5�   #   
���   �
�������$��0,0,0,2q�5�   #   $��Center=�5�   #   $��10,0,0,0q�5�   #   $��Center=�5�   #   .@�5�      �� $��Sortuj rosnąco��6+   �� 5�      $��Sortuj malejąco��6+   5�      5�      �� 5�      $
��Auto=�6#   $��Disabled=�5�   #   $��1��5�   #   $��3��60   .��5�      �� -   5         ��Name$ BookList��5�   #   ���#1B1448
�������$	��786��6]   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��
 ���� 6C   �� 5�   &    � ��
 �����6C   �� 5�   &    � ��$ 
Montserrat)�6C   �� 5�   &    � ��$ 12(�6A    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   ��  � �� �#D0E7FF6K   �� 5�   .    � ��
 �   �6K   5�   +   P� 5�   *    �@��
IsSelected$
 True��6H   . �5�   .   ��  � �� �#A9D0F56K   �� 5�   .    � ��
 �   �6K   5�   +   5�   #    �� View 5�      �� 5�   "   .P�5�   &   �� $��Tytuł��65    �� Width$	 200��6k    �� DisplayMemberBinding 6D   �� *Title+6k   �� 5�   &   $��Autor��65   $	 150��6l    6D   �� *Author+6l   �� 5�   &   $��	Kategoria��65   $	 150��6r    6H   �� *
Category+6r   �� 5�   &   $��Dostępność��65   $	 120��6w    6I   �� *Availability+6w   �� 5�   &   $��Szczegóły��65   $	 140��6H    �� CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� -   5        $��Szczegóły��5�   9   $	��120��5�   9   $��30��5�   9   ���#8A16C1
�������$��
Montserrat)�5�   9   $��12(�5�   9   $��Medium"�5�   9   $
 Hand��5�   9   $��Center=�5�   9   $��Center=�5�   9   ��5�   6   �� 5�   :   " ��6@   .�5�   >   ��  � �� �#8A16C16[   �� 5�   >    � ��$ Medium"�6[    5�   >   P� 5�   B    �@J�IsMouseOver$
 True��6a   . �5�   F   ��  � �� �#28AEED6c   5�   C   5�   ;   ��5�   6   �� 5�   :   " ��6J   .R�5�   >   �� $ 15��6E   #��z��5�   E   ._�5�   B   �� $��Center=�6S   $��Center=�5�   S   5�   ?   5�   ;   5�   3   5�   /   5�   '   �� 5�   &   $��Akcja��65   $	 140��6D    5�   *   �� 5�   .   .R�5�   2   �� -   5        $��	Wypożycz��5�   9   $	��120��5   9   $��30��5  9   ���#28AEED
�������$��
Montserrat)�5  9   $��12(�6Q   $��Medium"�5  9   $
 Hand��5  9   $��Center=�5  9   $��Center=�5  9   ��5	  6   �� 5
  :   " ��6@   .�5  >   ��  � �� �#28AEED6[   �� 5  >    � ��$ Medium"�6[    5  >   P� 5  B    �@J�IsMouseOver$
 True��6a   . �5  F   ��  � �� �#278BEF6c   5  C   5  ;   ��5  6   �� 5  :   " ��6J   .R�5  >   �� $ 15��6E   #��z��5  E   ._�5  B   �� $��Center=�6S   $��Center=�5  S   5  ?   5  ;   5  3   5  /   5   '   5!  #   5#     5$     5%     �� 5&     -	   5        $��Cofnij��5&     
�������$��14(�5(     $��
Montserrat)�5)     $��0,5,831,851q�5*     $��2��5+     ��5-     �� 5.     " ��6    .�5/     ��  � �� �#DA34AE6;    50     P� 51  "    �@J�IsMouseOver$
 True��6A   . �52  &   ��  � �� �#28AEED6C   53  #   55     ��57     �� 58     " ��6*   .R�59     �� $	��100��6%   $��30��61   $ 15��5:  !   #��z��5;  !   ._�5<  "   �� $��Center=�63   $��Center=�5=  %   5>     5?     5A     5D     5E     5F     5G     