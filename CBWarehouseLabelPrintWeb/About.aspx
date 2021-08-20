
<%@ Register src="Controls/Keypad.ascx" tagname="Keypad" tagprefix="uc1" %>
<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="CBWarehouseLabelPrintWeb.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;Buddig Process Monitor and Label Print Application </h2>
    
   
           

    <h2>
   
        &nbsp;</h2>
<p class="MsoNormal">
    This website requires that a cookie be placed on the computer accessing the site. If no cookie exists then an Admin page or Default page shall be displayed to prompt the user to adding a cookie. The cookie will consist of values for the KioskId, Computer Name, IP Address and Kiosk Name. Upon return to the website with the cookie added, the system shall check to see if the kiosk and IP address are registered in the database and forward the user to the process page.<o:p></o:p></p>
<h2>Admin setup<o:p></o:p></h2>
<p class="MsoNormal">
    If the computer you are using to access the website already has an entry in the Kiosk table, then you will be forwarded to the process form (line selection). If not then a cookie will beed to be placed on the computer you are using. If you have never been to this site using the computer you are logged into, then you must select which kiosk entry you will be using, this will filter the lines you see when you visit the process form<o:p></o:p></p>
<p class="MsoNormal">
    <span><v:shapetype id="_x0000_t75"
 coordsize="21600,21600" o:spt="75" o:preferrelative="t" path="m@4@5l@4@11@9@11@9@5xe"
 filled="f" stroked="f">
 <v:stroke joinstyle="miter" xmlns:v="urn:schemas-microsoft-com:vml"/>
 <v:formulas>
  <v:f eqn="if lineDrawn pixelLineWidth 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="sum @0 1 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="sum 0 0 @1" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @2 1 2" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @3 21600 pixelWidth" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @3 21600 pixelHeight" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="sum @0 0 1" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @6 1 2" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @7 21600 pixelWidth" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="sum @8 21600 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="prod @7 21600 pixelHeight" xmlns:v="urn:schemas-microsoft-com:vml"/>
  <v:f eqn="sum @10 21600 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
 </v:formulas>
 <v:path o:extrusionok="f" gradientshapeok="t" o:connecttype="rect" xmlns:v="urn:schemas-microsoft-com:vml"/>
 <o:lock v:ext="edit" aspectratio="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
</v:shapetype><v:shape id="Picture_x0020_9" o:spid="_x0000_i1025" type="#_x0000_t75"
 style='width:475pt;height:199.5pt;visibility:visible;mso-wrap-style:square'>
 <v:imagedata src="file:///C:/Users/bkinser/AppData/Local/Temp/msohtmlclip1/01/clip_image001.png"
  o:title="" croptop="18174f" cropbottom="10767f" cropleft="5811f" cropright="10713f" xmlns:v="urn:schemas-microsoft-com:vml"/>
</v:shape></span><o:p></o:p>
</p>
<p class="MsoNormal">
    <span><o:p>&nbsp;</o:p></span></p>
<h1>Process Flow<o:p></o:p></h1>
<p class="MsoNormal">
    A kiosk, or number is then used to account for where the web site requests are coming from, then filter a list of lines available for that kiosk (you can see all lines by clicking the SEE ALL LINES button)<o:p></o:p></p>
<p>
   
        &nbsp;</p>
    <p>Use this area to provide additional information.</p>
</asp:Content>
