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
            return _repository.GetAll().ToList();
        }

        public Course GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Course Update(string id, UpdateCourseDto updateCourseDto)
        {
            throw new NotImplementedException();
        }
    }
}
