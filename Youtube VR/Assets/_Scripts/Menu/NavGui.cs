using UnityEngine;
using UnityEngine.UI;

namespace TubeVR
{
    public class NavGui : MonoBehaviour
    {
        [SerializeField] private Menu menu;
        public Menu Menu { get { return menu; } }
        [SerializeField] private Image background;
        [SerializeField] private Color focusBackground;
        [SerializeField] private Image icon;
        [SerializeField] private Text label;
        [SerializeField] private Color focusIconLabel;

        private Color unfocusBackground;
        private Color defaultIconLabel;

        public void Focus()
        {
            background.color = focusBackground;
            icon.color = defaultIconLabel;
            label.color = defaultIconLabel;
        }

        public void Unfocus()
        {
            background.color = unfocusBackground;
            icon.color = defaultIconLabel;
            label.color = defaultIconLabel;
        }

        public void Selected()
        {
            background.color = focusBackground;
            icon.color = focusIconLabel;
            label.color = focusIconLabel;
        }

        private void Awake()
        {
            unfocusBackground = background.color;
            defaultIconLabel = icon.color;
        }
    }
}