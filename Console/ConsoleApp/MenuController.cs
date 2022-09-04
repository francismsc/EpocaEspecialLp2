using System;
using Lp2EpocaEspecial.Common;

namespace Lp2EpocaEspecial.ConsoleApp
{
    public class MenuController: IMenuController
    {
        private readonly MenuModel menuModel;
        private bool running = false;


        public MenuController(MenuModel menuModel)
        {
            this.menuModel = menuModel;
        
        }
        public void RunMenu(IMenuView view)
        {
            Console.Clear();
            running = true;
            view.Start();
            int msPerFrame = 500;
            while(running)
            {

                int start = DateTime.Now.Millisecond;

                view.GetInput();


                Thread.Sleep(
                    start + msPerFrame - DateTime.Now.Millisecond);

            }

        }

        public void ShowRulesAction()
        {
            menuModel.OnShowRules();
        }

        public void ShowAuthorAction()
        {
            menuModel.OnShowAuthor();
        }

        public void StartGameAction()
        {
            menuModel.OnStartGame();
        }

        public void ShowMenuAction()
        {
            menuModel.OnShowMenu();
        }

        public void Quit()
        {
            running = false;
        }
 


    }

}