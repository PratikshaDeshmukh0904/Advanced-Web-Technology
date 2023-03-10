<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/unlogin.master"%>

 <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="height: 410px; background-color: #FFFFFF;">
     <br />
     <br />
    <table class="style2" align="center">
        <tr>
            <td class="style11" colspan="3">
                <strong>Login Page</strong></td>
        </tr>
        <tr>
            <td class="style3">
                User ID:</td>
            <td class="style3">
                <asp:TextBox ID="TextBox1" runat="server" Width="222px" CssClass="style6"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Please Enter User ID" 
                    ForeColor="Red" Width="162px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                UserName:</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUserName" runat="server" Width="219px" 
                    CssClass="style6"></asp:TextBox>
            </td>
            <td class="style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxUserName" CssClass="style6" 
                    ErrorMessage="Please Enter User Name" ForeColor="Red" Width="170px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                PassWord:</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" 
                    Width="217px" CssClass="style6"></asp:TextBox>
            </td>
            <td class="style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxPassword" CssClass="style6" 
                    ErrorMessage="Please Enter Password" ForeColor="Red" Width="162px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label1" runat="server" Width="160px"></asp:Label>
            </td>
            <td class="style3">
                <asp:Button ID="Button_Login" runat="server" onclick="Button_Login_Click" 
                    Text="Login" Width="219px" CssClass="style6" />
            </td>
            <td class="style7">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registration.aspx" 
                    Width="162px">New User Register Here</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AdminLogin.aspx" 
                    Width="270px">Admin Login</asp:HyperLink>
            </td>
            <td class="style7">
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/ForgotPassword.aspx" Width="160px">Forgot Password?</asp:HyperLink>
            </td>
        </tr>
    </table>
    </div>
    </asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {
            width: 777px;
            height: 292px;
            font-weight: 700;
        }
        .style11
        {
            text-align: center;
            font-weight: normal;
            font-size: xx-large;
            color: #000099;
        }
        .style3
        {
            text-align: center;
        }
        .style8
        {
            width: 7px;
        }
        .style7
        {
            width: 7px;
        }
        .style4
        {
            width: 177px;
            text-align: center;
        }
    </style>
</asp:Content>
