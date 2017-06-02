using Microsoft.Win32;

namespace Netapad
{
    class WpfOpenDialog : IOpenDialog
    {
        OpenFileDialog d = new OpenFileDialog();

        public string FileName
        {
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