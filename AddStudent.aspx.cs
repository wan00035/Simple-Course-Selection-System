using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Lab8.Models;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ToRegerterCourse.Visible = false;
          
            if (!IsPostBack)
            {
                update_table();
            }


        }

        protected void update_table()
        {
            while (studentsTable.Rows.Count > 1)
            {
                studentsTable.Rows.RemoveAt(1);
            }

            if (Session["students"] == null)
            {
                TableRow newRow = new TableRow();
                TableCell newCell = new TableCell() { Text = "No Student Yet!", ColumnSpan = 2 };
                newRow.Cells.Add(newCell);
                studentsTable.Rows.Add(newRow);
            }
            else
            {
                ToRegerterCourse.Visible = true;

                Student[] students = (Student[])Session["students"];
                foreach (Student student in students)
                {
                    TableRow newRow = new TableRow();
                    TableCell idCell = new TableCell() { Text = student.Id.ToString(), ColumnSpan = 1 };
                    TableCell nameCell = new TableCell() { Text = student.Name, ColumnSpan = 1 };
                    newRow.Cells.Add(idCell);
                    newRow.Cells.Add(nameCell);
                    studentsTable.Rows.Add(newRow);
                }
            }
        }

        
        protected void addStudentBtn_Click(object sender, EventArgs e)
        {
            string name = txtSName.Text;
            string id = StudentType.SelectedValue;

            if (txtSName.Text != "" && StudentType.SelectedValue != "0")
            {
                Student[] students;
                List<Student> students_list = new List<Student>();
                if (Session["students"] != null)
                {
                    students = (Student[])Session["students"];
                    students_list = students.ToList();
                }


                string type = StudentType.SelectedValue;

                
                switch (type)
                {
                    case "Fulltime":
                        students_list.Add(new FulltimeStudent(txtSName.Text));
                        break;
                    case "Parttime":
                        students_list.Add(new ParttimeStudent(txtSName.Text));
                        break;
                    case "Coop":
                        students_list.Add(new CoopStudent(txtSName.Text));
                        break;
                };


                students = students_list.ToArray();

                Session["students"] = students;

            }

            
            txtSName.Text = "";
            StudentType.SelectedValue = "0";

            update_table();



        }


       
    }
}