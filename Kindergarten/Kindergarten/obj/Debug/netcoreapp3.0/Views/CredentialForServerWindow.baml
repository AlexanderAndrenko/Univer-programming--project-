   M S B A M L   `   `   `  ����G  CKindergarten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Kindergarten.ViewsKindergarten.Views  5   	   2    ,Kindergarten.Views.CredentialForServerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Kindergarten.Views     5   	   $	��280��5   	   $	��400��6   $��Center=�6"   .��5	      � .+�5
   
   �� -   5          ��Name$  	Container��5
      .+�5      �� $
��Wrap=�6   $<��6Реквизиты для входа на сервер��5      $��Center=�5      $��5q�5      $��14(�5      �� 5       �� Orientation$ 
Horizontal=�6   $��10q�5      .+�5      �� $
��Wrap=�6   $��Имя сервера��5      $	��120��5      $��25��5      $��14(�5      �� 5      $��25��6    �� TextWrapping$
 Wrap=�5      $��14(�5      ��5      ��  �� ElementName$ 	Container�� �� Path$ ActualWidth���5      �� *
DataSource+ �� Mode$ TwoWay=�5      5      �� 5      $ 
Horizontal=�6   $��10q�5      .+�5      �� $
��Wrap=�6   $��База данных��5       $	��120��5!      $��25��5"      $��14(�5#      �� 5$      $��25��6   $
 Wrap=�5&      $��14(�5(      ��5%      �� $ 	Container��$ ActualWidth���5'      �� *
DataBase+$ TwoWay=�5(      5)      �� 5*      $ 
Horizontal=�6   $��10q�5+      .+�5,      �� $
��Wrap=�6   $��
Логин��5-      $	��120��5.      $��25��5/      $��14(�50      �� 51      $��25��6   $
 Wrap=�53      $��14(�55      ��52      �� $ 	Container��$ ActualWidth���54      �� *Login+$ TwoWay=�55      56      �� 57      $ 
Horizontal=�6   $��10q�58      .+�59      �� $
��Wrap=�6   $��Пароль��5:      $	��120��5;      $��25��5<      $��14(�5=      �� 5>      $��25��6   $
 Wrap=�5@      $��14(�5B      ��5?      �� $ 	Container��$ ActualWidth���5A      �� *
Password+$ TwoWay=�5B      5C      �� 5E      -   5         ��Name$ button��5E      $��Сохранить��5F      $	��100��5G      $��25��5H      $��Right=�5I      $��0,0,12,0q�5J      ��5K      �� *SaveCredentialCommand+5M      5N      5O      