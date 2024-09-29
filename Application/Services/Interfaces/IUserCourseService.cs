using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserCourseService
{
    public void Create(int userId, int courseId);
    public void Update(int userId, int courseId, UpdateUserCourseDto updateUserCourseDto);
    public void Delete(int userId, int courseId);
    public UserCourse? GetById(int userId, int courseId);
    public List<UserCourse> GetAll(int userId);
}
