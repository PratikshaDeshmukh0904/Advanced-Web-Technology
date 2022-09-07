<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DayReport.aspx.cs" Inherits="DayReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Multikart admin is super flexible, powerful, clean &amp; modern responsive bootstrap 4 admin template with unlimited possibilities." />
    <meta name="keywords" content="admin template, Multikart admin template, dashboard template, flat admin template, responsive admin template, web app" />
    <meta name="author" content="pixelstrap" />

    <title>CENTRAL WATER POWER & RESEARCH STATION ,PUNE</title>

    <!-- Google font-->
    <link href="https://fonts.googleapis.com/css?family=Work+Sans:100,200,300,400,500,600,700,800,900" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Font Awesome-->
    <link rel="stylesheet" type="text/css" href="../assets/css/fontawesome.css" />

    <!-- Flag icon-->
    <link rel="stylesheet" type="text/css" href="../assets/css/flag-icon.css" />

    <!-- ico-font-->
    <link rel="stylesheet" type="text/css" href="../assets/css/icofont.css" />

    <!-- Prism css-->
    <link rel="stylesheet" type="text/css" href="../assets/css/prism.css" />

    <!-- Chartist css -->
    <link rel="stylesheet" type="text/css" href="../assets/css/chartist.css" />

    <!-- Bootstrap css-->
    <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.css"/>

    <!-- App css-->
    <link rel="stylesheet" type="text/css" href="../assets/css/admin.css"/>
</head>

