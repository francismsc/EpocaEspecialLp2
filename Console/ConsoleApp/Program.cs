using System;
using System.Threading;
using System.Collections.Concurrent;
using EpocaEspecialLp2.Common;

namespace EpocaEspecialLp2.ConsoleApp
{
    class Program
    {
        private const int DimX = 3, DimY = 3;
        private DoubleBuffer2D<Vertex> buffer2D;
        //private BlockingCollection<ConsoleKey>? input;
        //private Thread? inputThread;

       static void Main(string[] args)
        {
            Program p = new Program();

            p.GameLoop();


        }

        private Program()
        {
            buffer2D = new DoubleBuffer2D<Vertex>(DimX, DimY);
            MenuModel menuModel = new MenuModel();
            MenuController menuController = new MenuController(menuModel);
            MenuView menuView = new MenuView(menuController, menuModel);

            menuController.RunMenu(menuView);

        }



        public void GameLoop()
        {




        }

        
    }
    
}
