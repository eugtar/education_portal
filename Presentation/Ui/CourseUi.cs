using Application;
using Domain;

namespace Presentation
{
    public class CourseUi : Ui, ICourseUi
    {
        readonly ICourseService _service = new CourseService();
        public CreateCourseDto Create()
        {
            string title = ReadText("Course title");
            string description = ReadText("Course description");

            return new CreateCourseDto(title, description);
        }

        public string Delete()
        {
            List<Course?> courses = _service.GetAll();

            if (courses.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return courses[SelectOne<Course>(courses)]?.Id;
        }

        public string SelectOne()
        {
            throw new NotImplementedException();
        }

        public UpdateCourseDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
