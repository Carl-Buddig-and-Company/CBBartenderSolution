<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="CBWarehouseLabelPrintWeb.Admin" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %>- Buddig Warehouse Label Print</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/ProcessMonitor.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .auto-style1 {
            width: 985px;
        }
        .auto-style2 {
            width: 1039px;
        }
        .auto-style3 {
            width: 226%;
        }
        .auto-style4 {
            width: 580px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
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
                <div class="navbar-collapse collapse">
                    <asp:Menu ID="MenuView" runat="server" OnMenuItemClick="MenuView_MenuItemClick" Orientation="Horizontal">
                        <Items>
                            <asp:MenuItem Text="Setup &nbsp; |&nbsp;" Value="0"></asp:MenuItem>
                            <asp:MenuItem Text="Errors &nbsp;|&nbsp;" Value="1"></asp:MenuItem>
                            <asp:MenuItem Text="Checkup &nbsp;|&nbsp;" Value="2"></asp:MenuItem>
                            <asp:MenuItem Text="Audit Trail &nbsp;|&nbsp;" Value="3"></asp:MenuItem>
                            
                            <asp:MenuItem NavigateUrl="~/KeypadForm.aspx" Text="Process Monitor" Value="4"></asp:MenuItem>
                            
                        </Items>
                    </asp:Menu>
                </div>
            </div>
        </div>

      <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
       <h2> 
            &nbsp;</h2>
           <h2> 
            &nbsp;<asp:Label ID="LabelMessage" runat="server"></asp:Label>
        </h2>
        <div style="left: 10%" >
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
   <asp:View ID="Tab1" runat="server"  >
        <table width="600" height="400" cellpadding=0 cellspacing=0>
            <tr valign="top">
                <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">
                    <h2>
                        <asp:Label ID="LabelWelcome" runat="server"></asp:Label>
                    </h2>
                    <p class="auto-style1">
                        Setup a new Kiosk - Select a kiosk below and then click ADD KIOSK. Or you can create a new Kiosk cookie by just typeing in a valid kiok ID and name. This will add the default kiosk&nbsp;<asp:Label ID="LabelLocation" runat="server" Text="Label"></asp:Label>
                        &nbsp;<asp:Label ID="LabelKioskId" runat="server" Text="Label"></asp:Label>
                    </p>
                    <table class="auto-style3">
                        <tr>
                            <td style="vertical-align: top" class="auto-style2">
                                &nbsp; &nbsp;
                                <asp:DataList ID="DataListPlants" runat="server" CellPadding="1" CellSpacing="11" DataKeyField="Plant" DataSourceID="ObjectDataSourceLocations" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="5" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <div class="card">

                                        <h1><asp:Label ID="PlantDescLabel" runat="server" Text='<%# Eval("PlantDesc") %>' /></h1>
                                        <p class="price">
                                            <asp:Label ID="PlantLabel" runat="server" Text='<%# Eval("Plant") %>' />
                                            &nbsp;&nbsp;<asp:Label ID="AbrevLabel" runat="server" Text='<%# Eval("Abrev") %>' />
                                            </p>
                                        <br />
                                            <p>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="cardbutton1">Select Plant - <%# Eval("Plant") %> </asp:LinkButton>
                                            </p>
                                            &nbsp;<br />
                                            </div>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                    </SeparatorTemplate>
                                </asp:DataList>
                                <br />
                                <asp:GridView ID="GridViewKioskDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSourceKioskByPlant" ForeColor="#333333" GridLines="None" Visible="False" Width="923px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="strKioskName" HeaderText="Kiosk" SortExpression="strKioskName" />
                                        <asp:BoundField DataField="fk_nDefaultKioskId" HeaderText="KioskId" />
                                        <asp:BoundField DataField="strPrinterName" HeaderText="Printer" SortExpression="strPrinterName" />
                                        <asp:BoundField DataField="strPrinterTypeName" HeaderText="Printer Type" SortExpression="strPrinterTypeName" />
                                        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                        <asp:BoundField DataField="Plant" HeaderText="Plant" SortExpression="Plant" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSourceKioskByPlant" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPlant" TypeName="CBWarehouseLabelPrint.DataSetKioskSelectionTableAdapters.KioskTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="LabelLocation" Name="Plant" PropertyName="Text" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                                <asp:ObjectDataSource ID="ObjectDataSourceLocations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.DataSetLocationsTableAdapters.PlantMasterTableAdapter"></asp:ObjectDataSource>
                                <asp:GridView ID="GridViewFullDataset" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="fk_nDefaultKioskId" DataSourceID="ObjectDataSourceFullDataset" ForeColor="#333333" GridLines="None" PageSize="25" Width="822px" Visible="False">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True" />
                                        <asp:BoundField DataField="strKioskName" HeaderText="Name" SortExpression="strKioskName" />
                                        <asp:BoundField DataField="fk_nDefaultKioskId" HeaderText="Kiosk" SortExpression="fk_nDefaultKioskId" />
                                        <asp:BoundField DataField="Description" HeaderText="Desc" SortExpression="Description" />
                                        <asp:BoundField DataField="fk_nPrinterId" HeaderText="PrinterId" SortExpression="fk_nPrinterId" />
                                        <asp:BoundField DataField="strPrinterName" HeaderText="PrinterName" SortExpression="strPrinterName" />
                                        <asp:TemplateField HeaderText="PrintType" SortExpression="fk_nPrinterTypeId">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fk_nPrinterTypeId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fk_nPrinterTypeId") %>'></asp:Label>
                                                <br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                            <td valign="top" rowspan="2">
                                <asp:Panel ID="PanelAddNewKiosk" runat="server">
                                    <table class="nav-justified" style="height: 257px; width: 110%;">
                                        <tr>
                                            <td colspan="4" style="height: 70px">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr BackColor="#507CD1">
                                                        <td  colspan="2" style="height: 20px">
                                                            <asp:Label ID="LabelCookie" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 154px">Kiosk Name</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxKiosk" runat="server" style="margin-right: 0" Width="186px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 154px">Kiosk ID</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxKioskId" runat="server" Width="189px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 154px">Host Name</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxHostName" runat="server" Width="187px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 154px">IP Address:</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxIP" runat="server" Width="188px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 129px; height: 70px">&nbsp;</td>
                                            <td style="width: 336px; height: 70px">&nbsp;</td>
                                            <td style="height: 70px">&nbsp;</td>
                                            <td style="height: 70px">
                                                <br />
                                                <asp:Button ID="ButtonAddKioskCookie" runat="server" class="btn btn-primary btn-lg" Text="Add Kiosk »" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 129px; height: 70px"></td>
                                            <td style="width: 336px; height: 70px">&nbsp;</td>
                                            <td style="height: 70px">&nbsp;</td>
                                            <td style="height: 70px">
                                                <asp:Button ID="ButtonAddNewSubmit" runat="server" class="btn btn-primary btn-lg" Text="Delete Kiosk" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 129px; height: 140px;">&nbsp;</td>
                                            <td style="width: 336px; height: 140px;"></td>
                                            <td style="height: 140px">&nbsp;</td>
                                            <td style="height: 140px">
                                                <asp:ListBox ID="ListBoxLine" runat="server" DataSourceID="ObjectDataSourceFullDataset" DataTextField="Line" DataValueField="Line" Visible="False"></asp:ListBox>
                                                <asp:ListBox ID="ListBoxPrinter" runat="server" DataSourceID="ObjectDataSourceFullDataset" DataTextField="strPrinterName" DataValueField="strPrinterName" Width="191px" Visible="False"></asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 129px">:</td>
                                            <td style="width: 336px">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                        </tr>
                    </table>
                    <asp:ObjectDataSource ID="ObjectDataSourceKioskServer" runat="server" DataObjectTypeName="System.Data.DataRow" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByKioskId" TypeName="CBWarehouseLabelPrint.DataSetKioskServerTableAdapters.KioskServerTableAdapter" UpdateMethod="Update">
                        <InsertParameters>
                            <asp:Parameter Name="pk_nKioskServerId" Type="Int32" />
                            <asp:Parameter Name="strKioskServerName" Type="String" />
                            <asp:Parameter Name="strComputerName" Type="String" />
                            <asp:Parameter Name="strIPAddress" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridViewFullDataset" Name="pk_nKioskServerId" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceKioskSelection" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.DataSetKioskSelectionTableAdapters.KioskTableAdapter"></asp:ObjectDataSource>
                    <br />
                    <asp:ObjectDataSource ID="ObjectDataSourceFullDataset" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.LineFullTableAdapters.FullDataSetTableAdapter"></asp:ObjectDataSource>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
     </asp:View>
    <asp:View ID="Tab2" runat="server">
        <table width="600px" height="400px" cellpadding=0 cellspacing=0>
            <tr valign="top">
                <td class="TabArea" style="width: 600px">
                    <br />
                    <asp:Panel ID="Panel4" runat="server">
                        <table class="nav-justified" style="width: 158%">
                            <tr>
                                <td style="width: 413px">
                                    <asp:GridView ID="GridViewErrors" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RecordId" DataSourceID="ObjectDataSourceError" ForeColor="#333333" GridLines="None" PageSize="25" Width="1032px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowCancelButton="False" ShowSelectButton="True" />
                                            <asp:BoundField DataField="EntryDateTime" HeaderText="Date" SortExpression="EntryDateTime" />
                                            <asp:BoundField DataField="ProdOrder" HeaderText="Order" SortExpression="ProdOrder" />
                                            <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
                                            <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                                            <asp:BoundField DataField="Format" HeaderText="Format" SortExpression="Format" />
                                            <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjectDataSourceErrorDetails" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByRecordId" TypeName="CB.WebLabel.Framework.DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter" UpdateMethod="Update">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Original_RecordId" Type="Int64" />
                                            <asp:Parameter Name="Original_Location" Type="String" />
                                            <asp:Parameter Name="Original_UserId" Type="String" />
                                            <asp:Parameter Name="Original_JobDesc" Type="String" />
                                            <asp:Parameter Name="Original_ProdDate" Type="DateTime" />
                                            <asp:Parameter Name="Original_Shift" Type="Int32" />
                                            <asp:Parameter Name="Original_Line" Type="Int32" />
                                            <asp:Parameter Name="Original_StartTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_EndTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_EntryDateTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_DownTimeMinutes" Type="Int32" />
                                            <asp:Parameter Name="Original_ReasonCode" Type="Int32" />
                                            <asp:Parameter Name="Original_Comment" Type="String" />
                                            <asp:Parameter Name="Original_MoreInfo" Type="String" />
                                            <asp:Parameter Name="Original_ProdOrder" Type="String" />
                                            <asp:Parameter Name="Original_Format" Type="String" />
                                            <asp:Parameter Name="Original_Source" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Location" Type="String" />
                                            <asp:Parameter Name="UserId" Type="String" />
                                            <asp:Parameter Name="JobDesc" Type="String" />
                                            <asp:Parameter Name="ProdDate" Type="DateTime" />
                                            <asp:Parameter Name="Shift" Type="Int32" />
                                            <asp:Parameter Name="Line" Type="Int32" />
                                            <asp:Parameter Name="StartTime" Type="DateTime" />
                                            <asp:Parameter Name="EndTime" Type="DateTime" />
                                            <asp:Parameter Name="EntryDateTime" Type="DateTime" />
                                            <asp:Parameter Name="DownTimeMinutes" Type="Int32" />
                                            <asp:Parameter Name="ReasonCode" Type="Int32" />
                                            <asp:Parameter Name="Comment" Type="String" />
                                            <asp:Parameter Name="MoreInfo" Type="String" />
                                            <asp:Parameter Name="ProdOrder" Type="String" />
                                            <asp:Parameter Name="Format" Type="String" />
                                            <asp:Parameter Name="Source" Type="String" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="GridViewErrors" Name="RecordId" PropertyName="SelectedValue" Type="Int64" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Location" Type="String" />
                                            <asp:Parameter Name="UserId" Type="String" />
                                            <asp:Parameter Name="JobDesc" Type="String" />
                                            <asp:Parameter Name="ProdDate" Type="DateTime" />
                                            <asp:Parameter Name="Shift" Type="Int32" />
                                            <asp:Parameter Name="Line" Type="Int32" />
                                            <asp:Parameter Name="StartTime" Type="DateTime" />
                                            <asp:Parameter Name="EndTime" Type="DateTime" />
                                            <asp:Parameter Name="EntryDateTime" Type="DateTime" />
                                            <asp:Parameter Name="DownTimeMinutes" Type="Int32" />
                                            <asp:Parameter Name="ReasonCode" Type="Int32" />
                                            <asp:Parameter Name="Comment" Type="String" />
                                            <asp:Parameter Name="MoreInfo" Type="String" />
                                            <asp:Parameter Name="ProdOrder" Type="String" />
                                            <asp:Parameter Name="Format" Type="String" />
                                            <asp:Parameter Name="Source" Type="String" />
                                            <asp:Parameter Name="Original_RecordId" Type="Int64" />
                                            <asp:Parameter Name="Original_Location" Type="String" />
                                            <asp:Parameter Name="Original_UserId" Type="String" />
                                            <asp:Parameter Name="Original_JobDesc" Type="String" />
                                            <asp:Parameter Name="Original_ProdDate" Type="DateTime" />
                                            <asp:Parameter Name="Original_Shift" Type="Int32" />
                                            <asp:Parameter Name="Original_Line" Type="Int32" />
                                            <asp:Parameter Name="Original_StartTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_EndTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_EntryDateTime" Type="DateTime" />
                                            <asp:Parameter Name="Original_DownTimeMinutes" Type="Int32" />
                                            <asp:Parameter Name="Original_ReasonCode" Type="Int32" />
                                            <asp:Parameter Name="Original_Comment" Type="String" />
                                            <asp:Parameter Name="Original_MoreInfo" Type="String" />
                                            <asp:Parameter Name="Original_ProdOrder" Type="String" />
                                            <asp:Parameter Name="Original_Format" Type="String" />
                                            <asp:Parameter Name="Original_Source" Type="String" />
                                        </UpdateParameters>
                                    </asp:ObjectDataSource>
                                    <br />
                                </td>
                                <td style="vertical-align: top">
                                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="RecordId" DataSourceID="ObjectDataSourceErrorDetails" GridLines="None" Height="50px" Width="366px" ForeColor="#333333">
                                        <AlternatingRowStyle BackColor="White" />
                                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                        <Fields>
                                            <asp:BoundField DataField="RecordId" HeaderText="RecordId" InsertVisible="False" ReadOnly="True" SortExpression="RecordId" />
                                            <asp:BoundField DataField="EntryDateTime" HeaderText="EntryDateTime" SortExpression="EntryDateTime" />
                                            <asp:BoundField DataField="ProdOrder" HeaderText="ProdOrder" SortExpression="ProdOrder" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                            <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
                                            <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                            <asp:BoundField DataField="Format" HeaderText="Format" SortExpression="Format" />
                                            <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
                                            <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
                                            <asp:BoundField DataField="MoreInfo" HeaderText="MoreInfo" SortExpression="MoreInfo" />
                                        </Fields>
                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                    </asp:DetailsView>
                                    <br />
                                    <asp:Label ID="LabelErrorMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:ObjectDataSource ID="ObjectDataSourceError" runat="server" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CB.WebLabel.Framework.DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_RecordId" Type="Int64" />
                            <asp:Parameter Name="Original_Location" Type="String" />
                            <asp:Parameter Name="Original_UserId" Type="String" />
                            <asp:Parameter Name="Original_JobDesc" Type="String" />
                            <asp:Parameter Name="Original_ProdDate" Type="DateTime" />
                            <asp:Parameter Name="Original_Shift" Type="Int32" />
                            <asp:Parameter Name="Original_Line" Type="Int32" />
                            <asp:Parameter Name="Original_StartTime" Type="DateTime" />
                            <asp:Parameter Name="Original_EndTime" Type="DateTime" />
                            <asp:Parameter Name="Original_EntryDateTime" Type="DateTime" />
                            <asp:Parameter Name="Original_DownTimeMinutes" Type="Int32" />
                            <asp:Parameter Name="Original_ReasonCode" Type="Int32" />
                            <asp:Parameter Name="Original_Comment" Type="String" />
                            <asp:Parameter Name="Original_MoreInfo" Type="String" />
                            <asp:Parameter Name="Original_ProdOrder" Type="String" />
                            <asp:Parameter Name="Original_Format" Type="String" />
                            <asp:Parameter Name="Original_Source" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Location" Type="String" />
                            <asp:Parameter Name="UserId" Type="String" />
                            <asp:Parameter Name="JobDesc" Type="String" />
                            <asp:Parameter Name="ProdDate" Type="DateTime" />
                            <asp:Parameter Name="Shift" Type="Int32" />
                            <asp:Parameter Name="Line" Type="Int32" />
                            <asp:Parameter Name="StartTime" Type="DateTime" />
                            <asp:Parameter Name="EndTime" Type="DateTime" />
                            <asp:Parameter Name="EntryDateTime" Type="DateTime" />
                            <asp:Parameter Name="DownTimeMinutes" Type="Int32" />
                            <asp:Parameter Name="ReasonCode" Type="Int32" />
                            <asp:Parameter Name="Comment" Type="String" />
                            <asp:Parameter Name="MoreInfo" Type="String" />
                            <asp:Parameter Name="ProdOrder" Type="String" />
                            <asp:Parameter Name="Format" Type="String" />
                            <asp:Parameter Name="Source" Type="String" />
                            <asp:Parameter Name="Original_RecordId" Type="Int64" />
                            <asp:Parameter Name="Original_Location" Type="String" />
                            <asp:Parameter Name="Original_UserId" Type="String" />
                            <asp:Parameter Name="Original_JobDesc" Type="String" />
                            <asp:Parameter Name="Original_ProdDate" Type="DateTime" />
                            <asp:Parameter Name="Original_Shift" Type="Int32" />
                            <asp:Parameter Name="Original_Line" Type="Int32" />
                            <asp:Parameter Name="Original_StartTime" Type="DateTime" />
                            <asp:Parameter Name="Original_EndTime" Type="DateTime" />
                            <asp:Parameter Name="Original_EntryDateTime" Type="DateTime" />
                            <asp:Parameter Name="Original_DownTimeMinutes" Type="Int32" />
                            <asp:Parameter Name="Original_ReasonCode" Type="Int32" />
                            <asp:Parameter Name="Original_Comment" Type="String" />
                            <asp:Parameter Name="Original_MoreInfo" Type="String" />
                            <asp:Parameter Name="Original_ProdOrder" Type="String" />
                            <asp:Parameter Name="Original_Format" Type="String" />
                            <asp:Parameter Name="Original_Source" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <br />
                    <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                        <asp:BulletedList ID="BulletedListLog" runat="server">
                        </asp:BulletedList>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Tab3" runat="server">
        <table height="400px" cellpadding=0 cellspacing=0 style="width: 1214px">
            <tr valign="top">
                <td class="TabArea" style="width: 600px">
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Width="475px">
                        File Folders<br />
                        <asp:BulletedList ID="BulletedListFolders" runat="server" BulletImageUrl="~/Content/Images/Yes.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                        <asp:BulletedList ID="BulletedListFoldersStopped" runat="server" BulletImageUrl="~/Content/Images/no.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Width="475px">
                        License and Services<br />
                        <asp:BulletedList ID="BulletedListServices" runat="server" BulletImageUrl="~/Content/Images/Yes.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                        <asp:BulletedList ID="BulletedListServicesStopped" runat="server" BulletImageUrl="~/Content/Images/no.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                    </asp:Panel>
                    <br />
                     <asp:Panel ID="PanelPrintList" runat="server" BorderStyle="Solid" Width="475px">
                        Printers<br />
                        <asp:BulletedList ID="BulletedListPrinters" runat="server" BulletImageUrl="~/Content/Images/Yes.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                        <asp:BulletedList ID="BulletedListPrintersMissing" runat="server" BulletImageUrl="~/Content/Images/no.png" BulletStyle="CustomImage" Font-Size="Large">
                        </asp:BulletedList>
                    </asp:Panel>
                </td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="Existing Label Formats in documents folder" DataSourceID="ObjectDataSourceImages" Width="529px" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Medium">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:ImageField DataAlternateTextField="DisplayName" DataImageUrlField="ThumbnailRelativePath">
                                <ItemStyle Height="100px" Width="100px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="DisplayName" HeaderText="Format" SortExpression="DisplayName" />
                            <asp:BoundField DataField="FullPath" HeaderText="Path" SortExpression="FullPath" Visible="False" />
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
                    <asp:ObjectDataSource ID="ObjectDataSourceImages" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GenerateDocumentsList" TypeName="CBLabelPrinterBLL.CB.Bartender.Models.WebLabelPrintDocument"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </asp:View>
        <asp:View ID="View1" runat="server">
            Audit Trail<br />
            <table class="nav-justified">
                <tr valign="top">
                    <td style="width: 757px">
                        <asp:GridView ID="GridViewAudit" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RecordID" DataSourceID="ObjectDataSourceAudit" ForeColor="#333333" GridLines="None" Width="800px" Font-Size="Medium" PageSize="25">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="EntryDateTime" HeaderText="Entry" SortExpression="EntryDateTime" />
                                <asp:BoundField DataField="MfgOrderNumber" HeaderText="Order" SortExpression="MfgOrderNumber" />
                                <asp:BoundField DataField="Bin" HeaderText="Bin" SortExpression="Bin" />
                                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
                                <asp:BoundField DataField="Quantity" HeaderText="Qty" SortExpression="Quantity" />
                                <asp:BoundField DataField="RecordID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="RecordID" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:DataList ID="DataListAuditDetails" runat="server" DataSourceID="ObjectDataSourceAuditDetails" HorizontalAlign="Left" Width="554px">
                            <ItemTemplate>
                                <h2> <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProductDesc") %>' />
                                    &nbsp;</h2>
                                <h2>Order#:
                                    <asp:Label ID="MfgOrderNumberLabel" runat="server" Text='<%# Eval("MfgOrderNumber") %>' />
                                    <br />
                                </h2>
                                <p class="price"><asp:Label ID="SizeLabel" runat="server" Text='<%# Eval("Size") %>' />
                                    &nbsp;created on line <asp:Label ID="LineLabel" runat="server" Text='<%# Eval("Line") %>' />
                                    &nbsp;shift <asp:Label ID="ShiftLabel" runat="server" Text='<%# Eval("Shift") %>' />
                                   

                                </p>
                                <div>
                                    
                                <p class="price">Bin:<asp:Label ID="BinLabel2" runat="server" Text='<%# Eval("Bin") %>' /></p>
                               <p class="price">Date: <asp:Label ID="EntryDateTimeLabel" runat="server" Text='<%# Eval("EntryDateTime") %>' /></p>
                     </div>
                              <div align="center">
                                <div>
                                    RecordID:
                                <asp:Label ID="RecordIDLabel" runat="server" Text='<%# Eval("RecordID") %>' />
                                <br />
                                Location:
                                <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("Location") %>' />
                                <br />
                                Bin:
                                <asp:Label ID="BinLabel" runat="server" Text='<%# Eval("Bin") %>' />
                                <br />                              
                                Quantity:
                                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                <br />
                                FormatName:
                                <asp:Label ID="FormatNameLabel" runat="server" Text='<%# Eval("FormatName") %>' />
                                    <br />
                                    PackageQty:
                                    <asp:Label ID="PackageQtyLabel" runat="server" Text='<%# Eval("PackageQty") %>' />
                                    <br />
                                    PriceCode:
                                    <asp:Label ID="PriceCodeLabel" runat="server" Text='<%# Eval("PriceCode") %>' />
                                    <br />
                                    CodeDate:
                                    <asp:Label ID="CodeDateLabel" runat="server" Text='<%# Eval("CodeDate") %>' />
                                <br />
                                ProcByRecall:
                                <asp:Label ID="ProcByRecallLabel" runat="server" Text='<%# Eval("ProcByRecall") %>' />
                                <br />
                                TxID:
                                <asp:Label ID="TxIDLabel" runat="server" Text='<%# Eval("TxID") %>' />
                                <br />
                                TxDateTime:
                                <asp:Label ID="TxDateTimeLabel" runat="server" Text='<%# Eval("TxDateTime") %>' />
                               
                                <br />
                                    MeatCode:
                                    <asp:Label ID="MeatCodeLabel" runat="server" Text='<%# Eval("MeatCode") %>' />
                                    <br />
                                    SpecialPack:
                                <asp:Label ID="SpecialPackLabel" runat="server" Text='<%# Eval("SpecialPack") %>' />
                                <br />
                                    PackDesc:
                                    <asp:Label ID="PackDescLabel" runat="server" Text='<%# Eval("PackDesc") %>' />
                                    <br />
                                    MoreInfo:
                                    <asp:Label ID="MoreInfoLabel" runat="server" Text='<%# Eval("MoreInfo") %>' />
                                <br />
                                <br />
                                </div>
                               </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:ObjectDataSource ID="ObjectDataSourceAudit" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CB.WebLabel.Framework.DataSetAuditTableAdapters.ProductionLineNewTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceAuditDetails" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByRecordId" TypeName="CB.WebLabel.Framework.DataSetAuditTableAdapters.ProductionLineNewTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridViewAudit" Name="RecordID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:View>
        <asp:View runat="server" ID="viewMain">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
        </asp:View>
</asp:MultiView>
        </div>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 155px; width: 613px; vertical-align: top;">
                    &nbsp;</td>
                <td rowspan="3" style="font-size: medium; vertical-align: top;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 53px; width: 613px; vertical-align: top;">
                </td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 613px">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    e</p>
<p>
        Run Check up&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Checkup" />
    </p>
    <p>
        &nbsp;</p>
    <br />
    <br />
    <br />



    </form>
</body>
</html>
  