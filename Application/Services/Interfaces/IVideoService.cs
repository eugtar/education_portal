using Application.Dtos.VideoDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface IVideoService
{
    public Task<Result> CreateAsync(CreateVideoDto dto);
    public Task<Result> UpdateAsync(int id, UpdateVideoDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<VideoDto>> GetByIdAsync(int id);
    public Task<Result<List<VideoDto>>> GetAllAsync();
}
