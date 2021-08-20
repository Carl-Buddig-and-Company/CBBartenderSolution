<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KeypadForm.aspx.vb" Inherits="CBWarehouseLabelPrintWeb.KeypadForm" %>

<%@ Register src="Controls/Keypad.ascx" tagname="Keypad" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %>- Buddig Warehouse Label Print</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/ProcessMonitor.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
            var elem = document.getElementById('divContent'); elem.style.display = 'none';
        }, 200);
        return true
    }
    //$('form').live("submit", function () {
    //    ShowProgress();
    //});
</script>

    <style type="text/css">
        /*.chip {
    display: inline-block;
    padding: 0 25px;
    height: 50px;
    font-size: 16px;
    line-height: 50px;
    border-radius: 25px;
    background-color: #f1f1f1;
}

    .chip img {
        float: left;
        margin: 0 10px 0 -25px;
        height: 50px;
        width: 50px;
        border-radius: 50%;
    }

.card {
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    max-width: 300px;
    margin: auto;
    text-align: center;
    font-family: arial;
}

.price {
    color: grey;
    font-size: 22px;
}

.card button {
    border: none;
    outline: 0;
    padding: 12px;
    color: white;
    background-color: #000;
    text-align: center;
    cursor: pointer;
    width: 100%;
    font-size: 18px;
}

.cardbutton1 {
    border: none;
    outline: 0;
    padding: 12px;
    color: white;
    background-color: #000;
    text-align: center;
    cursor: pointer;
    width: 100%;
    font-size: 18px;
}
div.blueTable {
    border: 1px solid #1C6EA4;
    background-color: #EEEEEE;
    width: 100%;
    text-align: left;
    border-collapse: collapse;
}

.divTable.blueTable .divTableCell, .divTable.blueTable .divTableHead {
    border: 1px solid #AAAAAA;
    padding: 3px 2px;
}

.divTable.blueTable .divTableBody .divTableCell {
    font-size: 13px;
    color: #5D5D5D;
}

.divTable.blueTable .divTableRow:nth-child(even) {
    background: #D0E4F5;
}

.divTable.blueTable .divTableHeading {
    background: #FFFFFF;
    background: -moz-linear-gradient(top, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
    background: -webkit-linear-gradient(top, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
    background: linear-gradient(to bottom, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
    border-bottom: 2px solid #444444;
}

    .divTable.blueTable .divTableHeading .divTableHead {
        font-size: 15px;
        font-weight: bold;
        color: #111111;
        border-left: 2px solid #D0E4F5;
    }

        .divTable.blueTable .divTableHeading .divTableHead:first-child {
            border-left: none;
        }

.blueTable .tableFootStyle {
    font-size: 14px;
}

    .blueTable .tableFootStyle .links {
        text-align: right;
    }

        .blueTable .tableFootStyle .links a {
            display: inline-block;
            background: #1C6EA4;
            color: #FFFFFF;
            padding: 2px 8px;
            border-radius: 5px;
        }

.blueTable.outerTableFooter {
    border-top: none;
}

    .blueTable.outerTableFooter .tableFootStyle {
        padding: 3px 5px;
    }*/
