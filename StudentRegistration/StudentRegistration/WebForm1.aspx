<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StudentRegistration.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: "Arial Black";
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 class="style1">
            <strong>STUDENT REGISTRATION</strong></h1>
        <p class="style1">
            &nbsp;Sid:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p class="style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Sname:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p class="style1">
            Contact:&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p class="style1">
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p class="style1">
            DOB:    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p class="style1">
            Class:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:DropDownList 
                ID="DropDownList1" runat="server">
                <asp:ListItem>M.sc</asp:ListItem>
                <asp:ListItem>MCA</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp; &nbsp;
        </p>
        <p class="style1">
            Marks:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            &nbsp;&nbsp; &nbsp;
        </p>
        <p class="style1">
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
        <p class="style1">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
    
    </div>
    </form>
</body>
</html>
