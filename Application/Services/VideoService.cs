using Domain;
using Infrastructure;

namespace Application
{
    public class VideoService : IVideoService
    {
        private readonly IGenericRepository<Video> _repository;

        public VideoService() : this(new GenericRepository<Video>("video")) { }

        public VideoService(IGenericRepository<Video> videoRepository)
        {
            _repository = videoRepository;
        }

        public Video Create(CreateVideoDto createVideoDto)
        {
            var newVideo = new Video(
                Guid.NewGuid().ToString(),
                createVideoDto.Title,
                createVideoDto.Duration,
                createVideoDto.Quality,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newVideo) ? newVideo : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Video> GetAll()
        {
            var videos = _repository.GetAll().ToList();

            return videos.Count == 0 ? throw new NotImplementedException() : videos;
        }

        public Video GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public Video Update(string id, UpdateVideoDto updateVideoDto)
        {
            var video = _repository.GetById(id) ?? throw new NotImplementedException();

            video.Title = updateVideoDto.Title ?? video.Title;
            video.Duration = updateVideoDto.Duration ?? video.Duration;
            video.Quality = updateVideoDto.Quality ?? video.Quality;
            video.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(video) ? video : throw new NotImplementedException();
        }
    }
}
