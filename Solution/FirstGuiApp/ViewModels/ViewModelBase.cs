using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstGuiApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void SetProp<TField>(TField newValue, ref TField field, [CallerMemberName] string caller = "")
        {
            if (!EqualityComparer<TField>.Default.Equals(newValue, field))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
