using System.Windows.Input;

namespace Netapad
{
    class WpfExecutedEventArgs : IExecutedEventArgs, IControl
    {
        ExecutedRoutedEventArgs args;
        public object Handle {
            get { return args; }
        }

        public WpfExecutedEventArgs(ExecutedRoutedEventArgs aArgs) {
            this.args = aArgs;
        }
    }
    class WpfCanExecuteEventArgs : ICanExecuteEventArgs, IControl
    {
        CanExecuteRoutedEventArgs args;
        public object Handle {
            get { return args; }
        }

        public bool CanExecute {
            get { return args.CanExecute; }
            set { args.CanExecute = value; }
        }

        public WpfCanExecuteEventArgs(CanExecuteRoutedEventArgs aArgs) {
            this.args = aArgs;
        }
    }

    class WpfCommandBinding : ICommandBinding
    {
        CommandBinding binding;
        public object Handle {
            get { return binding; }
        }

        ExecutedEventHandler mExecuted;
        CanExecuteEventHandler mCanExecute;
        public WpfCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute)
        {
            mExecuted   = aExecuted;
            mCanExecute = aCanExecute;
            binding = new CommandBinding(aCommand, Executed, CanExecute);
        }

        public void Executed(object aSender, ExecutedRoutedEventArgs aArgs)
        {
            mExecuted(aSender, new WpfExecutedEventArgs(aArgs));
        }
        public void CanExecute(object aSender, CanExecuteRoutedEventArgs aArgs)
        {
            mCanExecute(aSender, new WpfCanExecuteEventArgs(aArgs));
        }
    }
}