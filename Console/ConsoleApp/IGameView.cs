

using Lp2EpocaEspecial.Common;

namespace Lp2EpocaEspecial.ConsoleApp
{
    public interface IGameView
    {
        void RenderMap(DoubleBuffer2D<Point> db);

        void RenderAnimation(DoubleBuffer2D<char> bufferAnimation);

        void Start();

        void ShowEscapeMessage();


    }
}

