using UnityEngine;
using UnityEngine.UI;

namespace TubeVR
{
    public class NavigationBar : MonoBehaviour
    {
        [SerializeField] private MenuNavigator menuNavigator;
        [SerializeField] private NavItem[] navItems;

        [SerializeField] private NavItem current;

        public void OnNone()
        {
            if(current != null) {
                current.Unfocus();
                current = null;
            }
        }

        public void OnSetNavSelection(Menu menu)
        {
            for (int i = 0; i < navItems.Length; i++)
            {
                if(navItems[i].Menu == menu)
                {
                    if (current != null)
                    {
                        current.Unfocus();
                    }

                    current = navItems[i];
                    current.OnSelect();
                }
            }
        }

        public void OnNav(NavItem navItem)
        {
            if(menuNavigator.Menu == navItem.Menu) {
                return;
            }

            if(current != null) {
                current.Unfocus();
            }

            current = navItem;
            menuNavigator.ShowMenu(current.Menu);
        }

        private void Awake()
        {
            current = navItems[0];
        }

        private void Start()
        {
            current.OnSelect();
        }
    }
}