/* DivTable.com */
/*.divTable {
    display: table;
}

.divTableRow {
    display: table-row;
}

.divTableHeading {
    display: table-header-group;
}

.divTableCell, .divTableHead {
    display: table-cell;
}

.divTableHeading {
    display: table-header-group;
}

.divTableFoot {
    display: table-footer-group;
}

.divTableBody {
    display: table-row-group;
}
div.columns {
    width: 900px;
}

    div.columns div {
        width: 300px;
        height: 100px;
        float: left;
    }

div.grey {
    background-color: #cccccc;
}

div.red {
    background-color: #e14e32;
}

div.clear {
    clear: both;
}


        .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #1C6EA4;
        border-radius: 32px;
        width: 600px;
        height: 400px;
        display: none;
        position: relative;
        background-color: White;
        z-index: 999;
        left:15%;
        top: 20%;
    }
    
.loader {
  border: 16px solid #f3f3f3;*/ /* Light grey */
  /*border-top: 16px solid #3498db;*/ /* Blue */
  /*border-radius: 50%;
  width: 120px;
  height: 120px;
  position: absolute;
  top: 40%;
  left: 25%;
  animation: spin 2s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}
        .PanelStyle
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #1C6EA4;
        border-radius: 32px;
        width: 600px;
        height: 400px;
        background-color: White;
        z-index: 999;
    }
        .auto-style1 {
            width: 16px;
        }
        div.blueTable {
  border: 1px solid #1C6EA4;
  background-color: #EEEEEE;
  width: 100%;
  text-align: left;
  border-collapse: collapse;
}
.divTable.blueTable .divTableCell, .divTable.blueTable .divTableHead {
  border: 1px solid #AAAAAA;
  padding: 3px 2px;
}
.divTable.blueTable .divTableBody .divTableCell {
  font-size: 13px;
  color: #5D5D5D;
}
.divTable.blueTable .divTableRow:nth-child(even) {
  background: #D0E4F5;
}
.divTable.blueTable .divTableHeading {
  background: #FFFFFF;
  background: -moz-linear-gradient(top, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
  background: -webkit-linear-gradient(top, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
  background: linear-gradient(to bottom, #ffffff 0%, #ffffff 66%, #FFFFFF 100%);
  border-bottom: 2px solid #444444;
}
.divTable.blueTable .divTableHeading .divTableHead {
  font-size: 30px;
  font-weight: bold;
  color: #111111;
  border-left: 2px solid #D0E4F5;
}
.divTable.blueTable .divTableHeading .divTableHead:first-child {
  border-left: none;
}

.blueTable .tableFootStyle {
  font-size: 14px;
}
.blueTable .tableFootStyle .links {
	 text-align: right;
}
.blueTable .tableFootStyle .links a{
  display: inline-block;
  background: #1C6EA4;
  color: #FFFFFF;
  padding: 2px 8px;
  border-radius: 5px;
}
.blueTable.outerTableFooter {
  border-top: none;
}
.blueTable.outerTableFooter .tableFootStyle {
  padding: 3px 5px; 
}*/
/* DivTable.com */
/*.divTable{ display: table; }
.divTableRow { display: table-row; }
.divTableHeading { display: table-header-group;}
.divTableCell, .divTableHead { display: table-cell;}
.divTableHeading { display: table-header-group;}
.divTableFoot { display: table-footer-group;}
.divTableBody { display: table-row-group;}
div.bkTable {
}
.divTable.bkTable .divTableCell, .divTable.bkTable .divTableHead {
  border: 0px solid #FFFFFF;
}
.divTable.bkTable .divTableBody .divTableCell {
  font-size: 20px;
}
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            height: 190px;
        }
        .auto-style5 {
            width: 996px;
        }
        .auto-style6 {
            width: 2px;
        }*/
        </style>

</head>
<body>
    <form id="form1" runat="server">
        
         <asp:ScriptManager runat="server" ID="ScriptManager1">
            <Scripts>
               
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                               <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
             
        </asp:ScriptManager>
 
        <table>
           <%-- header--%>
            <tr>
                <td>
        <div aria-orientation="horizontal">
  <div align="center">
    
    <ul class="nav navbar-nav">
      <li>
          <div class="chip">
          <asp:ImageButton ID="ImageButtonLine" runat="server" ImageUrl="~/Content/Images/yes.png" Height="48px" ImageAlign="Middle" Width="48px"  />
                         &nbsp;
         
          <asp:Label ID="LabelLine" runat="server" Font-Size="Large" ForeColor="Red" Text="Select Line"></asp:Label> 
      </div>
              </li>
         <li>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </li>
      <li> 
          <div class="chip">
          <asp:ImageButton ID="ImageButtonOrder" runat="server" ImageUrl="~/Content/Images/yes.png" Visible="False" Height="48px" ImageAlign="Middle" Width="48px" />
                         &nbsp;
          <asp:Label ID="LabelOrder" runat="server" Font-Size="Large" ForeColor="Red" Text="Enter Production Order" Visible="False"></asp:Label>
