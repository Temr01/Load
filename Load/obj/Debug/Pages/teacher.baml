   M S B A M L   `   `   `  ����?  ;Load, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Load.Pages
Load.Pages  5          Load.Pages.teacher   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Load.Pages     5      -   5          N� Title$   Преподователь��5	       N� FontSize$ 18(�6   $	��910��6+   $	��650��67   .��5      � .+�5   
   �� $��5q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $��
Поиск��6   $��0,0,30,0q�6)   �� 5      -   5         ��Name$ SearchTeacher��5      $	��300��61   $
��Left=�6=   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataTeacher��5      $��5q�6,      AutoGenerateColumns .  $	��590��6S      CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *middle_name+6V     5      $ Фамилия��6)   $		 200 6Y   
 6:   �� *
first_name+6Y     5      $ Отчество��6)   $		 200 6Y   
 6;   �� *	last_name+6Y     5      $ Категория��6)   $		 100 6[   
 6<   �� *
categories+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 * 6-      CellTemplate 5      �� 5      .R�5   "   �� .+�5   &   ��  ��Name$
 Edit��6-   -   5        $ ��Редактировать��5   ;   6S   5   #   5      5      5!      5"      5#      5$      