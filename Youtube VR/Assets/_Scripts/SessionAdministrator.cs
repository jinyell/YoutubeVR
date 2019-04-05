using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using System;
using BestHTTP.Authentication;

public class SessionAdministrator : MonoBehaviour
{
    private const string SEARCH_REQUEST = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=YouTube+Data+API&type=video&key={0}";

    [SerializeField] private string apiKey = string.Empty;

    private void Authenticate()
    {
        string searchURL = string.Format(SEARCH_REQUEST, apiKey);
        var request = new HTTPRequest(new Uri(searchURL), (req, resp) =>
        {
            if (resp.StatusCode != 401)
                Debug.Log("Authenticated");
            else
                Debug.Log("NOT Authenticated");


            if(resp.IsSuccess)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("Failure");
            }
            Debug.Log(resp.DataAsText);
        });
        request.Send();
    }

    private void Start()
    {
        Authenticate();
    }
}
