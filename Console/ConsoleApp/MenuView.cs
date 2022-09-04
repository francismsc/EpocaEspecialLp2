using System;
using EpocaEspecialLp2.Common;
using System.Collections.Concurrent;

namespace EpocaEspecialLp2.ConsoleApp
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
        public void GetInput()
        {

            ConsoleKey key;
            if (input.TryTake(out key))
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
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

        public void Finish()
        {
            Console.WriteLine("\n=== Bye! ===");
        }

        private void Render()
        {

        }

        private void RenderRules()
        {
            Console.WriteLine("\n--The Rules--");
            Console.WriteLine("Be a good Person");
            Console.WriteLine("Press 4 to");
        }

        private void RenderAuthor()
        {

            Console.WriteLine("\nAutores:");
            Console.WriteLine("Francisco Costa a21903228");
        }
        private void StartGame()
        {
            Console.WriteLine("NOPE");
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

        private void MenuAnimation()
        {
            Console.WriteLine();
        }
    }

}