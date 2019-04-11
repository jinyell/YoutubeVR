using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TubeVR
{
    public enum Menu
    {
        ERROR,
        HOME,
        TRENDING,
        SEARCH,
        KEYBOARD,
        THREE_SIXTY,
        NONE
    }

    public class MenuNavigator : MonoBehaviour
    {
        [SerializeField] private NavigationBar navigationBar;
        [SerializeField] private Screen[] screens = new Screen[3];
        
        [SerializeField] private Menu currentMenu;
        public Menu Menu { get { return currentMenu; } }

        [SerializeField] private Menu previousMenu;

        public void ToggleKeyBoard()
        {
            EventSystem.current.SetSelectedGameObject(null);
            if(currentMenu == Menu.KEYBOARD) {
                previousMenu = (previousMenu == Menu.KEYBOARD) ? Menu.HOME : previousMenu;
                navigationBar.OnSetNavSelection(previousMenu);
                ShowMenu(previousMenu);
            } else {
                ShowMenu(Menu.KEYBOARD);
            }
        }

        public void ShowMenu(Menu menu)
        {
            if(currentMenu != Menu.NONE) {
                screens[(int)currentMenu].Hide();
            }

            previousMenu = currentMenu;
            currentMenu = menu;

            switch (menu)
            {
                case Menu.ERROR:
                    screens[(int)Menu.ERROR].Show();
                    break;
                case Menu.HOME:
                    screens[(int)Menu.HOME].Show();
                    break;
                case Menu.TRENDING:
                    screens[(int)Menu.TRENDING].Show();
                    break;
                case Menu.SEARCH:
                    screens[(int)Menu.SEARCH].Show();
                    break;
                case Menu.KEYBOARD:
                    navigationBar.OnNone();
                    screens[(int)Menu.KEYBOARD].Show();
                    break;
                case Menu.NONE:
                default: break;
            }
        }

        private void Awake()
        {
            this.currentMenu = Menu.NONE;
        }

        private void Start()
        {
            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].Hide();
            }
            InitialSetupMenu();
            ShowMenu(Menu.HOME);
        }

        public void InitialSetupMenu()
        {
            string url = string.Empty;

            url = EndpointHelper.ConstructPersonalPlaylistURL();
            ((PlaylistScreen)screens[(int)Menu.HOME]).Setup(url);

            url = EndpointHelper.ConstructTrendingURL();
            ((PlaylistScreen)screens[(int)Menu.TRENDING]).Setup(url);
        }

        private void OnEnable()
        {
            ((SearchScreen)screens[(int)Menu.SEARCH]).onFinished += MenuNavigator_onFinished;
        }

        private void OnDisable()
        {
            ((SearchScreen)screens[(int)Menu.SEARCH]).onFinished -= MenuNavigator_onFinished;
        }

        private void MenuNavigator_onFinished()
        {
            ShowMenu(Menu.SEARCH);
        }
    }
}