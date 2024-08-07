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
            var newVideo = _videoService.Create(_ui.Create());

            ConsoleAlert.Result(newVideo);
        }

        public void Delete()
        {
            _videoService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            ConsoleAlert.Result(_ui.GetAll());
        }

        public void GetById()
        {
            ConsoleAlert.Result(_videoService.GetById(_ui.GetById()));
        }

        public void Update()
        {
            var id = _videoService.GetById(_ui.GetById()).Id;
            var video = _videoService.Update(id, _ui.Update());

            ConsoleAlert.Result(video);
        }
    }
}
