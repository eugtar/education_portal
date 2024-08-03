using Application;
using Domain;

namespace Presentation
{
    public class VideoUi : Ui, IVideoUi
    {
        private readonly IVideoService _service;


        public VideoUi(IVideoService videoService)
        {
            _service = videoService;
        }


        public CreateVideoDto Create()
        {
            var title = ReadText("Video title");
            var duration = new TimeOnly(
                ReadNumber("Hour(hh)"),
                ReadNumber("Minute(mm)")
            );

            List<string> videoQuality = ["low", "medium", "high", "ultrahigh"];
            var quality = SelectOne(videoQuality) switch
            {
                0 => VideoQuality.LOW,
                1 => VideoQuality.MEDIUM,
                2 => VideoQuality.HIGH,
                _ => VideoQuality.LOW,
            };

            return new CreateVideoDto(title, duration, quality);
        }


        public string Delete()
        {
            var videos = _service.GetAll();

            if (videos.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return videos[SelectOne<Video>(videos)]?.Id;
        }


        public string SelectOne()
        {
            throw new NotImplementedException();
        }


        public UpdateVideoDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
