namespace Netapad
{
    interface ISaveDialog
    {
        string FileName { get; }
        bool? ShowDialog();
    }
}