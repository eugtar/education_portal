using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class CourseUi : Ui, ICourseUi
{
    private readonly ICourseService _service;

    public CourseUi(ICourseService courseService)
    {
        _service = courseService;
    }

    public CreateCourseDto Create()
    {
        var title = ReadText("Course title");
        var description = ReadText("Course description");

        return new CreateCourseDto(title, description);
    }

    public int Delete()
    {
        var courses = _service.GetAll();

        return courses[SelectOne<Course>(courses)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }

    public int GetById()
    {
        var courses = _service.GetAll();

        return courses[SelectOne<Course>(courses)].Id;
    }

    public UpdateCourseDto Update()
    {
        var title = ReadText("Course title", false);
        var description = ReadText("Course description", false);

        return new UpdateCourseDto(title, description);
    }
}
