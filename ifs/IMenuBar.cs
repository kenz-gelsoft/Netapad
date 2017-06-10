using System;
using System.Windows.Input;

namespace Netapad
{
    class MenuDefinition : Tuple<string, string, MenuItemDefinition[]>
    {
        public MenuDefinition(string aLabel, string aMnemonic, MenuItemDefinition[] aItems) :
            base(aLabel, aMnemonic, aItems)
        {}
    }

    // TODO: make ICommand xp
    class MenuItemDefinition : Tuple<string, string, ICommand>
    {
        static MenuItemDefinition separator = new MenuItemDefinition("", "", null);
        public static MenuItemDefinition Separator {
            get {
                return separator;
            }
        }
        public MenuItemDefinition(string aLabel, string aMnemonic, ICommand aCommand) :
            base(aLabel, aMnemonic, aCommand)
        {}
    }

    interface IMenuBar : IControl
    {}
}
