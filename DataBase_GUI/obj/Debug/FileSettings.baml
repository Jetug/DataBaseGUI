   M S B A M L   `   `   `  ����G  CDataBase_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DataBase_GUIDataBase_GUI  5          DataBase_GUI.FileSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:DataBase_GUI     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��40* �6   �� 5      $	��60* �6   .+�5   
   �� -   5         ��Name$ fileView��5      $
��Left=�6%   $	��467��6@   $	��Top=�6M   $	��480��6e   $��1��6q    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   $��Имя файла��6   $
��Left=�5      $	��Top=�6/   $��24��5      $��71��6    $��
33,211,0,0q�5      �� 5   
   -   5         ��Name$ fileNameBox��5      $
��Left=�6'   $��126,208,0,0q�5      $�� ��6"   $	��Top=�6*    �� 	MaxLength$ 30��5      $��24��5      $	��158��6   �� 5   
   -   5         ��Name$ 	AddButton��5      $��Добавить��6    $
��Left=�63   $��
95,270,0,0q�5      $	��Top=�6!   $	��130��69   $��51��6E   ���	#FFDDDDDD5    %   �� 5!   
   -   5        $ deleteButton��5"      $��Удалить��6#   $
��Left=�65   $��240,467,0,0q�5#      $	��Top=�6"   $	��240��5$      $��33��6   $��1��5%      6   �� 5&   
   -   5        $ SelectButton��5'      $��Выбрать��6#   $
��Left=�65   $��	0,467,1,1q�5(      $	��Top=�6    $	��240��5)      $��33��6   $��1��5*      6   �� 5+   
   $��Текущий файл��6   $
��Left=�6'   $��	15,68,0,0q�5,      $	��Top=�6#   $��89��6;   �� 5-   
   -   5         ��Name$ CurrentName��5-      $��<не выбран>��5.      $
��Left=�5/      $��
109,68,0,0q�50      $	��Top=�51      $	��206��52      $��1q�53      ���	#FF828282#��� ��55      56      57      