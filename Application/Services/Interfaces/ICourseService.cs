using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ICourseService
{
    public void Create(CreateCourseDto createCourseDto);
    public void Update(int id, UpdateCourseDto updateCourseDto);
    public void Delete(int id);
    public Course? GetById(int id);
    public List<Course> GetAll();
}
