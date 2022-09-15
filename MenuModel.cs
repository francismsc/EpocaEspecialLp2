namespace Lp2EpocaEspecial.Common
{
    /// <summary>
    /// Contains the menustate data and calls invokes the menu events
    /// </summary>
    public class MenuModel
    {
        public int menustate = 4;
        public void OnShowRules()
        {
            menustate = 2;
            ShowRules?.Invoke();
        }
        public int GetMenuState()
        {
            return menustate;
        }
        public void OnShowAuthor()
        {
            menustate = 3;
            ShowAuthor?.Invoke();
        }
        public void OnStartGame()
        {
            menustate = 1;
            StartGame?.Invoke();
        }
        public void OnShowMenu()
        {
            menustate = 4;
            ShowMenu?.Invoke();
        }
        public void OnMenuChange(int menuscreen)
        {
            switch (menuscreen)
            {
                case 1:
                    StartGame?.Invoke();
                    break;
                case 2:
                    ShowRules?.Invoke();
                    break;
                case 3:
                    ShowAuthor?.Invoke();
                    break;
                case 4:
                    ShowMenu?.Invoke();
                    break;
                
            }
        }
        public event Action? ShowRules;
        public event Action? StartGame;
        public event Action? ShowAuthor;
        public event Action? ShowMenu;
    }
}