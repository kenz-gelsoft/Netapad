using AppKit;
using Foundation;
using ObjCRuntime;
using System;
using System.Windows.Input;

namespace Netapad
{
    class CommandTargetAdapter : NSObject
    {
        ICommand command;
        public CommandTargetAdapter(ICommand aCommand)
        {
            command = aCommand;
        }

        [Action("execute:")]
        public void defineKeyword (NSObject sender) {
            command.Execute(sender);
        }

        [Action("validateMenuItem:")]
        public bool ValidateMenuItem (NSMenuItem item) {
            // sender として何を送るべきか分からないので、
            // とりあえず null を送信しています。
            return command.CanExecute(null);
        }
    }

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
                    submenuItem.Target = new CommandTargetAdapter(item.Item3);
                    submenuItem.Action = new Selector("execute:");
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