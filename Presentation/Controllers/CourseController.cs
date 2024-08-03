using Application;
using Domain;

namespace Presentation
{
    public class CourseController : IController
    {
        private readonly ICourseService _courseService;
        private readonly ICourseUi _ui;

        public CourseController() : this(new CourseService()) { }

        public CourseController(ICourseService courseService) 
        {
            _courseService = courseService;
            _ui = new CourseUi(_courseService);
        }

        public void Create()
        {
            var newCourse = _courseService.Create(_ui.Create());

            ConsoleAlert.Result(newCourse);
        }

        public void Delete()
        {
            _courseService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
