namespace Domain
{
    public interface ICourseRepository
    {
        public Course Create(CreateCourseDto createCourseDto);
        public Course? Update(string id, UpdateCourseDto updateCourseDto);
        public void Delete(string id);
        public Course? GetUnique(string id);
        public List<Course?> GetAll();
    }
}
