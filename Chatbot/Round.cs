using System.Runtime.InteropServices;

namespace Chatbot
{
    internal class Round : TextBox
    {
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nheightRect,
            int nweightRect
        );
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Region = Region.FromHrgn(CreateRoundRectRgn(2, 3, Width, Height, 15, 15));
        }
    }
}
