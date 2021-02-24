using System.Windows;

namespace Lexicon.WPF.AttachableProperties
{
    public static class WindowAPs
    {
        public static readonly DependencyProperty QuitProperty = DependencyProperty.RegisterAttached("Quit", typeof(bool), typeof(WindowAPs), new PropertyMetadata(OnQuitChanged));
        public static bool GetQuit(DependencyObject obj) => (bool)obj.GetValue(QuitProperty);
        public static void SetQuit(DependencyObject obj, bool value) => obj.SetValue(QuitProperty, value);
        private static void OnQuitChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (sender is Window window)
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
