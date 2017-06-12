namespace Netapad
{
    interface ITextBox : IControl
    {
        string Text { get; set; }
        bool Wrap { get; set; }

        void Insert(string aText);
    }
}