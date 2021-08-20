<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CBWarehouseLabelPrintWeb._Default" %>

<%@ Register src="Controls/Keypad.ascx" tagname="Keypad" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Error in Production Process Monitor</h1>
        <p class="lead" style="color: #FF0000">NO KIOSK FOUND. 
        </p>
        <p class="lead">You are here because the kiosk your using is has not been configured.
        </p>
        <table class="nav-justified">
            <tr>
                <td style="width: 124px">Computer Name:</td>
                <td>
            <asp:Label ID="LabelComputerName" runat="server" Text="Compter Name"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 124px">IP Address:</td>
                <td>
            <asp:Label ID="LabelIP" runat="server" Text="IPAddress"></asp:Label>
                </td>
            </tr>
        </table>
        <p class="lead">&nbsp;&nbsp;</p>
        <p class="lead">Contact your Supervisor because
            <asp:Label ID="LabelKioskName" runat="server" Text="Defaul Kiosk"></asp:Label>
        </p>
        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 191px"><a href="Admin.aspx" class="btn btn-primary btn-lg">Admin Setup &raquo;

           </a>
                </td>
                <td>
                &nbsp;
                <asp:Button ID="ButtonAddKiosk" class="btn btn-primary btn-lg" runat="server" Text="Add New Kiosk &raquo;" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonAddKioskCookie" class="btn btn-primary btn-lg" runat="server" Text="Add Kiosk Cookie »" Visible="False" />
                </td>
            </tr>
        </table>
    </div>
    <div>

            <asp:Panel ID="PanelAddNewKiosk" runat="server" Visible="False">
                <table class="nav-justified">
                    <tr>
                        <td style="height: 70px" colspan="4">
                            <h2>Create new Kiosk </h2>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 129px; height: 70px">Kiosk Name</td>
                        <td style="width: 357px; height: 70px">
                            <asp:TextBox ID="TextBoxKiosk" runat="server" Width="229px"></asp:TextBox>
                        </td>
                        <td style="height: 70px">Printer:</td>
                        <td style="height: 70px">
                            <asp:ListBox ID="ListBoxPrinter" runat="server" DataSourceID="ObjectDataSourceFullDataset" DataTextField="fk_nPrinterId" DataValueField="strPrinterName" Width="191px"></asp:ListBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 129px">Computer Name:</td>
                        <td style="width: 357px">
                            <asp:TextBox ID="TextBoxHostName" runat="server" Width="226px"></asp:TextBox>
                        </td>
                        <td>Line:</td>
                        <td>
                            <asp:ListBox ID="ListBoxLine" runat="server" DataSourceID="ObjectDataSourceFullDataset" DataTextField="Line" DataValueField="Line"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 129px">IP Address:</td>
                        <td style="width: 357px">
                            <asp:TextBox ID="TextBoxIP" runat="server" Width="227px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonAddNewSubmit" runat="server" CssClass="btn-default active focus" Text="Submit" />
                        </td>
                    </tr>
                </table>
                <div>
                    here
                    <br />
                    <div class="col-md-4" style="left: 0px; top: 20px">
                        <h2>Select Kiosk, Line and printer to use</h2>
                        <p>
                            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model. A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                        </p>
                        <p>
                        </p>
                        <p>
                            &nbsp;</p>
                        <p>
                            <asp:GridView ID="GridViewFullDataset" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSourceFullDataset" ForeColor="#333333" GridLines="None" PageSize="25" Width="1032px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" ShowInsertButton="True" ShowSelectButton="True" />
                                    <asp:BoundField DataField="strKioskName" HeaderText="Name" SortExpression="strKioskName" />
                                    <asp:BoundField DataField="fk_nDefaultKioskId" HeaderText="Kiosk" SortExpression="fk_nDefaultKioskId" />
                                    <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" />
                                    <asp:BoundField DataField="Description" HeaderText="Desc" SortExpression="Description" />
                                    <asp:BoundField DataField="fk_nPrinterId" HeaderText="PrinterId" SortExpression="fk_nPrinterId" />
                                    <asp:BoundField DataField="strPrinterName" HeaderText="PrinterName" SortExpression="strPrinterName" />
                                    <asp:BoundField DataField="strIPAddress" HeaderText="IPAddress" SortExpression="strIPAddress" />
                                    <asp:BoundField DataField="fk_nPrinterTypeId" HeaderText="PrintType" SortExpression="fk_nPrinterTypeId" />
                                    <asp:BoundField DataField="computerName" HeaderText="HostName" SortExpression="computerName" />
                                    <asp:BoundField DataField="computerIP" HeaderText="HostIP" SortExpression="computerIP" />
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
                            <asp:ObjectDataSource ID="ObjectDataSourceFullDataset" runat="server" DataObjectTypeName="CBWarehouseLabelPrint.LineFull+FullDataSetDataTable" DeleteMethod="Fill" InsertMethod="Fill" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBWarehouseLabelPrint.LineFullTableAdapters.FullDataSetTableAdapter" UpdateMethod="Fill"></asp:ObjectDataSource>
                        </p>
                    </div>
                </div>
            </asp:Panel>

    </div>
    <div class="row">
        <div class="col-md-4">
            <p></h2>
            <p>
            &nbsp;</p>
        </div>
        
    </div>

</asp:Content>
