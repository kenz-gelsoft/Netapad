using System;
using System.Windows.Input;

namespace Netapad
{
    class MenuDefinition : Tuple<string, MenuItemDefinition[]>
    {
        public MenuDefinition(string aLabel, MenuItemDefinition[] aItems) : base(aLabel, aItems) {}
    }

    // TODO: make ICommand xp
    class MenuItemDefinition : Tuple<string, ICommand>
    {
        static MenuItemDefinition separator = new MenuItemDefinition("", null);
        public static MenuItemDefinition Separator {
            get {
                return separator;
            }
        }
        public MenuItemDefinition(string aLabel, ICommand aCommand) : base(aLabel, aCommand) {}
    }

    interface IMenuBar : IControl
    {}
}
