namespace Netapad
{
    interface IExecutedEventArgs
    {}
    interface ICanExecuteEventArgs
    {
        bool CanExecute { get; set; }
    }

    delegate void ExecutedEventHandler(object sender, IExecutedEventArgs e);
    delegate void CanExecuteEventHandler(object sender, ICanExecuteEventArgs e);

    interface ICommandBinding : IControl
    {}
}