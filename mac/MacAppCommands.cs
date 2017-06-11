using AppKit;
using Foundation;
using System;
using System.Windows;
using System.Windows.Input;

namespace Netapad
{
    class MacCommand : NSObject, ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected EditorWindow window;
        public MacCommand(EditorWindow aWindow)
        {
            window = aWindow;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public virtual void Execute(object parameter)
        {}
    }
    class CutCommand : MacCommand
    {
        public CutCommand(EditorWindow aWindow) : base(aWindow) {}
        public override void Execute(object parameter)
        {
            var textView = window.TextBox.Handle as NSTextView;
            textView.Cut(this);
        }
    }
    class CopyCommand : MacCommand
    {
        public CopyCommand(EditorWindow aWindow) : base(aWindow) {}
        public override void Execute(object parameter)
        {
            var textView = window.TextBox.Handle as NSTextView;
            textView.Copy(this);
        }
    }
    class PasteCommand : MacCommand
    {
        public PasteCommand(EditorWindow aWindow) : base(aWindow) {}
        public override void Execute(object parameter)
        {
            var textView = window.TextBox.Handle as NSTextView;
            textView.Paste(this);
        }
    }
    class DeleteCommand : MacCommand
    {
        public DeleteCommand(EditorWindow aWindow) : base(aWindow) {}
        public override void Execute(object parameter)
        {
            var textView = window.TextBox.Handle as NSTextView;
            textView.Delete(this);
        }
    }
    class SelectAllCommand : MacCommand
    {
        public SelectAllCommand(EditorWindow aWindow) : base(aWindow) {}
        public override void Execute(object parameter)
        {
            var textView = window.TextBox.Handle as NSTextView;
            textView.SelectAll(this);
        }
    }
    
    class MacAppCommands : IAppCommands
    {
        MacCommand newCommand;
        MacCommand openCommand;
        MacCommand saveCommand;
        MacCommand saveAsCommand;
        MacCommand printCommand;
        MacCommand undoCommand;
        MacCommand cutCommand;
        MacCommand copyCommand;
        MacCommand pasteCommand;
        MacCommand deleteCommand;
        MacCommand findCommand;
        MacCommand replaceCommand;
        MacCommand selectAllCommand;

        public MacAppCommands(EditorWindow aWindow)
        {
            newCommand = new MacCommand(aWindow);
            openCommand = new MacCommand(aWindow);
            saveCommand = new MacCommand(aWindow);
            saveAsCommand = new MacCommand(aWindow);
            printCommand = new MacCommand(aWindow);
            undoCommand = new MacCommand(aWindow);
            cutCommand = new CutCommand(aWindow);
            copyCommand = new CopyCommand(aWindow);
            pasteCommand = new PasteCommand(aWindow);
            deleteCommand = new DeleteCommand(aWindow);
            findCommand = new MacCommand(aWindow);
            replaceCommand = new MacCommand(aWindow);
            selectAllCommand = new SelectAllCommand(aWindow);
        }

        public ICommand New { get { return newCommand; } }
        public ICommand Open { get { return openCommand; } }
        public ICommand Save { get { return saveCommand; } }
        public ICommand SaveAs { get { return saveAsCommand; } }
        public ICommand Print { get { return printCommand; } }
        public ICommand Undo { get { return undoCommand; } }
        public ICommand Cut { get { return cutCommand; } }
        public ICommand Copy { get { return copyCommand; } }
        public ICommand Paste { get { return pasteCommand; } }
        public ICommand Delete { get { return deleteCommand; } }
        public ICommand Find { get { return findCommand; } }
        public ICommand Replace { get { return replaceCommand; } }
        public ICommand SelectAll { get { return selectAllCommand; } }
    }
}