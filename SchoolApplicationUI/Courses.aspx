<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="SchoolApplicationUI.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Courses</h2>

        <div class="mb-3">
            <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-primary" Text="Add Course" OnClick="btnAddCourse_Click" />
        </div>

        <asp:GridView ID="GridViewCourses" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowEditing="GridViewCourses_RowEditing" OnRowCancelingEdit="GridViewCourses_RowCancelingEdit" OnRowUpdating="GridViewCourses_RowUpdating" OnRowDeleting="GridViewCourses_RowDeleting">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="Course ID" ReadOnly="True" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="Credits" HeaderText="Credits" ItemStyle-CssClass="text-center" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-sm btn-danger" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
