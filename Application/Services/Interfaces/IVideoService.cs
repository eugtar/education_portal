using Application.Dtos;
using Application.Results;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IVideoService
{
    public Task<Result> CreateAsync(CreateVideoDto dto);
    public Task<Result> UpdateAsync(int id, UpdateVideoDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<Video?>> GetByIdAsync(int id);
    public Task<Result<List<Video>>> GetAllAsync();
}
