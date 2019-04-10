using System;
using UnityEngine;
using BestHTTP;

namespace TubeVR
{
    public class SessionAdministrator : MonoBehaviour
    {
        [Serializable]
        public class SessionData
        {
            public string remote_addr;
            public string uid;
            public string token;
        }

        public delegate void SessionTokenReady();
        public event SessionTokenReady onSessionTokenReady = delegate { };

        private static SessionAdministrator instance;
        public static SessionAdministrator Instance { get { return instance; } }

        [SerializeField] private string apiKey = string.Empty;
        public string Key { get { return apiKey; } }

        [SerializeField] private SessionData sessionData;
        public string Token { get { return sessionData.token; } }

        public HTTPRequest AddTokenHeader(HTTPRequest request)
        {
            request.AddHeader("Authorization", Token);
            return request;
        }

        public void RefreshSessionToken()
        {
            Uri sessionURI = new Uri(string.Empty);// Endpoints.API_BASE_URL + Endpoints.SESSION_ENDPOINT);
            HTTPRequest sessionRequest = new HTTPRequest(sessionURI, HTTPMethods.Get, OnSessionTokenRecieved);
            sessionRequest.Send();
        }

        private void Awake()
        {
            instance = this;
        }

        private void OnSessionTokenRecieved(HTTPRequest request, HTTPResponse response)
        {
            if (response == null || response.IsSuccess == false) {
                return;
            }

            //sessionData = JsonConvert.DeserializeObject<SessionData>(response.DataAsText);
            onSessionTokenReady();
        }
    }
}

/*
public delegate void PageDownloaded(Page downloadedPage);
public event PageDownloaded onPageDownloaded;

private Page downloadedPage;
public Page DownloadedPage { get { return downloadedPage; } }

public void DownloadPagebyURL(string endpoint)
{
    string url = string.Format(Endpoints.CHANNELS, apiKey);
    //Debug.Log("<color=green> Fetching Page at: " + url + "</color>");
    EndpointHelper.SendAPIRequest(url, OnContentFetched);

    Uri sessionURI = new Uri(url);
    HTTPRequest sessionRequest = new HTTPRequest(sessionURI, HTTPMethods.Get, finishedCallback);
    sessionRequest = SessionManager.Instance.AddTokenHeader(sessionRequest);
    sessionRequest.AddHeader("Content-Type", "application/json");
    sessionRequest.Send();
}



private void OnContentFetched(HTTPRequest request, HTTPResponse response)
{
    if (response == null || response.IsSuccess == false)
    {
        //Debug.Log("error");
        ErrorHandler.Instance.ErrorBadAPIFetch(request.Uri.ToString(), false);
        return;
    }
    downloadedPage = JsonConvert.DeserializeObject<Page>(response.DataAsText);

    //Debug.Log("URL " + request.Uri + " Response: " + response.DataAsText);

    if (onPageDownloaded != null)
    {
        onPageDownloaded(downloadedPage);
    }

    private void Authenticate()
    {
        string searchURL = string.Format(Endpoints.CHANNELS, apiKey);
        //HTTPRequest request = new HTTPRequest(new Uri(searchURL), DownloadComplete());
        //request.Send();
    }

    private void DownloadComplete(OnRequestFinishedDelegate onRequestFinishedDelegate, HTTPResponse response)
    {
        if (response.StatusCode != 401)
            Debug.Log("Authenticated");
        else
            Debug.Log("NOT Authenticated");


        if (response.IsSuccess)
        {
            Debug.Log("Successful");
        }
        else
        {
            Debug.Log("Failure");
        }
        Debug.Log(response.DataAsText);
    }

    private void Start()
    {
        Authenticate();
    }
}
*/
