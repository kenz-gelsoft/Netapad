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
                    : ScrollBarVisibility.Visible;
            }
        }

        public WpfTextBox()
        {
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            textBox.AcceptsReturn = true;
            Wrap = false;
        }

        public void Insert(string aText)
        {
            var selectionIndex = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(selectionIndex, aText);
            textBox.SelectionStart = selectionIndex + aText.Length;
        }
    }
}