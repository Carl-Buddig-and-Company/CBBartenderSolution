<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Keypad.ascx.vb" Inherits="CBWarehouseLabelPrintWeb.Keypad" %>
<DIV class="Keypad" style="WIDTH: 192px; POSITION: relative; HEIGHT: 320px; BACKGROUND-COLOR: #D8D8D8"
	ms_positioning="GridLayout">
	<INPUT onkeypress="if(event.keyCode==13){document.all('Keypad1_btnOK').click();return false;}if(event.keyCode==27){document.all('Keypad1_btnCancel').click();return false;}"
		id="txtResult" style="FONT-SIZE: medium; Z-INDEX: 102; LEFT: 8px; WIDTH: 176px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 8px; HEIGHT: 30px"
		type="text" size="24" name="txtResult" runat="server">
	<asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 104px; POSITION: absolute; TOP: 264px" runat="server"
		CssClass="FatButton" Text="OK" Width="81px" Height="48px" Font-Names="Verdana" Font-Size="Medium"></asp:button>
    <input style="font-weight: bold; font-size: 12pt; z-index: 104; left: 16px; width: 48px; font-family: Verdana; position: absolute; top: 152px; height: 48px"
        onclick="numClicked(this);" type="button" value="1">
    <input style="font-weight: bold; font-size: 12pt; z-index: 105; left: 72px; width: 48px; font-family: Verdana; position: absolute; top: 152px; height: 48px"
        onclick="numClicked(this);" type="button" value="2">
    <input style="font-weight: bold; font-size: 12pt; z-index: 106; left: 128px; width: 48px; font-family: Verdana; position: absolute; top: 152px; height: 48px"
        onclick="numClicked(this);" type="button" value="3">
    <input style="font-weight: bold; font-size: 12pt; z-index: 107; left: 16px; width: 48px; font-family: Verdana; position: absolute; top: 96px; height: 48px"
        onclick="numClicked(this);" type="button" value="4"><input style="font-weight: bold; font-size: 12pt; z-index: 108; left: 72px; width: 48px; font-family: Verdana; position: absolute; top: 96px; height: 48px"
        onclick="numClicked(this);" type="button" value="5"><input style="font-weight: bold; font-size: 12pt; z-index: 109; left: 128px; width: 48px; font-family: Verdana; position: absolute; top: 96px; height: 48px"
        onclick="numClicked(this);" type="button" value="6"><input style="font-weight: bold; font-size: 12pt; z-index: 110; left: 16px; width: 48px; font-family: Verdana; position: absolute; top: 40px; height: 48px"
        onclick="numClicked(this);" type="button" value="7"><input style="font-weight: bold; font-size: 12pt; z-index: 111; left: 72px; width: 48px; font-family: Verdana; position: absolute; top: 40px; height: 48px"
        onclick="numClicked(this);" type="button" value="8"><input style="font-weight: bold; font-size: 12pt; z-index: 112; left: 128px; width: 48px; font-family: Verdana; position: absolute; top: 40px; height: 48px"
        onclick="numClicked(this);" type="button" value="9"><input style="font-weight: bold; font-size: 12pt; z-index: 113; left: 72px; width: 48px; font-family: Verdana; position: absolute; top: 208px; height: 48px"
        onclick="numClicked(this);" type="button" value="0"><input style="font-weight: bold; font-size: 12pt; z-index: 114; left: 16px; width: 48px; font-family: Verdana; position: absolute; top: 208px; height: 48px"
        onclick="delClicked(this);" type="button" value="DEL"><input style="font-weight: bold; font-size: 12pt; z-index: 115; left: 128px; width: 48px; font-family: Verdana; position: absolute; top: 208px; height: 48px"
        onclick="clrClicked(this);" type="button" value="CLR">
	<asp:button id="btnCancel" style="Z-INDEX: 116; LEFT: 8px; POSITION: absolute; TOP: 264px" runat="server"
		CssClass="FatButton" Text="Cancel" Width="80px" Height="48px" Font-Names="Verdana" Font-Size="Medium"></asp:button><asp:label id="txtSource" style="Z-INDEX: 100; LEFT: 64px; POSITION: absolute; TOP: 280px"
		runat="server" Width="32px" Visible="False"></asp:label>
   <!-- <INPUT onkeypress="if(event.keyCode==13){document.all('Keypad1_btnOK').click();return false;}if(event.keyCode==27){document.all('Keypad1_btnCancel').click();return false;}"
		id="txtPasswordResult" style="FONT-SIZE: medium; Z-INDEX: 103; LEFT: 8px; WIDTH: 176px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 8px; HEIGHT: 30px"
		type="password" size="24" name="txtPasswordResult" runat="server">-->
	<asp:label id="lblIsPassword" style="Z-INDEX: 99; LEFT: 8px; POSITION: absolute; TOP: 240px"
		runat="server" Visible="False">False</asp:label></DIV>
<!--<script>document.onload=document.all("Keypad1_txtResult").focus();</script>-->
<script>
    function focusToInput() {
        try {
            document.all("Keypad1_txtResult").focus();
        }
        catch (e) {
            document.all("Keypad1_txtPasswordResult").focus();
        }
    }
    function numClicked(elem) {
        try {
            document.all("Keypad1_txtResult").value += elem.value;
        }
        catch (e) { }
        try {
            document.all("Keypad1_txtPasswordResult").value += elem.value;
        }
        catch (e) { }
        //document.all("Keypad1_txtResult").focus();
        focusToInput();
    }
    function delClicked(elem) {
        try {
            document.all("Keypad1_txtResult").value = document.all("Keypad1_txtResult").value.substr(0, document.all("Keypad1_txtResult").value.length - 1);
        }
        catch (e) { }
        try {
            document.all("Keypad1_txtPasswordResult").value = document.all("Keypad1_txtPasswordResult").value.substr(0, document.all("Keypad1_txtPasswordResult").value.length - 1);
        }
        catch (e) { }
        //document.all("Keypad1_txtResult").focus();
        focusToInput();
    }
    function clrClicked(elem) {
        try {
            document.all("Keypad1_txtResult").value = "";
        }
        catch (e) { }
        try {
            document.all("Keypad1_txtPasswordResult").value = "";
        }
        catch (e) { }

        //document.all("Keypad1_txtResult").focus();
        focusToInput();
    }
</script>
<script>document.onload = focusToInput();</script>