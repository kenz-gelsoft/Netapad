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
            {
                var toolkit = new MacToolkit();
                var win = new EditorWindow(toolkit);
                (win.Handle as NSWindow).MakeKeyAndOrderFront(null);
            }
            NSApplication.Main(args);
        }
    }
}
