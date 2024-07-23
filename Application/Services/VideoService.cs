using Domain;

namespace Application
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepo;

        public VideoService() : this(new VideoRepository()) { }

        public VideoService(IVideoRepository videoRepository) 
        {
            _videoRepo = videoRepository;
        }

        public Video Create(CreateVideoDto createVideoDto)
        {
            return _videoRepo.Create(createVideoDto);
        }

        public void Delete(string id)
        {
            _videoRepo.Delete(id);
        }

        public List<Video?> GetAll()
        {
            return _videoRepo.GetAll();
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
