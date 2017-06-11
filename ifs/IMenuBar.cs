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

    class MenuItemDefinition : Tuple<string, string, Shortcut, ICommand>
    {
        static MenuItemDefinition separator = new MenuItemDefinition("", "", null, null);
        public static MenuItemDefinition Separator {
            get {
                return separator;
            }
        }
        public MenuItemDefinition(string aLabel, string aMnemonic, Shortcut aShortcut, ICommand aCommand) :
            base(aLabel, aMnemonic, aShortcut, aCommand)
        {}
    }

    class Shortcut
    {
        public static int NONE  = 0;
        public static int CTRL  = 1 << 0;
        public static int SHIFT = 1 << 1;

        public static Shortcut Ctrl(string aKey)
        {
            return new Shortcut(CTRL, aKey);
        }

        public static Shortcut ShiftCtrl(string aKey)
        {
            return new Shortcut(SHIFT | CTRL, aKey);
        }

        string key;
        public string Key { get { return key; } }

        int modifiers;
        public int Modifiers { get { return modifiers; } }

        public Shortcut(int aModifiers, string aKey)
        {
            modifiers = aModifiers;
            key       = aKey;
        }
    }

    interface IMenuBar : IControl
    {}
}
