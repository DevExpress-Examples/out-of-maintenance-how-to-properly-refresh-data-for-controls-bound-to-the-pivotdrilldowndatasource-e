Imports System.Data
Imports System.Windows
Imports System.Data.OleDb
Imports System.Collections
Imports DevExpress.Xpf.PivotGrid

Namespace Q292166

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private filtered As Boolean

        Public Sub New()
            Me.InitializeComponent()
            Me.salesPersonPivot.DataSource = GetDataSource(False)
        End Sub

        Private Sub OnSalesPersonPivotCellClick(ByVal sender As Object, ByVal e As PivotCellEventArgs)
            Dim pivot As PivotGridControl = CType(sender, PivotGridControl)
            Call New DrillDownWindow(pivot, GetValues(pivot, e.GetColumnFields(), e.ColumnIndex), GetValues(pivot, e.GetRowFields(), e.RowIndex)).Show()
        End Sub

        Private Function GetValues(ByVal pivot As PivotGridControl, ByVal fields As PivotGridField(), ByVal lastLevelIndex As Integer) As Object()
            Dim result As ArrayList = New ArrayList()
            For Each field As PivotGridField In fields
                result.Add(pivot.GetFieldValue(field, lastLevelIndex))
            Next

            Return result.ToArray()
        End Function

        Private Function GetDataSource(ByVal filtered As Boolean) As DataTable
            Dim [select] As String = "select [Sales Person], CategoryName, [Extended Price] from SalesPerson"
            If filtered Then [select] = String.Concat([select], " where [Extended Price] > 100")
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter([select], "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\nwind.mdb")
            Dim source As DataTable = New DataTable()
            adapter.Fill(source)
            Return source
        End Function

        Private Sub OnReloadButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            filtered = Not filtered
            Me.salesPersonPivot.DataSource = GetDataSource(filtered)
            For Each window As Window In Application.Current.Windows
                If TypeOf window Is IDrillDownUpdateableWindow Then CType(window, IDrillDownUpdateableWindow).RefreshData()
            Next
        End Sub
    End Class
End Namespace
