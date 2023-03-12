<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display_Image.aspx.cs" Inherits="WebApp.Display_Image" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>  
    <form id="form1" runat="server">  
     <h3 style="color: #0000FF; font-style: italic">Display Image in GridView Using ASP.NET</h3>  
    <div>  
    <asp:FileUpload ID="fileupload" runat="server" />  
        <br />  
        <asp:Button ID="upload" runat="server" Font-Bold="true" Text="Upload" onclick="upload_Click" />  
        <br />  
        <br />  
    </div>  
        <div>  
            <asp:GridView runat="server" ID="gdImage" HeaderStyle-BackColor="Tomato"  AutoGenerateColumns="false"  Width="476px" >  
                <Columns>  
                    <asp:BoundField DataField="ImageId" HeaderText="ImageId" />  
                    <asp:BoundField DataField="ImageName" HeaderText="ImageName" />  
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ControlStyle-Height="100px" ControlStyle-Width="100px" ></asp:ImageField>                     
                </Columns>  
            </asp:GridView>  
        </div>  
    </form>  
</body>  
</html>
