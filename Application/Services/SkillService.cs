using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class SkillService : ISkillService
{
    private readonly IUnitOfWork _unitOfWork;

    public SkillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
