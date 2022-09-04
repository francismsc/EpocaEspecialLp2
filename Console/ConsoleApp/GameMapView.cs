using EpocaEspecialLp2.Common;

namespace Lp2EpocaEspecial.ConsoleApp
{      
    public class GameMapView
    {
        private static void PrintToScreen(
            DoubleBuffer2D<Vertex> db)
        {
            for (int y = 0; y < db.YDim; y++)
            {
                
                for (int x = 0; x < db.XDim; x++)
                {
                    
                    if (db[x, y] == default)
                        Console.Write(' ');
                    else
                    {
                        Console.Write(((char)db[x, y].value));
                        if(x != db.XDim-1 && y!=0)
                        {
                            Console.Write('-');
                        }
                        if(y==0)
                        {
                            Console.Write(" ");
                        }
                     
                    }
                    
                }
                if(y==0)
                {
                Console.WriteLine();
                Console.Write("|\\ /|");
                Console.WriteLine();
                }
                if(y==1)
                {
                    Console.WriteLine();
                    Console.Write("|/ \\|");
                    Console.WriteLine();
                }
            }
        }
    }
}