using AppKit;

namespace Netapad
{
    class MacSaveDialog : ISaveDialog
    {
        NSSavePanel dialog = new NSSavePanel();
        public string FileName {
            get {
                return dialog.Filename;
            }
        }

        public bool? ShowDialog()
        {
            return 0 < dialog.RunModal();
        }
    }
}