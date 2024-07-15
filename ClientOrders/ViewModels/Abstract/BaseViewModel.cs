using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientOrders.ViewModels.Abstract
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public abstract void OnAppearing();

        // standard implementation for setting property in Xamarin/MAUI
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        // event which informs that some property changed (usuallt used to invoke form validation method)
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
