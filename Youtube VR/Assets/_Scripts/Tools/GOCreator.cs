using UnityEngine;

namespace Tools
{
    public class GOCreator
    {
        public static GameObject Create(GameObject prefab, Transform parent, string name)
        {
            GameObject newGO = GameObject.Instantiate(prefab);
            newGO.name = name;
            newGO.SetActive(true);
            newGO.transform.SetParent(parent);
            newGO.transform.position = Vector3.zero;
            newGO.transform.localEulerAngles = Vector3.zero;
            newGO.transform.localScale = Vector3.one;
            newGO.tag = Tags.UNTAG;
            return newGO;
        }

        public static GameObject CreateUI(GameObject prefab, Transform parent, string name)
        {
            GameObject newGO = GameObject.Instantiate(prefab);
            newGO.name = name;
            newGO.SetActive(true);
            newGO.transform.SetParent(parent);
            RectTransform rectTransform = newGO.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
            newGO.tag = Tags.UNTAG;
            return newGO;
        }
    }
}