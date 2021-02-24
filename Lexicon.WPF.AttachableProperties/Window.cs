using System.Windows;

namespace Lexicon.WPF.AttachableProperties
{
    public static class Window
    {
        public static readonly DependencyProperty InvokeCloseProperty = DependencyProperty.RegisterAttached("InvokeClose", typeof(bool), typeof(Window), new PropertyMetadata(OnInvokeCloseChanged));
        public static bool GetInvokeClose(DependencyObject obj) => (bool)obj.GetValue(InvokeCloseProperty);
        public static void SetInvokeClose(DependencyObject obj, bool value) => obj.SetValue(InvokeCloseProperty, value);
        private static void OnInvokeCloseChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (sender is System.Windows.Window window)
            {
                if (args.NewValue is bool result)
                {
                    if (result)
                        window.Close();
                }
            }
        }
    }
}
