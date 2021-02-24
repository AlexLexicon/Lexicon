using System.Windows;

namespace Lexicon.WPF.AttachableProperties
{
    public static class Window
    {
        public static class Invoke
        {
            public static readonly DependencyProperty CloseProperty = DependencyProperty.RegisterAttached("Close", typeof(bool), typeof(Window), new PropertyMetadata(OnCloseChanged));
            public static bool GetClose(DependencyObject obj) => (bool)obj.GetValue(CloseProperty);
            public static void SetClose(DependencyObject obj, bool value) => obj.SetValue(CloseProperty, value);
            private static void OnCloseChanged(object sender, DependencyPropertyChangedEventArgs args)
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
}
