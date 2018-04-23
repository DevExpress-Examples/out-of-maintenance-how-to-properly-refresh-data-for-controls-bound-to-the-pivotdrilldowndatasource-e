Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace Q292166
	''' <summary>
	''' Interaction logic for DrillDownWindow.xaml
	''' </summary>
	Partial Public Class DrillDownWindow
		Inherits Window
		Implements IDrillDownUpdateableWindow
		Private fPivot As PivotGridControl
		Private fColumnValues() As Object
		Private fRowValues() As Object

		Private Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal pivot As PivotGridControl, ByVal columnValues() As Object, ByVal rowValues() As Object)
			Me.New()
				fPivot = pivot
				fColumnValues = columnValues
				fRowValues = rowValues
				DoRefreshData()
		End Sub

		Private Sub RefreshData() Implements IDrillDownUpdateableWindow.RefreshData
			DoRefreshData()
		End Sub

		Protected Overridable Sub DoRefreshData()
			Dim columnIndex As Integer = fPivot.GetColumnIndex(fColumnValues)
			Dim rowIndex As Integer = fPivot.GetRowIndex(fRowValues)
			If columnIndex < 0 OrElse rowIndex < 0 Then
				drillDownView.DataSource = Nothing
			Else
				drillDownView.DataSource = fPivot.CreateDrillDownDataSource(columnIndex, rowIndex)
			End If
			drillDownView.PopulateColumns()
		End Sub
	End Class

	Public Interface IDrillDownUpdateableWindow
		Sub RefreshData()
	End Interface
End Namespace
