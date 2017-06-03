namespace Netapad
{
    interface IExecutedEventArgs
    {}
    interface ICanExecuteEventArgs
    {
        bool CanExecute { get; set; }
    }

    delegate void ExecutedEventHandler(object aSender, IExecutedEventArgs aArgs);
    delegate void CanExecuteEventHandler(object aSender, ICanExecuteEventArgs aArgs);

    interface ICommandBinding : IControl
    {}
}