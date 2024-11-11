using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class VideoService : IVideoService
{
    private readonly IUnitOfWork _unitOfWork;

    public VideoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateVideoDto createVideoDto)
    {
        await _unitOfWork.Videos.AddAsync(
            new Video()
            {
                Title = createVideoDto.Title,
                Duration = createVideoDto.Duration,
                QualityId = (int)createVideoDto.QualityId,
            });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);

        if (video is not null)
        {
            await _unitOfWork.Videos.RemoveAsync(video);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<Video>> GetAllAsync()
    {
        return [.. await _unitOfWork.Videos.GetAllAsync()];
    }

    public async Task<Video?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Videos.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateVideoDto updateVideoDto)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);

        if (video is not null)
        {
            video.Title = updateVideoDto.Title ?? video.Title;
            video.Duration = updateVideoDto.Duration ?? video.Duration;
            video.QualityId = updateVideoDto.QualityId != null ? (int)updateVideoDto.QualityId : video.QualityId;

            await _unitOfWork.Videos.UpdateAsync(video);
            await _unitOfWork.CompleteAsync();
        }
    }
}
