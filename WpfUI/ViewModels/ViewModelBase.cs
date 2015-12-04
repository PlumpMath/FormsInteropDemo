namespace WpfUI.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    abstract class ViewModelBase : INotifyPropertyChanged
    {
        //
        // INotifyPropertyChanged
        //
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<PropertyType>(ref PropertyType storageVariable, PropertyType newValue,
            [CallerMemberName] string propertyName = null)
        {
            bool propertyChanged = !object.Equals(storageVariable, newValue);

            if(propertyChanged)
            {
                storageVariable = newValue;
                EmitPropertyChanged(propertyName);
            }

            return propertyChanged;
        }

        protected void EmitPropertyChanged(string propertyName)
        {
            if (null != propertyName)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
