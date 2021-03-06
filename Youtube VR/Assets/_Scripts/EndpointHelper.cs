﻿using System;
using BestHTTP;

namespace TubeVR
{
    public static class EndpointHelper
    {
        private const string CONTENT_TYPE = "Content-Type";
        private const string APPLICATION = "application/json";
        
        public static string ContructVideoURL(string id)
        {
            string url = Endpoints.STREAM_VIDEO;
            url = url.Replace(Endpoints.VIDEO_ID, id);
            return url;
        }

        public static string ConstructPersonalPlaylistURL()
        {
            string url = Endpoints.BASE_URL + Endpoints.PERSONAL_PLAYLIST;
            url = url.Replace(Endpoints.KEY, SessionAdministrator.Instance.Key);
            url = url.Replace(Endpoints.MAX_RESULTS, 5.ToString());
            return url;
        }

        public static string ConstructSearchURL(string search)
        {
            string url = Endpoints.BASE_URL + Endpoints.SEARCH_REQUEST;
            url = url.Replace(Endpoints.KEY, SessionAdministrator.Instance.Key);
            url = url.Replace(Endpoints.SEARCH, search);
            url = url.Replace(Endpoints.MAX_RESULTS, 5.ToString());
            return url;
        }

        public static string ConstructChannelURL(string channel)
        {
            string url = Endpoints.BASE_URL + Endpoints.CHANNELS;
            url = url.Replace(Endpoints.KEY, SessionAdministrator.Instance.Key);
            url = url.Replace(Endpoints.CHANNEL, channel);
            return url;
        }

        public static string ConstructTrendingURL()
        {
            string url = Endpoints.BASE_URL + Endpoints.TRENDING;
            url = url.Replace(Endpoints.KEY, SessionAdministrator.Instance.Key);
            url = url.Replace(Endpoints.MAX_RESULTS, 5.ToString());
            UnityEngine.Debug.Log("URL: " + url);
            return url;
        }

        public static void SendAPIRequest(string url, OnRequestFinishedDelegate finishedCallback)
        {
            Uri sessionURI = new Uri(url);
            HTTPRequest sessionRequest = new HTTPRequest(sessionURI, HTTPMethods.Get, finishedCallback);
            sessionRequest.AddHeader(CONTENT_TYPE, APPLICATION);
            sessionRequest.Send();
        }
    }
}