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
            return _repository.Create(createVideoDto);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Video> GetAll()
        {
            return _repository.GetAll();
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
