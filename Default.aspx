<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" CodeBehind="~/Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Default Page</title>
    <style type ="text/css">
        .style1
        {
            width:100%;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="labelEvent" runat="server" Text="Event:">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dropDownListEvents" runat="server">
                        <asp:ListItem>SQL Server 2008 and XML</asp:ListItem>
                        <asp:ListItem>Office 2007 and XML</asp:ListItem>
                        <asp:ListItem>Introduction to ASP.NET</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelFirstName" runat="server" Text="First name:"></asp:Label>  
                </td>
                <td>
                    <asp:TextBox ID="textFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Enter your first name" ControlToValidate="textFirstName"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelLastName" runat="server" Text="Last name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelEmail" runat="server" Text="Email:"></asp:Label>      
                </td>
                <td>
                    <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
                </td>    
            </tr>
            <tr>
                <td>
                    &nbsp
                </td>
                <td>
                    <asp:Button ID="buttonSubmit" runat="server" Height="26px" Text="Submit" PostBackUrl="ResultsPage.aspx"/>
                </td>
            </tr>
        </table>
    </div>
	</form>
</body>
</html>
