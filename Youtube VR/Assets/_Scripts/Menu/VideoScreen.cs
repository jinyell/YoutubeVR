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
    }
}

