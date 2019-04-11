using UnityEngine;
using UnityEngine.UI;

namespace TubeVR
{
    public class NavigationBar : MonoBehaviour
    {
        [System.Serializable]
        public class NavItem
        {
            public Menu menu;
            public Image icon;
        }

        [SerializeField] private NavItem[] navItems;
        private Menu current;

        public void OnNav(string nav)
        {
            Menu menu = (Menu)System.Enum.Parse((typeof(Menu)), nav);

        }
    }
}