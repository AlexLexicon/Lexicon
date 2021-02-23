using System.Windows;
using System.Windows.Controls;

namespace Lexicon.WPF.AttachableProperties
{
    public static class TextBoxAPs
    {
        private const string IS_ALL_SELECTED_PROPERTY = "IsSelectedAll";
        public static readonly DependencyProperty IsAllSelectedProperty = DependencyProperty.RegisterAttached(IS_ALL_SELECTED_PROPERTY, typeof(bool), typeof(TextBoxAPs), new FrameworkPropertyMetadata(IsAllSelectedChanged) { BindsTwoWayByDefault = true });
        public static bool GetIsAllSelected(DependencyObject obj) => (bool)obj.GetValue(IsAllSelectedProperty);
        public static void SetIsAllSelected(DependencyObject obj, bool isAllSelected) => obj.SetValue(IsAllSelectedProperty, isAllSelected);
        private static void IsAllSelectedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is TextBox textBox)
            {
                if (GetIsAllSelected(textBox))
                {
                    textBox.Focus();
                    textBox.SelectAll();
                }
            }
        }
    }
}
