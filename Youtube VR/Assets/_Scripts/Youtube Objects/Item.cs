using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    [System.Serializable]
    public class Item
    {
        public string kind;
        public string etag;
        public Snippet snippet;
    }

    [System.Serializable]
    public class SearchItem : Item
    {
        public Id id;
    }

    [System.Serializable]
    public class PlaylistItem : Item
    {
        public string id;
    }
}