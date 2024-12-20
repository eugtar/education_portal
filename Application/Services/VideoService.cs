using System.Globalization;
using System.Net;
using Application.Dtos.VideoDtos;
using Application.Interfaces;
using Application.Results;
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

    public async Task<Result> CreateAsync(CreateVideoDto dto)
    {
        await _unitOfWork.Videos.AddAsync(
            new Video()
            {
                Title = dto.Title,
                Duration = TimeOnly.ParseExact(
                    dto.Duration,
                    "HH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None),
                QualityId = (int)dto.QualityId,
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);

        if (video is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Video with ID: {id} not found");
        }

        await _unitOfWork.Videos.RemoveAsync(video);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<VideoDto>>> GetAllAsync()
    {
        var videos = await _unitOfWork.Videos.GetAllAsync();

        if (videos.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return videos.Select(v => VideoDto.MapToView(v)).ToList();
    }

    public async Task<Result<VideoDto>> GetByIdAsync(int id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);

        if (video is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Video with ID: {id} not found");
        }

        return VideoDto.MapToView(video);
    }

    public async Task<Result> UpdateAsync(int id, UpdateVideoDto dto)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);

        if (video is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Video with ID: {id} not found");
        }

        video.Title = dto.Title ?? video.Title;
        video.Duration = dto.Duration is null
            ? video.Duration
            : TimeOnly.ParseExact(
                dto.Duration,
                "HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);
        video.QualityId = dto.QualityId != null
            ? (int)dto.QualityId
            : video.QualityId;

        await _unitOfWork.Videos.UpdateAsync(video);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}
