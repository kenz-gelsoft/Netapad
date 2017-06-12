using System.Windows;
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

        public bool Wrap {
            get {
                return textBox.TextWrapping == TextWrapping.Wrap;
            }
            set {
                textBox.TextWrapping = value
                    ? TextWrapping.Wrap
                    : TextWrapping.NoWrap;
                textBox.HorizontalScrollBarVisibility = value
                    ? ScrollBarVisibility.Disabled
                    : ScrollBarVisibility.Auto;
            }
        }

        public WpfTextBox()
        {
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            textBox.AcceptsReturn = true;
            Wrap = false;
        }
    }
}