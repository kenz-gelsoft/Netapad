using Microsoft.Win32;

namespace Netapad
{
    class WpfSaveDialog : ISaveDialog
    {
        SaveFileDialog d = new SaveFileDialog();
        public string FileName {
            get {
                return d.FileName;
            }
        }

        public bool? ShowDialog()
        {
            return d.ShowDialog();
        }
    }
}