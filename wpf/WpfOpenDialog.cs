using Microsoft.Win32;

namespace Netapad
{
    class WpfOpenDialog : IOpenDialog
    {
        OpenFileDialog dialog = new OpenFileDialog();

        public string FileName
        {
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