using UnityEngine;
using UnityEngine.UI;

namespace TubeVR
{
    public class VideoItem : MonoBehaviour
    {
        [SerializeField] private ImageCollector imageCollector;
        [SerializeField] private RawImage thumbnail;
        [SerializeField] private Text title;
        [SerializeField] private Text description;

        [SerializeField] private Item video;
        private Tools.FetchImage fetchImage;

        public void Setup(Item video)
        {
            this.video = video;
            this.title.text = video.snippet.title;
            this.description.text = video.snippet.description;
            CheckImage();
        }

        private void CheckImage()
        {
            if(imageCollector.TextureExists(video.snippet.thumbnails.medium.url)) {
                thumbnail.texture = imageCollector.FindTexture(video.snippet.thumbnails.medium.url);
            } else {
                DownloadImage();
            }
        }

        private void DownloadImage()
        {
            string url = video.snippet.thumbnails.medium.url;
            fetchImage = new Tools.FetchImage();
            fetchImage.Fetch(url, thumbnail);
            fetchImage.onComplete += FetchImage_onComplete;
        }

        private void FetchImage_onComplete()
        {
            fetchImage.onComplete -= FetchImage_onComplete;
            imageCollector.AddTexture(video.snippet.thumbnails.medium.url, thumbnail.texture);
        }
    }
}

