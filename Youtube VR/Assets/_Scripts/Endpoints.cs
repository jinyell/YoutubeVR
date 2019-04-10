using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    public static class Endpoints
    {
        public const string KEY = "{KEY}";
        public const string CHANNEL = "{CHANNEL}";

        public const string VIEW_YOUTUBE_ACCOUNT = "https://www.googleapis.com/auth/youtube.readonly";
        public const string SEARCH_REQUEST = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=YouTube+Data+API&type=video&key={KEY}";
        public const string CHANNELS = "https://www.googleapis.com/youtube/v3/channels?part=snippet,contentDetails&forUsername={CHANNEL}&key{KEY}";
    }
}
