<%@ Page Title="" Language="vb" EnableSessionState="True" Async="true" AutoEventWireup="false" CodeBehind="LabelPrint.aspx.vb" Inherits="CBWarehouseLabelPrintWeb.LabelPrint" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %>- Buddig Warehouse Label Print</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

 

    <style resource="/Content/ProcessMonitor.css" type="text/css">
        /* Style the Image Used to Trigger the Modal */
#myImg {
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

#myImg:hover {opacity: 0.7;}

/*The print loadinig messages modal*/
.loading
{
    font-family: Arial;
    font-size: 10pt;
    border: 5px solid #1C6EA4;
    border-radius: 32px;
    width: 400px;
    height: 400px;
    display: none;
    position: relative;
    background-color: White;
    z-index: 999;
    left:5%;
    top: 10%;
}
    
.loader {
  border: 16px solid #f3f3f3; /* Light grey */
  /*border-top: 16px solid #3498db;  Blue */
  border-top: 16px solid blue;
  border-bottom: 16px solid blue;
  border-radius: 50%;
  width: 120px;
  height: 120px;
  position: absolute;
  top: 50%;
  left: 50%;
  -ms-transform: translateY(-50%);
  transform: translateY(-50%);
  animation: spin 2s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}
    .modal2
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

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
}
.modal .btnPrint {
  position: absolute;
  top: 80%;
  left: 80%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  background-color: #555;
  color: white;
  font-size: 16px;
  padding: 12px 24px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  text-align: center;
}
.modal .btnStart {
  position: absolute;
  top: 80%;
  right: 80%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  background-color: #555;
  color: white;
  font-size: 16px;
  padding: 12px 24px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  text-align: center;
}

/* Modal Content (image) */
.modal-content {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
}

/* Caption of Modal Image */
#caption {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
  text-align: center;
  color: #ccc;
  padding: 10px 0;
  height: 150px;
}

/* Add Animation */
.modal-content, #caption {  
  -webkit-animation-name: zoom;
  -webkit-animation-duration: 0.6s;
  animation-name: zoom;
  animation-duration: 0.6s;
}

@-webkit-keyframes zoom {
  from {-webkit-transform:scale(0)} 
  to {-webkit-transform:scale(1)}
}

@keyframes zoom {
  from {transform:scale(0)} 
  to {transform:scale(1)}
}

/* The Close Button */
.close {
  position: absolute;
  top: 15px;
  right: 35px;
  color: #f1f1f1;
  font-size: 40px;
  font-weight: bold;
  transition: 0.3s;
}

