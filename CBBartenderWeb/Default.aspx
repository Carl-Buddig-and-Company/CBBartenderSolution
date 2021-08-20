<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CBBartenderWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Buddig Web Label Print</h1>
        <p class="lead">This uses bartender label print API and custom code to provide a way to see lines for a given kiosk, then the work orders for that line and print the labels for each pan.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a>
            <asp:Button ID="Button1" runat="server" Text="Print Labels" />
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Kiosk / Station Selection UI</h2>
            <p>
                Design an interface that provides easy selection of kiosk/station. User could save his preference so default kiosk/line master selection is made, then also can select other kiosk if needed.
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:ListBox ID="ListBox1" runat="server">
                    <asp:ListItem>Kiosk 14</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>Kiosk 13</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:ListBox>
&nbsp;
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Login to Kiosk &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Line Master</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Line" DataSourceID="ObjectDataSourceLineMaster" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Line" HeaderText="Line" ReadOnly="True" SortExpression="Line" />
                        <asp:BoundField DataField="Impressions" HeaderText="Impressions" SortExpression="Impressions" />
                        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                        <asp:BoundField DataField="LineType" HeaderText="LineType" SortExpression="LineType" />
                        <asp:BoundField DataField="Plant" HeaderText="Plant" SortExpression="Plant" />
                        <asp:BoundField DataField="Active" HeaderText="Active" SortExpression="Active" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="StdPackers" HeaderText="StdPackers" SortExpression="StdPackers" />
                        <asp:BoundField DataField="StdOperators" HeaderText="StdOperators" SortExpression="StdOperators" />
                        <asp:BoundField DataField="LineGroup" HeaderText="LineGroup" SortExpression="LineGroup" />
                        <asp:BoundField DataField="PhysLine" HeaderText="PhysLine" SortExpression="PhysLine" />
                        <asp:BoundField DataField="Repack" HeaderText="Repack" SortExpression="Repack" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                        <asp:BoundField DataField="MaintTest" HeaderText="MaintTest" SortExpression="MaintTest" />
                        <asp:BoundField DataField="Slicer" HeaderText="Slicer" SortExpression="Slicer" />
                        <asp:BoundField DataField="ShiftGroup" HeaderText="ShiftGroup" SortExpression="ShiftGroup" />
                        <asp:BoundField DataField="fk_nPrinterId" HeaderText="fk_nPrinterId" SortExpression="fk_nPrinterId" />
                        <asp:BoundField DataField="fk_nDefaultKioskId" HeaderText="fk_nDefaultKioskId" SortExpression="fk_nDefaultKioskId" />
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
                <asp:ObjectDataSource ID="ObjectDataSourceLineMaster" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBLabelPrinterBLL.DataSetLineMasterTableAdapters.LineMasterTableAdapter" UpdateMethod="Update">
                    <UpdateParameters>
                        <asp:Parameter Name="Impressions" Type="Int32" />
                        <asp:Parameter Name="StdLbsHour" Type="Double" />
                        <asp:Parameter Name="Location" Type="String" />
                        <asp:Parameter Name="LineType" Type="Int32" />
                        <asp:Parameter Name="Plant" Type="Int32" />
                        <asp:Parameter Name="Active" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="StdPackers" Type="Decimal" />
                        <asp:Parameter Name="StdOperators" Type="Decimal" />
                        <asp:Parameter Name="LineGroup" Type="Int32" />
                        <asp:Parameter Name="PhysLine" Type="String" />
                        <asp:Parameter Name="Repack" Type="String" />
                        <asp:Parameter Name="StartDate" Type="DateTime" />
                        <asp:Parameter Name="EndDate" Type="DateTime" />
                        <asp:Parameter Name="MaintTest" Type="String" />
                        <asp:Parameter Name="Slicer" Type="Int32" />
                        <asp:Parameter Name="ShiftGroup" Type="Int32" />
                        <asp:Parameter Name="fk_nPrinterId" Type="Int32" />
                        <asp:Parameter Name="fk_nDefaultKioskId" Type="Int32" />
                        <asp:Parameter Name="Original_Line" Type="Int32" />
                        <asp:Parameter Name="Original_Impressions" Type="Int32" />
                        <asp:Parameter Name="Original_StdLbsHour" Type="Double" />
                        <asp:Parameter Name="Original_Location" Type="String" />
                        <asp:Parameter Name="Original_LineType" Type="Int32" />
                        <asp:Parameter Name="Original_Plant" Type="Int32" />
                        <asp:Parameter Name="Original_Active" Type="String" />
                        <asp:Parameter Name="Original_Description" Type="String" />
                        <asp:Parameter Name="Original_StdPackers" Type="Decimal" />
                        <asp:Parameter Name="Original_StdOperators" Type="Decimal" />
                        <asp:Parameter Name="Original_LineGroup" Type="Int32" />
                        <asp:Parameter Name="Original_PhysLine" Type="String" />
                        <asp:Parameter Name="Original_Repack" Type="String" />
                        <asp:Parameter Name="Original_StartDate" Type="DateTime" />
                        <asp:Parameter Name="Original_EndDate" Type="DateTime" />
                        <asp:Parameter Name="Original_MaintTest" Type="String" />
                        <asp:Parameter Name="Original_Slicer" Type="Int32" />
                        <asp:Parameter Name="Original_ShiftGroup" Type="Int32" />
                        <asp:Parameter Name="Original_fk_nPrinterId" Type="Int32" />
                        <asp:Parameter Name="Original_fk_nDefaultKioskId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Production Orders</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MfgOrdNumber,Shift#,Line#,Date Produced" DataSourceID="ObjectDataSourceProductionOrders" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Company Number" HeaderText="Company Number" SortExpression="Company Number" />
                        <asp:BoundField DataField="MfgOrdNumber" HeaderText="MfgOrdNumber" ReadOnly="True" SortExpression="MfgOrdNumber" />
                        <asp:BoundField DataField="Meat Code" HeaderText="Meat Code" SortExpression="Meat Code" />
                        <asp:BoundField DataField="Package Qty" HeaderText="Package Qty" SortExpression="Package Qty" />
                        <asp:BoundField DataField="Special Pack" HeaderText="Special Pack" SortExpression="Special Pack" />
                        <asp:BoundField DataField="Price Code" HeaderText="Price Code" SortExpression="Price Code" />
                        <asp:BoundField DataField="Code Date" HeaderText="Code Date" SortExpression="Code Date" />
                        <asp:BoundField DataField="Shift#" HeaderText="Shift#" ReadOnly="True" SortExpression="Shift#" />
                        <asp:BoundField DataField="Line#" HeaderText="Line#" ReadOnly="True" SortExpression="Line#" />
                        <asp:BoundField DataField="Date Produced" HeaderText="Date Produced" ReadOnly="True" SortExpression="Date Produced" />
                        <asp:BoundField DataField="Vendor UPC #" HeaderText="Vendor UPC #" SortExpression="Vendor UPC #" />
                        <asp:BoundField DataField="Item UPC #" HeaderText="Item UPC #" SortExpression="Item UPC #" />
                        <asp:BoundField DataField="Product Description" HeaderText="Product Description" SortExpression="Product Description" />
                        <asp:BoundField DataField="Product #" HeaderText="Product #" SortExpression="Product #" />
                        <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                        <asp:BoundField DataField="Format Name" HeaderText="Format Name" SortExpression="Format Name" />
                        <asp:BoundField DataField="PackDesc" HeaderText="PackDesc" SortExpression="PackDesc" />
                        <asp:BoundField DataField="ProductionComment" HeaderText="ProductionComment" SortExpression="ProductionComment" />
                        <asp:BoundField DataField="PrivateLabel" HeaderText="PrivateLabel" SortExpression="PrivateLabel" />
                        <asp:BoundField DataField="Funny Date" HeaderText="Funny Date" SortExpression="Funny Date" />
                        <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                        <asp:BoundField DataField="DateInFile" HeaderText="DateInFile" SortExpression="DateInFile" />
                        <asp:BoundField DataField="ProductNo" HeaderText="ProductNo" SortExpression="ProductNo" />
                        <asp:BoundField DataField="GTIN" HeaderText="GTIN" SortExpression="GTIN" />
                        <asp:BoundField DataField="Processed" HeaderText="Processed" SortExpression="Processed" />
                        <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                        <asp:BoundField DataField="OrderLineNo" HeaderText="OrderLineNo" SortExpression="OrderLineNo" />
                        <asp:BoundField DataField="MOQUANA" HeaderText="MOQUANA" SortExpression="MOQUANA" />
                        <asp:BoundField DataField="KioskUpdate" HeaderText="KioskUpdate" SortExpression="KioskUpdate" />
                        <asp:BoundField DataField="PackedOnDate" HeaderText="PackedOnDate" SortExpression="PackedOnDate" />
                        <asp:BoundField DataField="SchedDate" HeaderText="SchedDate" SortExpression="SchedDate" />
                        <asp:BoundField DataField="Pounds" HeaderText="Pounds" SortExpression="Pounds" />
                        <asp:BoundField DataField="CanadaCert" HeaderText="CanadaCert" SortExpression="CanadaCert" />
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
                <asp:ObjectDataSource ID="ObjectDataSourceProductionOrders" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CBLabelPrinterBLL.DataSetProdTicketsTableAdapters.Production_TicketsTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_Company_Number" Type="String" />
                        <asp:Parameter Name="Original_MfgOrdNumber" Type="Int32" />
                        <asp:Parameter Name="Original_Meat_Code" Type="String" />
                        <asp:Parameter Name="Original_Package_Qty" Type="String" />
                        <asp:Parameter Name="Original_Special_Pack" Type="String" />
                        <asp:Parameter Name="Original_Price_Code" Type="String" />
                        <asp:Parameter Name="Original_Code_Date" Type="String" />
                        <asp:Parameter Name="_Original_Shift_" Type="String" />
                        <asp:Parameter Name="_Original_Line_" Type="Int32" />
                        <asp:Parameter Name="Original_Date_Produced" Type="String" />
                        <asp:Parameter Name="_Original_Vendor_UPC__" Type="String" />
                        <asp:Parameter Name="_Original_Item_UPC__" Type="String" />
                        <asp:Parameter Name="Original_Product_Description" Type="String" />
                        <asp:Parameter Name="_Original_Product__" Type="Int32" />
                        <asp:Parameter Name="Original_Version" Type="Int32" />
                        <asp:Parameter Name="Original_Format_Name" Type="String" />
                        <asp:Parameter Name="Original_PackDesc" Type="String" />
                        <asp:Parameter Name="Original_ProductionComment" Type="String" />
                        <asp:Parameter Name="Original_PrivateLabel" Type="String" />
                        <asp:Parameter Name="Original_Funny_Date" Type="String" />
                        <asp:Parameter Name="Original_Size" Type="String" />
                        <asp:Parameter Name="Original_DateInFile" Type="DateTime" />
                        <asp:Parameter Name="Original_ProductNo" Type="String" />
                        <asp:Parameter Name="Original_GTIN" Type="String" />
                        <asp:Parameter Name="Original_Processed" Type="String" />
                        <asp:Parameter Name="Original_OrderID" Type="Int64" />
                        <asp:Parameter Name="Original_OrderLineNo" Type="Int32" />
                        <asp:Parameter Name="Original_MOQUANA" Type="Int32" />
                        <asp:Parameter Name="Original_KioskUpdate" Type="String" />
                        <asp:Parameter Name="Original_PackedOnDate" Type="String" />
                        <asp:Parameter Name="Original_SchedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_Pounds" Type="Decimal" />
                        <asp:Parameter Name="Original_CanadaCert" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Company_Number" Type="String" />
                        <asp:Parameter Name="MfgOrdNumber" Type="Int32" />
                        <asp:Parameter Name="Meat_Code" Type="String" />
                        <asp:Parameter Name="Package_Qty" Type="String" />
                        <asp:Parameter Name="Special_Pack" Type="String" />
                        <asp:Parameter Name="Price_Code" Type="String" />
                        <asp:Parameter Name="Code_Date" Type="String" />
                        <asp:Parameter Name="_Shift_" Type="String" />
                        <asp:Parameter Name="_Line_" Type="Int32" />
                        <asp:Parameter Name="Date_Produced" Type="String" />
                        <asp:Parameter Name="_Vendor_UPC__" Type="String" />
                        <asp:Parameter Name="_Item_UPC__" Type="String" />
                        <asp:Parameter Name="Product_Description" Type="String" />
                        <asp:Parameter Name="_Product__" Type="Int32" />
                        <asp:Parameter Name="Version" Type="Int32" />
                        <asp:Parameter Name="Format_Name" Type="String" />
                        <asp:Parameter Name="PackDesc" Type="String" />
                        <asp:Parameter Name="ProductionComment" Type="String" />
                        <asp:Parameter Name="PrivateLabel" Type="String" />
                        <asp:Parameter Name="Funny_Date" Type="String" />
                        <asp:Parameter Name="Size" Type="String" />
                        <asp:Parameter Name="DateInFile" Type="DateTime" />
                        <asp:Parameter Name="ProductNo" Type="String" />
                        <asp:Parameter Name="GTIN" Type="String" />
                        <asp:Parameter Name="Processed" Type="String" />
                        <asp:Parameter Name="OrderID" Type="Int64" />
                        <asp:Parameter Name="OrderLineNo" Type="Int32" />
                        <asp:Parameter Name="MOQUANA" Type="Int32" />
                        <asp:Parameter Name="KioskUpdate" Type="String" />
                        <asp:Parameter Name="PackedOnDate" Type="String" />
                        <asp:Parameter Name="SchedDate" Type="DateTime" />
                        <asp:Parameter Name="Pounds" Type="Decimal" />
                        <asp:Parameter Name="CanadaCert" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Company_Number" Type="String" />
                        <asp:Parameter Name="Meat_Code" Type="String" />
                        <asp:Parameter Name="Package_Qty" Type="String" />
                        <asp:Parameter Name="Special_Pack" Type="String" />
                        <asp:Parameter Name="Price_Code" Type="String" />
                        <asp:Parameter Name="Code_Date" Type="String" />
                        <asp:Parameter Name="_Vendor_UPC__" Type="String" />
                        <asp:Parameter Name="_Item_UPC__" Type="String" />
                        <asp:Parameter Name="Product_Description" Type="String" />
                        <asp:Parameter Name="_Product__" Type="Int32" />
                        <asp:Parameter Name="Version" Type="Int32" />
                        <asp:Parameter Name="Format_Name" Type="String" />
                        <asp:Parameter Name="PackDesc" Type="String" />
                        <asp:Parameter Name="ProductionComment" Type="String" />
                        <asp:Parameter Name="PrivateLabel" Type="String" />
                        <asp:Parameter Name="Funny_Date" Type="String" />
                        <asp:Parameter Name="Size" Type="String" />
                        <asp:Parameter Name="DateInFile" Type="DateTime" />
                        <asp:Parameter Name="ProductNo" Type="String" />
                        <asp:Parameter Name="GTIN" Type="String" />
                        <asp:Parameter Name="Processed" Type="String" />
                        <asp:Parameter Name="OrderID" Type="Int64" />
                        <asp:Parameter Name="OrderLineNo" Type="Int32" />
                        <asp:Parameter Name="MOQUANA" Type="Int32" />
                        <asp:Parameter Name="KioskUpdate" Type="String" />
                        <asp:Parameter Name="PackedOnDate" Type="String" />
                        <asp:Parameter Name="SchedDate" Type="DateTime" />
                        <asp:Parameter Name="Pounds" Type="Decimal" />
                        <asp:Parameter Name="CanadaCert" Type="String" />
                        <asp:Parameter Name="Original_Company_Number" Type="String" />
                        <asp:Parameter Name="Original_MfgOrdNumber" Type="Int32" />
                        <asp:Parameter Name="Original_Meat_Code" Type="String" />
                        <asp:Parameter Name="Original_Package_Qty" Type="String" />
                        <asp:Parameter Name="Original_Special_Pack" Type="String" />
                        <asp:Parameter Name="Original_Price_Code" Type="String" />
                        <asp:Parameter Name="Original_Code_Date" Type="String" />
                        <asp:Parameter Name="_Original_Shift_" Type="String" />
                        <asp:Parameter Name="_Original_Line_" Type="Int32" />
                        <asp:Parameter Name="Original_Date_Produced" Type="String" />
                        <asp:Parameter Name="_Original_Vendor_UPC__" Type="String" />
                        <asp:Parameter Name="_Original_Item_UPC__" Type="String" />
                        <asp:Parameter Name="Original_Product_Description" Type="String" />
                        <asp:Parameter Name="_Original_Product__" Type="Int32" />
                        <asp:Parameter Name="Original_Version" Type="Int32" />
                        <asp:Parameter Name="Original_Format_Name" Type="String" />
                        <asp:Parameter Name="Original_PackDesc" Type="String" />
                        <asp:Parameter Name="Original_ProductionComment" Type="String" />
                        <asp:Parameter Name="Original_PrivateLabel" Type="String" />
                        <asp:Parameter Name="Original_Funny_Date" Type="String" />
                        <asp:Parameter Name="Original_Size" Type="String" />
                        <asp:Parameter Name="Original_DateInFile" Type="DateTime" />
                        <asp:Parameter Name="Original_ProductNo" Type="String" />
                        <asp:Parameter Name="Original_GTIN" Type="String" />
                        <asp:Parameter Name="Original_Processed" Type="String" />
                        <asp:Parameter Name="Original_OrderID" Type="Int64" />
                        <asp:Parameter Name="Original_OrderLineNo" Type="Int32" />
                        <asp:Parameter Name="Original_MOQUANA" Type="Int32" />
                        <asp:Parameter Name="Original_KioskUpdate" Type="String" />
                        <asp:Parameter Name="Original_PackedOnDate" Type="String" />
                        <asp:Parameter Name="Original_SchedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_Pounds" Type="Decimal" />
                        <asp:Parameter Name="Original_CanadaCert" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
