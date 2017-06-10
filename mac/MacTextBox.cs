using AppKit;
using CoreGraphics;

namespace Netapad
{
    class MacTextBox : ITextBox, IMacControl
    {
        NSTextView textBox = new NSTextView();
        public object Handle {
            get {
                return textBox;
            }
        }

        public string Text {
            get {
                return textBox.Value;
            }
            set {
                textBox.Value = value;
            }
        }

        public MacTextBox()
        {}

        public void AddToWindow(MacWindow aWindow)
        {
            var content = (aWindow.Handle as NSWindow).ContentView;

            textBox.Frame = new CGRect(CGPoint.Empty, content.Bounds.Size);
            textBox.TranslatesAutoresizingMaskIntoConstraints = false;
            content.AddSubview(textBox);

            foreach (var direction in new NSLayoutAttribute[] {
                NSLayoutAttribute.Left,  NSLayoutAttribute.Top,
                NSLayoutAttribute.Right, NSLayoutAttribute.Bottom
            })
            {
                content.AddConstraint(NSLayoutConstraint.Create(
                        textBox, direction, NSLayoutRelation.Equal,
                        content, direction, 1.0f, 0.0f));
            }
        }
    }
}