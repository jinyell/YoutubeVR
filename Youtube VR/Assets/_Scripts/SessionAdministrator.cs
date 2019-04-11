using System;
using UnityEngine;
using BestHTTP;

namespace TubeVR
{
    public class SessionAdministrator : MonoBehaviour
    {
        private static SessionAdministrator instance;
        public static SessionAdministrator Instance { get { return instance; } }

        [SerializeField] private string apiKey = string.Empty;
        public string Key { get { return apiKey; } }

        private void Awake()
        {
            instance = this;
        }
    }
}