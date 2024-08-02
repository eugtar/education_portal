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
            Video newVideo = new(
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
            return _repository.GetAll().ToList();
        }

        public Video GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Video Update(string id, UpdateVideoDto updateVideoDto)
        {
            throw new NotImplementedException();
        }
    }
}
