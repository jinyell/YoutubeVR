﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public static class Endpoints
    {
        public const string KEY = "{KEY}";
        public const string CHANNEL = "{CHANNEL}";
        public const string MAX_RESULTS = "{MAX_RESULTS}";
        public const string VIDEO_ID = "{VIDEO_ID}";
        public const string SEARCH = "{SEARCH}";

        public const string VIEW_YOUTUBE_ACCOUNT = "https://www.googleapis.com/auth/youtube.readonly";
        public const string SEARCH_REQUEST = "search?part=snippet&q={SEARCH}&maxResults={MAX_RESULTS}&type=video&key={KEY}";
        public const string CHANNELS = "channels?part=snippet,contentDetails&forUsername={CHANNEL}&key{KEY}";
        public const string TRENDING = "videos?part=snippet&chart=mostPopular&type=video&regionCode=US&maxResults={MAX_RESULTS}&key={KEY}";
        public const string VIDEO_CATEGORIES = "videoCategories?part=snippet&chart=recommended&regionCode=US&maxResults={MAX_RESULTS}&key={KEY}";
        public const string GUIDE_CATEGORIES = "guideCategories?part=snippet&chart=recommended&regionCode=US&maxResults={MAX_RESULTS}&key={KEY}";
        public const string PERSONAL_PLAYLIST = "playlistItems?part=snippet&maxResults={MAX_RESULTS}&playlistId=PLbA4wKRGGn8UJC_LqCjf4HhRgl1xkSDCD&key={KEY}";

        public const string STREAM_VIDEO = "https://www.youtube.com/watch?v={VIDEO_ID}";
        public const string BASE_URL = "https://www.googleapis.com/youtube/v3/";
    }
}