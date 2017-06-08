using System.Windows.Input;

namespace Netapad
{
    interface IAppCommands
    {
        ICommand New { get; }
        ICommand Open { get; }
        ICommand Save { get; }
        ICommand SaveAs { get; }
        ICommand Print { get; }
        ICommand Undo { get; }
        ICommand Cut { get; }
        ICommand Copy { get; }
        ICommand Paste { get; }
        ICommand Delete { get; }
        ICommand Find { get; }
        ICommand Replace { get; }
        ICommand SelectAll { get; }
    }
}