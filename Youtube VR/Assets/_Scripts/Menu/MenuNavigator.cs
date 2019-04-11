using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public enum Menu
    {
        ERROR,
        HOME,
        TRENDING,
        SEARCH,
        NONE
    }

    public class MenuNavigator : MonoBehaviour
    {
        [SerializeField] private Screen[] screens = new Screen[3];
        
        private Menu currentMenu;

        public void ShowMenu(Menu menu)
        {
            if(currentMenu != Menu.NONE) {
                screens[(int)currentMenu].Hide();
            }

            currentMenu = menu;

            switch (menu)
            {
                case Menu.ERROR:
                    screens[(int)Menu.ERROR].Show();
                    break;
                case Menu.TRENDING:
                    screens[(int)Menu.TRENDING].Show();
                    break;
                case Menu.NONE:
                default: break;
            }
        }

        private void Awake()
        {
            this.currentMenu = Menu.NONE;
        }

        public void SetupMenu(Menu menu, GuideCategories guide)
        {
            switch (menu)
            {
                case Menu.TRENDING:
                    screens[(int)Menu.TRENDING].Setup(guide);
                    break;
                case Menu.ERROR:
                case Menu.NONE:
                default: break;
            }
        }
    }
}