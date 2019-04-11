using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    [System.Serializable]
    public class Snippet
    {
        public string publishedAt;
        public string channelId;
        public string title;
        public string description;
        public Thumbnail thumbnails;
        public string channelTitle;
        public string[] tags;
        public string categoryId;
        public string liveBroadcastContent;
        public string defaultLanguage;
        public Localized localized;
        public string defaultAudioLanguage;
        public string playlistID;
        public int position;
        public ResourceId resourceId;
    }
}