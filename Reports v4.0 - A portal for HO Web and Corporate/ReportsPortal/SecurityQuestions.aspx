<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecurityQuestions.aspx.cs" Inherits="SecurityQuestions" %>

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
            <asp:ScriptReference Path="~/JSFiles/JScript2.js" />
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
                <td width="50" align="right">
                    <b>6.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp6"  
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
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans6"  
                    runat="server"
                    width="255"></asp:TextBox>
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
                <td width="50" align="right">
                    <b>7.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp7"  
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
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans7"  
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
                 <td width="50" align="right">
                    <b>8.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp8"  
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
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans8"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>4.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp4"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
                 <td width="50" align="right">
                    <b>9.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp9"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans4"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans9"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>5.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp5"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
                <td width="50" align="right">
                    <b>10.</b>
                </td>
                <td>
                    <asp:Dropdownlist   
                    ID="drp10"  
                    runat="server"
                    width="260">
                    </asp:Dropdownlist>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans5"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:TextBox   
                    ID="ans10"  
                    runat="server"
                    width="255"></asp:TextBox>
                </td>
            </tr>
        </table>
        
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr align="left" />
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
                <td>&nbsp;</td>
                <td align="right">
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
    </div>
     <asp:UpdatePanel runat="server" ID="upConfirmation1">
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
