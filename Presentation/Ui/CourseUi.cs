﻿using Application;
using Domain;

namespace Presentation
{
    public class CourseUi : Ui, ICourseUi
    {
        private readonly ICourseService _service;


        public CourseUi(ICourseService courseService)
        {
            _service = courseService;
        }


        public CreateCourseDto Create()
        {
            var title = ReadText("Course title");
            var description = ReadText("Course description");

            return new CreateCourseDto(title, description);
        }


        public string Delete()
        {
            var courses = _service.GetAll();

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
