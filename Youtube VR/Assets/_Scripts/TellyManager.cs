using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public class TellyManager : MonoBehaviour
    {
        private static TellyManager instance;
        public static TellyManager Instance { get { return instance; } }


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            Fetch fetch = new Fetch();
            fetch.DownloadChannel("Gudetama");
        }
    }
}