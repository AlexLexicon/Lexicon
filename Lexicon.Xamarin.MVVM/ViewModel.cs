using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lexicon.Xamarin.MVVM
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = default) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        protected virtual void Setter<T>(ref T field, T value, bool invokeOnMatchingValue = true, [CallerMemberName] string name = default)
        {
            if (!invokeOnMatchingValue || !EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}