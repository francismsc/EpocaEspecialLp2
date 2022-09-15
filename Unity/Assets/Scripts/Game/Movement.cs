using Lp2EpocaEspecial.Common;
using UnityEngine;
using Vertex = Lp2EpocaEspecial.Common.Vertex;

/// <summary>
/// Makes the movements between pieces
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField]private KeyReader keyReader;
    private Map gameMap;
    private GameModel gameModel;
    private Value valueToMove;
    [SerializeField] private ScriptableObjectContainer scriptableObjectContainer;
    public void Start()
    {
        gameModel = scriptableObjectContainer.gameModelContainer.GameModel;
        keyReader = gameObject.GetComponent<KeyReader>();
        gameMap = gameObject.GetComponentInParent<Background>().gameMap;
    }

    /// <summary>
    /// Checks playerturn to know what color is moving
    /// Waits for input
    /// Checks if the move was legal
    /// Calls Swap to change the positions to make the move
    /// </summary>
    public void Update()
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
            if (gameMap != null)
                foreach (Point points in gameMap.points)
                {
                    if (points.vertex.number == pieceToMove &&
                        points.vertex.value == valueToMove)
                    {
                        foreach (Point point in points.connections)
                        {
                            if (point.vertex.value == Value.None)
                            {
                                if (gameMap != null)
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
    /// Swaps the positions of the vertex data to make a move
    /// </summary>
    /// <param name="pointMoved">Point the player wanted to move</param>
    /// <param name="pointNone">Point where the value was None</param>
    public void Swap(Point pointMoved, Point pointNone)
    {
        Vertex temp = pointMoved.vertex;
        pointMoved.vertex = pointNone.vertex;
        pointNone.vertex = temp;
    }
}
