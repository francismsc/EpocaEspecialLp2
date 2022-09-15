using Lp2EpocaEspecial.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
