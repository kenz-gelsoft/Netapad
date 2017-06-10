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

    class MacCommandBinding : ICommandBinding
    {
        public object Handle {
            get { return null; }
        }

        ExecutedEventHandler mExecuted;
        CanExecuteEventHandler mCanExecute;
        public MacCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute)
        {
            mExecuted   = aExecuted;
            mCanExecute = aCanExecute;
        }
    }
}