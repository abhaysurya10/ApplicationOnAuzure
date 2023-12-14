<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="SchoolApplicationUI.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Students</h2>

        <div class="mb-3">
            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />

        </div>

        <asp:GridView ID="GridViewStudents" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowEditing="GridViewStudents_RowEditing" OnRowCancelingEdit="GridViewStudents_RowCancelingEdit" OnRowUpdating="GridViewStudents_RowUpdating" OnRowDeleting="GridViewStudents_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" ReadOnly="True" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-CssClass="text-center" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" ItemStyle-CssClass="text-center" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-sm btn-danger" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
