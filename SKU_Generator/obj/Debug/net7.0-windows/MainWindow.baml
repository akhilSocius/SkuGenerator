   M S B A M L   `   `   `  ????H  DSKU_Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SKU_GeneratorSKU_Generator  5   	       SKU_Generator.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SKU_Generator     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??380??6)    ? AllowsTransparency$
 True??5	   	   
??????  ? WindowStyle$
 None=?5
   	    ? 
ResizeMode$ NoResize=?6   .??5      ? .+?5   
   ?  ? RowDefinitions 5      ?? 5      6"   ?? 5      $	??200 ?6    5      ?? 5      6"   .+?5      ??  ?? CornerRadius$ 10??6   $??3??6'   $??0,8,0,8q?68   ??5      ?? 5      .??5      ?  ? Color$ #0085c0??6'    ? Offset$	 0.0Q?67   5      ? 5      $ Beige??6'   $ 1Q?65   5       5!      5#      ?? 5$      $	??100??6   .+?5%      ?? $??image/LoginHead.png??6    J? RenderTransformOrigin$ 0.505,0.355&?65   $??45??6Y   6g   ?? 5&      $??Light"?6   $??22(?5'      $??0,10,0,0q?5(      $??	helvetica)?5)      
???????$	??148??5*   /   $??27??6;   Login to SAP B16X   5,      ?? 5-      $??1??6   .+?5.      ?  5/      ?? 50      52      ?? 53      55      	 ? ColumnDefinitions	 57      ?? 58      6-   ?? 59      6-   .+?5;      ?? $??Light"?6    $??1??63   $??	20,21,0,2q?5<      $??15(?5=      $??	helvetica)?5>      
???????$??19??5?   /   $
??Left=?6;   $	??124??6V   ?? 6c   $?Choose Company  :??6g   6?   ?? 5@      -   5        
 ??Name$
 CompanyCombo??5G      $	??159??5@      $??1??5A      $??1??5B      $??20??5C      $??	18,22,0,0q?5D      $	??Top=?5E      $
??Left=?5F      5G      ?? 5I      $??Light"?6    $??1??63   $??15(?5J      $
??Wrap=?5K      $??	helvetica)?5L      
???????$??20,54,36,-34q?5M   /   ?? 6F   $?Enter B1 Username :??6J   6h   ?? 5N      -   5         ??Name$ UserName??5V      $	??159??5N      $??19??5O      $??1??5P      $??	helvetica)?5Q      $??Light"?5R       ?? TextAlignment$
 Left=?5S      $??18,54,13,-34q?5T      $??1??5U      5V      ?? 5X      $??Light"?6    $??1??5Y       $
??Left=?5Z      $??15(?5[      $??	helvetica)?5\      
???????$	??170??5]   /   $??20,87,0,-67q?6;   ?? 6Q   $?Enter B1 Password  :??6U   6t   G? 5_      -   5         G?Name$ Password??5e   "   $	??159??5_   "   $??
18,0,0,-64q?5`   "   $??19??5a   "   $??1??6.   $??1??5b   "   $??Bottom=?5c   "   $
??Left=?5d   "   5e   "   5f      5i      ?? 5j      -   5        $??LogIn??5j      $??134,134,132,34q?6%   $??1??6=   6J   5m      5n      5o      