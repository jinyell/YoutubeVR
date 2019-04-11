using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public class VideoScreen : Screen
    {
        [SerializeField] private Swipe swipe;

        public override void Setup(GuideCategories guideCategories)
        {
            base.Setup(guideCategories);
            swipe.SetupSwipe(guideCategories.items);
        }

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

