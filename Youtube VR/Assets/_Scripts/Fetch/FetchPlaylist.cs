using UnityEngine;
using BestHTTP;
using Newtonsoft.Json;

namespace TubeVR
{
    public class FetchPlaylist
    {
        public delegate void OnComplete(Playlists playlist);
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
            Playlists playlist = JsonConvert.DeserializeObject<Playlists>(response.DataAsText);
            onComplete(playlist);
        }
    }
}