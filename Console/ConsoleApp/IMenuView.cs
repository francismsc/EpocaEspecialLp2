namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Interface for the Menu View
    /// </summary>
    public interface IMenuView
    {
        void Start();
        void GetMenuInput();
        void Finish();
        void GetAnyInput();
        void RenderMenu();
        void RenderAnimation(DoubleBuffer2D<char> bufferAnimation);
    }
}