   M S B A M L   `   `   `  ????L  HPhamTrongThanhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PhamTrongThanhWPF.rentingPhamTrongThanhWPF.renting  5      +    %PhamTrongThanhWPF.renting.RentingPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PhamTrongThanhWPF.renting     5        N? Title$  RentingPage??5	      .??5      ??  ?? Orientation$ Vertical=?6   .+?5   
   ?? -   5        $??lblRentingManagement??5      $??DemiBold"?6,   $??20(?6B   $??Center=?6P   $??Renting Information??5      64   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dgRentingManagement??5         AutoGenerateColumns$ False??6.      
IsReadOnly$
 True??6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Customer ID??6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? *
CustomerId+  5      $ * 6%   $ Car ID??6/    6?   ?? *CarId+  5      $ * 6%   $ Pickup Date??6/    6D   ?? *
PickupDate+  5      $ * 6%   $ Return Date??6/    6D   ?? *
ReturnDate+  5      $ * 6%   $ 
Rent Price??6/    6C   ?? *	RentPrice+  5      $ * 6%   $ Total Price??6/    6D   ?? *
TotalPrice+5      ?? 5   
   $ 
Horizontal=?6   .+?5      ?? -   5        $??btnAdd??5      $	??Add??6#   $??80??6G   $??
180 0 40 0q?6R   6h   ?? 5      -   5        $??btnView??5      $??View Report Statistic??6$   $??80??6[   $??
40 0 180 0q?6f   6|   5      5      5       