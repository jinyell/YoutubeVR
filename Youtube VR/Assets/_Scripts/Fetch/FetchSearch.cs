using UnityEngine;
using BestHTTP;
using Newtonsoft.Json;

namespace TubeVR
{
    public class FetchSearch
    {
        public delegate void OnComplete(SearchList list);
        public OnComplete onComplete = delegate { };

        public delegate void OnError(int statusCode);
        public OnError onError = delegate { };
        
        public void DownloadContent(string url)
        {
            Debug.Log("<color=green> Fetching Page at: " + url + "</color>");
            EndpointHelper.SendAPIRequest(url, OnContentFetched);
        }

        private void OnContentFetched(HTTPRequest request, HTTPResponse response)
        {
            if (response == null || response.IsSuccess == false) {
                onError(response.StatusCode);
                Debug.LogError("Error: " + response.Message + " | " + response.StatusCode);
                return;
            }
            //Tools.FileWriter.DebugFile(response.DataAsText);
            SearchList list = JsonConvert.DeserializeObject<SearchList>(response.DataAsText);
            onComplete(list);
        }
    }
}