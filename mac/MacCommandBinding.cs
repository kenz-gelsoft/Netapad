using System;
using System.Windows.Input;

namespace Netapad
{
    class MacExecutedEventArgs : IExecutedEventArgs, IControl
    {
        public object Handle {
            get { return null; }
        }
        public MacExecutedEventArgs() {
        }
    }
    class MacCanExecuteEventArgs : ICanExecuteEventArgs, IControl
    {
        public object Handle {
            get { return null; }
        }

        bool canExecute = true;
        public bool CanExecute {
            get { return canExecute; }
            set { canExecute = value; }
        }

        public MacCanExecuteEventArgs() {
        }
    }

    class MacCommandBinding : ICommandBinding, ICommand
    {
        public object Handle {
            get { return null; }
        }

        ICommand mCommand;
        public ICommand Command {
            get {
                return mCommand;
            }
        }

        public event EventHandler CanExecuteChanged;
        ExecutedEventHandler mExecuted;
        CanExecuteEventHandler mCanExecute;
        public MacCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute)
        {
            mCommand    = aCommand;
            mExecuted   = aExecuted;
            mCanExecute = aCanExecute;
        }

        public void Execute(object parameter)
        {
            mExecuted(parameter, null);
        }
        public bool CanExecute(object sender)
        {
            var arg = new MacCanExecuteEventArgs();
            mCanExecute(sender, arg);
            return arg.CanExecute;
        }
    }
}