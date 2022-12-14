using Lp2EpocaEspecial.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls the gameLoop of the game
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private ScriptableObjectContainer gameModelObjectContainer;
    [SerializeField] private GameView gameView;
    [SerializeField] private GameObject Player1, Player2, Background;
    private void Awake()
    {
        gameView.SetGameModel(gameModelObjectContainer.gameModelContainer.GameModel);
    }
    private void Update()
    {
        if (gameModelObjectContainer.gameModelContainer.GameModel.
            CheckWinCondition(Background.GetComponent<Background>().gameMap))
        {
            GameEnded(gameModelObjectContainer.gameModelContainer.GameModel);
        }
        CheckPlayerTurn(gameModelObjectContainer.gameModelContainer.GameModel);
        gameView.RenderMap(Background.GetComponent<Background>().gameMap,
         Background.GetComponent<Background>().ObjectsList);
    }
    public void GameEnded(GameModel gameModel)
    {
        gameModel.OnGameEnd();
    }
    /// <summary>
    /// Checks who is playing and calls the method to update the GameObjects
    /// </summary>
    /// <param name="gameModel"></param>
    public void CheckPlayerTurn(GameModel gameModel)
    {
        switch (gameModel.playerTurn)
        {
            case 1:
                Player1Turn();
                break;
            case 2:
                Player2Turn();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Activates the objects that contain the playerTurn scripts move and keyreader gameObjects
    /// </summary>
    public void Player1Turn()
    {
        Player2.SetActive(false);
        Player1.SetActive(true);
        gameModelObjectContainer.gameModelContainer.GameModel.OnPlayer1Turn();
    }
    public void Player2Turn()
    {
        Player1.SetActive(false);
        Player2.SetActive(true);
        gameModelObjectContainer.gameModelContainer.GameModel.OnPlayer2Turn();
    }
   
}
