   M S B A M L   `   `   `  ����  BibliotekaWSB,    &BibliotekaWSB.ViewsWPFModel.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  ControlPanel��5   	   $	��560��6   $	��800��6+    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      ��  �� CornerRadius$ 12��6   ._�5   
   �� $ 10��6   $��2q�5       J� Opacity$
 0.95Q�5      $
��Left=�6    $	��800��6;   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #462AD8��6#   
 � Offset$
 0Q�63   � 5      $	 #DA34AE��6#   $

 0.75Q�63   � 5      $	 #8A16C1��6#   $
 1Q�63   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $	 #060531��6#   $
 0Q�63   � 5      $	 #1B1448��6#   $
 1Q�63   5      ._�5      �  � RowDefinitions 5       �� 5!      $��30 �6$   �� 5"      .+�5$      � $��0��6    � Cursor$  ��6$    � ColumnDefinitions 5%      �� 5&      �� 5'      $��25 �6+   �� 5(      $��25 �6+   �� 5)      $��5 �6+   .+�5-      �� -   5         ��Name$ btnMinimize��5-      $��0q�5.      $��-��5/      
�������$��16(�51      $��
Montserrat)�52      $
 Hand��53      $��1��54      ��56      �� 57       �� 
TargetType" ��6$   .�58   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 59   "   P� 5:   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5;   *   ��  � �� �#278BEF6G   5<   '   5>      ��5@      �� 5A       �� 
TargetType" ��6.   .R�5B   "   �� $��18��6)   $��18��64   $ 9��5C   )   #��z��5D   )   ._�5E   &   �� $��Center=�67   $��Center=�5F   7   5G   #   5H      5J      �� 5K      -   5        $ btnClose��5K      $��0q�5L      $��X��5M      
�������$��12(�5O      $��
Montserrat)�5P      $
 Hand��5Q      $��2��5R      $��30��5S   4   $��Center=�6@   ��5T      �� 5U      " ��6$   .�5V   "   ��  � �� �#DA34AE6?    5W   "   P� 5X   &    �@J�IsMouseOver$
 True��6E   . �5Y   *   ��  � �� �#C62DAE6G   5Z   '   5\      ��5^      �� 5_      " ��6.   .R�5`   "   �� $��18��6)   $��18��64   $ 9��5a   )   #��z��5b   )   ._�5c   &   �� $��Center=�67   $��Center=�5d   7   5e   #   5f      5h      5i      �� 5l      $	��350��6   $��1��6)    �� Orientation$ Vertical=�66   $��Center=�6M   $	��Top=�6j   $��	0,133,0,0q�6�   .+�5o      �� 
�������$��25(�5q       $��Medium"�5r       $��
Montserrat)�5s       $��Center=�5t       ��5o       �� *
FullName+ �� StringFormat$ 	Witaj {0}�� �� FallbackValue$ Witaj, Gość��5t       �� 5w      -   5        $ MyAccountView_��5w      $��
Moje konto��5x      $��0q�5y      
�������$��12(�5{      $��
Montserrat)�5|      $
 Hand��5}      $��0,20,0,0q�5~      $��Center=�5      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   )   #��z��5�   )   $  ��6S   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      �� 5�      -   5        $ RenatalHistoryViews��5�      $��Historia wypożyczeń��5�      $��0q�5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0,10,0,0q�5�      $��Center=�5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      �� 5�      -   5        $ SearchBooks��5�      $��Wyszukiwarka książek��5�      $��0q�5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0,10,0,0q�5�      $��Center=�5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      �� 5�      -   5        $ 
StaffPanel��5�      $��Panel Pracownika��5�      $��0q�5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��40��5�      $��0,10,0,0q�5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�6R   5�   #   5�      5�      �� 5�      -   5        $ 	btnLogout��5�      $��Wyloguj��5�      $��0q�5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��66��5�   2   ��5�      �� 5      " ��6$   .�5  "   ��  � �� �#DA34AE6?    5  "   P� 5  &    �@J�IsMouseOver$
 True��6E   . �5  *   ��  � �� �#C62DAE6G   5  '   5     ��5	     �� 5
     " ��6.   .R�5  "   �� $	��150��6)   $��40��65   $ 20��5  )   #��z��5  )   ._�5  &   �� $��Center=�67   $��Center=�5  7   5  #   5     5     5     5     5     5     5     