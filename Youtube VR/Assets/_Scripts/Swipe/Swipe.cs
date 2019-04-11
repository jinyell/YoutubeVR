using UnityEngine;

namespace TubeVR
{
    public class Swipe : MonoBehaviour
    {
        [System.Serializable]
        public class SwipeItem
        {
            public GameObject go;
            public RectTransform rectTrans;
            public int positionIndex;
        }
        
        [SerializeField] private RectTransform container;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int total;
        [SerializeField] private float padding;
        [SerializeField] private int hiddenItems = 3;
        [SerializeField] private int semiHidden = 1;

        [SerializeField] private SwipeItem[] items;
        private Vector3[] positions;
        [SerializeField] private Video[] swipeItems;
        private int currentIndex = 0;

        private bool setup = true;
        
        public void SetupSwipe(Video[] items)
        {
            if(setup == true)
            {
                Setup();
                setup = false;
            }
            this.swipeItems = items;
            PopulateSwipeItems();
        }

        private void Setup()
        {
            PopulateItems();
            CalculatePositions();
        }

        private void PopulateSwipeItems()
        {
            currentIndex = 0;
            for (int i = 0; i < total; i++)
            {
                if(swipeItems.Length < i) {
                    Tools.CanvasGroupSetter.Hide(items[i].go.GetComponent<CanvasGroup>());
                } else {
                    Tools.CanvasGroupSetter.Show(items[i].go.GetComponent<CanvasGroup>());
                }

                if(i != 0 && (i < swipeItems.Length)) {
                    items[i].go.GetComponent<VideoItem>().Setup(swipeItems[(i - 1)]);
                }
            }
        }

        private void PopulateItems()
        {
            items = new SwipeItem[total];
            for (int i = 0; i < total; i++)
            {
                items[i] = new SwipeItem();
                items[i].positionIndex = i;
                items[i].go = (Tools.GOCreator.CreateUI(prefab, container, i.ToString()));
                items[i].rectTrans = items[i].go.GetComponent<RectTransform>();
            }
        }

        private void CalculatePositions()
        {
            positions = new Vector3[total];
            float height = prefab.GetComponent<RectTransform>().sizeDelta.y;
            float position = (height + padding);

            for(int i = 0; i < total; i++)
            {
                positions[i] = new Vector3(0f, position, 0f);
                items[i].rectTrans.localPosition = positions[i];
                position -= (height + padding);
            }
        }

        private void OnEnable()
        {
            TubeVRInput.Instance.onDown += Instance_onDown;
            TubeVRInput.Instance.onUp += Instance_onUp;
        }

        private void OnDisable()
        {
            TubeVRInput.Instance.onDown -= Instance_onDown;
            TubeVRInput.Instance.onUp -= Instance_onUp;
        }

        private void Instance_onUp()
        {
            if (currentIndex >= (swipeItems.Length - hiddenItems)) {
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                int index = items[i].positionIndex;
                index = ((index - 1) < 0) ? (total - 1) : (index - 1);
                items[i].positionIndex = index;
                items[i].rectTrans.localPosition = positions[items[i].positionIndex];
                items[i].go.name = index.ToString();

                if (((items[i].positionIndex + currentIndex) < swipeItems.Length)) {
                    Tools.CanvasGroupSetter.Show(items[i].go.GetComponent<CanvasGroup>());
                    int swipeIndex = (items[i].positionIndex + currentIndex);
                    swipeIndex = (swipeIndex < 0) ? 0 : swipeIndex;
                    items[i].go.GetComponent<VideoItem>().Setup(swipeItems[swipeIndex]);
                } else {
                    Tools.CanvasGroupSetter.Hide(items[i].go.GetComponent<CanvasGroup>());
                }
            }

            currentIndex++;
        }

        private void Instance_onDown()
        {
            if (currentIndex <= 0) {
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                int index = items[i].positionIndex;
                index = ((index + 1) >= total) ? 0 : (index + 1);
                items[i].positionIndex = index;
                items[i].rectTrans.localPosition = positions[items[i].positionIndex];
                items[i].go.name = index.ToString();

                if((currentIndex - (total - items[i].positionIndex) + hiddenItems + semiHidden) >= 0)
                {
                    Tools.CanvasGroupSetter.Show(items[i].go.GetComponent<CanvasGroup>());
                    int swipeIndex = (currentIndex - (total - items[i].positionIndex) + hiddenItems + semiHidden);
                    swipeIndex = (swipeIndex >= swipeItems.Length) ? (swipeItems.Length - 1) : swipeIndex;
                    items[i].go.GetComponent<VideoItem>().Setup(swipeItems[swipeIndex]);
                } else {
                    Tools.CanvasGroupSetter.Hide(items[i].go.GetComponent<CanvasGroup>());
                }
            }

            currentIndex--;
        }
    }
}