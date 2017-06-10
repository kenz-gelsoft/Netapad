using AppKit;
using System;
using System.Windows.Input;

namespace Netapad
{
    class MacMenuBar : IMenuBar, IMacControl
    {
        NSMenu menuBar = new NSMenu();
        public object Handle {
            get { return menuBar; }
        }

        public MacMenuBar(MenuDefinition[] aMenus)
        {
            foreach (var menuDef in aMenus)
            {
                var menuItem = new NSMenuItem();
                var submenu = new NSMenu(menuDef.Item1);
                menuItem.Submenu = submenu;

                foreach (var item in menuDef.Item3)
                {
                    if (item == MenuItemDefinition.Separator) {
                        submenu.AddItem(NSMenuItem.SeparatorItem);
                        continue;
                    }
                    var submenuItem = new NSMenuItem(item.Item1);
                    submenu.AddItem(submenuItem);
                }

                menuBar.AddItem(menuItem);
            }
        }

        public void AddToWindow(MacWindow aWindow)
        {
            // TODO メニューバーの設定はアプリケーション単位にした方がよさそう
            NSApplication.SharedApplication.MainMenu = menuBar;
        }
    }
}