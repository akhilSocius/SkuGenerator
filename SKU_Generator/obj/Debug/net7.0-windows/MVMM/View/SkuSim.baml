   M S B A M L   `   `   `  ????H  DSKU_Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SKU_Generator.MVMM.ViewSKU_Generator.MVMM.View  5      $    SKU_Generator.MVMM.View.SkuSim   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:SKU_Generator.MVMM.View     5      $	??750??5      $
??1338??6   .??5	      ?   ? ColumnDefinitions  5
   
   ?? 5      $
??1000 ?6   6.   ?? 5      $??* ?6   6+   .+?5   
   ?? $??0??6   ._?5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
SkuDisplay??5      $??0??5      $
??Auto??5      $
{?True??5         
IsReadOnly$
 True??5         SelectionMode$ Single=?5      
???   ?
??????    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Sku code??5   )      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5    )   ?? *Code+5#        5$      $ 	Prod name??5%   )   $ * 5&   )    5'   )   ?? *Prod+5*        5+      $ Style??5,   )   $ * 5-   )    5.   )   ?? *Style+51        52      $ 
Color name??53   )   $ * 54   )    55   )   ?? *Color+58        59      $
 Size??5:   )   $ * 5;   )    5<   )   ?? *Size+5?        5@      $ Supplier price??5A   )   $ * 5B   )    5C   )   ?? *
Supplier+5F        5G      $ Supplier price??5H   )   $ * 5I   )    5J   )   ?? *
Supplier+5M        5N      $ Suggested sell price??5O   )   $ * 5P   )    5Q   )   ?? *	Suggested+5T        5U      $ 
Sell price??5V   )   $ * 5W   )    5X   )   ?? *	SellPrice+5[        5\      $ Suggested action??5]   )   $ * 5^   )    5_   )   ?? *Action+5b      5i      5j      ?? 5k   
   $??1??6   ._?5l      ?? -   5         ??Name$ Validate??5o      $??35,50,67,669q?5l      $??Validate??5m      5o      5p      5q      5r      