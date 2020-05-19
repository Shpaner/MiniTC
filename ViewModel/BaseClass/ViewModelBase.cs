using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MiniTC.ViewModel.BaseClass
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(params string[] namesOfproperties)
        {
            if (PropertyChanged != null)
            {
                foreach (var property in namesOfproperties)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }

        
    }
}
