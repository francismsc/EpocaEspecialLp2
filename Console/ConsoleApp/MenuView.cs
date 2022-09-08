using System;
using Lp2EpocaEspecial.Common;
using System.Collections.Concurrent;

namespace Lp2EpocaEspecial.ConsoleApp
{
    public class MenuView : IMenuView
    {
        private readonly IMenuController menuController;
        private BlockingCollection<ConsoleKey> input;
        private Thread inputThread;

        public MenuView(IMenuController menuController, MenuModel menuModel)
        {
            this.menuController = menuController;
            menuModel.ShowRules += RenderRules;
            menuModel.ShowAuthor += RenderAuthor;
            menuModel.StartGame += StartGame;
            menuModel.ShowMenu += RenderMenu;

            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            inputThread.Start();
        }

        public void Start() 
        {
            RenderMenu();
        }
        public void GetMenuInput()
        {

            ConsoleKey key;
            if (input.TryTake(out key))
            {
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.D1:
                        menuController.StartGameAction();
                        break;
                    case ConsoleKey.D2:
                        menuController.ShowRulesAction();
                        break;
                    case ConsoleKey.D3:
                        menuController.ShowAuthorAction();
                        break;
                    case ConsoleKey.D4:
                        menuController.ShowMenuAction();
                        break;
                    case ConsoleKey.Escape:
                        Finish();
                        menuController.Quit();
                        break;
                    default:
                        Console.WriteLine("\tUnknown option!");

                        break;
                }
            }
        }

        public void GetAnyInput()
        {
            ConsoleKey key;
            if (input.TryTake(out key))
            {
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        Finish();
                        menuController.Quit();
                        break;
                    default:
                        menuController.ShowMenuAction();
                        break;
                }
            }
        }

        public void Finish()
        {
            Console.WriteLine("\n=== Bye! ===");
        }

        public void RenderAnimation(DoubleBuffer2D<char> bufferAnimation)
        {
            Console.SetCursorPosition(50, 0);
            Console.Write(bufferAnimation[0, 0]);
        }

        private void RenderRules()
        {
            Console.WriteLine("\n--The Rules--");
            Console.WriteLine("Be a good Person");
            Console.WriteLine("Press any key to go back to the Menu");
        }

        private void RenderAuthor()
        {

            Console.WriteLine("\nAutores:");
            Console.WriteLine("Francisco Costa a21903228");
            Console.WriteLine("Press any key to go back to the Menu");
        }
        private void StartGame()
        {;
            Console.WriteLine("\nLet the games Begin");
        }

        public void RenderMenu()
        {

            Console.WriteLine("\n=== Welcome to the Madelinette ===");
            Console.WriteLine("Press 1 to Start playing Madelinette");
            Console.WriteLine("Press 2 to see the rules of the game");
            Console.WriteLine("Press 3 to see the authors of this project");
            Console.WriteLine("Press 4 to show this menu again");
            Console.WriteLine("Press escape to quit the game at any moment");
        }

        private void ReadKeys()
        {
            ConsoleKey ck;
            do
            {
                // When a key is pressed, add it to the collection
                ck = Console.ReadKey(true).Key;
                input.Add(ck);
            } while (ck != ConsoleKey.Escape);
        }

    }

}