using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Lexicon.WPF.AttachableProperties
{
    public class DataGrid
    {
        public static readonly DependencyProperty BindableColumnsProperty = DependencyProperty.RegisterAttached("BindableColumns", typeof(ObservableCollection<DataGridColumn>), typeof(DataGrid), new UIPropertyMetadata(null, BindableColumnsPropertyChanged));
        public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value) => element.SetValue(BindableColumnsProperty, value);
        public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject element) => (ObservableCollection<DataGridColumn>)element.GetValue(BindableColumnsProperty);
        private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid dataGrid = source as System.Windows.Controls.DataGrid;
            dataGrid.Columns.Clear();
            if (e.NewValue is not ObservableCollection<DataGridColumn> columns)
                return;
            foreach (DataGridColumn column in columns)
            {
                dataGrid.Columns.Add(column);
            }
            columns.CollectionChanged += (sender, e2) =>
            {
                NotifyCollectionChangedEventArgs ne = e2;
                if (ne.Action == NotifyCollectionChangedAction.Reset)
                {
                    dataGrid.Columns.Clear();
                    if (ne.NewItems != null)
                    {
                        foreach (DataGridColumn column in ne.NewItems)
                        {
                            dataGrid.Columns.Add(column);
                        }
                    }
                }
                else if (ne.Action == NotifyCollectionChangedAction.Add)
                {
                    if (ne.NewItems != null)
                    {
                        foreach (DataGridColumn column in ne.NewItems)
                        {
                            dataGrid.Columns.Add(column);
                        }
                    }
                }
                else if (ne.Action == NotifyCollectionChangedAction.Move)
                {
                    dataGrid.Columns.Move(ne.OldStartingIndex, ne.NewStartingIndex);
                }
                else if (ne.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (ne.OldItems != null)
                    {
                        foreach (DataGridColumn column in ne.OldItems)
                        {
                            dataGrid.Columns.Remove(column);
                        }
                    }
                }
                else if (ne.Action == NotifyCollectionChangedAction.Replace)
                {
                    dataGrid.Columns[ne.NewStartingIndex] = ne.NewItems[0] as DataGridColumn;
                }
            };
        }
    }
}
