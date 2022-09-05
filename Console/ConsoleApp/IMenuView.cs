
namespace Lp2EpocaEspecial.ConsoleApp
{
    public interface IMenuView
    {
        void Start();
        void GetMenuInput();
        void Finish();
        void GetAnyInput();
        void RenderMenu();
    }
}