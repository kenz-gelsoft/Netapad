using Foundation;
using System;
using System.Windows;
using System.Windows.Input;

namespace Netapad
{
    class MacCommand : NSObject, ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {}
    }
    
    class MacAppCommands : IAppCommands
    {
        MacCommand newCommand = new MacCommand();
        public ICommand New { get { return newCommand; } }
        MacCommand openCommand = new MacCommand();
        public ICommand Open { get { return openCommand; } }
        MacCommand saveCommand = new MacCommand();
        public ICommand Save { get { return saveCommand; } }
        MacCommand saveAsCommand = new MacCommand();
        public ICommand SaveAs { get { return saveAsCommand; } }
        MacCommand printCommand = new MacCommand();
        public ICommand Print { get { return printCommand; } }
        MacCommand undoCommand = new MacCommand();
        public ICommand Undo { get { return undoCommand; } }
        MacCommand cutCommand = new MacCommand();
        public ICommand Cut { get { return cutCommand; } }
        MacCommand copyCommand = new MacCommand();
        public ICommand Copy { get { return copyCommand; } }
        MacCommand pasteCommand = new MacCommand();
        public ICommand Paste { get { return pasteCommand; } }
        MacCommand deleteCommand = new MacCommand();
        public ICommand Delete { get { return deleteCommand; } }
        MacCommand findCommand = new MacCommand();
        public ICommand Find { get { return findCommand; } }
        MacCommand replaceCommand = new MacCommand();
        public ICommand Replace { get { return replaceCommand; } }
        MacCommand selectAllCommand = new MacCommand();
        public ICommand SelectAll { get { return selectAllCommand; } }
    }
}