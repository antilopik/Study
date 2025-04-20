using System.ComponentModel;
using System.Windows.Input;
using FirstGuiApp.Commands;

namespace FirstGuiApp.ViewModels
{
    public class PaymentsRegistrationViewModel : INotifyPropertyChanged
    {
        private string _address;

        public string Address
        {
            get => _address;
            set 
            {
                if (!string.Equals(value, _address))
                { 
                    _address = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }

        public string Period { get; set; }
        public decimal Amount { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PaymentsRegistrationViewModel()
        {
            Command = new DelegateCommand(OnButtonClick);
        }

        public ICommand Command { get; }

        private void OnButtonClick(object param)
        {
            Address = "Valitie";
        }
    }
}
