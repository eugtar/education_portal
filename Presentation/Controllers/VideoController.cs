using Application;
using Domain;

namespace Presentation
{
    public class VideoController : IController
    {
        IVideoUi _ui;
        IVideoService _videoService;

        public VideoController() : this(new VideoUi(), new VideoService()) { }

        public VideoController(IVideoUi ui, IVideoService videoService)
        {
            _ui = ui;
            _videoService = videoService;
        }

        public void Create()
        {
            Video newVideo = _videoService.Create(_ui.Create());

            Console.WriteLine(newVideo);
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
