using Microsoft.Win32;

namespace Netapad
{
    class WpfSaveDialog : ISaveDialog
    {
        SaveFileDialog dialog = new SaveFileDialog();
        public string FileName {
            get {
                return dialog.FileName;
            }
        }

        public bool? ShowDialog()
        {
            return dialog.ShowDialog();
        }
    }
}