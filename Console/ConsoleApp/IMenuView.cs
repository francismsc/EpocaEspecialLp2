
namespace Lp2EpocaEspecial.ConsoleApp
{
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