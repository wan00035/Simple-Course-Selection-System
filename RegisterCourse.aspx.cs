using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab8.Models;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeAvailableCourses();
                InitializeStudentDropDown();
                StudentInfo_SelectedIndexChanged(null, null);
               
            }

            ResetControls();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            RegisterSelectedCourses();
            UpdateSessionData();
            UpdateSummary();
            

        }

        protected void StudentInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAvailableCourses();
        }

        private void InitializeAvailableCourses()
        {
            foreach (Course c in Helper.GetAvailableCourses())
            {
                AvailableCourses.Items.Add(new ListItem($"{c.Code} {c.Title} - {c.WeeklyHours} hours per week", c.Code));
            }
        }


        private void InitializeStudentDropDown()
        {
            if (Session["students"] != null)
            {
                Student[] students_Array = (Student[])Session["students"];

                foreach (Student student in students_Array)
                {
                    ListItem list = new ListItem(student.ToString(), student.Id.ToString());
                    StudentInfo.Items.Add(list);
                }

                StudentInfo.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        private void ResetControls()
        {
            Summary.Text = "";
            Message.Text = "";

            AvailableCourses.Visible = true;
            Submit.Visible = true;
            Summary.Visible = true;
            Message.Visible = false;
        }

        private void RegisterSelectedCourses()
        {
            if (Session["students"] != null)
            {
                Student[] students_Array = (Student[])Session["students"];
                string selectedSID = StudentInfo.SelectedValue;

                List<Course> selectedCourses = GetSelectedCourses();

                try
                {
                    foreach (Student s in students_Array)
                    {
                        if (s.Id.ToString() == selectedSID)
                        {
                            s.RegisterCourses(selectedCourses);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Summary.Visible = false;
                    Message.Visible = true;
                    Message.Text = ex.Message;
                }
            }
        }

        private List<Course> GetSelectedCourses()
        {
            List<Course> selectedCourses = new List<Course>();

            foreach (ListItem listItem in AvailableCourses.Items)
            {
                if (listItem.Selected)
                {
                    selectedCourses.Add(Helper.GetCourseByCode(listItem.Value));
                }
            }

            return selectedCourses;
        }

        private void UpdateSessionData()
        {
            Dictionary<string, List<string>> selectedCoursesData = new Dictionary<string, List<string>>();

            List<Course> selectedCourses = GetSelectedCourses();
            List<string> selectedCoursesCodes = new List<string>();

            foreach (Course course in selectedCourses)
            {
                selectedCoursesCodes.Add(course.Code);
            }

            if (Session["selectedCourses"] != null)
            {
                selectedCoursesData = (Dictionary<string, List<string>>)Session["selectedCourses"];
            }

            if (selectedCoursesData.ContainsKey(StudentInfo.SelectedValue))
            {
                selectedCoursesData[StudentInfo.SelectedValue] = selectedCoursesCodes;
            }
            else
            {
                selectedCoursesData.Add(StudentInfo.SelectedValue, selectedCoursesCodes);
            }

            Session["selectedCourses"] = selectedCoursesData;
        }


        private void UpdateSummary()
        {
            List<Course> selectedCourses = GetSelectedCourses();
            int totalSelectedHour = selectedCourses.Sum(c => Convert.ToInt32(c.WeeklyHours));

            if (selectedCourses.Count == 0)
            {
                Summary.Visible = false;
                Message.Visible = true;
                Message.Text = "You need to select at least one Course";
            }
            else
            {
                Summary.Text = $"Selected Student has registered {selectedCourses.Count} course(s), {totalSelectedHour} hours weekly.";
            }
        }
        private void UpdateAvailableCourses()
        {
            string selected = StudentInfo.SelectedValue;

            Dictionary<string, List<string>> selectedCoursesData = new Dictionary<string, List<string>>();
            List<string> selectedCoursesCodes = new List<string>();

            if (Session["selectedCourses"] != null)
            {
                selectedCoursesData = (Dictionary<string, List<string>>)Session["selectedCourses"];
            }

            if (selectedCoursesData.TryGetValue(selected, out List<string> tempSelectedCoursesCodes))
            {
                selectedCoursesCodes = tempSelectedCoursesCodes;
            }


            foreach (ListItem listItem in AvailableCourses.Items)
            {
                listItem.Selected = selectedCoursesCodes.Contains(listItem.Value);
            }
        }
    }
}