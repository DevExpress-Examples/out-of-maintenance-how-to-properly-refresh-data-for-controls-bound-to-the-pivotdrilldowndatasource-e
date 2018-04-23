using System;
using System.Windows;
using DevExpress.Xpf.PivotGrid;

namespace Q292166 {
    /// <summary>
    /// Interaction logic for DrillDownWindow.xaml
    /// </summary>
    public partial class DrillDownWindow :Window, IDrillDownUpdateableWindow {
        PivotGridControl fPivot;
        object[] fColumnValues;
        object[] fRowValues;

        private DrillDownWindow() {
            InitializeComponent();
        }

        public DrillDownWindow(PivotGridControl pivot, object[] columnValues, object[] rowValues)
            : this() {
                fPivot = pivot;
                fColumnValues = columnValues;
                fRowValues = rowValues;
                DoRefreshData();   
        }

        void IDrillDownUpdateableWindow.RefreshData() {
            DoRefreshData();
        }

        protected virtual void DoRefreshData() {
            int columnIndex = fPivot.GetColumnIndex(fColumnValues);
            int rowIndex = fPivot.GetRowIndex(fRowValues);
            if (columnIndex < 0 || rowIndex < 0) drillDownView.DataSource = null;
            else drillDownView.DataSource = fPivot.CreateDrillDownDataSource(columnIndex, rowIndex);
            drillDownView.PopulateColumns();
        }
    }

    public interface IDrillDownUpdateableWindow {
        void RefreshData();
    }
}
