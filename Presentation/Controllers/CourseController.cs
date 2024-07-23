using Application;
using Domain;

namespace Presentation
{
    public class CourseController : IController
    {
        ICourseUi _ui;
        ICourseService _courseService;

        public CourseController() : this(new CourseUi(), new CourseService() ) { }

        public CourseController(ICourseUi ui, ICourseService courseService) 
        {
            _ui = ui;
            _courseService = courseService;
        }

        public void Create()
        {
            Course newCourse = _courseService.Create(_ui.Create());

            Console.WriteLine(newCourse);
        }

        public void Delete()
        {
            _courseService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetUnique()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
