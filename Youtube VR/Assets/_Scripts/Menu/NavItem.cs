using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TubeVR
{
    [RequireComponent(typeof(NavGui))]
    public class NavItem : Button
    {
        private NavGui navGui;
        private bool selected = false;
        public Menu Menu { get { return navGui.Menu; } }

        public void Unfocus()
        {
            selected = false;
            navGui.Unfocus();
        }

        public void OnSelect()
        {
            selected = true;
            navGui.Selected();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if(selected == false)
            {
                navGui.Focus();
                base.OnPointerEnter(eventData); ;
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if(selected == false)
            {
                navGui.Unfocus();
                base.OnPointerExit(eventData);
            }
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            selected = true;
            navGui.Selected();
            base.OnPointerClick(eventData);
        }

        protected override void Awake()
        {
            base.Awake();
            navGui = this.GetComponent<NavGui>();
        }
    }
}