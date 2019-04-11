using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace TubeVR
{
    [RequireComponent (typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        
        public virtual void Show()
        {
            CanvasGroupSetter.ShowEnableGO(canvasGroup);
        }

        public virtual void Hide()
        {
            CanvasGroupSetter.HideDisableGO(canvasGroup);
        }

        protected virtual void Awake()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }
    }
}