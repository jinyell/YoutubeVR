using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace TubeVR
{
    public class TubeVRManager : MonoBehaviour
    {
        private static TubeVRManager instance;
        public static TubeVRManager Instance { get { return instance; } }

        [SerializeField] private MenuNavigator menuNavigator;
        
        private void Awake()
        {
            instance = this;
        }
    }
}