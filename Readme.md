<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578881/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2655)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DrillDownWindow.xaml](./CS/Q292166/DrillDownWindow.xaml) (VB: [DrillDownWindow.xaml](./VB/Q292166/DrillDownWindow.xaml))
* [DrillDownWindow.xaml.cs](./CS/Q292166/DrillDownWindow.xaml.cs) (VB: [DrillDownWindow.xaml.vb](./VB/Q292166/DrillDownWindow.xaml.vb))
* [MainWindow.xaml](./CS/Q292166/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/Q292166/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/Q292166/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/Q292166/MainWindow.xaml.vb))
<!-- default file list end -->
# How to properly refresh data for controls bound to the PivotDrillDownDataSource


<p>The PivotDrillDownDataSource is not automatically refreshed if the data source of the PivotGridControl is changed, or filter is applied to the PivotGridControl. Also, changes in the data source might change the data cells layout, and the cell for which the PivotDrillDownDataSource is created can disappear. So, to properly refresh data it is necessary to check whether the parent cell exists, and create a new PivotDrillDownDataSource.</p>

<br/>


