   M S B A M L   `   `   `  ����H  DWpfWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfWeatherAppWpfWeatherApp  5   	       WpfWeatherApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfWeatherApp     5   	     � Title$  
WeatherApp��5   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � 	Resources 5	         Backgrounds �� 	UriSource �� CacheOption��%B   &	        �� 5
   
   $ /Image2.png?�6*   $ Default=�6B   5      .��5      � $��
7,1,-1,-35q�6    J� RenderTransformOrigin$ 0.481,0.259&�6   .+�5   
   �� #���   6   $��	-6,-1,0,0q�67   $
��Left=�6J   $
��1002��6e   $��5��6r   $��UniformToFill=�6�   �� 5   
   -   5        $��Button��5      $��Подтвердить��6!   $
��Left=�67   $��376,415,0,0q�6R   $	��Top=�6g   $��70��6   $	��178��6�   $��Consolas)�6�   $��18(�6�   �� 5   
   -   5        $��TextBoxC��5      $
��Left=�6"   $��376,359,0,0q�6=    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��178��6�   $��19��6�    �� 	UndoLimit$ 12��6�   �� 5   
   -   5        $��LabelOpenWeat��5      $
��Left=�6'   $��	20,57,0,0q�6B   $	��Top=�6U   $	��117��6m   $	��224��6z   $��20(�6�   $��Bahnschrift SemiLight)�6�   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -0.017Q�6$   �� 5      	 �� Angle$	 0.294Q�6&   T� 5      5      5      �� 5   
   -   5        $��LabelVisualCros��5      $�� ��6)   $
��Left=�64   $��
283,57,0,0q�6O   $	��Top=�6c   $	��114��6{   $	��194��6�   $��19(�6�   $��Bahnschrift SemiLight)�6�   $ 
2.856,5.06&�6�   �� 5   
   -   5        $��LabelWeatherApi��5      $�� ��6(   $
��Left=�63   $��
515,59,0,0q�6N   $	��Top=�6b   $	��114��6z   $	��198��6�   $��19(�6�   $��Bahnschrift SemiLight)�6�   �� 5   
   -   5        $��LabelWeatherStack��5      $�� ��6*   $
��Left=�65   $��
731,57,0,0q�6P   $	��Top=�6d   $	��111��6|   $	��194��6�   $��Bahnschrift SemiLight)�6�   $��19(�6�   $��3��6�   �� 5   
   -   5        $��AverageTemp��5      $�� ��6$   $
��Left=�6/   $��313,198,0,0q�6J   $	��Top=�6_   $��91��6w   $	��308��6�   $��Bahnschrift SemiLight)�6�   $��19(�6�   �� 5   
   -   5        $��
ButtonLoad��5      $��Загрузить��6$   $
��Left=�68   $��763,411,0,0q�6S   $	��Top=�6h   $��76��6�   $	��153��6�   $��Bahnschrift SemiLight)�6�   $��18(�6�   $��2��6�   �� 5   
   -	   5        $��LabelEx��5   ?   $K��EВведите название необходимой локации��6   $
��Left=�6N   $��297,307,0,0q�6i   $	��Top=�6~   $��52��6�   $	��340��6�   $��16(�6�   $
��Bold"�6�   �� 5    
   -
   5        $��
GrafButton��5       $��График��6$   $
��Left=�65   $��
58,419,0,0q�6P   $	��Top=�6d   $��69��6|   $	��155��6�   $��Bahnschrift SemiLight)�6�   $��18(�6�   5!      5"      