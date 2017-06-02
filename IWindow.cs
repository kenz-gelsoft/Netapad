namespace Netapad
{
    interface IWindow : IControl
    {
        string Title { get; set; }
        void Add(IControl aControl);
        void AddCommandBinding(ICommandBinding a);

        void Close();
    }
}