   M S B A M L   `   `   `  ����?  ;Load, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Load.Pages
Load.Pages  5          Load.Pages.Student   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Load.Pages     5      -   5          N� Title$  Студенты��5	       N� FontSize$ 18(�6   $	��910��6&   $	��650��62   .��5      � .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�66   $
��Left=�6Q   $��5q�6l   .+�5      �� $��Студент: ��6    $��0,0,8,0q�61   �� 5      -   5         ��Name$ StudentSearch��5      $	��200��65   $��0,0,30,0q�6A   6S   5      �� 5      $ 
Horizontal=�6   $��10q�66   $��Right=�6B   .+�5      �� $��Группа: ��6    $��0,0,8,0q�60   �� 5      -   5         ��Name$ search��5       �� DisplayMemberPath$
 name��6/   $	��250��6H   $��0,0,8,0q�6T   �� 5      -   5         ��Name$ FilterGroup��5      $��0,0,8,0q�62   .��5      �� $ 
Horizontal=�6%   .+�5      �� $��Фильтр��6(   �� 5         binacle#��[  6$   $��30��6F   $��17��6Q   5      5      �� 5      -   5        $ CancelFilter��5      .��5      �� $ 
Horizontal=�6%   .+�5      �� $��Отмена��6(   �� 5       
 cancel#��[ 6$   $��22��6E   $��22��6Q   5      5       5!      5"      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ StudentData��5#      $��16(�6,   $	��526��6:      AutoGenerateColumns .  	   CanUserAddRows	 .  
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *
first_name+  5&      $ Имя��6)   $	 180 66    6B   �� *middle_name+  5'      $ Отчество��6)   $	 180 6;    6G   �� *	last_name+  5(      $ Дата рождения��6)   $	 130 6@    6L   �� *
bithdate+ �� StringFormat$ {0:dd.MM.yyyy}��  5)      $ Группа��6)   $	 100 69    6E   �� *name+4  .System.Windows.Controls.DataGridTemplateColumn  5*      $ * 6-      CellTemplate 5+      �� 5,      .R�5-   "   �� .+�5.   &   �� $
 Edit��6-   -   5        $��Изменить��5.   ;   6N   5/   #   50      52      54      �� 55      $ 
Horizontal=�6   $��10q�62   .+�56      �� -   5        $ 
addStudent��56      $��42��6-   $	��160��69   $��	0,0,250,0q�6^   .��57      �� $ 
Horizontal=�6!   .+�58      ��   add#��[ 6    $��35��6>   $��64��6J   �� 59      $��Добавить��6$   $��Center=�64   5:      5;      �� 5<      -	   5        $ StudentSelect��5<      $	��250��65   $��0,0,8,0q�6A   $��26��6R   �� 5=      -
   5        $ FilterStudent��5=      $��0,0,8,0q�64   $��30��6E   .��5>      �� $ 
Horizontal=�6%   .+�5?      �� $��Фильтр��6(   �� 5@      #��[  6$   $��30��6F   $��17��6Q    J� RenderTransformOrigin$ 0.7,0.5&�6]   5A      5B      �� 5C      -   5        $ CancelStudFilt��5C      $��30��65   .��5D      �� $ 
Horizontal=�6%   .+�5E      �� $��Отмена��6(   �� 5F      #��[ 6$   $��22��6E   $��22��6Q   5G      5H      5I      5J      �� 5K   
    �� CornerRadius$ 8��6   $y�Hidden=�6"   $��1q�66   
�������$��0,0,8,0q�6]   5L      5M      5N      