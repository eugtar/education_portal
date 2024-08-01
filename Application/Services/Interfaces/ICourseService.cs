using Domain;

namespace Application
{
    public interface ICourseService
    {
        public Course Create(CreateCourseDto createCourseDto);
        public Course Update(string id, UpdateCourseDto updateCourseDto);
        public void Delete(string id);
        public Course GetById(string id);
        public List<Course> GetAll();
    }
}
