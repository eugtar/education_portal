namespace Domain
{
    public interface IVideoRepository
    {
        public Video Create(CreateVideoDto createVideoDto);
        public Video? Update(string id, UpdateVideoDto updateVideoDto);
        public void Delete(string id);
        public Video? GetUnique(string id);
        public List<Video?> GetAll();
    }
}
