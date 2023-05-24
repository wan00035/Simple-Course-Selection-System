<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Course Resitration</title>
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
    </head>
    <body>
        <div class="container">
            <h1>Algonquin College Course Resitration</h1>
            <form id="form1" runat="server">
                <div>
                    <asp:Label ID="lblName" runat="server" Text="Student : "></asp:Label>

                    <asp:DropDownList ID="StudentInfo" runat="server"
                        AutoPostBack="True" OnSelectedIndexChanged="StudentInfo_SelectedIndexChanged" Width="350px" Height="30">
                    </asp:DropDownList>



                    <asp:RequiredFieldValidator ID="StudentInfoValidator" runat="server" ErrorMessage="Must select one!"
                        Display="Dynamic" ControlToValidate="StudentInfo" EnableClientScript="true" CssClass="error"
                        InitialValue="0"></asp:RequiredFieldValidator>


                </div>
                <br />
                <asp:Label ID="Summary" runat="server" Style="color: blue;"></asp:Label>
                <br /> 
                
                <h3>Following courses are currently available for registration</h3>
                <br />
                <div>
                    <asp:Label ID="Message" runat="server" CssClass="error"></asp:Label>
                </div>

                <asp:CheckBoxList ID="AvailableCourses" runat="server">
                </asp:CheckBoxList>
                <br />
                <asp:Button ID="Submit" runat="server" Text="Save" OnClick="Submit_Click"/>
               

            </form>

        </div>
        <br />
        <asp:HyperLink ID="ToAddStudent" runat="server" NavigateUrl="~/AddStudent.aspx">Add Student</asp:HyperLink>
    </body>
</html>
