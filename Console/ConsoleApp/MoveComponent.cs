using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    public class MoveComponent : Component
    {
        private KeyReaderComponent? keyReader;
        private Map? map;
        private GameModel gameModel;
        private Value valueToMove;
        private BackgroundComponent? background;
        private GameObject? playerComponent, backgroundComponent;
        public MoveComponent(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }
        public override void Start()
        {
            playerComponent = ParentGameObject;
            if (playerComponent != null)
            {
                backgroundComponent = playerComponent.ParentGameObject;
                if (backgroundComponent != null)
                {
                    this.keyReader = playerComponent.GetComponent<KeyReaderComponent>();
                    this.background = backgroundComponent.GetComponent<BackgroundComponent>();
                    if (background != null)
                    {
                        this.map = background.gameMap;
                    }
                }
            }
        }
        public override void Update()
        {
            if (gameModel.playerTurn == 1)
            {
                valueToMove = Value.White;
            }
            else
            {
                valueToMove = Value.Black;
            }
            if (keyReader?.pieceToMove != null)
            {
                char? pieceToMove = keyReader.pieceToMove;
                if (map != null)
                    foreach (Point points in map.points)
                    {
                        if (points.vertex.number == pieceToMove &&
                            points.vertex.value == valueToMove)
                        {
                            foreach (Point point in points.connections)
                            {
                                if (point.vertex.value == Value.None)
                                {
                                    if (background != null)
                                        Swap(points, point, background.gameMap);
                                    gameModel.ChangePlayer();
                                    break;
                                }
                            }
                            break;
                        }
                    }
            }
        }
        public void Swap(Point pointMoved, Point pointNone, Map gamemap)
        {
            Vertex temp = pointMoved.vertex;
            pointMoved.vertex = pointNone.vertex;
            pointNone.vertex = temp;
        }
    }
}