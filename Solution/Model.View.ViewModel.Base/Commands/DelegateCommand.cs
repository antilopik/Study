﻿using System.Windows.Input;

namespace Model.View.ViewModel.Base.Commands
{
    public sealed class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<object?> _function;
        public DelegateCommand(Action<object?> function)
        {
            _function = function;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _function(parameter);
        }
    }
}
