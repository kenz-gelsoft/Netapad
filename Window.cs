using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class NetapadWindow : Window
{
    public NetapadWindow()
    {
        this.Title = "ネタ帳";

        DockPanel panel = new DockPanel();

        panel.Children.Add(BuildMenuBar());

        TextBox textBox = new TextBox();
        textBox.AcceptsReturn = true;
        panel.Children.Add(textBox);

        this.Content = panel;
    }

    class MenuDefinition : Tuple<string, MenuItemDefinition[]>
    {
        public MenuDefinition(string s, MenuItemDefinition[] items) : base(s, items) {}
    }

    class MenuItemDefinition : Tuple<string, ICommand>
    {
        static MenuItemDefinition separator = new MenuItemDefinition("", null);
        public static MenuItemDefinition Separator {
            get {
                return separator;
            }
        }
        public MenuItemDefinition(string s, ICommand c) : base(s, c) {}
    }

    Menu BuildMenuBar()
    {
        Menu menuBar = new Menu();
        DockPanel.SetDock(menuBar, Dock.Top);

        MenuDefinition[] menus = {
            new MenuDefinition("ファイル(_F)", new MenuItemDefinition[] {
                new MenuItemDefinition("新規(_N)", ApplicationCommands.New),
                new MenuItemDefinition("開く(_O)...", ApplicationCommands.Open),
                new MenuItemDefinition("上書き保存(_S)", ApplicationCommands.Save),
                new MenuItemDefinition("名前を付けて保存(_A)...", ApplicationCommands.SaveAs),
                MenuItemDefinition.Separator,
                new MenuItemDefinition("ページ設定(_U)...", new PageSettingsCommand(this)),
                new MenuItemDefinition("印刷(_P)...", ApplicationCommands.Print),
                MenuItemDefinition.Separator,
                new MenuItemDefinition("ネタ帳の終了(_X)", new ExitCommand(this)),
            }),
            new MenuDefinition("編集(_E)", new MenuItemDefinition[] {
                new MenuItemDefinition("元に戻す(_U)", ApplicationCommands.Undo),
                MenuItemDefinition.Separator,
                new MenuItemDefinition("切り取り(_T)", ApplicationCommands.Cut),
                new MenuItemDefinition("コピー(_C)", ApplicationCommands.Copy),
                new MenuItemDefinition("貼り付け(_P)", ApplicationCommands.Paste),
                new MenuItemDefinition("削除(_L)", ApplicationCommands.Delete),
                MenuItemDefinition.Separator,
                new MenuItemDefinition("検索(_F)...", ApplicationCommands.Find),
                new MenuItemDefinition("次を検索(_N)", new FindNextCommand(this)),
                new MenuItemDefinition("置換(_R)...", ApplicationCommands.Replace),
                new MenuItemDefinition("行へ移動(_G)...", new GotoCommand(this)),
                MenuItemDefinition.Separator,
                new MenuItemDefinition("すべて選択(_A)", ApplicationCommands.SelectAll),
                new MenuItemDefinition("日付と時刻(_D)...", new DateTimeCommand(this)),
            }),
        };

        foreach (var menuDef in menus)
        {
            MenuItem menu = new MenuItem();
            menu.Header = menuDef.Item1;

            foreach (var item in menuDef.Item2)
            {
                if (item == MenuItemDefinition.Separator) {
                    menu.Items.Add(new Separator());
                    continue;
                }
                MenuItem menuItem = new MenuItem();
                menuItem.Header = item.Item1;
                menuItem.Command = item.Item2;
                menu.Items.Add(menuItem);
            }

            menuBar.Items.Add(menu);
        }
        return menuBar;
    }

    class PageSettingsCommand : WindowCommand
    {
        public PageSettingsCommand(Window w) : base(w) {}
        public override void Execute(object parameter)
        {
            // TODO
        }
    }
    class ExitCommand : WindowCommand
    {
        public ExitCommand(Window w) : base(w) {}
        public override void Execute(object parameter)
        {
            window.Close();
        }
    }
    class FindNextCommand : WindowCommand
    {
        public FindNextCommand(Window w) : base(w) {}
        public override void Execute(object parameter)
        {
            // TODO
        }
    }
    class GotoCommand : WindowCommand
    {
        public GotoCommand(Window w) : base(w) {}
        public override void Execute(object parameter)
        {
            // TODO
        }
    }
    class DateTimeCommand : WindowCommand
    {
        public DateTimeCommand(Window w) : base(w) {}
        public override void Execute(object parameter)
        {
            // TODO
        }
    }

    abstract class WindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add {} remove {} }

        protected Window window;
        public WindowCommand(Window w)
        {
            window = w;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public abstract void Execute(object parameter);
    }
}
