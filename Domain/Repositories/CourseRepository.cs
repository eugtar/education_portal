
namespace Domain
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository() : this("courses") { }

        public CourseRepository(string name) : base(name) { }

        public Course Create(CreateCourseDto createCourseDto)
        {
            Course newCourse = new(
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


            List<Course> courses = Read();
            Write([newCourse, .. courses]);

            return newCourse;
        }

        public void Delete(string id)
        {
            List<Course> courses = Read();
            if (courses.Count == 0)
            {
                return;
            }

            int i = courses.FindIndex(course => course?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            courses.RemoveAt(i);
            Write(courses);

            return;
        }

        public List<Course> GetAll()
        {
            return Read();
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