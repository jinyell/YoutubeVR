using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace TubeVR
{
    public class TubeVRManager : MonoBehaviour
    {
        private static TubeVRManager instance;
        public static TubeVRManager Instance { get { return instance; } }

        [SerializeField] private MenuNavigator menuNavigator;
        [SerializeField] private GuideCategories guide;

        private Fetch channelFetch;
        private Fetch trendingFetch;
        private Fetch searchFetch;
        private Fetch homeFetch;

        public void Search(string search)
        {
            SearchFetcher(search);
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            string path = Application.dataPath + "/TEST.txt";
            Debug.Log("path is : " + path);
            string allContent = System.IO.File.ReadAllText(path);
            guide = JsonConvert.DeserializeObject<GuideCategories>(allContent);
            menuNavigator.SetupMenu(Menu.TRENDING, guide);
            menuNavigator.ShowMenu(Menu.TRENDING);
            HomeFetcher();
            //TrendingFetcher();
        }

        private void HomeFetcher()
        {
            homeFetch = new Fetch();
            string url = EndpointHelper.ConstructRecommendedListsURL();
            homeFetch.DownloadContent(url);
            homeFetch.onError += OnError;
        }

        private void SearchFetcher(string search)
        {
            searchFetch = new Fetch();
            string url = EndpointHelper.ConstructSearchURL(search);
            searchFetch.DownloadContent(url);
            searchFetch.onError += OnError;
        }

        private void TrendingFetcher()
        {
            trendingFetch = new Fetch();
            string url = EndpointHelper.ConstructTrendingURL();
            trendingFetch.DownloadContent(url);
            trendingFetch.onError += OnError;

        }
        
        private void ChannelFetcher(string channel)
        {
            channelFetch = new Fetch();
            string url = EndpointHelper.ConstructChannelURL(channel);
            channelFetch.DownloadContent(url);
            channelFetch.onError += OnError; 
        }

        private void OnError(int statusCode)
        {
            channelFetch.onError -= OnError;
            trendingFetch.onError -= OnError;
            homeFetch.onError -= OnError;
            menuNavigator.ShowMenu(Menu.ERROR);
        }
    }
}