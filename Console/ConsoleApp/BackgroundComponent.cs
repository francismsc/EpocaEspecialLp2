using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    public class BackgroundComponent : Component
    {
        // The buffer used for rendering
        public IBuffer2D<Point> buffer { get; set; }
        public Map gameMap { get; set; }
        public BackgroundComponent(IBuffer2D<Point> buffer, int maxX, int maxY, Map gameMap)
        {
            this.buffer = buffer;
            this.gameMap = gameMap;
        }
        public override void Update()
        {
            int counter = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    buffer[x, y] = gameMap.points[counter];
                    counter++;
                }
            }
        }
    }
}
