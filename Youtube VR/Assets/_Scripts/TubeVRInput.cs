using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public class TubeVRInput : MonoBehaviour
    {
        public delegate void InputEvent();
        public event InputEvent onUp = delegate { };
        public event InputEvent onDown = delegate { };

        private static TubeVRInput instance;
        public static TubeVRInput Instance { get { return instance; } }

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            Keyboard();
        }

        private void Keyboard()
        {
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                onUp();
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                onDown();
            }
        }
    }
}