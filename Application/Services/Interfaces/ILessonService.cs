using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ILessonService
{
    public void Create(CreateLessonDto createLessonDto);
    public void Update(int id, UpdateLessonDto updateLessonDto);
    public void Delete(int id);
    public Lesson? GetById(int id);
    public List<Lesson> GetAll();
}
