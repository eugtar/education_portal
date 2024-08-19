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

    public void Create(CreateVideoDto createVideoDto)
    {
        _unitOfWork.Videos.Add(
            new Video()
            {
                Title = createVideoDto.Title,
                Duration = createVideoDto.Duration,
                Quality = createVideoDto.Quality,
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var video = _unitOfWork.Videos.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Videos.Remove(video);
        _unitOfWork.Complete();
    }

    public List<Video> GetAll()
    {
        return [.. _unitOfWork.Videos.GetAll()];
    }

    public Video? GetById(int id)
    {
        return _unitOfWork.Videos.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateVideoDto updateVideoDto)
    {
        var video = _unitOfWork.Videos.GetById(id) ?? throw new ArgumentNullException();

        video.Title = updateVideoDto.Title ?? video.Title;
        video.Duration = updateVideoDto.Duration ?? video.Duration;
        video.Quality = updateVideoDto.Quality ?? video.Quality;

        _unitOfWork.Videos.Update(video);
        _unitOfWork.Complete();
    }
}
