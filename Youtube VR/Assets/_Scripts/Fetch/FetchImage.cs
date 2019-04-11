using System;
using UnityEngine.UI;
using BestHTTP;

namespace Tools
{
    public class FetchImage
    {
        public delegate void OnComplete();
        public event OnComplete onComplete = delegate { };

        private RawImage image;

        public void Fetch(string url, RawImage rawImage)
        {
            InitiateDownload(url, rawImage);
        }

        private void InitiateDownload(string url, RawImage rawImage)
        {
            //UnityEngine.Debug.Log("<color=white>URL: " + url + "</color>");
            image = rawImage;
            Uri imageURI = new Uri(url);
            HTTPRequest imageRequest = new HTTPRequest(imageURI);
            imageRequest.Callback = OnDownloadComplete;
            imageRequest.Send();
        }
        
        private void OnDownloadComplete(HTTPRequest request, HTTPResponse response)
        {
            if (response.IsSuccess && image != null) {
                image.texture = response.DataAsTexture2D;
                onComplete();
            }
        }
    }
}
