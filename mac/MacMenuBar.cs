using AppKit;
using Foundation;
using ObjCRuntime;
using System;
using System.Windows.Input;

namespace Netapad
{
    class CommandTargetAdapter : NSObject
    {
        MacMenuBar parent;

        ICommand command;
        public CommandTargetAdapter(MacMenuBar aParent, ICommand aCommand)
        {
            parent  = aParent;
            command = aCommand;
        }

        [Action("execute:")]
        public void Execute(NSObject sender) {
            parent.BindingOrCommand(command).Execute(sender);
        }

        [Action("validateMenuItem:")]
        public bool ValidateMenuItem (NSMenuItem item) {
            // sender として何を送るべきか分からないので、
            // とりあえず null を送信しています。
            return parent.BindingOrCommand(command).CanExecute(null);
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
                    submenuItem.Target = new CommandTargetAdapter(this, item.Item4);
                    submenuItem.Action = new Selector("execute:");
                    var shortcut = item.Item3;
                    if (shortcut != null) {
                        submenuItem.KeyEquivalent = shortcut.Key.ToLower();
                        submenuItem.KeyEquivalentModifierMask = ToCocoaMask(shortcut.Modifiers);
                    }
                    submenu.AddItem(submenuItem);
                }

                menuBar.AddItem(menuItem);
            }
        }

        NSEventModifierMask ToCocoaMask(int aModifiers)
        {
            NSEventModifierMask mask = 0;
            if ((aModifiers & Shortcut.SHIFT) != 0) {
                mask |= NSEventModifierMask.ShiftKeyMask;
            }
            if ((aModifiers & Shortcut.CTRL) != 0) {
                mask |= NSEventModifierMask.CommandKeyMask;
            }
            return mask;
        }

        MacWindow attachedWindow;
        public void AddToWindow(MacWindow aWindow)
        {
            attachedWindow = aWindow;
            // TODO メニューバーの設定はアプリケーション単位にした方がよさそう
            NSApplication.SharedApplication.MainMenu = menuBar;
        }
        public ICommand BindingOrCommand(ICommand aCommand)
        {
            return attachedWindow.BindingOrCommand(aCommand);
        }
    }
}