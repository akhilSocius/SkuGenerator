   M S B A M L   `   `   `  ????H  DSKU_Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SKU_GeneratorSKU_Generator  5   	   K*clr-namespace:SKU_Generator.MVMM.ViewModelSKU_Generator.MVMM.ViewModel  5          SKU_Generator.SKU   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   'localclr-namespace:SKU_Generator  5   	   :	viewModel*clr-namespace:SKU_Generator.MVMM.ViewModel  5        ? Title$  
MainWindow??5
   	    ? WindowState$ 	Maximized=?6   $	??500??64   $	??500??6A    ? WindowStyle$
 None=?5   	    ? DataContext 5      0  *SKU_Generator.MVMM.ViewModel.MainViewModel  5   
   .??5      ? .+?5   
   ??  ?? CornerRadius$ 	0,10,10,0??6   $??1??5      ??5      ?? 5       ?? 
StartPoint$	 0,2&?6&    ?? EndPoint$	 1,0&?67   .??5      ?  ? Color$ #00628d??6#    ? Offset$	 0.5Q?63   ? 5      $ #107dac??6#   $ 1Q?63   5      ._?5!      ? 	 ? RowDefinitions	 5"      ?? 5#      $??35 ?6$   ?? 5$      $??* ?6$   ?? 5%      $??30 ?6$   .+?5(      ?? $ 	10,0,0,10??6   $??0??5)      ??5+      ?? 5,      $
 0,.1&?6.   $	 1,1&?6@   .??5-      ? $ #107dac??6+   $	 0.1Q?6;   ? 5.      $ #005073??6+   $	 0.8Q?6;   51      ._?53      ?? .+?54      ?? 
 ?? Orientation$
 
Horizontal=?6%   $??35??55   !   .+?59      ?? $??Sku Generator??6(      titleColor2#??[  6=   $??15(?5:   $   $??
Montserrat)?5;   $   $??Medium"?5<   $   $??Center=?5=   $   $
??Left=?5>   $   $??0,0,10,0q?5?   (   	? 5A      -   5         	?Name$ NewSkuButton??5E   "     
menuButton#??[ 5A   *    
 color6
 ? Tag# [ 5B   "    d? 	IsChecked$
 TrueY?5C   "   $??99??5E   8   ??5D   "   ?? *SkuViewCommand+.??5F   "   ?? $
 
Horizontal=?6-   .+?5G   &   !  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ barcode=?63     menuButtonIcon#??[ 6B   ?? 5H   &   $??New Sku??60     menuButtontext#??[ 6?   5K   #   5L      	? 5M      -   5        $ SkuSimButton??5N   !   #??[ 5O   !   # [ 5P   "   $ FalseY?5R   "   $??99??5T   "   ??5Q   "   ?? *SkuSimCommand+.??5U   "   ?? $
 
Horizontal=?6-   .+?5V   &     $ HourglassHalf=?63   #??[ 6H   ?? 5W   &   $??Sku Sim??60   #??[ 6?   5Z   #   5[      	? 5\      #??[ 6*   # [ 5]   "   $ FalseY?5^   "   $??99??5`   "   .??5a   "   ?? $
 
Horizontal=?6-   .+?5b   &     $
 Plus=?63   #??[ 6?   ?? 5c   &   $??New Sku??60   #??[ 6?   5f   #   5g      5i      5j      5l      ?? 5m      $ 	10,0,0,10??6   $??1??5n      ??5p      ?? 5q      $	 0,1&?62   $	 1,1&?6C   .??5r      ? $ #00628d??6+   $	 0.1Q?6;   ? 5s      $ #0085c0??6+   $ 1Q?6;   5u      ._?5x      ?? $??1??6%   $??10q?5y   %   ??5z   %   ?? *CurrentView+5|      5}      ?? 5      $??2??5?      $??Version 1.0??5?      
???????$??10(?5?      $??10,0,0,0q?5?      $??
Montserrat)?5?      5?      ?? 5?      $??2??5?      $4??.@ Socius Innovative Golbal Brains Pvt.Ltd 2022??5?      
???????$??13(?5?      $??	10,10,0,0q?5?      $??
Montserrat)?5?      5?      5?      5?      5?      5?      