   M S B A M L   `   `   `  ����A  =Adminn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AdminnAdminn  5          Adminn.InertfacePannier   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Adminn     5        N� Title$  InertfacePannier��5	      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��0��6   
���   �6%   �� 5      $��1��6   
�������6%   � 5      $��0��6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� -   5        $��0��5      $��Burgers��6&   
�������$��70,18,70,18q�6L   6a   �� 5      -   5        $��1��5      $��Boissons��6&   
�������$��70,18,70,18q�6M   6b   �� 5      -   5        $��2��5      $��Frites��6&   
�������$��70,18,70,18q�6K   6`   �� 5       -   5        $��3��5       $��Menus��6&   
�������$��70,18,70,18q�6J   6_   �� 5!      $��4��6   $��Panier��6&   
�������$��70,18,70,18q�6T   �� 5"      -   5        $��5��5"      $��	Commandes��6&   
�������$��70,18,70,18q�6N   6c   �� 5#      -   5        $��7��5#      $��Déconnecter��6&   
�������$��70,18,70,18q�6P   6e   5$      � 5%      $��1��6    5&      �� 5'      $��* �6$   �� 5(      $��50 �6$   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��5q�6S   $��1��6^   .+�5+      �� -   5        $��Passer la commande��5+      $��0,0,20,0q�6:   
�������$��Center=�6h   $	��142��6�   $��23��6�   6�   �� 5,      -   5        $��Vider le pannier��5,      $��0,0,20,0q�68   
�������$��Center=�6f   $	��142��6�   $��23��6�   6�   5-      � 50      $��0��6   .+�51      �� -	   5         ��Name$ PannierListBox��51      $��0q�66   $��10q�6J   $
��Auto��6W   $
��Auto��6e   $	��700��6r   ��52      �� 53      .R�54   "   A�  A� Columns$ 5��6.   $	��Top=�6:   $��Stretch=�6R   55      ��57      �� 58      .R�59   "   �� 
�������$��1q�6<   $��5q�6P    �� Padding$ 10q�6[    �� CornerRadius$ 5��6h   ._�5:   &   �� .+�5<   *   �� $
��Bold"�6M   $��14(�6_    �� TextAlignment$ Center=�6m   ��64   �� *	IdOrder+6m   �� 5=   *   $��12(�6O   $ Center=�6]   ��64   �� *	EtatOrder+6]   �� 5@   *   ��67   �� *
Nouritures+��5A   .   �� 5B   2   .R�5C   6   �� 
�������$	��0.5q�6U   $��5q�6k   $ 5q�6v   ._�5D   :   �� .+�5E   >   �� $
��Bold"�6]   $��12(�6o   $ Center=�6}   ��6H   �� *Nom+6}   �� 5F   >   
��� � �$��11(�6�   $ Center=�6�   ��6H   �� *Prix+	 �� StringFormat$	 Prix: {0:C}��6�   5G   ;   5H   7   5I   3   5K   +   �� 5M   *   ��67   �� *
Boissons+��5N   .   �� 5O   2   .R�5P   6   �� 
�������$	��0.5q�6U   $��5q�6k   $ 5q�6v   ._�5Q   :   �� .+�5R   >   �� $
��Bold"�6]   $��12(�6o   $ Center=�6}   ��6H   �� *Nom+6}   �� 5S   >   
��� � �$��11(�6�   $ Center=�6�   ��6H   �� *Prix+$	 Prix: {0:C}��6�   5T   ;   5U   7   5V   3   5X   +   �� 5Z   *   ��67   �� *Frites+��5[   .   �� 5\   2   .R�5]   6   �� 
�������$	��0.5q�6U   $��5q�6k   $ 5q�6v   ._�5^   :   �� .+�5_   >   �� $
��Bold"�6]   $��12(�6o   $ Center=�6}   ��6H   �� *Nom+6}   �� 5`   >   
��� � �$��11(�6�   $ Center=�6�   ��6H   �� *Prix+$	 Prix: {0:C}��6�   5a   ;   5b   7   5c   3   5e   +   �� 5h   *   $��Italic$�6P   $��11(�6c   $��Right=�6q   ��64   �� *
client.Nom+6q   �� 5i   *   $��10(�6R   $��Right=�6`   ��64   �� *client.Email+6`   5j   '   5k   #   5l      5n      5o      5p      5q      5r      5s      