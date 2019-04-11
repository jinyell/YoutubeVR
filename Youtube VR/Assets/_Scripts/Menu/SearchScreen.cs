using UnityEngine;
using UnityEngine.UI;

namespace TubeVR
{
    public class SearchScreen : VideoScreen
    {
        public delegate void OnFinished();
        public event OnFinished onFinished = delegate { };

        [SerializeField] private Text input;

        private FetchSearch fetchSearch;
        private string search;

        public void OnReturn()
        {
            input.text = input.text.Trim();
            if (string.IsNullOrEmpty(input.text)) {
                return;
            } else if(search == input.text) {
                onFinished();
            }

            search = input.text;
            string url = EndpointHelper.ConstructSearchURL(input.text);
            Fetcher(url);
        }

        protected override void Awake()
        {
            base.Awake();
            search = string.Empty;
        }

        private void Fetcher(string url)
        {
            fetchSearch = new FetchSearch();
            fetchSearch.DownloadContent(url);
            fetchSearch.onError += OnError;
            fetchSearch.onComplete += OnComplete;
        }

        private void OnComplete(SearchList guide)
        {
            fetchSearch.onError -= OnError;
            fetchSearch.onComplete -= OnComplete;
            swipe.SetupSwipe(guide.items);
            onFinished();
        }

        private void OnError(int statusCode)
        {
            fetchSearch.onError -= OnError;
            fetchSearch.onComplete -= OnComplete;
            onFinished();
            //menuNavigator.ShowMenu(Menu.ERROR);
        }
    }
}