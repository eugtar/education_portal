
namespace Domain {
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository() : this("videos") { }

        public VideoRepository(string name) : base(name) { }

        public Video Create(CreateVideoDto createVideoDto)
        {
            Video newVideo = new(
                Guid.NewGuid().ToString(),
                createVideoDto.Title,
                createVideoDto.Duration,
                createVideoDto.Quality,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );


            List<Video?> skills = Read();
            Write([newVideo, .. skills]);

            return newVideo;
        }

        public void Delete(string id)
        {
            List<Video?> videos = Read();
            if (videos.Count == 0)
            {
                return;
            }

            int i = videos.FindIndex(video => video?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            videos.RemoveAt(i);
            Write(videos);

            return;
        }

        public List<Video?> GetAll()
        {
            return Read();
        }

        public Video? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public Video? Update(string id, UpdateVideoDto updateVideoDto)
        {
            throw new NotImplementedException();
        }
    }
}