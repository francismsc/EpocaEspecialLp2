﻿namespace Lp2EpocaEspecial.Common
{
    public class GameModel
    {
        public int playerTurn = 1;
        public Value colorPiecePlaying = Value.White;
        public bool gameEnded;
        public void ChangePlayer()
        {
            if (playerTurn == 1)
            {
                playerTurn = 2;
                colorPiecePlaying = Value.Black;
                OnPlayer2Turn();
            }
            else
            {
                playerTurn = 1;
                colorPiecePlaying = Value.White;
                OnPlayer1Turn();
            }
        }
        public void OnPlayer1Turn()
        {
            ShowPlayer1Turn?.Invoke();
        }
        public void OnPlayer2Turn()
        {
            ShowPlayer2Turn?.Invoke();
        }
        public bool CheckWinCondition(Map gamemap)
        {
            foreach (Point points in gamemap.points)
            {
                if (points.vertex.value == colorPiecePlaying)
                {
                    foreach (Point point in points.connections)
                    {
                        if (point.vertex.value == Value.None)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void OnGameEnd()
        {
            if (playerTurn == 2)
            {
                playerTurn = 3;
                ShowVictoryP2?.Invoke();
            }
            else if (playerTurn == 1)
            {
                playerTurn = 3;
                ShowVictoryP1?.Invoke();
            }
        }
#nullable enable
        public event Action? ShowPlayer1Turn;
        public event Action? ShowPlayer2Turn;
        public event Action? ShowVictoryP1;
        public event Action? ShowVictoryP2;
    }
}
