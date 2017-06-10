using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Netapad
{
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
                menu.Header = LabelWithMnemonic(menuDef.Item1, menuDef.Item2);

                foreach (var item in menuDef.Item3)
                {
                    if (item == MenuItemDefinition.Separator) {
                        menu.Items.Add(new Separator());
                        continue;
                    }
                    var menuItem = new MenuItem();
                    menuItem.Header = LabelWithMnemonic(item.Item1, item.Item2);
                    menuItem.Command = item.Item3;
                    menu.Items.Add(menuItem);
                }

                menuBar.Items.Add(menu);
            }
        }

        static string LabelWithMnemonic(string aLabel, string aMnemonic)
        {
            var insertPosition = aLabel.LastIndexOf("...");
            if (insertPosition < 0) {
                insertPosition = aLabel.Length;
            }
            return aLabel.Insert(insertPosition, String.Format("(_{0})", aMnemonic));
        }
    }
}