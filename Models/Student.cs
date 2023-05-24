using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string name)
        {
            Id = new Random().Next(100000, 1000000);
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            var registeredCourses = RegisteredCourses as List<Course>;
            registeredCourses.Clear();
            registeredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (var course in RegisteredCourses)
            {
                totalHours += course.WeeklyHours;
            }
            return totalHours;
        }
    }
}
