using System;
using System.Windows.Controls;
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

    class WpfMenuBar : IMenuBar
    {
        Menu menuBar = new Menu();
        public object Handle {
            get { return menuBar; }
        }

        public WpfMenuBar(MenuDefinition[] aMenus)
        {
            DockPanel.SetDock(menuBar, Dock.Top);
            foreach (var menuDef in aMenus)
            {
                var menu = new MenuItem();
                menu.Header = menuDef.Item1;

                foreach (var item in menuDef.Item2)
                {
                    if (item == MenuItemDefinition.Separator) {
                        menu.Items.Add(new Separator());
                        continue;
                    }
                    var menuItem = new MenuItem();
                    menuItem.Header = item.Item1;
                    menuItem.Command = item.Item2;
                    menu.Items.Add(menuItem);
                }

                menuBar.Items.Add(menu);
            }
        }
    }
}