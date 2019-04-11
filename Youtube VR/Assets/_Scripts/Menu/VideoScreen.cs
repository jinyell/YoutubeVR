using UnityEngine;

namespace TubeVR
{
    public class VideoScreen : Screen
    {
        [SerializeField] protected Swipe swipe;

        public override void Show()
        {
            base.Show();
            swipe.enabled = true;
        }

        public override void Hide()
        {
            base.Hide();
            swipe.enabled = false;
        }
    }
}

