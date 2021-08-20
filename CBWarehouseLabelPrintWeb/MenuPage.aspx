<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MenuPage.aspx.vb" Inherits="CBWarehouseLabelPrintWeb.MenuPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/ProcessMonitor.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    </head>
<body>
           <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/">Buddig Process Monitor</a>
                </div>

                <div class="navbar">
                    <a href="#home">Home</a>&nbsp;&nbsp;
                    <a href="#news">News</a>
                      
                </div>

                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="MenuView_MenuItemClick" Orientation="Horizontal">
                        <Items>
                            <asp:MenuItem Text="Setup &nbsp; |&nbsp;" Value="0"></asp:MenuItem>
                            <asp:MenuItem Text="Errors &nbsp;|&nbsp;" Value="1"></asp:MenuItem>
                            <asp:MenuItem Text="Checkup &nbsp;|&nbsp;" Value="2"></asp:MenuItem>
                            <asp:MenuItem Text="Audit Trail &nbsp;|&nbsp;" Value="3"></asp:MenuItem>
                            
                            <asp:MenuItem NavigateUrl="~/KeypadForm.aspx" Text="Process Monitor" Value="4"></asp:MenuItem>
                            
                        </Items>
                    </asp:Menu>

                <div class="navbar-collapse collapse">
                    <asp:Menu ID="MenuView" CssClass="navbar" runat="server" OnMenuItemClick="MenuView_MenuItemClick" Orientation="Horizontal">
                        <Items>
                            <asp:MenuItem Text="Setup" Value="0"></asp:MenuItem>
                            <asp:MenuItem Text="Errors" Value="1"></asp:MenuItem>
                            <asp:MenuItem Text="Checkup" Value="2"></asp:MenuItem>
                            <asp:MenuItem Text="Audit Trail" Value="3"></asp:MenuItem>
                            
                            <asp:MenuItem NavigateUrl="~/KeypadForm.aspx" Text="Process Monitor" Value="4"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/About.aspx" Text="About" Value="5"></asp:MenuItem>
                            
                        </Items>
                    </asp:Menu>
                </div>
            </div>
        </div>

      <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
       <h2> 
            &nbsp;</h2>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
