using System.ComponentModel;
using System.Windows.Input;
using FirstGuiApp.Commands;

namespace FirstGuiApp.ViewModels
{
    public class PaymentsRegistrationViewModel : ViewModelBase
    {
        private string _address;

        public string Address
        {
            get => _address;
            set => SetProp(value, ref _address);
        }

        private string _period;

        public string Period
        { 
            get => _period;
            set => SetProp(value, ref _period);
        }

        private decimal _amount;
        public decimal Amount 
        {
            get => _amount;
            set => SetProp(value, ref _amount);
        }


        public PaymentsRegistrationViewModel()
        {
            Command = new DelegateCommand(OnButtonClick);
        }

        public ICommand Command { get; }

        private void OnButtonClick(object param)
        {
            Address = "Valitie";
            Period = "adadaf fsa";
            Amount = Amount + 1;
        }
    }
}
