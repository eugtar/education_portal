using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class LessonUi : Ui, ILessonUi
{
    private readonly ILessonService _service;

    public LessonUi(ILessonService lessonService)
    {
        _service = lessonService;
    }

    public CreateLessonDto Create()
    {
        var title = ReadText("Course title");
        var description = ReadText("Course description");

        return new CreateLessonDto(title, description);
    }

    public int Delete()
    {
        var lessons = _service.GetAll();

        return lessons[SelectOne<Lesson>(lessons)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }

    public int GetById()
    {
        var lessons = _service.GetAll();

        return lessons[SelectOne<Lesson>(lessons)].Id;
    }

    public UpdateLessonDto Update()
    {
        var title = ReadText("Course title", false);
        var description = ReadText("Course description", false);

        return new UpdateLessonDto(title, description);
    }
}
