using HomeWork.Services;

namespace HomeWork.Tests.ServicesFakes
{
    internal class FakeDialog : IDialogService
    {
        public bool ValueToReturn { get; set; } = true;
        public bool ShowYesNoDialog(string title, string question)
        {
            return ValueToReturn;
        }
    }
}
