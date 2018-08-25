<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" Title="M.lhuillier" %>
<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register namespace="Bewise.Web.UI.WebControls" tagprefix="Bewise" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
//    function getCheckedRadio(opt) {
//        if (opt == '5') {
//            document.getElementById('<%=Username.ClientID%>').disabled = true;
//            document.getElementById('<%=Password.ClientID%>').disabled = true;
//            document.getElementById('<%=Label3.ClientID%>').innerHTML = "Note: Click Go to Page to Login";
//            document.getElementById('<%=Username.ClientID%>').value = "";
//            document.getElementById('<%=Password.ClientID%>').value = "";
//        }else
//        {
//            document.getElementById('<%=Username.ClientID%>').disabled = false;
//            document.getElementById('<%=Password.ClientID%>').disabled = false;
//            document.getElementById('<%=Label3.ClientID%>').innerHTML = "Note: Select Reports To be Directed";
//        }
//    }
    function returnFalse() {
        return false;
    }
    
</script>   
    
    <table align="center">
        <tr>
    <td class="style1" align="center">
    <Bewise:FlashControl ID="FlashControl1" runat="server" Height="208px" 
        Loop="True" MovieUrl="~/Images/WebLoginAnimation.swf" Width="339px" 
            style="text-align: center" /></td>
   </tr> 
    <tr>
    <td class="style1">
        <asp:RadioButtonList ID="radionBut" runat="server" Font-Size="Small" 
            RepeatDirection="Horizontal" Width="830px" Height="30px">
            <asp:ListItem Value="0" onClick="getCheckedRadio('0')">Global</asp:ListItem>
            <asp:ListItem Value="1" onClick="getCheckedRadio('1')">Partners (US)</asp:ListItem>
            <asp:ListItem Value="2" onClick="getCheckedRadio('2')">Domestic</asp:ListItem>
            <asp:ListItem Value="3" onClick="getCheckedRadio('3')">Partners (Phils.)</asp:ListItem>
            <asp:ListItem Value="4" onClick="getCheckedRadio('4')">File Upload</asp:ListItem>
            <asp:ListItem Value="5" onClick="getCheckedRadio('5')">File Transmit</asp:ListItem>
            <asp:ListItem Value="6" onClick="getCheckedRadio('6')">File Transmit 2</asp:ListItem>
            <asp:ListItem Value="7" onClick="getCheckedRadio('7')">File Transmit 3</asp:ListItem>
        </asp:RadioButtonList>
        </td> </tr>
        <tr><td align="center" >
            <asp:Label ID="Label3" runat="server" Font-Italic="True" Font-Size="XX-Small" 
                ForeColor="#CC0000" Text="Note: Select Reports To be Directed"></asp:Label>
            </td></tr>
           
        <tr><td>
            <table align="center" style="top:20px;">
                <tr>
                    <td style="font-size: 12px; padding-left: 20px;" width="75px">
                        &nbsp;</td>
                    <td>
                       
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                       
                    </td>
                </tr>
                 <tr>
                   <td>

                   </td>
                   <td id="tdfplink" style="font-size: 12px; text-align:right;" >
                        <a id="fplink" runat="server" href="Resource.aspx" onclick="window.open(this.href, 'mywin',
                        'left=20,top=20,width=630,height=500,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=yes,directories=no, status=yes'); return false;"><u>Forgot Password?</u></a> 
                   </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; padding-left: 20px">
                        <asp:Label ID="uname" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Username" runat="server" Rows="10" MaxLength="50" Width="174px" NAME="uname"
                            ontextchanged="Username_TextChanged" CssClass="txtUppercase" Enabled="true" ></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, UppercaseLetters, LowercaseLetters"
    TargetControlID="Username" />
    
    
                              <%--<asp:FilteredTextBoxExtender ID="Username_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" 
                                    FilterType="Numbers, UppercaseLetters, LowercaseLetters" 
                                    TargetControlID="Username">
                                </asp:FilteredTextBoxExtender>--%>
               
    
                    </td>
                </tr>
                <tr style="text-align: left">
                    <td style="font-size: 12px; padding-left: 20px; ">
                        <asp:Label ID="pword" runat="server"  Rows="10" MaxLength="50" Text="Password:"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="174px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters"
    TargetControlID="Password" ValidChars=" " />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; height: 37px;">
                    </td>
                    <td style="height: 37px">
                <%--</ContentTemplate>
                    </asp:UpdatePanel> --%>
                <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Reports\MLKPSMSReport.rpt">
                    </Report>
                </CR:CrystalReportSource>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                        ReportSourceID="CrystalReportSource1" 
                        DisplayGroupTree="False" AutoDataBind="True" 
                    EnableParameterPrompt="False" />--%>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
                            Text="Go To Page" Width="93px" OnClientClick ="target='_blank';" />
                    </td>
                </tr>
                <tr>
    <%--       
    <asp:ModalPopupExtender ID="changepass"  runat="server" TargetControlID = "btncpass" PopupControlID = "panelapp" BehaviorID="changepass">
                </asp:ModalPopupExtender>
                --%>
                
                
                
                
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; height: 19px;">
                <%--</ContentTemplate>
                    </asp:UpdatePanel> --%>
                <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Reports\MLKPSMSReport.rpt">
                    </Report>
                </CR:CrystalReportSource>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                        ReportSourceID="CrystalReportSource1" 
                        DisplayGroupTree="False" AutoDataBind="True" 
                    EnableParameterPrompt="False" />--%>
                  <%--</ContentTemplate>
                    </asp:UpdatePanel> --%>
                        <asp:Panel ID="panelapp" runat="server" BackColor="#E5E5E5" 
                            BorderColor="#666666" BorderStyle="Solid" Font-Bold="False" Font-Size="small" 
                            Height="291px" style="display:none;" Width="358px">
                            <table style="width: 99%; height: 110px;">
                                <tr>
                                    <td class="style4" style="width: 147px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Username:</td>
                                    <td>
                                        <asp:TextBox ID="lblnamepan" runat="server" CssClass="txtUppercase" 
                                            Enabled="False" Width="184px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style4" style="width: 147px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Current Password:</td>
                                    <td>
                                        <asp:TextBox ID="txtcurrpass" runat="server" TextMode="Password" Width="184px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style4" style="width: 147px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Password:</td>
                                    <td>
                                        <asp:TextBox ID="txtnewpass" runat="server" TextMode="Password" Width="184px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style4" style="width: 147px">
                                        &nbsp;Confirm New Password:</td>
                                    <td>
                                        <asp:TextBox ID="txtconpass" runat="server" TextMode="Password" Width="183px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="X-Small" 
                                            ForeColor="Red" Text="* Retry. Password did not match." Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Size="Small" 
                                ForeColor="Red" Text="Successfully updated." Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn" runat="server" Height="41px" Text="Change" />
                            <asp:Button ID="btncancel" runat="server" Height="39px" Text="Cancel" />
                            <br />
                   <%-- tago2x portion--%>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            </td></tr>
            <tr><td>
            &nbsp;
                </td></tr>
        <tr><td align ="center" >
            &nbsp;</td></tr> 
       </table> 
  

    
</asp:Content>

