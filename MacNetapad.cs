using AppKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using System;

namespace Netapad
{
    class Netapad
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            var NetapadController = new NetapadController();
            NetapadController.Open();

            NSApplication.Main(args);
        }
    }

    class NetapadController : NSObject
    {
        EditorWindowController controller;
        public NetapadController()
        {
            BuildMenuBar();
            controller = new EditorWindowController();
        }
        void BuildMenuBar()
        {
            var menuBar = new NSMenu();
            NSApplication.SharedApplication.MainMenu = menuBar;

            var appMenuItem = new NSMenuItem();
            menuBar.AddItem(appMenuItem);

            var appMenu = new NSMenu();
            appMenuItem.Submenu = appMenu;

            var appAbout = new NSMenuItem("ネタ帳について");
            appMenu.AddItem(appAbout);
            appMenu.AddItem(NSMenuItem.SeparatorItem);

            var appPreferences = new NSMenuItem("環境設定");
            appMenu.AddItem(appPreferences);
            appMenu.AddItem(NSMenuItem.SeparatorItem);

            var appExit = new NSMenuItem("ネタ帳を終了", "q");
            appExit.Action = new Selector("terminate:");
            appMenu.AddItem(appExit);

            var fileMenuItem = new NSMenuItem();
            menuBar.AddItem(fileMenuItem);

            var fileMenu = new NSMenu("ファイル");
            fileMenuItem.Submenu = fileMenu;

            var fileExit = new NSMenuItem("終了");
            fileMenu.AddItem(fileExit);
        }
        public void Open()
        {
            controller.ShowWindow(this);
        }
    }

    class EditorWindowController : NSWindowController
    {
        static NSWindow NewWindow()
        {
            var styles = NSWindowStyle.Titled | NSWindowStyle.Resizable | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable;
            var newWnd = new NSWindow(new CGRect(0, 0, 640, 480), styles, NSBackingStore.Buffered, false);
            newWnd.SetFrameTopLeftPoint(new CGPoint(0, NSScreen.MainScreen.Frame.Size.Height));
            newWnd.Title = "ネタ帳";
            return newWnd;
        }

        public EditorWindowController() : base(NewWindow())
        {
            SetupSubviews();
            // Window.MakeKeyAndOrderFront(null);
        }

        void SetupSubviews()
        {
            var content = Window.ContentView;

            var textView = new NSTextView(new CGRect(CGPoint.Empty, content.Bounds.Size));
            textView.TranslatesAutoresizingMaskIntoConstraints = false;
            content.AddSubview(textView);

            foreach (var direction in new NSLayoutAttribute[] {
                NSLayoutAttribute.Left,  NSLayoutAttribute.Top,
                NSLayoutAttribute.Right, NSLayoutAttribute.Bottom
            })
            {
                content.AddConstraint(NSLayoutConstraint.Create(
                        textView, direction, NSLayoutRelation.Equal,
                        content, direction, 1.0f, 0.0f));
            }
        }
    }
}
