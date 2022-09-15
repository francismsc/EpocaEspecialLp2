using Lp2EpocaEspecial.Common;
namespace Lp2EpocaEspecial.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
        }
        private Program()
        {
            MenuModel menuModel = new MenuModel();
            MenuController menuController = new MenuController(menuModel);
            MenuView menuView = new MenuView(menuController, menuModel);
            menuController.RunMenu(menuView);
        }
    }
}
