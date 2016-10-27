using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class Notifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Interface implementation. Event handler for Property Changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets Property. Use in setter.
        /// </summary>
        /// <typeparam name="T">Type of parameter</typeparam>
        /// <param name="storage">Backing Field</param>
        /// <param name="value">value to be set</param>
        /// <param name="PropertyName">Name of Property for backing field</param>
        /// <returns></returns>
        public bool SetProperty<T>(ref T storage, T value, string PropertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        /// <summary>
        /// On PropertyChange Notifier. Use outside setter.
        /// </summary>
        /// <param name="PropertyName">Name of Property being updated. Use nameof(Property) to pass in string.</param>
        public void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
