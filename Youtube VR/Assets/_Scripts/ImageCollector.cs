using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public class ImageCollector : MonoBehaviour
    {
        [SerializeField] private Dictionary<string, Texture> allTextures;

        public void AddTexture(string url, Texture texture)
        {
            allTextures.Add(url, texture);
        }

        public bool TextureExists(string url)
        {
            return allTextures.ContainsKey(url);
        }

        public Texture FindTexture(string url)
        {
            return (allTextures.ContainsKey(url)) ? allTextures[url] : null;
        }

        private void Awake()
        {
            this.allTextures = new Dictionary<string, Texture>();
        }
    }
}