using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Lexicon.WPF.AttachableProperties
{
    public static class Hyperlink
    {
        private const string IS_EXTERNAL_PROPERTY = "IsExternal";
        public static readonly DependencyProperty IsExternalProperty = DependencyProperty.RegisterAttached(IS_EXTERNAL_PROPERTY, typeof(bool), typeof(Hyperlink), new UIPropertyMetadata(false, OnIsExternalChanged));
        public static bool GetIsExternal(DependencyObject obj) => (bool)obj.GetValue(IsExternalProperty);
        public static void SetIsExternal(DependencyObject obj, bool value) => obj.SetValue(IsExternalProperty, value);
        private static void OnIsExternalChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (sender is System.Windows.Documents.Hyperlink hyperlink)
            {
                if (args.NewValue != null && args.NewValue is bool value && value)
                    hyperlink.RequestNavigate += Hyperlink_RequestNavigate;
                else
                    hyperlink.RequestNavigate -= Hyperlink_RequestNavigate;
            }
        }
        private static void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
