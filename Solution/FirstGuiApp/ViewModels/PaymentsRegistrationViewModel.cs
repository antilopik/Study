using System.IO;
using System.Windows.Input;
using Model.View.ViewModel.Base;
using Model.View.ViewModel.Base.Commands;

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
            const string fileName = "payment.txt";
            if (!File.Exists(fileName))
            {
                var stream = File.Create(fileName);
                stream.Dispose();
            }


            var input = $"Адресс: {Address}, период: {Period}, сумма: {Amount}";
            {
                File.AppendAllLines(fileName, new string[] { input });
            }
        }
    }
}
