using System;
using BestHTTP;

namespace TubeVR
{
    public static class EndpointHelper
    {
        public static string ConstructChannelURL(string channel)
        {
            string url = Endpoints.CHANNELS;
            return url;
        }

        public static void SendAPIRequest(string url, OnRequestFinishedDelegate finishedCallback)
        {
            Uri sessionURI = new Uri(url);
            HTTPRequest sessionRequest = new HTTPRequest(sessionURI, HTTPMethods.Get, finishedCallback);
            sessionRequest = SessionAdministrator.Instance.AddTokenHeader(sessionRequest);
            sessionRequest.AddHeader("Content-Type", "application/json");
            sessionRequest.Send();
        }
    }
}