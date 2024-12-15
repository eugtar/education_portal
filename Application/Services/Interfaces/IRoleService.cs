using Domain.Entities.UserGroup;

namespace Application.Services.Interfaces;

public interface IRoleService
{
    public Task SetAsAdministratorAsync(User user);
    public Task SetAsTeacherAsync(User user);
    public Task SetAsStudentAsync(User user);
}
