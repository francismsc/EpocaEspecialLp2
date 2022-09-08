using Lp2EpocaEspecial.Common;
using System;
using System.Collections.Concurrent;

namespace Lp2EpocaEspecial.ConsoleApp
{

    public class GameView : IGameView
    {
        private readonly IGameController gameController;
        private readonly GameModel gameModel;
        public GameView(IGameController gameController, GameModel gameModel)
        {
            this.gameController = gameController;
            gameModel.ShowPlayer1Turn += ShowPlayer1Turn;
            gameModel.ShowPlayer2Turn += ShowPlayer2Turn;
            gameModel.ShowVictoryP1 += RenderVictoryP1;
            gameModel.ShowVictoryP2 += RenderVictoryP2;
        }

        public void RenderMap(
        DoubleBuffer2D<Point> db)
        {

            Console.SetCursorPosition(0, 10);
            for (int y = 0; y < db.YDim; y++)
            {

                for (int x = 0; x < db.XDim; x++)
                {

                    if (db[x, y] == default)
                        Console.Write(' ');
                    else
                    {
                        if (db[x, y].vertex.value == Value.Black || db[x, y].vertex.value == Value.White || db[x, y].vertex.value == Value.None)
                        {
                            Console.Write((db[x, y].vertex.number.ToString()) + (char)db[x, y].vertex.value);
                        }
                        else
                        {
                            Console.Write(((char)db[x, y].vertex.value));
                        }

                        if (x != db.XDim - 1 && y != 0)
                        {
                            Console.Write('-');
                        }
                        if (y == 0)
                        {
                            Console.Write(" ");
                        }

                    }

                }
                if (y == 0)
                {
                    Console.WriteLine();
                    Console.Write("| \\ / |");
                    Console.WriteLine();
                }
                if (y == 1)
                {
                    Console.WriteLine();
                    Console.Write("| / \\ |");
                    Console.WriteLine();
                }
            }
        }

        public void RenderAnimation(DoubleBuffer2D<char> bufferAnimation)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(bufferAnimation[0, 0]);
        }

        public void ShowPlayer1Turn()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Time To Play");
            Console.WriteLine("  Player 1");


        }

        public void ShowPlayer2Turn()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Time To Play");
            Console.WriteLine("  Player 2");



        }

        public void RenderVictoryP1()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("The Game has Ended");
            Console.WriteLine("  Player 1 WON!!!");
        }

        public void RenderVictoryP2()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("The Game has Ended");
            Console.WriteLine("  Player 2 WON!!!");
        }
    }

}
