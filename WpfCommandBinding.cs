using System.Windows.Input;

namespace Netapad
{
    class WpfExecutedEventArgs : IExecutedEventArgs, IControl
    {
        ExecutedRoutedEventArgs e;
        public object Handle {
            get { return e; }
        }

        public WpfExecutedEventArgs(ExecutedRoutedEventArgs e) {
            this.e = e;
        }
    }
    class WpfCanExecuteEventArgs : ICanExecuteEventArgs, IControl
    {
        CanExecuteRoutedEventArgs e;
        public object Handle {
            get { return e; }
        }

        public bool CanExecute {
            get { return e.CanExecute; }
            set { e.CanExecute = value; }
        }

        public WpfCanExecuteEventArgs(CanExecuteRoutedEventArgs e) {
            this.e = e;
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
        public WpfCommandBinding(ICommand cmd, ExecutedEventHandler executed, CanExecuteEventHandler canExecute)
        {
            mExecuted   = executed;
            mCanExecute = canExecute;
            binding = new CommandBinding(cmd, Executed, CanExecute);
        }

        public void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mExecuted(sender, new WpfExecutedEventArgs(e));
        }
        public void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            mCanExecute(sender, new WpfCanExecuteEventArgs(e));
        }
    }
}