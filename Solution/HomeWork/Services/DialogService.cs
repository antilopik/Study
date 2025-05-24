using System.Windows;

namespace HomeWork.Services
{
    internal sealed class DialogService : IDialogService
    {
        public bool ShowYesNoDialog(string title, string question)
        {
            return MessageBox.Show(question, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}
