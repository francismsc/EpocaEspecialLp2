using Lp2EpocaEspecial.Common;
using System;
using System.Collections.Concurrent;

namespace Lp2EpocaEspecial.ConsoleApp
{

    public class GameView : IGameView
    {


        public GameView(GameModel gameModel)
        {

            gameModel.ShowPlayer1Turn += ShowPlayer1Turn;
            gameModel.ShowPlayer2Turn += ShowPlayer2Turn;
            gameModel.ShowVictoryP1 += RenderVictoryP1;
            gameModel.ShowVictoryP2 += RenderVictoryP2;
        }

        public void Start()
        {
            ShowPlayer1Turn();
        }


        public void RenderMap(
        DoubleBuffer2D<Point> db)
        {

            Console.SetCursorPosition(0, 10);
            for (int y = 0; y < db.YDim; y++)
            {
                Console.Write("\t      ");
                for (int x = 0; x < db.XDim; x++)
                {
                    if (db[x, y] == default)
                        Console.Write(' ');
                    else
                    {
                        if (db[x, y].vertex.value == Value.Black || db[x, y].
                            vertex.value == Value.White || db[x, y].vertex.value == Value.None)
                        {
                            Console.Write((db[x, y].vertex.number.ToString())
                             + (char)db[x, y].vertex.value);
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
                    Console.Write("\t      | \\ / |");
                    Console.WriteLine();
                }
                if (y == 1)
                {
                    Console.WriteLine();
                    Console.Write("\t      | / \\ |");
                    Console.WriteLine();
                }
            }
        }

        public void RenderAnimation(DoubleBuffer2D<char> bufferAnimation)
        {
            Console.SetCursorPosition(0, 0);
            for (int bufferY = 0; bufferY < bufferAnimation.YDim; bufferY++)
            {
                for (int bufferX = 0; bufferX < bufferAnimation.XDim; bufferX++)
                {
                    Console.Write(bufferAnimation[bufferX, bufferY]);
                }

            }
        }

        public void ShowPlayer1Turn()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\t--It's your turn!--");
            Console.WriteLine("\t--Whites Pieces!--");
        }

        public void ShowPlayer2Turn()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\t--It's your turn!--");
            Console.WriteLine("\t--Black Pieces!--");
        }

        public void ShowEscapeMessage()
        {
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("Press Escape at any moment to go back to the menu");
        }

        public void RenderVictoryP1()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\tThe Game has Ended");
            Console.WriteLine("\t White Pieces Won");
        }

        public void RenderVictoryP2()
        {
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\tThe Game has Ended");
            Console.WriteLine("\t Black Pieces Won");
        }
    }

}
