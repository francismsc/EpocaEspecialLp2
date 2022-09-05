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

        public MenuController(MenuModel menuModel)
        {
            this.menuModel = menuModel;
            gameObjects = new List<IGameObject>();
        
        }
    

        public void RunMenu(IMenuView view)
        {
            buffer2D = new DoubleBuffer2D<char>(1, 1);
            SetupScene();
            menustate = 4;
            Console.Clear();
            running = true;
            view.Start();
            int previous = DateTime.Now.Millisecond;
            int lag = 0;
            while(running)
            {
                int current = DateTime.Now.Millisecond;
                int elapsed = current - previous;
                lag += current;

                Console.SetCursorPosition(0, 0);
                int start = DateTime.Now.Millisecond;
                while(lag >= 60)
                {
                    lag -= 60;
                }
                switch(menustate)
                {
                    case 1:
                        break;
                    case 2:
                    case 3:
                        view.GetAnyInput();
                        break;
                    case 4:
                        view.GetMenuInput();
                        break;

                }

                foreach (IGameObject gObj in gameObjects) gObj.Update();
                Render();

            }

        }

        public void SetupScene()
        {

            GameObject animation;
            animation = new GameObject("Animation");
            animation.AddComponent(new AnimationComponent(buffer2D));
            gameObjects.Add(animation);
  
        }

        public void Render()
        {
            buffer2D.Swap();
            Console.SetCursorPosition(50, 0);
            Console.Write(buffer2D[0, 0]);
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