using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Interface for the View of the game
    /// </summary>
    public interface IGameView
    {
        void RenderMap(DoubleBuffer2D<Point> db);
        void RenderAnimation(DoubleBuffer2D<char> bufferAnimation);
        void Start();
        void ShowEscapeMessage();
    }
}
