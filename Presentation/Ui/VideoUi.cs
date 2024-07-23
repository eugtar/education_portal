using Application;
using Domain;

namespace Presentation
{
    public class VideoUi : Ui, IVideoUi
    {
        readonly IVideoService _service = new VideoService();
        public CreateVideoDto Create()
        {
            string title = ReadText("Video title");
            TimeOnly duration = new TimeOnly(
                ReadNumber("Hour(hh)"), 
                ReadNumber("Minute(mm)")
            );

            List<string> videoQuality = ["low", "medium", "high", "ultrahigh"];
            VideoQuality quality = SelectOne(videoQuality) switch
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
            List<Video?> videos = _service.GetAll();

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
