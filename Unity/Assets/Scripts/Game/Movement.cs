using Lp2EpocaEspecial.Common;
using UnityEngine;
using Vertex = Lp2EpocaEspecial.Common.Vertex;
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
    public void Swap(Point pointMoved, Point pointNone)
    {
        Vertex temp = pointMoved.vertex;
        pointMoved.vertex = pointNone.vertex;
        pointNone.vertex = temp;
    }
}
