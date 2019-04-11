using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace TubeVR
{
    [RequireComponent (typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        protected GuideCategories guideCategories;
        private CanvasGroup canvasGroup;

        public virtual void Setup(GuideCategories guideCategories)
        {
            this.guideCategories = guideCategories;
        }

        public void Show()
        {
            CanvasGroupSetter.Show(canvasGroup);
        }

        public void Hide()
        {
            CanvasGroupSetter.Hide(canvasGroup);
        }

        private void Awake()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }
    }
}