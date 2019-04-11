using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

namespace TubeVR
{
    [RequireComponent(typeof(VideoPlayer))]
    public class TubeVRPlayer : MonoBehaviour
    {
        private VideoPlayer vidPlayer;

        public void PlayPlaylistVideo(GameObject vid)
        {
            PlaylistItem item = (PlaylistItem)vid.GetComponent<VideoItem>().Item;
            PlayVideo(item.snippet.resourceId.videoId);
        }

        public void PlaySearchVideo(GameObject vid)
        {
            SearchItem item = (SearchItem)vid.GetComponent<VideoItem>().Item;
            PlayVideo(item.id.videoId);
        }

        public void PlayVideo(string id)
        {
            string url = EndpointHelper.ContructVideoURL(id);
            vidPlayer.url = url;
            vidPlayer.Play();
        }

        public void PauseVideo()
        {

        }

        private void Awake()
        {
            vidPlayer = this.GetComponent<VideoPlayer>();
        }
    }
}