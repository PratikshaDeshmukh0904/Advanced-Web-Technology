<%@ Page Language="C#" AutoEventWireup="true" CodeFile="samplechart.aspx.cs" Inherits="samplechart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">  
    <h4 style="color: White;">  
       Line Chart
    </h4>  
    <asp:Chart ID="Chart1" runat="server" BackColor="#ADD8E6"   
        BackGradientStyle="LeftRight" Height="350px" Palette="None"   
        PaletteCustomColors="0, 0, 139" Width="350px">  
        <Series>  
            <asp:Series Name="Series1">  
            </asp:Series>  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" >  
            </asp:ChartArea>  
        </ChartAreas>  
        <BorderSkin BackColor="lightblue" PageColor="#00ccff" />  
    </asp:Chart>  
  
  
    </form> 
</body>
</html>
