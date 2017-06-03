using System.Windows;
using System.Windows.Input;

namespace Netapad
{
    class WpfAppCommands
    {
        public ICommand New {
            get {
                return ApplicationCommands.New;
            }
        }
        public ICommand Open {
            get {
                return ApplicationCommands.Open;
            }
        }
        public ICommand Save {
            get {
                return ApplicationCommands.Save;
            }
        }
        public ICommand SaveAs {
            get {
                return ApplicationCommands.SaveAs;
            }
        }
        public ICommand Print {
            get {
                return ApplicationCommands.Print;
            }
        }
    }
}