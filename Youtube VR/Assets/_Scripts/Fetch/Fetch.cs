using UnityEngine;
using BestHTTP;
using Newtonsoft.Json;

namespace TubeVR
{
    public class Fetch
    {
        //public delegate void PageDownloaded(Page downloadedPage);
        //public event PageDownloaded onPageDownloaded = delegate { };

        //private Page downloadedPage;
        //public Page DownloadedPage { get { return downloadedPage; } }

        public void DownloadChannel(string channel)
        {
            string url = Endpoints.CHANNELS;
            url = url.Replace(Endpoints.KEY, SessionAdministrator.Instance.Key);
            url = url.Replace(Endpoints.CHANNEL, channel);
            Debug.Log("<color=green> Fetching Page at: " + url + "</color>");
            EndpointHelper.SendAPIRequest(url, OnContentFetched);
        }

        private void OnContentFetched(HTTPRequest request, HTTPResponse response)
        {
            if (response == null || response.IsSuccess == false) {
                Debug.LogError("Error");
                return;
            }

            //downloadedPage = JsonConvert.DeserializeObject<Page>(response.DataAsText);

            Debug.Log("URL " + request.Uri + " Response: " + response.DataAsText);
            
            //onPageDownloaded(downloadedPage);
        }
    }
}