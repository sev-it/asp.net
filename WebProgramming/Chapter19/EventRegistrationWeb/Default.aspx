<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="~/Default.aspx.cs" CodeBehind="~/Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Default Page</title>
    <style type ="text/css">
        .style1
        {
            width:100%;
        }
        .auto-style1 {
            width: 177px;
        }
        .auto-style2 {
            width: 77px;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
    <div>
        <table class="style1" id="table1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="labelEvent" runat="server" Text="Event:">
                    </asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="dropDownListEvents" runat="server">
                        <asp:ListItem>SQL Server 2008 and XML</asp:ListItem>
                        <asp:ListItem>Office 2007 and XML</asp:ListItem>
                        <asp:ListItem>Introduction to ASP.NET</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="labelFirstName" runat="server" Text="First name:"></asp:Label>  
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="textFirstName" runat="server"></asp:TextBox>
                </td>
                <td>                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required" ControlToValidate="textFirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="labelLastName" runat="server" Text="Last name:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="textLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required" ControlToValidate="textLastName"></asp:RequiredFieldValidator> 
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="labelEmail" runat="server" Text="Email:"></asp:Label>      
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textEmail" Display="Dynamic" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid email" ControlToValidate="textEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>    
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp
                </td>
                <td class="auto-style1">
                    <asp:Button ID="buttonSubmit" runat="server" Height="26px" Text="Submit" PostBackUrl="ResultsPage.aspx"/>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
	</form>
</body>
</html>