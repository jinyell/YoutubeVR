using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TubeVR
{
    [System.Serializable]
    public class SearchList
    {
        public string kind;
        public string etag;
        public string nextPageToken;
        public string prevPageToken;
        public PageInfo pageInfo;
        public SearchItem[] items;
        public string regionCode;
    }
}