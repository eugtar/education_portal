using System.Net;
using Application.Dtos.CourseDtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;
using Domain.Common;
using Domain.Entities;

namespace Application.Services.CourseGroup;

public partial class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISkillService _skillService;

    public CourseService(IUnitOfWork unitOfWork, ISkillService skillService)
    {
        _unitOfWork = unitOfWork;
        _skillService = skillService;
    }

    // Courses
    public async Task<Result> CreateAsync(CreateCourseDto dto)
    {
        IEnumerable<Material> materials = [];
        IEnumerable<Skill> skills = [];

        if (dto.Materials.Count() == 0)
        {
            return new Error(HttpStatusCode.BadRequest, "The course must contain at least one material");
        }

        if (dto.Skills.Count() == 0)
        {
            return new Error(HttpStatusCode.BadRequest, "The course must contain at least one skill");
        }

        foreach (var material in dto.Materials)
        {
            var result = await GetExistingMaterialAsync(material.Id);

            if (result.IsFailure)
            {
                return result.Error;
            }

            materials = materials.Append(result.Value);
        }

        foreach (var skill in dto.Skills)
        {
            var result = await GetExistingSkillAsync(skill.Id);

            if (result.IsFailure)
            {
                return result.Error;
            }

            skills = skills.Append(result.Value);
        }

        var course = new Course()
        {
            Title = dto.Title,
            Description = dto.Description,
            Materials = materials.ToList(),
            Skills = skills.ToList()
        };

        await _unitOfWork.Courses.AddAsync(course);

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        await _unitOfWork.Courses.RemoveAsync(course);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<CourseDto>>> GetAllAsync()
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();

        if (courses.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, $"Not found");
        }

        return courses.Select(c => CourseDto.MapToView(c)).ToList();
    }

    public async Task<Result<CourseDto>> GetByIdAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        return CourseDto.MapToView(course);
    }

    public async Task<Result> UpdateAsync(int id, UpdateCourseDto dto)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        if (dto.Materials is not null && dto.Materials.Count() != 0)
        {
            IEnumerable<Material> materials = [];
            course.Materials.Clear();

            foreach (var material in dto.Materials)
            {
                var result = await GetExistingMaterialAsync(material.Id);

                if (result.IsFailure)
                {
                    return result.Error;
                }

                materials = materials.Append(result.Value);
            }

            course.Materials = materials.ToList();
        }

        if (dto.Skills is not null && dto.Skills.Count() != 0)
        {
            IEnumerable<Skill> skills = [];
            course.Skills.Clear();

            foreach (var skill in dto.Skills)
            {
                var result = await GetExistingSkillAsync(skill.Id);

                if (result.IsFailure)
                {
                    return result.Error;
                }

                skills = skills.Append(result.Value);
            }

            course.Skills = skills.ToList();
        }

        course.Title = dto.Title ?? course.Title;
        course.Description = dto.Description ?? course.Description;

        await _unitOfWork.Courses.UpdateAsync(course);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    private async Task<Result<Material>> GetExistingMaterialAsync(int materialId)
    {
        var existingMaterial = await _unitOfWork.Materials.GetByIdAsync(materialId);

        if (existingMaterial is null)
        {
            return new Error(HttpStatusCode.NotFound, "Material does not exist");
        }

        return existingMaterial;
    }

    private async Task<Result<Skill>> GetExistingSkillAsync(int skillId)
    {
        var existingSkill = await _unitOfWork.Skills.GetByIdAsync(skillId);

        if (existingSkill is null)
        {
            return new Error(HttpStatusCode.NotFound, "Skill does not exist");
        }

        return existingSkill;
    }
}
