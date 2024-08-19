using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IVideoService
{
    public void Create(CreateVideoDto createVideoDto);
    public void Update(int id, UpdateVideoDto updateVideoDto);
    public void Delete(int id);
    public Video? GetById(int id);
    public List<Video> GetAll();
}
