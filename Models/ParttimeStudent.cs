using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {

            // throw exception
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Your selection exceeds maximum number of courses (Max {MaxNumOfCourses}) courses");
            }


        }

        public override string ToString()
        {
            string studentInfo = $"{this.Id.ToString()} – {this.Name}(Part time)";
            return studentInfo;
        }

    }
}

