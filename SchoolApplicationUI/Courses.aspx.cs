using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolApplicationUI
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind GridView with sample data
                GridViewCourses.DataSource = GetSampleCourses();
                GridViewCourses.DataBind();
            }
        }

        private DataTable GetSampleCourses()
        {
            // Implement logic to fetch sample course data from the database
            // For simplicity, we'll use a DataTable here
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseID", typeof(int));
            dt.Columns.Add("CourseName", typeof(string));
            dt.Columns.Add("Credits", typeof(int));

            // Add sample data
            dt.Rows.Add(1, "Math", 3);
            dt.Rows.Add(2, "History", 4);

            return dt;
        }

        protected void GridViewCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Handle row editing event
            GridViewCourses.EditIndex = e.NewEditIndex;
            // Rebind GridView
            GridViewCourses.DataSource = GetSampleCourses();
            GridViewCourses.DataBind();
        }

        protected void GridViewCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Handle row canceling edit event
            GridViewCourses.EditIndex = -1;
            // Rebind GridView
            GridViewCourses.DataSource = GetSampleCourses();
            GridViewCourses.DataBind();
        }

        protected void GridViewCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Handle row updating event
            int rowIndex = e.RowIndex;
            GridViewRow row = GridViewCourses.Rows[rowIndex];

            // Retrieve edited values
            int courseID = Convert.ToInt32(GridViewCourses.DataKeys[row.RowIndex].Values[0]);
            string courseName = ((TextBox)row.Cells[1].Controls[0]).Text;
            int credits = Convert.ToInt32(((TextBox)row.Cells[2].Controls[0]).Text);

            // Update the DataTable (in a real scenario, you would update the database here)
            DataTable dt = GetSampleCourses();
            DataRow dr = dt.Select($"CourseID = {courseID}")[0];
            dr["CourseName"] = courseName;
            dr["Credits"] = credits;

            // Exit edit mode
            GridViewCourses.EditIndex = -1;
            // Rebind GridView
            GridViewCourses.DataSource = GetSampleCourses();
            GridViewCourses.DataBind();
        }

        protected void GridViewCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Handle row deleting event
            int rowIndex = e.RowIndex;
            int courseID = Convert.ToInt32(GridViewCourses.DataKeys[rowIndex].Values[0]);

            // Update the DataTable (in a real scenario, you would update the database here)
            DataTable dt = GetSampleCourses();
            DataRow dr = dt.Select($"CourseID = {courseID}")[0];
            dr.Delete();

            // Rebind GridView
            GridViewCourses.DataSource = GetSampleCourses();
            GridViewCourses.DataBind();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Add a new course (in a real scenario, you would add to the database here)
            DataTable dt = GetSampleCourses();
            DataRow newRow = dt.NewRow();
            newRow["CourseID"] = dt.Rows.Count + 1;
            newRow["CourseName"] = "New Course";
            newRow["Credits"] = 3;
            dt.Rows.Add(newRow);

            // Rebind GridView
            GridViewCourses.DataSource = GetSampleCourses();
            GridViewCourses.DataBind();
        }

    }
}