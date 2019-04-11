using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TubeVR
{
    public class KeyboardScreen : Screen
    {
        [SerializeField] private Text input;

        public void AddCharacter(string letter)
        {
            EventSystem.current.SetSelectedGameObject(null);
            input.text += letter;
        }

        public void AddSpace()
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (string.IsNullOrEmpty(input.text) || input.text[input.text.Length-1] == ' ') {
                return;
            }

            input.text += " ";
        }

        public void Clear()
        {
            EventSystem.current.SetSelectedGameObject(null);
            input.text = string.Empty;
        }

        public void Backspace()
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (string.IsNullOrEmpty(input.text)) {
                return;
            }
            input.text = input.text.Remove(input.text.Length - 1, 1);
        }

        protected override void Awake()
        {
            base.Awake();
            Clear();
        }        
    }
}