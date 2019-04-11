using UnityEngine;
using BestHTTP;
using Newtonsoft.Json;

namespace TubeVR
{
    public class Fetch
    {
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

            //DebugFile(response.DataAsText);
            Debug.Log("URL " + request.Uri + " Response: " + response.DataAsText);
        }

        private void DebugFile(string response)
        {
            string path = Application.dataPath + "/TEST.txt";
            Debug.Log("path is : " + path);
            System.IO.File.WriteAllText(path, response);
        }
    }
}