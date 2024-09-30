using Domain;
using Infrastructure;

namespace Application
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _repository;

        public CourseService() : this(new GenericRepository<Course>("course")) { }

        public CourseService(IGenericRepository<Course> courseRepository)
        {
            _repository = courseRepository;
        }

        public Course Create(CreateCourseDto createCourseDto)
        {
            var newCourse = new Course(
                Guid.NewGuid().ToString(),
                createCourseDto.Title,
                createCourseDto.Description,
                new List<EBook>(),
                new List<Article>(),
                new List<Video>(),
                new List<Skill>(),
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newCourse) ? newCourse : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Course> GetAll()
        {
            var courses = _repository.GetAll().ToList();

            return courses.Count == 0 ? throw new NotImplementedException() : courses;
        }

        public Course GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public Course Update(string id, UpdateCourseDto updateCourseDto)
        {
            var course = _repository.GetById(id) ?? throw new NotImplementedException();

            course.Title = updateCourseDto.Title ?? course.Title;
            course.Description = updateCourseDto.Description ?? course.Description;
            course.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(course) ? course : throw new NotImplementedException();
        }
    }
}
