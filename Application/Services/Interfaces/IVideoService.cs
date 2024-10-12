using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IVideoService
{
    public Task CreateAsync(CreateVideoDto createVideoDto);
    public Task UpdateAsync(int id, UpdateVideoDto updateVideoDto);
    public Task DeleteAsync(int id);
    public Task<Video?> GetByIdAsync(int id);
    public Task<List<Video>> GetAllAsync();
}
