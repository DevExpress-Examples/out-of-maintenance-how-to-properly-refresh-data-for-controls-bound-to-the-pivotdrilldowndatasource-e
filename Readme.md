# How to properly refresh data for controls bound to the PivotDrillDownDataSource


<p>The PivotDrillDownDataSource is not automatically refreshed if the data source of the PivotGridControl is changed, or filter is applied to the PivotGridControl. Also, changes in the data source might change the data cells layout, and the cell for which the PivotDrillDownDataSource is created can disappear. So, to properly refresh data it is necessary to check whether the parent cell exists, and create a new PivotDrillDownDataSource.</p>

<br/>


