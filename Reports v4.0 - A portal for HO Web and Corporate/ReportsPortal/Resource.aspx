﻿<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Resource.aspx.cs" Inherits="Resource" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="asp"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/StyleSheet1.css" rel="Stylesheet" type="text/css" />
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.js" type="text/javascript"></script>      
    <script src="http://ajax.microsoft.com/ajax/beta/0911/Start.debug.js" type="text/javascript"></script>  
    <script src="http://ajax.microsoft.com/ajax/beta/0911/extended/ExtendedControls.debug.js" type="text/javascript"></script>  
</head>
<body>
    <form id="formresource" runat="server" defaultbutton="Next">
    <asp:ScriptManager  
            ID="ScriptManager1"  
            runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JSFiles/jquery-1.2.6.min.js" />
            <asp:ScriptReference Path="~/JSFiles/jquery.blockUI.js" />
            <asp:ScriptReference Path="~/JSFIles/JScript1.js" />
        </Scripts>  

        </asp:ScriptManager>
    
    <div class="img"><img src="images/MLKP_Logo2.PNG" alt=""/></div>
    <div id="EntryForm">
        <h3 style=" max-height:10px; margin-left:2px;">We need your resource ID to verify your identity</h3>
        <p style="font-size:small; line-height:0px; margin-left:2px;">This protects your account from unauthorized access.</p>
        <hr align="left" />
        
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:TextBoxWatermarkExtender   
            ID="tbwresource"  
            runat="server"
            Enabled="true"
            TargetControlID="resourceid"  
            WatermarkText="Enter resource ID here"
            >  
        </asp:TextBoxWatermarkExtender>
        <asp:FilteredTextBoxExtender ID="ftbe" runat="server" 
        TargetControlID="resourceid"
        FilterType="Numbers"  />  
    
        <asp:TextBox   
            ID="resourceid"  
            runat="server"    
            >  
        </asp:TextBox>  
        <asp:Button   
            ID="Next"  
            runat="server"  
            Text="Next"  
            OnClick="Button1_Click"  
            Height="25"  
            Font-Bold="true"
            UseSubmitBehavior="false"   
            />  
        <br />
            </ContentTemplate>
         </asp:UpdatePanel>
       
    </div>

    <asp:UpdatePanel runat="server" ID="upConfirmation">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Next" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel runat="server" ID="ConfirmSave" Visible="false">
                <h4>
                    <asp:Literal runat="server" ID="popupmsg" /></h4>
                <a href="#" id="CloseConfirm">Close</a>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
