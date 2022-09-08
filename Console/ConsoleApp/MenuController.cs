using System;
using Lp2EpocaEspecial.Common;

namespace Lp2EpocaEspecial.ConsoleApp
{
    public class MenuController: IMenuController
    {
        private readonly MenuModel menuModel;
        private bool running = false;
        private ICollection<IGameObject> gameObjects;
        private int menustate;
        private DoubleBuffer2D<char> buffer2D;
        private readonly GameController gameController;
        private readonly GameView gameView;
        private int msPerFrame = 100;

        public MenuController(MenuModel menuModel)
        {
            this.menuModel = menuModel;
            gameObjects = new List<IGameObject>();

            GameModel gameModel = new GameModel();
            this.gameController = new GameController(gameModel);
            this.gameView = new GameView(gameController, gameModel);

     

        }
    

        public void RunMenu(IMenuView view)
        {
            buffer2D = new DoubleBuffer2D<char>(1, 1);
            SetupScene();
            menustate = 4;
            Console.Clear();
            running = true;
            view.Start();

            while(running)
            {
                int start = DateTime.Now.Millisecond;

                Console.SetCursorPosition(0, 0);

                switch(menustate)
                {
                    case 1:
                       
                        break;
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

                Thread.Sleep(
                    start + msPerFrame - DateTime.Now.Millisecond);

            }

            foreach (GameObject gObj in gameObjects) gObj.Finish();
        }

        private void Render(IMenuView view)
        {
            buffer2D.Swap();
            view.RenderAnimation(buffer2D);
        }

        public void SetupScene()
        {

            GameObject animation;
            animation = new GameObject("Animation");
            animation.AddComponent(new AnimationComponent(buffer2D));
            gameObjects.Add(animation);
  
        }

        public void ShowRulesAction()
        {
            menustate = 2;
            menuModel.OnShowRules();

        }

        public void ShowAuthorAction()
        {
            menustate = 3;
            menuModel.OnShowAuthor();
        }

        public void StartGameAction()
        {
            menustate = 1;

            menuModel.OnStartGame();
            gameController.RunGame(gameView);

        }

        public void ShowMenuAction()
        {
            menustate = 4;
            menuModel.OnShowMenu();
        }

        public void Quit()
        {
            running = false;
        }


 


    }

}