namespace Netapad
{
    interface IWindow : IControl
    {
        string Title { get; set; }
        void Add(IControl aControl);
        void AddCommandBinding(ICommandBinding aBinding);

        void Close();
    }
}