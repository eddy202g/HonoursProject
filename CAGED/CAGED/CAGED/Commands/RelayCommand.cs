﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;

namespace CAGED.Commands
{
    public class RelayCommand : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

    }
}
