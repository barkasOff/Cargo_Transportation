using System.ComponentModel;

namespace Cargo_Transportation.ViewModels.Base
{
    public class                                    BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler    PropertyChanged = (sender, e) => { };

        public void                                 OnPropertyChanged(string name) => PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}
