<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Helpdesk.aspx.cs" Inherits="Helpdesk" %>
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
        <h3 style=" max-height:10px; margin-left:2px;">Welcome Helpdesk!</h3>
        <hr align="left" />
        
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:TextBoxWatermarkExtender   
            ID="tbwhelpdesk"  
            runat="server"
            Enabled="true"
            TargetControlID="helpdesk"  
            WatermarkText="Enter resource id here"
            >  
        </asp:TextBoxWatermarkExtender>
        <asp:FilteredTextBoxExtender ID="ftbe" runat="server" 
        TargetControlID="helpdesk"
        FilterType="Numbers"  />  
    
        <asp:TextBox   
            ID="helpdesk"  
            runat="server" ontextchanged="helpdesk_TextChanged"    
            >  
        </asp:TextBox>  
        <asp:Button   
            ID="Next"  
            runat="server"  
            Text="Reset Code"  
            OnClick="Button1_Click"  
            Height="25"  
            Font-Bold="true"
            UseSubmitBehavior="false"   
            />  
        <br />
            </ContentTemplate>
         </asp:UpdatePanel>
         
        <table cellpadding="2px" width="600" style="font-size:small; line-height:0px">
            <tr>
                <td style="width:1px; white-space:nowrap">Send code to: </td>
                <td style="width:1px; white-space:nowrap">
                    <asp:CheckBoxList ID="radiobutton" runat="server" Font-Size="Small" 
                        Height="22px" RepeatDirection="Horizontal" Width="174px">
                        <asp:ListItem>Cell No.</asp:ListItem>
                        <asp:ListItem>Email</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
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
