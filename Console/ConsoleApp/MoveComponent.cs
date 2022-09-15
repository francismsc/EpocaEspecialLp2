using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Moves the Vertex of a Point to the wanted space
    /// </summary>
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
        /// <summary>
        /// Checks who is playing to know what color is moving
        /// Checks if there was a valid input from the player
        /// Swaps the vertex data between the points
        /// </summary>
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
                                        Swap(points, point);
                                    gameModel.ChangePlayer();
                                    break;
                                }
                            }
                            break;
                        }
                    }
            }
        }
        /// <summary>
        /// Swaps the vertex data between points to move them
        /// </summary>
        /// <param name="pointMoved">The point the player wants to move</param>
        /// <param name="pointNone">The point that contained None as value</param>
        public void Swap(Point pointMoved, Point pointNone)
        {
            Vertex temp = pointMoved.vertex;
            pointMoved.vertex = pointNone.vertex;
            pointNone.vertex = temp;
        }
    }
}