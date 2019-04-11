using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace TubeVR
{
    [RequireComponent (typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        [SerializeField] protected GuideCategories guideCategories;
        private CanvasGroup canvasGroup;

        public virtual void Setup(GuideCategories guideCategories)
        {
            this.guideCategories = guideCategories;
        }

        public virtual void Show()
        {
            CanvasGroupSetter.Show(canvasGroup);
        }

        public virtual void Hide()
        {
            CanvasGroupSetter.Hide(canvasGroup);
        }

        protected virtual void Awake()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }
    }
}