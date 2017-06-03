using System;
using System.IO;
using System.Windows.Input;

namespace Netapad
{
    class EditorWindow
    {
        IToolkit toolkit;
        IAppCommands appCommands;

        IWindow  window;
        ITextBox textBox;

        public object Handle
        {
            get {
                return window.Handle;
            }
        }

        private string filePath = null;
        string FilePath {
            get { return filePath; }
            set {
                filePath = value;
                UpdateTitle();
            }
        }

        private void UpdateTitle()
        {
            var fileName = filePath != null ? Path.GetFileName(filePath) : "無題";
            window.Title = fileName + " - ネタ帳";
        }

        public EditorWindow(IToolkit aToolkit)
        {
            toolkit = aToolkit;
            appCommands = aToolkit.NewAppCommands();
            window  = aToolkit.NewWindow();
            textBox = aToolkit.NewTextBox();

            UpdateTitle();

            window.Add(BuildMenuBar());
            window.Add(textBox);

            ICommandBinding[] bindings = {
                toolkit.NewCommandBinding(appCommands.New,
                    NewCmdExecuted, AlwaysCanExecute),
                toolkit.NewCommandBinding(appCommands.Open,
                    OpenCmdExecuted, AlwaysCanExecute),
                toolkit.NewCommandBinding(appCommands.Save,
                    SaveCmdExecuted, AlwaysCanExecute),
                toolkit.NewCommandBinding(appCommands.SaveAs,
                    SaveAsCmdExecuted, AlwaysCanExecute),
            };
            foreach (var binding in bindings) {
                window.AddCommandBinding(binding);
            }
        }

        void NewCmdExecuted(object aTarget, IExecutedEventArgs aArgs)
        {
            textBox.Text = "";
            FilePath = null;
        }
        void OpenCmdExecuted(object aTarget, IExecutedEventArgs aArgs)
        {
            IOpenDialog dialog = toolkit.NewOpenDialog();
            if (dialog.ShowDialog() == true) {
                textBox.Text = File.ReadAllText(dialog.FileName);
                FilePath = dialog.FileName;
            }
        }
        void SaveCmdExecuted(object aTarget, IExecutedEventArgs aArgs)
        {
            if (FilePath == null) {
                SaveAsCmdExecuted(aTarget, aArgs);
            } else {
                SaveTo(filePath);
            }
        }
        void SaveAsCmdExecuted(object aTarget, IExecutedEventArgs aArgs)
        {
            ISaveDialog dialog = toolkit.NewSaveDialog();
            if (dialog.ShowDialog() == true) {
                SaveTo(dialog.FileName);
            }
        }
        void SaveTo(string aFileName)
        {
            File.WriteAllText(aFileName, textBox.Text);
            FilePath = aFileName;
        }
        void AlwaysCanExecute(object aSender, ICanExecuteEventArgs aArgs)
        {
            aArgs.CanExecute = true;
        }

        IMenuBar BuildMenuBar()
        {
            MenuDefinition[] menus = {
                new MenuDefinition("ファイル(_F)", new MenuItemDefinition[] {
                    new MenuItemDefinition("新規(_N)", appCommands.New),
                    new MenuItemDefinition("開く(_O)...", appCommands.Open),
                    new MenuItemDefinition("上書き保存(_S)", appCommands.Save),
                    new MenuItemDefinition("名前を付けて保存(_A)...", appCommands.SaveAs),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("ページ設定(_U)...", new PageSettingsCommand(window)),
                    new MenuItemDefinition("印刷(_P)...", appCommands.Print),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("ネタ帳の終了(_X)", new ExitCommand(window)),
                }),
                new MenuDefinition("編集(_E)", new MenuItemDefinition[] {
                    new MenuItemDefinition("元に戻す(_U)", appCommands.Undo),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("切り取り(_T)", appCommands.Cut),
                    new MenuItemDefinition("コピー(_C)", appCommands.Copy),
                    new MenuItemDefinition("貼り付け(_P)", appCommands.Paste),
                    new MenuItemDefinition("削除(_L)", appCommands.Delete),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("検索(_F)...", appCommands.Find),
                    new MenuItemDefinition("次を検索(_N)", new FindNextCommand(window)),
                    new MenuItemDefinition("置換(_R)...", appCommands.Replace),
                    new MenuItemDefinition("行へ移動(_G)...", new GotoCommand(window)),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("すべて選択(_A)", appCommands.SelectAll),
                    new MenuItemDefinition("日付と時刻(_D)...", new DateTimeCommand(window)),
                }),
            };

            return toolkit.NewMenuBar(menus);
        }

        class PageSettingsCommand : WindowCommand
        {
            public PageSettingsCommand(IWindow aWindow) : base(aWindow) {}
            public override void Execute(object aParameter)
            {
                // TODO
            }
        }
        class ExitCommand : WindowCommand
        {
            public ExitCommand(IWindow aWindow) : base(aWindow) {}
            public override void Execute(object aParameter)
            {
                window.Close();
            }
        }
        class FindNextCommand : WindowCommand
        {
            public FindNextCommand(IWindow aWindow) : base(aWindow) {}
            public override void Execute(object aParameter)
            {
                // TODO
            }
        }
        class GotoCommand : WindowCommand
        {
            public GotoCommand(IWindow aWindow) : base(aWindow) {}
            public override void Execute(object aParameter)
            {
                // TODO
            }
        }
        class DateTimeCommand : WindowCommand
        {
            public DateTimeCommand(IWindow aWindow) : base(aWindow) {}
            public override void Execute(object aParameter)
            {
                // TODO
            }
        }

        abstract class WindowCommand : ICommand
        {
            public event EventHandler CanExecuteChanged { add {} remove {} }

            protected IWindow window;
            public WindowCommand(IWindow aWindow)
            {
                window = aWindow;
            }

            public bool CanExecute(object aParameter)
            {
                return true;
            }
            public abstract void Execute(object aParameter);
        }
    }
}
