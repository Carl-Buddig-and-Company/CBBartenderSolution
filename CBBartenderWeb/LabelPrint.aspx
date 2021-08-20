<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LabelPrint.aspx.vb" Inherits="CBBartenderWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Your contact page.</p>
    <table __designer:mapid="19" class="nav-justified">
        <tr __designer:mapid="1a">
            <td __designer:mapid="1b" style="width: 490px">&nbsp;</td>
            <td __designer:mapid="1c" style="width: 48px">&nbsp;</td>
            <td __designer:mapid="1d">&nbsp;</td>
        </tr>
        <tr __designer:mapid="1e">
            <td __designer:mapid="1f" style="width: 490px">
    <asp:Panel ID="Panel1" runat="server" Height="147px" Width="474px">
        <asp:ListView ID="lstLabelBrowser" runat="server">
        </asp:ListView>
    </asp:Panel>
            </td>
            <td __designer:mapid="20" style="width: 48px">&nbsp;</td>
            <td __designer:mapid="21">
        <asp:Panel ID="Panel2" runat="server" Height="141px" Width="716px">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
            </td>
        </tr>
        <tr __designer:mapid="22">
            <td __designer:mapid="23" style="width: 490px">&nbsp;</td>
            <td __designer:mapid="24" style="width: 48px">&nbsp;</td>
            <td __designer:mapid="25">&nbsp;</td>
        </tr>
        <tr __designer:mapid="26">
            <td __designer:mapid="27" style="width: 490px">&nbsp;</td>
            <td __designer:mapid="28" style="width: 48px">&nbsp;</td>
            <td __designer:mapid="29">Printer List&nbsp;&nbsp; <asp:DropDownList ID="DropDownListPrinters" runat="server" DataSourceID="ObjectDataSourcePrinterList" DataTextField="PrinterName" DataValueField="PrinterName">
</asp:DropDownList>

                <asp:ObjectDataSource ID="ObjectDataSourcePrinterList" runat="server" SelectMethod="GetServerPrinters" TypeName="CBLabelPrinterBLL.CB.Bartender.Models.ServerPrinterInfo"></asp:ObjectDataSource>

            </td>
        </tr>
    </table>
                
    <br />
    <br />
    <br />
    <br />

    <br />
    <br />
    <br />
    <br />
    <br />

    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>
    <address>

        <strong>Support:</strong><a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
