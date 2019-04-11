using UnityEngine;

namespace TubeVR
{
    public class PlaylistScreen : VideoScreen
    {
        private FetchPlaylist fetchPlaylist;

        public void Setup(string url)
        {
            Fetcher(url);
        }

        private void Fetcher(string url)
        {
            fetchPlaylist = new FetchPlaylist();
            fetchPlaylist.DownloadContent(url);
            fetchPlaylist.onError += OnError;
            fetchPlaylist.onComplete += OnComplete;
        }

        private void OnComplete(Playlists guide)
        {
            fetchPlaylist.onError -= OnError;
            fetchPlaylist.onComplete -= OnComplete;
            swipe.SetupSwipe(guide.items);
        }

        private void OnError(int statusCode)
        {
            fetchPlaylist.onError -= OnError;
            fetchPlaylist.onComplete -= OnComplete;
            //menuNavigator.ShowMenu(Menu.ERROR);
        }
    }
}