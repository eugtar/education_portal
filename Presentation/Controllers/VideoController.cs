using Application;
using Domain;

namespace Presentation
{
    public class VideoController : IController
    {
        public readonly IVideoService _videoService;
        public readonly IVideoUi _ui;

        public VideoController() : this(new VideoService()) { }

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
            _ui = new VideoUi(_videoService);
        }

        public void Create()
        {
            Video newVideo = _videoService.Create(_ui.Create());

            Logger.LogResult(newVideo);
        }

        public void Delete()
        {
            _videoService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetUnique()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