.close:hover,
.close:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
  .modal-content {
    width: 100%;
  }
}
        .auto-style11 {
            width: 137px;
        }
        .auto-style21 {
            width: 95%;
        }
        .auto-style26 {
            width: 137px;
            height: 20px;
        }
        .auto-style27 {
            height: 20px;
        }
        #dvLoading
	{
	   background:#000 url(images/loader.gif) no-repeat center center;
	   height: 100px;
	   width: 100px;
	   position: fixed;
	   z-index: 1000;
	   left: 50%;
	   top: 50%;
	   margin: -25px 0 0 -25px;
	}

        .auto-style30 {
            width: 683px;
        }
        div.columns       { width: 900px; }
        div.columns div   { width: 450px; height: 75px; float: left; }
        div.grey          { width: 350px; height: 75px; float: left; background-color: #cccccc; }
        div.red           { width: 100px; height: 75px; float: left; background-color: #e14e32; }
        div.clear         { clear: both; }

        .auto-style32 {
            width: 656px;
            height: 125px;
        }

        .auto-style33 {
            width: 73%;
            height: 362px;
        }

        .auto-style34 {
            width: 247px;
            height: 125px;
        }

        .auto-style35 {
            height: 18px;
        }
        .auto-style36 {
            height: 125px;
        }

    </style>

            <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal2");
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

         <script type="text/javascript">
        function showModalImage() {
            var modal = document.getElementById("myModal");
            
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById("ImagePreview");
            var modalImg = document.getElementById("img01");
            var captionText = document.getElementById("caption");
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }
    </script>	

</head>
    <body>
         <form id="form1" runat="server" style="padding-top: 0px; margin-top: 0px; vertical-align: top">

             

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
             <div id="divContent" align="center">
<table class="auto-style33">
                 <tr>
                     <td class="auto-style32">
                         <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                     &nbsp;
                                     <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                 </h2>

                     </td>
                     <td align="left" class="auto-style34">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate> 
                             <h2>&nbsp;&nbsp;&nbsp; <asp:Label ID="LabelTime" runat="server" Text="30" BorderStyle="Dotted" ForeColor="Black"></asp:Label></h2>
                              <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick1">
                                  </asp:Timer> 

                          </ContentTemplate>
                    </asp:UpdatePanel>

                     </td>
                     <td class="auto-style36">
                         
                         </td>
                 </tr>
                 <tr>
                     <td colspan="3" class="auto-style35"></td>
                 </tr>
                 <tr>
                     <td colspan="3"><asp:Image ID="ImagePreview" runat="server" BorderStyle="Solid" ImageAlign="Middle" />
                         <br />
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">&nbsp;</td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2">

                <asp:Button ID="ButtonStartOver" runat="server" CssClass="btn btn-primary btn-lg" Text="Start Over" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonPrint" runat="server" OnClientClick="return ShowProgress()" CssClass="btn btn-primary btn-lg" Text="Print Label" />

                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
             </div>
              <div class="loading">
            <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />Printing ......
                       <div class="loader">
           
                       </div>  
                  </div>
             <br />
             
             <!-- The Modal -->
<div id="myModal" class="modal">

  <!-- The Close Button -->
  <span class="close">&times;</span>

  <!-- Modal Content (The Image) -->
 
    <asp:Image ID="img01" CssClass="modal-content" runat="server" />
        <!-- buttons -->

    <asp:Button ID="Button1" CssClass="btnPrint"  OnClick="ButtonPrint_Click" OnClientClick="return ShowProgress()" runat="server" Text="Print" />
    <asp:Button ID="Button2" CssClass="btnStart" align="right"  OnClick="ButtonStartOver_Click" runat="server" Text="Start Over" />
  <!-- Modal Caption (Image Text) -->
  <div id="caption"></div>
</div>

&nbsp;<br />
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
    <div>
             <asp:Button ID="ButtonPrintPreview" runat="server" CssClass="btn btn-primary btn-lg" Text="Print Preview" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;<br /></div>
    <br />
    <br />        
    <table class="nav-justified">
        <tr>
            <td class="auto-style30">
                <br />
                 <br />
                <br />

                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceImages" Visible="False">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:ImageField DataAlternateTextField="DisplayName" DataImageUrlField="ThumbnailRelativePath">
                            <ItemStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName" />
                        <asp:BoundField DataField="FullPath" HeaderText="Path" SortExpression="FullPath" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSourceImages" runat="server" SelectMethod="GenerateDocumentsList" TypeName="CBLabelPrinterBLL.CB.Bartender.Models.WebLabelPrintDocument"></asp:ObjectDataSource>
                <br />
            </td>
            <td>
                <br />
        <asp:BulletedList ID="BulletedList2" runat="server" Height="48px" Visible="False">
        </asp:BulletedList>
                <br />
                <br />
                <br />
                <br />
                <asp:BulletedList ID="BulletedListMessages" runat="server">
                </asp:BulletedList>
              
                <br />
                <br />
                <br />
                <br />

                <br />
                <br />
                Printer Selected <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                </asp:DropDownList>
                <br />
                No of Copies<br />
                No of Seq<br />
                Label Format Substrings<br />
                <asp:GridView ID="GridViewSubStrings" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>

    TEST AREA<br />
    <br />
                         <table class="auto-style21" __designer:mapid="197">
                             <tr __designer:mapid="198">
                                 <td class="auto-style25" __designer:mapid="199" rowspan="17">
                                    <asp:BulletedList ID="BulletedList1" runat="server" ForeColor="Red">
                                    </asp:BulletedList>
                                    </td>
                                 <td class="auto-style11" __designer:mapid="19a">Kiosk</td>
                                 <td __designer:mapid="19b" style="width: 109px">
                                     <asp:Label ID="LabelKiosk" runat="server" Text="Kiosk"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1f7">
                                 <td class="auto-style26" __designer:mapid="1f8">Line</td>
                                 <td __designer:mapid="1f9" class="auto-style27" style="width: 109px">
                                     <asp:Label ID="LabelLineNumber" runat="server" Text="Line"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1fc">
                                 <td class="auto-style26" __designer:mapid="1fd">Shift</td>
                                 <td __designer:mapid="1fe" class="auto-style27" style="width: 109px">
                                     <asp:Label ID="LabelShift" runat="server" Text="Shift"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1f4">
                                 <td class="auto-style11" __designer:mapid="1f5">Printer</td>
                                 <td __designer:mapid="1f6" style="width: 109px">
                                     <asp:Label ID="LabelPrinterName" runat="server" Text="Printer Name"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="19d">
                                 <td class="auto-style11" __designer:mapid="19f">Printer ID:</td>
                                 <td __designer:mapid="1a0" style="width: 109px">
                                     <asp:Label ID="LabelPrinterId" runat="server" Text="PrinterID"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1a2">
                                 <td class="auto-style11" __designer:mapid="1a4">Production Order:</td>
                                 <td __designer:mapid="1a5" style="width: 109px">
                                     <asp:Label ID="LabelProdOrder" runat="server" Text="Production Order"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1a7">
                                 <td class="auto-style11" __designer:mapid="1a9">Product Desc</td>
                                 <td __designer:mapid="1aa" style="width: 109px">
                                     <asp:Label ID="LabelProdDesc" runat="server" Text="Production Order"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="208">
                                 <td class="auto-style11" __designer:mapid="209">Pack Desc:</td>
                                 <td __designer:mapid="20a" style="width: 109px">
                                     <asp:Label ID="LabelPack" runat="server" Text="PackDesc"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1df">
                                 <td class="auto-style11" __designer:mapid="1e0">Pack Qty</td>
                                 <td __designer:mapid="1e1" style="width: 109px">
                                     <asp:Label ID="LabelQty" runat="server" Text="Qty"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="203">
                                 <td class="auto-style11" __designer:mapid="204">GTIN</td>
                                 <td __designer:mapid="205" style="width: 109px">
                                     <asp:Label ID="LabelGTIN" runat="server" Text="GTIN"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1e4">
                                 <td class="auto-style11" __designer:mapid="1e5">Format</td>
                                 <td __designer:mapid="1e6" style="width: 109px">
                                     <asp:Label ID="LabelFormat" runat="server" Text="Format"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1ea">
                                 <td class="auto-style11" __designer:mapid="1eb">File Path:</td>
                                 <td __designer:mapid="1ec" style="width: 109px">
                                     <asp:Label ID="LabelFilePath" runat="server" Text="File Path"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1e7">
                                 <td class="auto-style11" __designer:mapid="1e8">Preview Path</td>
                                 <td __designer:mapid="1e9" style="width: 109px">
                                     <asp:Label ID="LabelPreview" runat="server" Text="Preview"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1e7">
                                 <td class="auto-style11">rint type</td>
                                 <td style="width: 109px">
                                     <asp:Label ID="LabelPrintType" runat="server" Text="LabelPrintType"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1e7">
                                 <td class="auto-style11">basketb</td>
                                 <td style="width: 109px">
                                     <asp:Label ID="LabelBasketNumber" runat="server" Text="BasketNumber"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1e7">
                                 <td class="auto-style11">&nbsp;</td>
                                 <td style="width: 109px">
                                     <asp:Label ID="LabelCert" runat="server" Text="Label"></asp:Label>
                                 </td>
                             </tr>
                             <tr __designer:mapid="1ac">
                                 <td colspan="2" __designer:mapid="1ae">
                                     &nbsp;</td>
                             </tr>
                         </table>
             <asp:Label ID="LabelJS" runat="server" Text="Label"></asp:Label>
             </form>
         <script>
             // Get the modal
             var modal = document.getElementById("myModal");
             // Get the image and insert it inside the modal - use its "alt" text as a caption
             var img = document.getElementById("ImagePreview");
             var modalImg = document.getElementById("img01");
             var captionText = document.getElementById("caption");

            
             img.onclick = function () {
                 modal.style.display = "block";
                 modalImg.src = this.src;
                 captionText.innerHTML = this.alt;
             }

             // Get the <span> element that closes the modal
             var span = document.getElementsByClassName("close")[0];

             // When the user clicks on <span> (x), close the modal
             span.onclick = function () {
                 modal.style.display = "none";
             }
         </script>
                  </body>
