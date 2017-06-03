namespace Netapad
{
    interface IOpenDialog
    {
        string FileName { get; }
        bool? ShowDialog();
    }
}