using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolApplicationUI
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind GridView with sample data
                GridViewStudents.DataSource = GetSampleStudents();
                GridViewStudents.DataBind();
            }
        }

        private DataTable GetSampleStudents()
        {
            // Implement logic to fetch sample student data from the database
            // For simplicity, we'll use a DataTable here
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Grade", typeof(int));

            // Add sample data
            dt.Rows.Add(1, "Abhay", "Surya", 10);
            dt.Rows.Add(2, "Nikhil", "Subba", 11);

            return dt;
        }

        protected void GridViewStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Handle row editing event
            GridViewStudents.EditIndex = e.NewEditIndex;
            // Rebind GridView
            GridViewStudents.DataSource = GetSampleStudents();
            GridViewStudents.DataBind();
        }

        protected void GridViewStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Handle row canceling edit event
            GridViewStudents.EditIndex = -1;
            // Rebind GridView
            GridViewStudents.DataSource = GetSampleStudents();
            GridViewStudents.DataBind();
        }

        protected void GridViewStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Handle row updating event
            int rowIndex = e.RowIndex;
            GridViewRow row = GridViewStudents.Rows[rowIndex];

            // Retrieve edited values
            int studentID = Convert.ToInt32(GridViewStudents.DataKeys[row.RowIndex].Values[0]);
            string firstName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)row.Cells[2].Controls[0]).Text;
            int grade = Convert.ToInt32(((TextBox)row.Cells[3].Controls[0]).Text);

            // Update the DataTable (in a real scenario, you would update the database here)
            DataTable dt = GetSampleStudents();
            DataRow dr = dt.Select($"StudentID = {studentID}")[0];
            dr["FirstName"] = firstName;
            dr["LastName"] = lastName;
            dr["Grade"] = grade;

            // Exit edit mode
            GridViewStudents.EditIndex = -1;
            // Rebind GridView
            GridViewStudents.DataSource = GetSampleStudents();
            GridViewStudents.DataBind();
        }

        protected void GridViewStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Handle row deleting event
                int rowIndex = e.RowIndex;

                // Check if the index is within the bounds of the DataKeys collection
                if (rowIndex >= 0 && rowIndex < GridViewStudents.DataKeys.Count)
                {
                    int studentID = Convert.ToInt32(GridViewStudents.DataKeys[rowIndex].Values["StudentID"]);

                    // Update the DataTable (in a real scenario, you would update the database here)
                    DataTable dt = GetSampleStudents();

                    // Find the row to delete using LINQ
                    DataRow dr = dt.AsEnumerable().FirstOrDefault(row => row.Field<int>("StudentID") == studentID);

                    // Check if the row is found before deleting
                    if (dr != null)
                    {
                        dr.Delete();

                        // Rebind GridView
                        GridViewStudents.DataSource = GetSampleStudents();
                        GridViewStudents.DataBind();
                    }
                    else
                    {
                        // Log or handle the case where the row was not found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
            }
        }


        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                // Add a new student (in a real scenario, you would add to the database here)
                DataTable dt = GetSampleStudents();
                DataRow newRow = dt.NewRow();
                newRow["StudentID"] = dt.Rows.Count + 1;
                newRow["FirstName"] = " ";
                newRow["LastName"] = "";
                newRow["Grade"] = 10; // Set a default grade, change as needed
                dt.Rows.Add(newRow);

                // Rebind GridView
                GridViewStudents.DataSource = dt;
                GridViewStudents.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}