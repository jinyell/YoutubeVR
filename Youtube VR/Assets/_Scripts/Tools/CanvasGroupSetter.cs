﻿using UnityEngine;

namespace Tools
{
    public static class CanvasGroupSetter
    {
        private const float SHOW_ALPHA = 1f;
        private const float HIDE_ALPHA = 0f;

        public static void Show(CanvasGroup canvasGroup)
        {
            Set(canvasGroup, true);
        }

        public static void Hide(CanvasGroup canvasGroup)
        {
            Set(canvasGroup, false);
        }

        public static void ShowEnableGO(CanvasGroup canvasGroup)
        {
            Set(canvasGroup, true);
            canvasGroup.gameObject.SetActive(true);
        }

        public static void HideDisableGO(CanvasGroup canvasGroup)
        {
            Set(canvasGroup, false);
            canvasGroup.gameObject.SetActive(false);
        }

        private static void Set(CanvasGroup canvasGroup, bool show)
        {
            canvasGroup.alpha = (show == true) ? SHOW_ALPHA : HIDE_ALPHA;
            canvasGroup.interactable = show;
            canvasGroup.blocksRaycasts = show;
            canvasGroup.ignoreParentGroups = show;
        }
    }
}