<body>

    <!-- page-wrapper Start-->
    <div class="page-wrapper">

        <!-- Page Header Start-->
        <div class="page-main-header">
            <div class="main-header-right row">
                <div class="main-header-left d-lg-none">
                    <div class="logo-wrapper">
                        <a href="index.html">
                            <img class="blur-up lazyloaded" alt=""></a>
                    </div>
                </div>
                <div class="mobile-sidebar">
                    <div class="media-body text-right switch-sm">
                        <label class="switch"><a href="#"><i id="sidebar-toggle" data-feather="align-left"></i></a></label>
                    </div>
                </div>
                <div class="nav-right col">
                    <ul class="nav-menus">
                        <li>

                            <li class="onhover-dropdown">
                                <div class="media align-items-center">
                                    <img class="align-self-center pull-right img-50 rounded-circle blur-up lazyloaded" src="../assets/images/dashboard/man.png" alt="header-user">
                                    <div class="dotted-animation"><span class="animate-circle"></span><span class="main-circle"></span></div>
                                </div>
                                <ul class="profile-dropdown onhover-show-div p-20">
                                    <%--                            <li><a href="AdminProfile.aspx"><i data-feather="user"></i>View Profile</a></li>--%>
                                    <li><a href="Default.aspx" onclick="preventBack()"><i data-feather="log-out"></i>Logout</a></li>
                                </ul>
                            </li>
                    </ul>
                    <div class="d-lg-none mobile-toggle pull-right"><i data-feather="more-horizontal"></i></div>
                </div>
            </div>
        </div>
        <!-- Page Header Ends -->

        <!-- Page Body Start-->
        <div class="page-body-wrapper">

            <!-- Page Sidebar Start-->
            <div class="page-sidebar">
                <div class="main-header-left d-none d-lg-block">
                    <div class="logo-wrapper">
                        <a href="index.html">
                            <img class="blur-up lazyloaded" alt=""></a>
                    </div>
                </div>
                <div class="sidebar custom-scrollbar">
                  <ul class="sidebar-menu">
                       <%-- <li><a class="sidebar-header" href="DailyDashboard.aspx"><i data-feather="home"></i><span>Dashboard</span></a></li>--%>
                       
                        <li><a class="sidebar-header" href="#"><i data-feather="box"></i><span>Daily_Reporting</span><i class="fa fa-angle-right pull-right"></i></a>
                            <ul class="sidebar-submenu">
                                 <li><a href="DailyDashboard.aspx"><i class="fa fa-circle"></i>Daily_Dashboard</a></li>
                                <li><a href="DayChart.aspx"><i class="fa fa-circle"></i>Graphical Report</a></li>
                                <li><a href="DayReport.aspx"><i class="fa fa-circle"></i>Tabular Report</a></li>
                               
                            </ul>
                             
                        </li>
                         <%--<li><a class="sidebar-header" href="MonthlyDashboard.aspx"><i data-feather="home"></i><span>Monthly_Dashboard</span></a></li>--%>
                          <li><a class="sidebar-header" href="MonthlyDashboard.aspx"><i data-feather="box"></i><span>Monthly_Reporting</span><i class="fa fa-angle-right pull-right"></i></a>
                            <ul class="sidebar-submenu">
                                <%-- <li><a href="MonthlyDashboard.aspx"><i class="fa fa-circle"></i>Monthly_Dashboard</a></li>--%>
                                <li><a href="chart.aspx"><i class="fa fa-circle"></i>Graphical Report</a></li>
                                <li><a href="DayToDayReport.aspx"><i class="fa fa-circle"></i>Tabular Report</a></li>
                               
                            </ul>
                             
                        </li>
                     
                     </ul>
                </div>
            </div>
            <!-- Page Sidebar Ends-->

            <!-- Right sidebar Start-->
            <div class="right-sidebar" id="right_side_bar">
                <div>
                    <div class="container p-0">
                        <div class="modal-header p-l-20 p-r-20">
                            <div class="col-sm-8 p-0">
                                <h6 class="modal-title font-weight-bold">FRIEND LIST</h6>
                            </div>
                            <div class="col-sm-4 text-right p-0"><i class="mr-2" data-feather="settings"></i></div>
                        </div>
                    </div>
                    <div class="friend-list-search mt-0">
                        <input type="text" placeholder="search friend"><i class="fa fa-search"></i>
                    </div>
                    <div class="p-l-30 p-r-30">
                        <div class="chat-box">
                            <div class="people-list friend-list">
                                <ul class="list">
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/user.png" alt="">
                                        <div class="status-circle online"></div>
                                        <div class="about">
                                            <div class="name">Vincent Porter</div>
                                            <div class="status">Online</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/user1.jpg" alt="">
                                        <div class="status-circle away"></div>
                                        <div class="about">
                                            <div class="name">Ain Chavez</div>
                                            <div class="status">28 minutes ago</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/user2.jpg" alt="">
                                        <div class="status-circle online"></div>
                                        <div class="about">
                                            <div class="name">Kori Thomas</div>
                                            <div class="status">Online</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/user3.jpg" alt="">
                                        <div class="status-circle online"></div>
                                        <div class="about">
                                            <div class="name">Erica Hughes</div>
                                            <div class="status">Online</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/man.png" alt="">
                                        <div class="status-circle offline"></div>
                                        <div class="about">
                                            <div class="name">Ginger Johnston</div>
                                            <div class="status">2 minutes ago</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/user5.jpg" alt="">
                                        <div class="status-circle away"></div>
                                        <div class="about">
                                            <div class="name">Prasanth Anand</div>
                                            <div class="status">2 hour ago</div>
                                        </div>
                                    </li>
                                    <li class="clearfix">
                                        <img class="rounded-circle user-image" src="../assets/images/dashboard/designer.jpg" alt="">
                                        <div class="status-circle online"></div>
                                        <div class="about">
                                            <div class="name">Hileri Jecno</div>
                                            <div class="status">Online</div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Right sidebar Ends-->

            <div class="page-body">

                <!-- Container-fluid starts-->
                <div class="container-fluid">
                    <div class="page-header">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="page-header-left">
                                    <h3>Daily Report
                                    <%--<small>Admin panel</small>--%>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Container-fluid Ends-->


                <!-- Container-fluid starts-->

                   <form name="form1" runat="server" class="theme-form">
                     <div class="form-row">
                         <%-- <div class="col-md-2">
                            
                               </div>--%>
                        <div class="col-md-1">
                            <asp:Label ID="label1" runat="server" Style="margin-bottom: 10px; margin-left: 10px; height: 54px; width: 100px;font-weight:bold;margin-top:auto;">From :</asp:Label>
                        </div> 
                         <div class="col-md-3">
                            <asp:TextBox ID="DATE" type="date" runat="server" name="DATE" required="" Class="form-control" Style="margin-bottom: 10px; margin-left: 10px; height: 54px; width:100%"></asp:TextBox>
                      </div>
                        <%-- <div class="col-md-1"></div>--%>
                          <div class="col-md-1">
                            <asp:Label ID="label2" runat="server" Style="margin-bottom: 10px; margin-left: 10px; height: 54px; width: 100px; font-weight:bold;margin-top:auto; ">To:</asp:Label>
                           </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="enddate" type="date" runat="server" name="End" required="" Class="form-control" Style="margin-bottom: 10px; margin-left: 10px; height: 54px; width: 100%"></asp:TextBox>
                        </div>
                       <div class="col-md-1"></div>
                        <div class="col-md-2" >
                            <asp:Button ID="show" runat="server" Class="btn btn-primary" Style="margin-bottom: 10px; height: 54px; margin-left: 0px; width: 200px" Text="Show" OnClick="show_Click" ></asp:Button>
                        </div>
                         
                         
                   
                    <hr />
                    <div class="table-responsive" style="text-align: center; margin: 10px;" runat="server">
                        <div class="clsmargin" style="margin: auto">
                            <asp:GridView ID="GridView1" calss="table table-bordered responsive-table" runat="server" BackColor="#DEBA84" CssClass="table table-hover table-striped" BorderStyle="None" Style="font: 300;" Width="100%" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
                                
                                <Columns ></Columns>
                                

                                <EmptyDataTemplate>
                                    No Data Found
                                </EmptyDataTemplate>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BorderStyle="Solid" Font-Bold="true" BackColor="#A55129" ForeColor="White" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                            </asp:GridView>




                             <asp:GridView ID="Gridview2" calss="table table-bordered responsive-table" runat="server"  HeaderStyle-CssClass="header"  CssClass="table table-hover table-striped" ItemStyleWidth="200px" CellPadding="4" GridLines="None" Style="font: 500;" AlternatingRowStyle-BackColor="WhiteSmoke" ForeColor="#333333">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                 <EditRowStyle BackColor="#999999" />
                                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BorderStyle="Solid" BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" Font-Size="Larger" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle Width="100%" BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns ></Columns>
                              
                                <HeaderStyle BorderStyle="Solid" Font-Bold="true" />
                                 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                 <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                 <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                 <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </div>
                       

                       
                    <div class="container-fluid">
                        <div class="page-header">
                            <div class="row">
                                <div class="col-md-2">
                            
                               </div>
                                <div class="col-md-4">
                                    <asp:Button ID="export" runat="server" Text="Export To Excel" Class="btn btn-primary" Style="margin-bottom: 10px; height: 54px; margin-left: 0px; width: 200px" OnClick="export_Click" />
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="pdfclick" runat="server" Text="Export To Pdf" Class="btn btn-primary" Style="margin-bottom: 10px; height: 54px; margin-left: 0px; width: 200px" OnClick="pdfclick_Click" />
                                </div>
                                <div class="col-md-2">
                            
                                </div>
                            </div>
                        </div>
                    </div>
                       </div>
                   </form>
                   
                    <!-- Container-fluid starts -->

                <!-- Container-fluid Ends-->


            </div>
        </div>
        <hr />


        <!-- footer start-->
        <footer class="footer">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-6 footer-copyright">
                        <p class="mb-0">Copyright &copy 2022</p>
                    </div>
                    <div class="col-md-6">
                        <p class="pull-right mb-0">Aashay Measurements Private Limited . All rights reserved.</p>
                    </div>
                </div>
            </div>
        </footer>
        <!-- footer end-->
    </div>

    </div>

    <!-- latest jquery-->
    <script src="../assets/js/jquery-3.3.1.min.js"></script>

    <!-- Bootstrap js-->
    <script src="../assets/js/popper.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>

    <!-- feather icon js-->
    <script src="../assets/js/icons/feather-icon/feather.min.js"></script>
    <script src="../assets/js/icons/feather-icon/feather-icon.js"></script>

    <!-- Sidebar jquery-->
    <script src="../assets/js/sidebar-menu.js"></script>

    <!--chartist js-->
    <script src="../assets/js/chart/chartist/chartist.js"></script>

    <!--chartjs js-->
    <script src="../assets/js/chart/chartjs/chart.min.js"></script>

    <!-- lazyload js-->
    <script src="../assets/js/lazysizes.min.js"></script>

    <!--copycode js-->
    <script src="../assets/js/prism/prism.min.js"></script>
    <script src="../assets/js/clipboard/clipboard.min.js"></script>
    <script src="../assets/js/custom-card/custom-card.js"></script>

    <!--counter js-->
    <script src="../assets/js/counter/jquery.waypoints.min.js"></script>
    <script src="../assets/js/counter/jquery.counterup.min.js"></script>
    <script src="../assets/js/counter/counter-custom.js"></script>

    <!--peity chart js-->
    <script src="../assets/js/chart/peity-chart/peity.jquery.js"></script>

    <!--sparkline chart js-->
    <script src="../assets/js/chart/sparkline/sparkline.js"></script>

    <!--Customizer admin-->
    <script src="../assets/js/admin-customizer.js"></script>

    <!--dashboard custom js-->
    <script src="../assets/js/dashboard/default.js"></script>

    <!--right sidebar js-->
    <script src="../assets/js/chat-menu.js"></script>

    <!--height equal js-->
    <script src="../assets/js/height-equal.js"></script>

    <!-- lazyload js-->
    <script src="../assets/js/lazysizes.min.js"></script>

    <!--script admin-->
    <script src="../assets/js/admin-script.js"></script>

</body>
</html>

