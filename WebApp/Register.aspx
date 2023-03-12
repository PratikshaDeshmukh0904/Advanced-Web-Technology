<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 257px;
        }
        .auto-style3 {
            margin-left: 139px;
        }
    </style>
</head>
<body style="height: 248px">
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Size="Larger" Text="Registration"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtuser" runat="server" Height="34px" Width="183px"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="DateofBirth" ></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtdob" type="date"  runat="server" Height="34px" Width="183px"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="rb1"  Text="Male" runat="server" name="gender" GroupName="gender" />

                   <asp:RadioButton ID="rb2"  Text="Female" runat="server" name="gender" GroupName="gender"/>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" name="pho" runat="server" Height="35px" Width="184px"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Valid Mobile Number" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Address" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" name="add" Height="35px" Width="184px"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Image"></asp:Label>
                </td>
                <td>
                   <asp:FileUpload ID="fileupload" runat="server" />  
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="btnsave" runat="server" CssClass="auto-style3" Height="32px" Text="Button" Width="129px" OnClick="btnsave_Click" />
    
        <br />
        <br />
        <br />
        <br />
   

           <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="Tomato"  OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">  
                <Columns>  
                    <asp:BoundField DataField="id" HeaderText="id" />  
                    <asp:BoundField DataField="name" HeaderText="Name" />  
                    <asp:BoundField DataField="dob" HeaderText="DOB" />  
                    <asp:BoundField DataField="sex" HeaderText="Sex" />
                     <asp:BoundField DataField="phone" HeaderText="Phone" />   
                    <asp:BoundField DataField="address" HeaderText="Address" />    
                  <asp:ImageField DataImageUrlField="image" HeaderText="Image" ControlStyle-Height="100px" ControlStyle-Width="100px" ></asp:ImageField>                                     
                           
                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnEdit" CommandName="lnkbtnEdit" CommandArgument='<%#Eval("id") %>' runat="server">Edit</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDelete" CommandName="lnkbtnDelete" CommandArgument='<%#Eval("id") %>' runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>  
            </asp:GridView>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
