using System;
namespace Lp2EpocaEspecial.Common
{
    /// <summary>
    /// Contains some of the game's data and methods that
    ///  need use some of the data
    /// Also contains some C#events 
    /// </summary>
    public class GameModel
    {
        public int playerTurn = 1;
        public Value colorPiecePlaying = Value.White;
        public bool gameEnded;
        /// <summary>
        /// Change's who's player turn is
        /// </summary>
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
        /// <summary>
        /// Calls event to the view to show who is playing
        /// </summary>
        public void OnPlayer1Turn()
        {
            ShowPlayer1Turn?.Invoke();
        }
        public void OnPlayer2Turn()
        {
            ShowPlayer2Turn?.Invoke();
        }
        /// <summary>
        /// Checks if someone won this turn
        /// </summary>
        /// <param name="gamemap">Map of the board</param>
        /// <returns>true if someone won false if no one won</returns>
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
        /// <summary>
        /// Ends the game and evokes the event to display the victory screen
        /// </summary>
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
