<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>
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
    <form id="formchangepassword" runat="server" defaultbutton="Next">
    <asp:ScriptManager  
            ID="ScriptManager2"  
            runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JSFiles/jquery-1.2.6.min.js" />
            <asp:ScriptReference Path="~/JSFiles/jquery.blockUI.js" />
            <asp:ScriptReference Path="~/JSFIles/JScript2.js" />
        </Scripts>  

        </asp:ScriptManager>

    <div class="img"><img src="images/MLKP_Logo2.png" alt="" /> </div>
    <div id="EntryForm1">  
        <h3 style=" max-height:10px;">Enter a new password.</h3>
        
        <hr align="left" />  
            
        <asp:PasswordStrength ID="PS" runat="server"
        TargetControlID="TextBox1"
        DisplayPosition="RightSide"
        StrengthIndicatorType="Text"
        PreferredPasswordLength="10"
        PrefixText="Strength:"
        TextCssClass="TextIndicator_TextBox1"
        MinimumNumericCharacters="0"
        MinimumSymbolCharacters="0"
        RequiresUpperAndLowerCaseCharacters="false"
        TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
        TextStrengthDescriptionStyles="cssClass1;cssClass2;cssClass3;cssClass4;cssClass5"
        CalculationWeightings="50;15;15;20" />  
    
    <table>
        <tr>
            <td style="font-family:Arial; font-size:small">New Password</td>
            <td>
                <asp:TextBox   
                ID="TextBox1"  
                runat="server"
                TextMode="Password">  
                </asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td style="font-family:Arial; font-size:small">Retype the new password</td>
            <td>
                <asp:TextBox   
                ID="TextBox2"  
                runat="server"
                TextMode="Password">  
                </asp:TextBox> 
            </td>
        </tr>
    </table>
    <hr align="left" />
       
        <asp:Button   
            ID="Next"  
            runat="server"  
            Text="Save"  
            OnClick="Button1_Click"  
            Height="25"  
            Font-Bold="true"
            UseSubmitBehavior="false"   
            />
   
        <br />
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
