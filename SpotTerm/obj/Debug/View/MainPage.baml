   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      C ?SpotTerm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SpotTerm.ViewSpotTerm.View 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      C&clr-namespace:SpotTerm.Utils.ConverterSpotTerm.Utils.Converter 5	      /clr-namespace:SpotTerm.ModelSpotTerm.Model 5         SpotTerm.View.MainPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:SpotTerm.View     5      9System&clr-namespace:System;assembly=mscorlib     5      <	converter&clr-namespace:SpotTerm.Utils.Converter     5	      R NMahApps.Metro.IconPacks, Version=1.9.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5
      'enumclr-namespace:SpotTerm.Model  5        N� Title$  MainPage��5       � 	Resources 5      )  #SpotTerm.Utils.Converter.StatusConv   
StatusConv  EnumProrityProvider S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName  EventControlTemplate �� 
TargetType �� 	Converter  CardControlTemplate �� Padding	 �� CornerRadius
 � ColumnDefinitions � RowDefinitions �� Padding �� TextAlignment �� Orientation:  4MahApps.Metro.IconPacks.PackIconFontAwesomeExtension �� Path �� RelativeSource �� AncestorType��%�  &	        &	      &	 �     7   &	 F      5   
   6   S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $ enum:PriorityMeet��6   5      �� 5   
   " ��67   .R�5      � $��5q�6   .+�5      �� .+�5       �� 
���   ���6    �� *	EventInfo+��6;   �� *Status+8   6�   5!      5"      5#      �� 5%      " ��6:   .R�5&      �� 
���   ����#113B51$ 5q�6>   $��2q�6J   $	 8��6^   $��5q�5'      ._�5(      � $��5q�6   
 5)      �� 5*      $
