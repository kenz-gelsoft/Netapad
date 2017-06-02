using System;
using System.IO;
using System.Windows.Input;

namespace Netapad
{
    class EditorWindow
    {
        IWindow  window  = new WpfWindow();
        ITextBox textBox = new WpfTextBox();

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

        public EditorWindow()
        {
            UpdateTitle();

            window.Add(BuildMenuBar());
            window.Add(textBox);

            WpfCommandBinding[] bindings = {
                new WpfCommandBinding(ApplicationCommands.New,
                    NewCmdExecuted, AlwaysCanExecute),
                new WpfCommandBinding(ApplicationCommands.Open,
                    OpenCmdExecuted, AlwaysCanExecute),
                new WpfCommandBinding(ApplicationCommands.Save,
                    SaveCmdExecuted, AlwaysCanExecute),
                new WpfCommandBinding(ApplicationCommands.SaveAs,
                    SaveAsCmdExecuted, AlwaysCanExecute),
            };
            foreach (var binding in bindings) {
                window.AddCommandBinding(binding);
            }
        }

        void NewCmdExecuted(object target, IExecutedEventArgs e)
        {
            textBox.Text = "";
            FilePath = null;
        }
        void OpenCmdExecuted(object target, IExecutedEventArgs e)
        {
            IOpenDialog dialog = new WpfOpenDialog();
            if (dialog.ShowDialog() == true) {
                textBox.Text = File.ReadAllText(dialog.FileName);
                FilePath = dialog.FileName;
            }
        }
        void SaveCmdExecuted(object target, IExecutedEventArgs e)
        {
            if (FilePath == null) {
                SaveAsCmdExecuted(target, e);
            } else {
                SaveTo(filePath);
            }
        }
        void SaveAsCmdExecuted(object target, IExecutedEventArgs e)
        {
            ISaveDialog dialog = new WpfSaveDialog();
            if (dialog.ShowDialog() == true) {
                SaveTo(dialog.FileName);
            }
        }
        void SaveTo(string fileName)
        {
            File.WriteAllText(fileName, textBox.Text);
            FilePath = fileName;
        }
        void AlwaysCanExecute(object sender, ICanExecuteEventArgs e)
        {
            e.CanExecute = true;
        }

        IMenuBar BuildMenuBar()
        {
            MenuDefinition[] menus = {
                new MenuDefinition("ファイル(_F)", new MenuItemDefinition[] {
                    new MenuItemDefinition("新規(_N)", ApplicationCommands.New),
                    new MenuItemDefinition("開く(_O)...", ApplicationCommands.Open),
                    new MenuItemDefinition("上書き保存(_S)", ApplicationCommands.Save),
                    new MenuItemDefinition("名前を付けて保存(_A)...", ApplicationCommands.SaveAs),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("ページ設定(_U)...", new PageSettingsCommand(window)),
                    new MenuItemDefinition("印刷(_P)...", ApplicationCommands.Print),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("ネタ帳の終了(_X)", new ExitCommand(window)),
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
                    new MenuItemDefinition("次を検索(_N)", new FindNextCommand(window)),
                    new MenuItemDefinition("置換(_R)...", ApplicationCommands.Replace),
                    new MenuItemDefinition("行へ移動(_G)...", new GotoCommand(window)),
                    MenuItemDefinition.Separator,
                    new MenuItemDefinition("すべて選択(_A)", ApplicationCommands.SelectAll),
                    new MenuItemDefinition("日付と時刻(_D)...", new DateTimeCommand(window)),
                }),
            };

            return new WpfMenuBar(menus);
        }

        class PageSettingsCommand : WindowCommand
        {
            public PageSettingsCommand(IWindow w) : base(w) {}
            public override void Execute(object parameter)
            {
                // TODO
            }
        }
        class ExitCommand : WindowCommand
        {
            public ExitCommand(IWindow w) : base(w) {}
            public override void Execute(object parameter)
            {
                window.Close();
            }
        }
        class FindNextCommand : WindowCommand
        {
            public FindNextCommand(IWindow w) : base(w) {}
            public override void Execute(object parameter)
            {
                // TODO
            }
        }
        class GotoCommand : WindowCommand
        {
            public GotoCommand(IWindow w) : base(w) {}
            public override void Execute(object parameter)
            {
                // TODO
            }
        }
        class DateTimeCommand : WindowCommand
        {
            public DateTimeCommand(IWindow w) : base(w) {}
            public override void Execute(object parameter)
            {
                // TODO
            }
        }

        abstract class WindowCommand : ICommand
        {
            public event EventHandler CanExecuteChanged { add {} remove {} }

            protected IWindow window;
            public WindowCommand(IWindow w)
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
}
