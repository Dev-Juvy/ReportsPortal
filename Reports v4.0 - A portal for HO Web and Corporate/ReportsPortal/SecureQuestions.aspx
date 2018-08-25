<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecureQuestions.aspx.cs" Inherits="SecureQuestions" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="asp"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/StyleSheet1.css" rel="Stylesheet" type="text/css" />
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.js" type="text/javascript"></script>      
    <script src="http://ajax.microsoft.com/ajax/beta/0911/Start.debug.js" type="text/javascript"></script>  
    <script src="http://ajax.microsoft.com/ajax/beta/0911/extended/ExtendedControls.debug.js" type="text/javascript"></script>  
</head>
<body>
    <form id="frmsecurityquestion" runat="server" defaultbutton="Next">
    <asp:ScriptManager  
            ID="ScriptManager1"  
            runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JSFiles/jquery-1.2.6.min.js" />
            <asp:ScriptReference Path="~/JSFiles/jquery.blockUI.js" />
            <asp:ScriptReference Path="~/JSFIles/JScript2.js" />
        </Scripts>  

        </asp:ScriptManager>
    <div class="img"><img src="images/MLKP_Logo2.png" alt="" /> </div>
    <div id="EntryForm1">  
        <p style="font-size:small; line-height:0px">Please take time to answer our security questions.</p>
        
        <hr align="left" />  
         
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                 <table>
            <tr>
                <td>
                    <b>1.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp1"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans1"  
                    runat="server"
                    width="255">  
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>2.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp2"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans2"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>3.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp3"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans3"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
            </tr>
            <tr align="right">
            <td colspan=4 align="right">
                <asp:Button   
                ID="Next"  
                runat="server"  
                Text="Next"  
                OnClick="Button1_Click"  
                Height="25"  
                Font-Bold="true"
                UseSubmitBehavior="false"
                /> 
            </td>
            </tr>
        </table>
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
