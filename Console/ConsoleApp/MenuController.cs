using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    /// <summary>
    /// Controls game loop of the Menu
    /// </summary>
    public class MenuController : IMenuController
    {
        private readonly MenuModel menuModel;
        private bool running = false;
        private ICollection<IGameObject> gameObjects;
        private int menustate;
        private DoubleBuffer2D<char> buffer2D;
        private readonly GameController gameController;
        private readonly GameView gameView;
        private int msPerFrame = 60;
        public MenuController(MenuModel menuModel)
        {
            this.menuModel = menuModel;
            gameObjects = new List<IGameObject>();
            buffer2D = new DoubleBuffer2D<char>(30, 1);
            GameModel gameModel = new GameModel();
            this.gameController = new GameController(gameModel);
            this.gameView = new GameView(gameModel);
        }
        /// <summary>
        /// Game loop of the menu
        /// </summary>
        /// <param name="view"></param>
        public void RunMenu(IMenuView view)
        {
            SetupScene();
            menustate = 4;
            Console.Clear();
            Console.CursorVisible = false;
            running = true;
            view.Start();
            while (running)
            {
                int start = DateTime.Now.Millisecond;
                Console.SetCursorPosition(0, 0);
                switch (menustate)
                {
                    case 2:
                        view.GetAnyInput();
                        break;
                    case 3:
                        view.GetAnyInput();
                        break;
                    case 4:
                        view.GetMenuInput();
                        break;
                }
                foreach (IGameObject gObj in gameObjects) gObj.Update();
                Render(view);
                if (start + msPerFrame - DateTime.Now.Millisecond >= 0)
                {
                    Thread.Sleep(
                        start + msPerFrame - DateTime.Now.Millisecond);
                }
            }
            foreach (GameObject gObj in gameObjects) gObj.Finish();
        }
        /// <summary>
        /// Swaps buffers and calls the view to display changes
        /// </summary>
        /// <param name="view"></param>
        private void Render(IMenuView view)
        {
            buffer2D.Swap();
            view.RenderAnimation(buffer2D);
        }
        /// <summary>
        /// Setups Menu gameObjects
        /// </summary>
        private void SetupScene()
        {
            GameObject animation;
            animation = new GameObject("Animation");
            animation.AddComponent(new AnimationComponent(buffer2D));
            gameObjects.Add(animation);
        }
        /// <summary>
        /// Changes what menu we are in and calls model to invoke the view
        /// to display the rules
        /// </summary>
        public void ShowRulesAction()
        {
            menustate = 2;
            menuModel.OnShowRules();
        }
        /// <summary>
        /// Changes what menu we are in and calls model to invoke the view
        /// to display the Author
        /// </summary>
        public void ShowAuthorAction()
        {
            menustate = 3;
            menuModel.OnShowAuthor();
        }
        /// <summary>
        /// Changes what menu we are in and calls model to invoke the view
        /// to display the game
        /// Starts the gameLoop of the game
        /// </summary>
        public void StartGameAction()
        {
            menustate = 1;
            menuModel.OnStartGame();
            gameController.RunGame(gameView);
        }
        /// <summary>
        /// Changes what menu we are in and calls model to invoke the view
        /// to display the Menu
        /// </summary>
        public void ShowMenuAction()
        {
            menustate = 4;
            menuModel.OnShowMenu();
        }
        /// <summary>
        /// Quits the game
        /// </summary>
        public void Quit()
        {
            running = false;
        }
    }
}