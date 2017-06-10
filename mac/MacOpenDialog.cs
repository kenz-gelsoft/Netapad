using AppKit;

namespace Netapad
{
    class MacOpenDialog : IOpenDialog
    {
        NSOpenPanel dialog = new NSOpenPanel();

        public string FileName
        {
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