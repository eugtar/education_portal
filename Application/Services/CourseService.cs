using Domain;

namespace Application
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;

        public CourseService() : this(new CourseRepository()) { }

        public CourseService(ICourseRepository courseRepository) 
        {
            _courseRepo = courseRepository;
        }

        public Course Create(CreateCourseDto createCourseDto)
        {
            return _courseRepo.Create(createCourseDto);
        }

        public void Delete(string id)
        {
            _courseRepo.Delete(id);
        }

        public List<Course?> GetAll()
        {
            return _courseRepo.GetAll();
        }

        public Course? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public Course? Update(string id, UpdateCourseDto updateCourseDto)
        {
            throw new NotImplementedException();
        }
    }
}
