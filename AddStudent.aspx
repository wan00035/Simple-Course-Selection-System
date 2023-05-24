<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
    <title>Add Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Students </h1>
        
         <table>
            <tr>
                <td>
                    <asp:Label ID="lblSName" runat="server" Text="Student Name :" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSName" runat="server" width="158px"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required!"
                        Display="Dynamic" ControlToValidate="txtSName" CssClass="error" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSType" runat="server" Text="Student Type :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="StudentType" runat="server" width="164px">
                        <asp:ListItem Value="0" hidden="true">-- Select --</asp:ListItem>
                        <asp:ListItem Value="Fulltime">Full Time</asp:ListItem>
                        <asp:ListItem Value="Parttime">Part Time</asp:ListItem>
                        <asp:ListItem Value="Coop">Coop</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSType" runat="server" ErrorMessage="Must Select one!"
                        Display="Dynamic" ControlToValidate="StudentType" EnableClientScript="true" CssClass="error"
                        InitialValue="0">
                    </asp:RequiredFieldValidator>

                </td>

            </tr>
         </table>
        <p>
           <asp:Button ID="addStudentBtn" runat="server" Text="Add" OnClick="addStudentBtn_Click" CssClass="button" />
        </p>

        <asp:Table ID="studentsTable" runat="server" CssClass="table">
            <asp:TableHeaderRow runat="server" TableSection="TableHeader">
                <asp:TableHeaderCell runat="server">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Name</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:HyperLink ID="ToRegerterCourse" runat="server" NavigateUrl="~/RegisterCourse.aspx" >
        Register Course
        </asp:HyperLink>
    </form>
</body>
</html>
