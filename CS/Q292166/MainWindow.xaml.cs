using System;
using System.Data;
using System.Windows;
using System.Data.OleDb;
using System.Collections;
using DevExpress.Xpf.PivotGrid;

namespace Q292166 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {
        bool filtered;

        public MainWindow() {
            InitializeComponent();
            salesPersonPivot.DataSource = GetDataSource(false);
        }

        private void OnSalesPersonPivotCellClick(object sender, PivotCellEventArgs e) {
            PivotGridControl pivot = (PivotGridControl)sender;
            new DrillDownWindow(pivot, GetValues(pivot, e.GetColumnFields(), e.ColumnIndex), GetValues(pivot, e.GetRowFields(), e.RowIndex)).Show();
        }

        object[] GetValues(PivotGridControl pivot, PivotGridField[] fields, int lastLevelIndex) {
            ArrayList result = new ArrayList();
            foreach (PivotGridField field in fields)
                result.Add(pivot.GetFieldValue(field, lastLevelIndex));
            return result.ToArray();
        }

        DataTable GetDataSource(bool filtered) {
            string select = "select [Sales Person], CategoryName, [Extended Price] from SalesPerson";
            if (filtered) select = string.Concat(select, " where [Extended Price] > 100");
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\nwind.mdb");
            DataTable source = new DataTable();
            adapter.Fill(source);
            return source;
        }

        private void OnReloadButtonClick(object sender, RoutedEventArgs e) {
            filtered = !filtered;
            salesPersonPivot.DataSource = GetDataSource(filtered);
            foreach (Window window in Application.Current.Windows)
                if (window is IDrillDownUpdateableWindow)
                    ((IDrillDownUpdateableWindow)window).RefreshData();
        }
    }
}
