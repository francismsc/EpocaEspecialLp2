using System;

namespace EpocaEspecialLp2.Common
{
    public class MenuModel
    {


        public void OnShowRules()
        {
            ShowRules?.Invoke();
        }

        public void OnShowAuthor()
        {
            ShowAuthor?.Invoke();
        }

        public void OnStartGame()
        {
            StartGame?.Invoke();
        }

        public void OnShowMenu()
        {
            ShowMenu?.Invoke();
        }

        public event Action ShowRules;

        public event Action StartGame;

        public event Action ShowAuthor;

        public event Action ShowMenu;
    }


}