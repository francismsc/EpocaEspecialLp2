using Lp2EpocaEspecial.Common;
using System.Collections.Concurrent;
namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Displays the UI of the menu
    /// </summary>
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
        /// <summary>
        /// Accepts the input on the menu and calls the controller to act upon it
        /// </summary>
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
                        Console.WriteLine("\tPress 4 to go back!");
                        break;
                }
            }
        }
        /// <summary>
        /// Accepts any input in the subMenus to go back to the menu
        /// </summary>
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
        /// <summary>
        /// Render the animation in the menu
        /// </summary>
        /// <param name="bufferAnimation"></param>
        public void RenderAnimation(DoubleBuffer2D<char> bufferAnimation)
        {
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
        }
        /// <summary>
        /// Displays the rules
        /// </summary>
        private void RenderRules()
        {
            Console.WriteLine("\n--The Rules--");
            Console.WriteLine("Player 1 plays as whites (W) and Player 2 as black (B)");
            Console.WriteLine("Each player in his turn moves a piece from its point," +
                " along the marked line, to an adjacent empty point");
            Console.WriteLine("The game is over when one of the players" +
                " is trapped and cannot move. His opponent is declared the winner.");
            Console.WriteLine("\n--Controls--");
            Console.WriteLine("To move a piece in your turn press the number key" +
                "that corresponds to the number of the piece you wanna move on the board");
            Console.WriteLine("Press Escape to go back to the menu at any point in the game");
            Console.WriteLine("\nPress any key to go back to the Menu");
        }
        /// <summary>
        /// Displays the Author
        /// </summary>
        private void RenderAuthor()
        {
            Console.WriteLine("\nAuthor:");
            Console.WriteLine("Francisco Costa a21903228");
            Console.WriteLine("\nPress any key to go back to the Menu");
        }
        /// <summary>
        /// Displays the gameStart
        /// </summary>
        private void StartGame()
        {
            Console.WriteLine("\nLet the games Begin");
        }
        /// <summary>
        /// Displays the menu
        /// </summary>
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