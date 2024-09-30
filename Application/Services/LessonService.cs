using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class LessonService : ILessonService
{
    private readonly IUnitOfWork _unitOfWork;

    public LessonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateLessonDto createLessonDto)
    {
        _unitOfWork.Lessons.Add(
            new Lesson()
            {
                Title = createLessonDto.Title,
                Description = createLessonDto.Description
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var lesson = _unitOfWork.Lessons.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Lessons.Remove(lesson);
        _unitOfWork.Complete();
    }

    public List<Lesson> GetAll()
    {
        return [.. _unitOfWork.Lessons.GetAll()];
    }

    public Lesson? GetById(int id)
    {
        return _unitOfWork.Lessons.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateLessonDto updateLessonDto)
    {
        var lesson = _unitOfWork.Lessons.GetById(id) ?? throw new ArgumentNullException();

        lesson.Title = updateLessonDto.Title ?? lesson.Title;
        lesson.Description = updateLessonDto.Description ?? lesson.Description;

        _unitOfWork.Lessons.Update(lesson);
        _unitOfWork.Complete();
    }
}
