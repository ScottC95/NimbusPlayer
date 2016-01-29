using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NimbusPlayer.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        protected ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            VerfiyPropertyName(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged<T>(T oldValue = default(T),
                                                    T newValue = default(T),
                                                    bool broadcast = false,
                                                    [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("This method cannot be called with an empty string", propertyName);
            }
            OnPropertyChanged(propertyName);
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

        protected virtual void SetAndNotify<T>(ref T field,
                                               T newValue,
                                               bool broadcast = false,
                                               [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return;
            var oldValue = field;
            field = newValue;
            OnPropertyChanged(oldValue, newValue, broadcast, propertyName);
        }

        public void VerfiyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentNullException("Invalid property name: " + propertyName);
            }
        }
    }
}