</div>
</li>
         <li>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </li>
      <li>
          <div class="chip">
          <asp:ImageButton ID="ImageButtonBasket" runat="server" ImageUrl="~/Content/Images/yes.png" Visible="False" Height="48px" ImageAlign="Middle" Width="48px" />
                         &nbsp;
          <asp:Label ID="LabelBasket" runat="server" Font-Size="Large" ForeColor="Red" Text="Enter Basket" Visible="False"></asp:Label>
</div>

      </li>
    </ul>
  </div>
    
</div>
                    <div><asp:Label ID="LabelMessage" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
 <hr />
                    </div>
                               
            <br />
            <br />
                </td>
             
            </tr>
             <%--  body--%>
            <tr>
                <td>
  <div id="divContent">

           <asp:Panel ID="Panel2" runat="server" BorderStyle="None" Width="1261px" HorizontalAlign="center" Wrap="False">
                <table style="position: relative; left: .25in">
                    <tr>
                        <td class="auto-style12" style="vertical-align: top">
                            <asp:MultiView ID="MultiView1" runat="server">
                                
                                <asp:View ID="ViewLineMaster" runat="server">
                                    <asp:DataList ID="DataList2" runat="server" CellPadding="1" CellSpacing="11" DataSourceID="ObjectDataSourceLineMaster" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="3" ShowFooter="False" OnItemCommand="DataList2_ItemCommand" RepeatDirection="Horizontal" ShowHeader="False">
                                        <ItemTemplate>
                                            
                           
                                        <table class="auto-style3">
                                                <tr>
                                                    <td>

                                                    </td>
                                                    <td rowspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                    <td>
                                                       <div class="card">
                                              <h1>
                                                  <asp:Label ID="LabelLineNumberItem" runat="server" Text='<%# Eval("Line") %>'><%# Eval("Line") %></asp:Label>
                                                </h1>
                                              <p class="price">
                                                  <asp:Label ID="LabelDLPrinterName" runat="server" Text='<%# Eval("strPrinterName") %>' />
                                                </p>
                                              <p>Printer ID:
                                                  <asp:Label ID="fk_nPrinterTypeIdLabel" runat="server" Text='<%# Eval("fk_nPrinterId") %>' />
                                                </p>
                                              <p><asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="cardbutton1">Select Line - <%# Eval("Line") %></asp:LinkButton></p>
                                            </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br /> </td>
                                                </tr>
                                            </table>
                                            &nbsp;   
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                           
                                        </SeparatorTemplate>
                                    </asp:DataList>
                                    <br />
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="5" DataSourceID="ObjectDataSourceLineMaster" Font-Size="Large" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="782px" Visible="False">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                            <asp:BoundField DataField="fk_nPrinterId" HeaderText="Printer ID" SortExpression="fk_nPrinterId" />
                                            <asp:BoundField DataField="strPrinterName" HeaderText="Printer Name" SortExpression="strPrinterName" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <span style="color: #333333">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonKiosk" runat="server" class="btn btn-primary btn-lg" Height="39px" Text="Show All Lines" Width="156px" />
                                    </span>&nbsp;<asp:ObjectDataSource ID="ObjectDataSourceLineMaster" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByKiosk" TypeName="CBWarehouseLabelPrint.LineFullTableAdapters.FullDataSetTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="fk_nDefaultKioskId" SessionField="Kiosk" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <br />
                                </asp:View>
                                <asp:View ID="ViewProductionOrders" runat="server">
                                    <asp:DataList ID="DataList1" runat="server" CellPadding="5" CellSpacing="11" OnItemCommand="DataList1_ItemCommand" DataKeyField="MfgOrdNumber" DataSourceID="ObjectDataSourceProductionOrders" RepeatColumns="4" HorizontalAlign="Center">
                                        <FooterTemplate>
                                            <asp:Label Visible='<%# Boolean.Parse(DataList1.Items.Count = 0)%>' runat="server" ID="lblNoOrderRecord" Text="No Production Orders Found!" Font-Size="Large"></asp:Label>

                                        </FooterTemplate>
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                             <table class="auto-style3">
                                                <tr>
                                                    <td>
                                                      
                                                    </td>
                                                    <td rowspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                          <div class="card">
                                                              <h1>
                                                                <asp:Label ID="lblProdDL" runat="server" Text='<%# Eval("MfgOrdNumber") %>'></asp:Label>
                                                        </h1>
                                          <p class="price"><asp:Label ID="Product_DescriptionLabel" runat="server" Text='<%# Eval("[Product Description]") %>' /></p>
                                        <p>Line:<asp:Label ID="LineLabel" runat="server" Text='<%# Eval("Line") %>' /></p>
                                       <p>Shift:<asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift") %>' /></p>
                                                                                          <br />
                                       <p> <asp:Label ID="Format_NameLabel" runat="server" Text='<%# Eval("[Format Name]") %>' /></p>
                                       <p> <asp:Label ID="CanadaCertLabel" runat="server" Text='<%# Eval("CanadaCert") %>' /></p>
                                        <p>  <asp:LinkButton ID="LinkButtonOrder" runat="server" CommandName="Select" CssClass="cardbutton1">Select Order - <%# Eval("MfgOrdNumber") %></asp:LinkButton>                                                                                                                                                                          
                                               </p>           
                                                          </div>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        
                                                        <br /> </td>
                                                </tr>
                                                 <tr>
                                                     <td>  </td>
                                                 </tr>
                                                 <tr>
                                                     <td>
                                                        </td>
                                                 </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:GridView ID="GridViewProductionOrders" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="6" DataSourceID="ObjectDataSourceProductionOrders" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="20" Visible="False" Width="1046px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="MfgOrdNumber" HeaderText="Order" SortExpression="MfgOrdNumber" />
                                            <asp:BoundField DataField="Product Description" HeaderText="Desc" SortExpression="Product Description" />
                                            <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
                                            <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:ObjectDataSource ID="ObjectDataSourceProductionOrders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByLineSchedule" TypeName="CBWarehouseLabelPrint.DataSetProductionOrdersTableAdapters.Production_TicketsTableAdapter">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="LabelLineNumber" Name="Line_" PropertyName="Text" Type="Int32" />
                                            <asp:ControlParameter ControlID="LabelShift" Name="Shift_" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </asp:View>
                                <asp:View ID="ViewBaskets" runat="server">
                                    Enter Basket<br />&nbsp;&nbsp;&nbsp;<br />
                                </asp:View>
                                <asp:View ID="ViewPrinters" runat="server">
                                    Print Labels -
                                    <asp:Label ID="LabelPrinterSelected" runat="server" Text="No Line Selected"></asp:Label>
                                    &nbsp;<br />
                                    <br />
                                    <br />
                                </asp:View>
                                <asp:View ID="ViewStart" runat="server">
                                    Select from any Line<br />
                                    <asp:GridView ID="GridViewKiosk" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Line" DataSourceID="ObjectDataSourceLineMasterFull" ForeColor="#333333" GridLines="None" PageSize="25" Width="1008px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="Line" HeaderText="Line" ReadOnly="True" SortExpression="Line" />
                                            <asp:BoundField DataField="fk_nPrinterId" HeaderText="Printer ID" SortExpression="fk_nPrinterId" />
                                            <asp:BoundField DataField="strPrinterName" HeaderText="Printer Name" SortExpression="strPrinterName" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings Mode="NextPreviousFirstLast" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjectDataSourceLineMasterFull" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.LineFullTableAdapters.FullDataSetTableAdapter"></asp:ObjectDataSource>
                                    <br />
                                </asp:View>
                                <asp:View ID="ViewCanadianCert" runat="server">
                                    Enter Canadian cert #
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td class="auto-style6" style="vertical-align: top">&nbsp;</td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td style="vertical-align: top">
                            <asp:Panel ID="PanelKeypad" runat="server">
                                <uc1:Keypad ID="Keypad1" runat="server" />
                            </asp:Panel>
                            
                            <asp:Panel ID="PanelShiftChange" runat="server" Height="145px" Visible="False">
                                <br />
                                <asp:RadioButtonList ID="RadioButtonListShift" runat="server">
                                    <asp:ListItem Value="1" Selected="True">1st Shift</asp:ListItem>
                                    <asp:ListItem Value="2">2nd Shift</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Button ID="ButtonShiftChange" runat="server" class="btn btn-primary btn-lg" Text="Change Shift" Width="174px" />
                            </asp:Panel>
                        </td>
                    </tr>
                   
                   
                </table>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Width="1365px" Visible="False">
             <table class="auto-style13">
                 <tr>
                     <td class="auto-style8">&nbsp;</td>
                     <td class="auto-style20" colspan="3" >
                         <h2>Test Panel -
                             <asp:Button ID="ButtonAdmin" runat="server" CssClass="btn btn-primary btn-lg" Text="Admin" />
                             &nbsp;
                             <asp:Button ID="ButtonBasketGo" runat="server" class="btn btn-primary btn-lg" Height="46px" Text="Label Print Preview" Width="208px" />
                             &nbsp;
                             <asp:Button ID="ButtonViewPrinters" runat="server" CssClass="btn btn-primary btn-lg" Text="Admin - View More" />
                         </h2>
                         <p>
                         </p>
                         <p>
                         </p>
                         <p>
                         </p>
                     </td>
                     <td rowspan="3">
                         <table class="auto-style21">
                             <tr>
                                 <td class="auto-style11">Kiosk</td>
                                 <td>
                                     <asp:Label ID="LabelKiosk" runat="server" Text="Kiosk"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style26">Line</td>
                                 <td class="auto-style27">
                                     <asp:Label ID="LabelLineNumber" runat="server" Text="Line"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style26">Shift</td>
                                 <td class="auto-style27">
                                     <asp:Label ID="LabelShift" runat="server" Text="Shift"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Printer</td>
                                 <td>
                                     <asp:Label ID="LabelPrinterName" runat="server" Text="Printer Name"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Printer ID:</td>
                                 <td>
                                     <asp:Label ID="LabelPrinterId" runat="server" Text="PrinterID"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Production Order:</td>
                                 <td>
                                     <asp:Label ID="LabelProdOrder" runat="server" Text="Production Order"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Product Desc</td>
                                 <td>
                                     <asp:Label ID="LabelProdDesc" runat="server" Text="Production Order"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Pack Desc:</td>
                                 <td>
                                     <asp:Label ID="LabelPack" runat="server" Text="PackDesc"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Pack Qty</td>
                                 <td>
                                     <asp:Label ID="LabelQty" runat="server" Text="Qty"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">GTIN</td>
                                 <td>
                                     <asp:Label ID="LabelGTIN" runat="server" Text="GTIN"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Format</td>
                                 <td>
                                     <asp:Label ID="LabelFormat" runat="server" Text="Format"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">File Path:</td>
                                 <td>
                                     <asp:Label ID="LabelFilePath" runat="server" Text="File Path"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Preview Path</td>
                                 <td>
                                     <asp:Label ID="LabelPreview" runat="server" Text="Preview"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Printer Type</td>
                                 <td>
                                     <asp:Label ID="LabelPrintType" runat="server" Text="LabelPrintType"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">Basket</td>
                                 <td>
                                     <asp:Label ID="LabelBasketNumber" runat="server" Text="BasketNumber"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style11">
                                     &nbsp;</td>
                                 <td>
                                     <asp:Label ID="LabelCert" runat="server" Text="Label"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="2">&nbsp;</td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style8"></td>
                     <td class="auto-style9">
                         <h2>
                             <asp:Button ID="ButtonLineMaster" runat="server" class="btn btn-primary btn-lg" Text="Line Number » " />
                         </h2>
                     </td>
                     <td class="auto-style4">
                         <h2>
                             <asp:Button ID="ButtonProdOrder" runat="server" class="btn btn-primary btn-lg" Text="Production Order » " Visible="False" />
                         </h2>
                     </td>
                     <td class="auto-style23">
                         <h2 class="auto-style22">
                             <asp:Button ID="ButtonBasket" runat="server" class="btn btn-primary btn-lg" Text="Basket » " Visible="False" Width="154px" />
                         </h2>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style10"></td>
                     <td class="auto-style1">
                         <asp:Panel ID="PanelPrinter" runat="server" Visible="False" Width="1076px">
                             Admin Panel<br />
                             <br />
                             <br />
                             Installed Printers<br />
                             <asp:ListBox ID="ListBoxBTPrinters" runat="server" DataSourceID="ObjectDataSourceBTPrinters" DataTextField="PrinterName" DataValueField="PrinterName"></asp:ListBox>
                             <asp:ObjectDataSource ID="ObjectDataSourceBTPrinters" runat="server" SelectMethod="GetServerPrinters" TypeName="CBLabelPrinterBLL.CB.Bartender.Models.ServerPrinterInfo"></asp:ObjectDataSource>
                             <br />
                             Selected printer<br />
                             <asp:ListBox ID="ListBoxDALPrinter" runat="server" DataSourceID="ObjectDataSourceDALPrinters" DataTextField="strPrinterName" DataValueField="pk_nPrinterId"></asp:ListBox>
                             <asp:ObjectDataSource ID="ObjectDataSourceDALPrinters" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.DataSetPrintersTableAdapters.PrinterTableAdapter" UpdateMethod="Update">
                                 <DeleteParameters>
                                     <asp:Parameter Name="Original_pk_nPrinterId" Type="Int32" />
                                     <asp:Parameter Name="Original_strPrinterName" Type="String" />
                                     <asp:Parameter Name="Original_strIPAddress" Type="String" />
                                     <asp:Parameter Name="Original_nSortOrder" Type="Int32" />
                                     <asp:Parameter Name="Original_fk_nPrinterTypeId" Type="Int32" />
                                     <asp:Parameter Name="Original_nPlant" Type="Int32" />
                                     <asp:Parameter DbType="Guid" Name="Original_msrepl_tran_version" />
                                 </DeleteParameters>
                                 <InsertParameters>
                                     <asp:Parameter Name="pk_nPrinterId" Type="Int32" />
                                     <asp:Parameter Name="strPrinterName" Type="String" />
                                     <asp:Parameter Name="strIPAddress" Type="String" />
                                     <asp:Parameter Name="nSortOrder" Type="Int32" />
                                     <asp:Parameter Name="fk_nPrinterTypeId" Type="Int32" />
                                     <asp:Parameter Name="nPlant" Type="Int32" />
                                     <asp:Parameter DbType="Guid" Name="msrepl_tran_version" />
                                 </InsertParameters>
                                 <UpdateParameters>
                                     <asp:Parameter Name="strPrinterName" Type="String" />
                                     <asp:Parameter Name="strIPAddress" Type="String" />
                                     <asp:Parameter Name="nSortOrder" Type="Int32" />
                                     <asp:Parameter Name="fk_nPrinterTypeId" Type="Int32" />
                                     <asp:Parameter Name="nPlant" Type="Int32" />
                                     <asp:Parameter DbType="Guid" Name="msrepl_tran_version" />
                                     <asp:Parameter Name="Original_pk_nPrinterId" Type="Int32" />
                                     <asp:Parameter Name="Original_strPrinterName" Type="String" />
                                     <asp:Parameter Name="Original_strIPAddress" Type="String" />
                                     <asp:Parameter Name="Original_nSortOrder" Type="Int32" />
                                     <asp:Parameter Name="Original_fk_nPrinterTypeId" Type="Int32" />
                                     <asp:Parameter Name="Original_nPlant" Type="Int32" />
                                     <asp:Parameter DbType="Guid" Name="Original_msrepl_tran_version" />
                                 </UpdateParameters>
                             </asp:ObjectDataSource>
                             <br />
                         </asp:Panel>
                     </td>
                     <td #cccccc;"="" background-color:="" class="auto-style5" modal-sm"="">
                         <h3>&nbsp;</h3>
                     </td>
                     <td class="auto-style24">
                         <h3>&nbsp;</h3>
                     </td>
                 </tr>
             </table>
         </asp:Panel>
            <br />
            <br />
                                    <asp:BulletedList ID="BulletedList1" runat="server" ForeColor="Red">
                                    </asp:BulletedList>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div align="center" class="loading">
            Loading Print Preview......
       <div class="loader">
           
       </div>    

    </div>
                </td>
            </tr>
        </table>

                    
      

    </form>
</body>
</html>
