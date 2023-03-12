<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="WebApp.EditInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Info</title>
</head>
<body style="height: 248px">

    <form class="needs-validation" runat="server" enctype="multipart/form-data">
                                
                                    
                                    
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title f-w-600" id="exampleModalLabel">Update Information</h5>
                                                </div>
                                                <div class="modal-body">
                                                   
                                                        <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Status :</label>
                                                                <input class="form-control" id="validationCustom01" style="margin:auto" name="user" value="<% =servervalue %>" type="text">
                                                                  
                                                            </div>
                                                         
                                                        </div>
                                                     <br />
       
                                                     <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Dob :</label>
                                                                <input class="form-control" id="validationCustom01" style="margin:auto" name="dob" value="<% =servervalue1 %>" type="date">
                                                                  
                                                            </div>
                                                         
                                                        </div>
                                                     <br />
        
                                                     <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Sex :</label>
                                                               <asp:RadioButton ID="rb1"  Text="Male" runat="server" />

                                                               <asp:RadioButton ID="rb2"  Text="Female" runat="server" />
                                                            </div>
                                                         
                                                        </div>
                                                     <br />
                                                     
                                                     <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Phone :</label>
                                                                <input class="form-control" id="validation1" style="margin:auto" name="pho" value="<% =servervalue2%>" type="tel" onchange="ValidateMobileNumber()" >
                                                                
                                                            </div>
                                                         
                                                        </div
                                                    <br />
                                                    <br />
                                                    <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Address :</label>
                                                                <input class="form-control" id="validationCustom01" style="margin:auto" name="add" value="<% =servervalue3%>" type="text">
                                                                  
                                                            </div>
                                                         
                                                        </div>
                                                     <br />
                                                    <br />
       
                                                      <div class="form">
                                                            <div class="form-group">
                                                                <label for="validationCustom01" class="mb-1">Image :</label>
                                                               <asp:FileUpload ID="fileupload" runat="server" />
                                                                  
                                                            </div>
                                                         
                                                        </div>                              
                                                
                                               
                                                
                                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                
                                <div class="table-responsive">

                                    <div class="clsmargin" style="margin-top: 5%">
            
                                     

                                </div>
                                   
                               
    
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
        <asp:Button ID="btnUpdate" runat="server" CssClass="auto-style3" Height="32px" Text="Update" Width="129px" onclick="btnUpdate_Click" />
    
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="476px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
            <Columns>
                    <asp:TemplateField HeaderText="ID" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Middle Name" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("sex") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Branch" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("image") %>'></asp:Label>
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
   <script type="text/javascript">
       function ValidateMobileNumber() {
           var mobileNumber = document.getElementById("validation1").value;
           var lblError = document.getElementById("lblError");
           lblError.innerHTML = "";
           var expr = /^(0|91)?[6-9][0-9]{9}$/;
           if (!expr.test(mobileNumber)) {
               lblError.innerHTML = "Invalid Mobile Number.";
           }
       }
</script>
</body>
</html>
