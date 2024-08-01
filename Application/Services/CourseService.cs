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
            return _repository.Insert(createCourseDto);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Course> GetAll()
        {
            return _repository.GetAll();
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
