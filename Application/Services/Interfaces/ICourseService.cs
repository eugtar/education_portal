using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ICourseService
{
    public Task CreateAsync(CreateCourseDto createCourseDto);
    public Task UpdateAsync(int id, UpdateCourseDto updateCourseDto);
    public Task DeleteAsync(int id);
    public Task<Course?> GetByIdAsync(int id);
    public Task<List<Course>> GetAllAsync();
}