��Auto �6+    5,      �� 5-      $
��Auto �6(   �� 5.      $
��Auto �6(   �� 5/      $
��Auto �6(   .+�53      � $��0��6   $��5q�6(   .+�54      �� $ 2q�6$   $��Center=�6L   $ Center=�55   $   ��54   0   �� *
ClientName+55   $   56      � 58      $��1��6   $��5q�6(   .+�59      �� $ 2q�6$   $��Center=�6K   $ Center=�5:   $   ��59   0   �� *	PlaceName+5:   $   5;      � 5=      $��2��6   $��5q�6(   .+�5>      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6Y   .+�5?      �� $��5q�6%   $��30��61   $��30��6<   
������ 
���������6t     *
InfoCircle+��5@   %   �� $! DataContext.ShowInfoCommand� �� " ����5A   %   �� 5B      �� 5D      $��5q�6%   $��30��61   $��30��6<   
������ 
���������6u     *CheckCircle+��5E   %   �� $% DataContext.CompleteCardCommand� �� " ����5G   %   �� 5H      �� 5J      $��5q�6%   $��30��61   $��30��6<   
������ 
���������6t     *Bug+��5K   %   �� $# DataContext.DeleteCardCommand� �� " ����5M   %   �� 5N      �� 5P      $��5q�6%   $��30��61   $��30��6<   
������ 
���������6t     *Map+��5Q   %   �� $  DataContext.GoToMapCommand� �� " ����5S   %   �� 5T      5U      5V      5X      5Y      5Z      5\      .��5^      � ���#28546C
 5_   
   �� 5`      $��2* �6   �� 5a      $��1* �6   .+�5c   
   � $	��421��6   $��
28,74,26,0q�6   $	��Top=�60   $��1��6H    5d      �� 5e      $��1* �6    �� 5f      $��1* �6    �� 5g      $��1* �6    �� 5h      $��2* �6    �� 5i      $��1* �6    �� 5j      $��1* �6    �� 5k      $��1* �6    .+�5m      �� -   5         ��Name$ 	InfoBlock��5m      $��Center=�6+   $��24(�6F   $ Center=�6T   $��10,10,10,10q�5n      $
��Wrap=�6-   $��Dodaj nowy wpis��6A   ���#6F90A26X   �� 5o      -   5         ��Name$ ClientNameText��5o      *   $MahApps.Metro.Controls.TextBoxHelper   AutoWatermark .    	Watermark$ Nazwa klienta..��6Z   $��22(�6�   $��10,9.6,12,9.8q�5p       �� TextWrapping$
 Wrap=�6-   $��1��6A   ��6N   �� *
ClientName+ �� Mode$ TwoWay=��� 5q      -   5        $ PlaceNameText��5q      $ Miejsce spotkania..��6-   $��22(�6d   $��10,10.2,12,10.2q�5r      $
 Wrap=�6/   $��2��6C   ��6P   �� *	PlaceName+$ TwoWay=��� 5s      -   5        $ DescriptionText��5s      $ Opis..��6/   $��22(�6Y   $��10,9.8,12,9.8q�5t      $
 Wrap=�6-   $��3��6A   ��6N   �� *Description+$ TwoWay=��� 5u      -   5         ��Name$ ComboPrority��5u      $��10,10,10,10q�6-   $��4��6B   $��22(�6O   ��5w      ��  �� Source# [  �� SelectedItem 5x      �� $ PriorityMeet�+   %MahApps.Metro.Controls.DateTimePicker  5z      $��5��6&   $��10,0.5,10.5,0.5q�63      SelectedDate 6L   �� *
PropTime+6p   �� 5|      -   5         ��Name$ 	AddButton��5|      $��
Zatwierdź��6(   $��10,10,10,10q�6`   $��6��6u   
����������#477187��6<   �� *AddCardCommand+6�   5}      4   .MahApps.Metro.Controls.MetroAnimatedTabControl  5   
   $��0��6+   ���#6F90A2.@�5�      )   #MahApps.Metro.Controls.MetroTabItem  $��W realizacji��6$   .��5�      �� -   5         ��Name$ listView��5�      $��60,60,61,60q�6-   $��0q�6B   
������  �� SelectionMode$ Single=�5�      ��5�      �� *
CardList+ 5�      �� *SelectedCard+��5�      �� 5�       �� 
TargetType" ��6    .�5�      ��   �� Property  � ��! �� Value#! [ 69   �� 5�        � ��! �#6F90A26;   " �� Triggers" 5�      P� 5�   "   # P� Property# �@J�IsMouseOver$ P� Value$ . . �5�   &   ��   � ��
! �����6C   5�   #   5�      ��5�      �� 5�      .R�5�      � ��5�      �� * (FrameworkElement.ActualWidth)+ �� $ ScrollContentPresenterL���5�      �� *	ItemWidth+ �� *Self+% � 
ItemHeight% 5�      �� *(ListView.View).ItemHeight+ �� $ ListViewL�& � 	ItemWidth& 5�      �� *(ListView.View).ItemWidth+ �� $ ListViewL�5�      5�      5�        5�      $��Zakończono��6$   .��5�      �� -   5        $ 	listView2��5�      $��60,60,61,60q�6.   $��0q�6C   
������ $ Single=�5�      ��5�      �� *CardListCompleted+��5�      �� 5�      " ��6    .�5�      ��   � ��#! [ 69   �� 5�        � ��! �#6F90A26;   " 5�      P� 5�   "   # �@J�IsMouseOver$ . . �5�   &   ��   � ��
! �����6C   5�   #   5�      ��5�      �� 5�      .R�5�      � ��5�      �� * (FrameworkElement.ActualWidth)+ �� $ ScrollContentPresenterL���5�      �� *	ItemWidth+ �� *Self+% 5�      �� *(ListView.View).ItemHeight+ �� $ ListViewL�& 5�      �� *(ListView.View).ItemWidth+ �� $ ListViewL�5�      5�      5�      5�      �� 5�   
   -	   5        $
 load��5�      
����������#477187$��Załaduj��6m   $��1��6   $
��Left=�6�   $��142.4,500,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *LoadFromFile+6�   �� 5�   	   -
   5        $
 save��5�      
����������#477187$��Zapisz��6l   $��1��6}   $
��Left=�6�   $��222.4,500,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *SaveFromFile+6�   �� 5�   
   $��1��6   $��28.5,576,26,44q�6#   ��6;   �� *	EventList+��5�      �� 5�      " ��6   .�5�      ��   � ��#! [ 61   5�      5�      5�      5�      