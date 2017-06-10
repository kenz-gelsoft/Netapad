using System.Windows;
using System.Windows.Input;

namespace Netapad
{
    class WpfAppCommands : IAppCommands
    {
        public ICommand New { get { return ApplicationCommands.New; } }
        public ICommand Open { get { return ApplicationCommands.Open; } }
        public ICommand Save { get { return ApplicationCommands.Save; } }
        public ICommand SaveAs { get { return ApplicationCommands.SaveAs; } }
        public ICommand Print { get { return ApplicationCommands.Print; } }
        public ICommand Undo { get { return ApplicationCommands.Undo; } }
        public ICommand Copy { get { return ApplicationCommands.Copy; } }
        public ICommand Cut { get { return ApplicationCommands.Cut; } }
        public ICommand Paste { get { return ApplicationCommands.Paste; } }
        public ICommand Delete { get { return ApplicationCommands.Delete; } }
        public ICommand Find { get { return ApplicationCommands.Find; } }
        public ICommand Replace { get { return ApplicationCommands.Replace; } }
        public ICommand SelectAll { get { return ApplicationCommands.SelectAll; } }
    }
}