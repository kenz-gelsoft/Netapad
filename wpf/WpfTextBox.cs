using System.Windows.Controls;

namespace Netapad
{
    class WpfTextBox : ITextBox
    {
        TextBox textBox = new TextBox();
        public object Handle {
            get {
                return textBox;
            }
        }

        public string Text {
            get {
                return textBox.Text;
            }
            set {
                textBox.Text = value;
            }
        }

        public WpfTextBox()
        {
            textBox.AcceptsReturn = true;
        }
    }
}