using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserCourseService
{
    public void Create(int userId, int courseId);
    public void Update(int id, UpdateUserCourseDto updateUserCourseDto);
    public void Delete(int id);
    public UserCourse? GetById(int id);
    public List<UserCourse> GetAll();
}
