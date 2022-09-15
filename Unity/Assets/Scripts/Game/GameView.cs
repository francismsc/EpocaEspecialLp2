using Lp2EpocaEspecial.Common;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Controls the UI and board display to the player
/// </summary>
public class GameView : MonoBehaviour
{
    private Color black  = new Color (0.1f,0.1f,0.1f,1);
    private Color white = new Color(0.9f, 0.9f, 0.9f, 1);
    private Color red = new Color(0.9f, 0, 0, 1);
    private GameModel gameModel;
    [SerializeField] private GameObject Player1Turn;
    [SerializeField] private GameObject Player2Turn;
    [SerializeField] private GameObject Player1Victory;
    [SerializeField] private GameObject Player2Victory;
    public void ChangeText(TextMeshProUGUI text,char number, Value color)
    {
        text.text = number+((char)color).ToString();
    }
    public void Awake()
    {       
    }
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        gameModel.ShowPlayer1Turn += ShowPlayer1Turn;
        gameModel.ShowPlayer2Turn += ShowPlayer2Turn;
        gameModel.ShowVictoryP1 += RenderVictoryP1;
        gameModel.ShowVictoryP2 += RenderVictoryP2;
    }
    /// <summary>
    /// Changes the color of the sprites to represent the new color of the point
    /// </summary>
    /// <param name="point"></param>
    /// <param name="color"></param>
    public void ChangeColor(GameObject point, Value color)
    {
        if(color == Value.White)
        {
            point.GetComponent<SpriteRenderer>().color = white;
        }else if(color == Value.Black)
        { 
            point.GetComponent<SpriteRenderer>().color = black;
        }else if(color == Value.None)
        {
            point.GetComponent<SpriteRenderer>().color = red;
        }
    }

    /// <summary>
    /// Renders the gameMap sprites
    /// Calls to change the color of the sprites
    /// Calls to change the text of the sprites
    /// </summary>
    /// <param name="gameMap"></param>
    /// <param name="points"></param>
    public void RenderMap(Map gameMap, List<GameObject> points)
    {
        int counter = 0;
        for (int x = 0; x < gameMap.points.Count; x++)
        {
            ChangeColor(points[counter], gameMap.points[x].vertex.value);
            ChangeText(points[counter].transform.GetChild(0).GetChild(0).
                GetComponent<TextMeshProUGUI>(),
                gameMap.points[x].vertex.number,
                gameMap.points[x].vertex.value);
            counter++;
        }
        
    }
    public void SetGameModel(GameModel gameModel)
    {
        this.gameModel = gameModel;
    }
    /// <summary>
    /// Displays the objects that contain the message of who is playing
    /// </summary>
    public void ShowPlayer1Turn()
    {
        Player2Turn.SetActive(false);
        Player1Turn.SetActive(true);
    }
    public void ShowPlayer2Turn()
    {
        Player2Turn.SetActive(true);
        Player1Turn.SetActive(false);
    }
    /// <summary>
    /// Displays the objects that contain the victory screen
    /// </summary>
    public void RenderVictoryP1()
    {
        Player1Victory.SetActive(true);
        Player2Victory.SetActive(false);
        Player2Turn.SetActive(false);
        Player1Turn.SetActive(false);
    }
    public void RenderVictoryP2()
    {
        Player1Victory.SetActive(false);
        Player2Victory.SetActive(true);
        Player2Turn.SetActive(false);
        Player1Turn.SetActive(false);
    }
}
