using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSScriptLibrary;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Security;
using System.Net.Mail;
using System.Net.Sockets;

public partial class Helpdesk : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    
    protected void Page_Load(object sender, EventArgs e)
    {

       

        if (!IsPostBack) 
        {
            if (Session["HelpdeskUser"] == null)
            {
                Response.Redirect("Resource.aspx", false);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if(this.helpdesk.Text == string.Empty)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Please enter resource id.";
                return;
            }

            MySqlDataReader dr = null;
            string m1 = string.Empty;
            DAL.ConnectionString = ConfigurationManager.AppSettings["myConnectionStringB"].ToString();
            DAL.Provider = EnumProviders.MySQL;
            DAL.CmdTimeout = 1;

            dr = (MySqlDataReader)DAL.ExecReader("Select classtext from classes where classname='ForgotPassword';", System.Data.CommandType.Text);

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    m1 = dr.GetString("classtext");
                }
            }


            string path = HttpRuntime.AppDomainAppPath + "Bin\\System.configuration.dll";
            string path1 = HttpRuntime.AppDomainAppPath + "Bin\\System.Data.dll";

            CSScript.Evaluator.ReferenceAssembly(@"" + path + "");
            CSScript.Evaluator.ReferenceAssembly(@"" + path1 + "");

            dynamic pass = CSScript.Evaluator
                                   .LoadCode(@"" + m1 + "");

            //Generate random password
            string _randomcode = pass.generaterandompassword();
          //  Global.GetEmail = _randomcode;
            //reset security code
            bool _success = pass.insertsecuritycode(Convert.ToInt32(this.helpdesk.Text), _randomcode);

            //get message format
            string _msg = pass.getMessageFormat(Convert.ToInt32(this.helpdesk.Text));

            //get contact number of a user
            string _cellno = pass.getcontactno(this.helpdesk.Text);

            // Send code to the user
            if (radiobutton.SelectedValue == "Email")
            {
                string EmailADDHP = helpdesk.Text;
                verifydetailsForHPusers(EmailADDHP);
                String Emaill = Global.GetEmail;
                SendEmail(Emaill.Trim());
                //int eml = pass.SendEmail(Emaill.Trim());
            }
            if (radiobutton.SelectedValue == "Cell No.")
            {
                smsservice.ServiceSoapClient sms = new smsservice.ServiceSoapClient();
                sms.SendMessage(_cellno, _msg);
            }

            if (Global .MAilStatus == 0)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Failed Sending Mail.";
            }
            else
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Password has been successfully reset.";
            }
            Session.Remove("HelpdeskUser");
        }
        catch (Exception ex) 
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }
        
    }

    public int SendEmail(string EmailAddress)
    {
        try


        {

            string[] email = null;
            email = EmailAddress.ToString().Split(',');

            string[] Recipient = null;
            Recipient = email;

            MailMessage MailMessage = new MailMessage("donotreply@developer1.com", Recipient[0]);

            short ctr = 0;
            foreach (string e_add in Recipient)
            {
                if (ctr > 0)
                {
                    MailMessage.To.Add(e_add);
                }
                else
                {
                    ctr += 1;
                }
            }

            MailMessage.Subject = "Security Code";

            String SEcCode = Global.getCode;

            MailMessage.Body = "Your security code is" + SEcCode + "Note: This code is expired in 5 minutes.";

            MailMessage.IsBodyHtml = true;

            SmtpClient emailClient = new SmtpClient();
              String _password = ConfigurationManager.AppSettings["password"];
              String __username = ConfigurationManager.AppSettings["username"];
              System.Net.NetworkCredential auth = new System.Net.NetworkCredential(__username, _password);
             string URLP = string.Empty;
                String IPaddress = ConfigurationManager.AppSettings["MailServerIPaddress"];
                emailClient.Host = IPaddress;
            emailClient.UseDefaultCredentials = true;
            emailClient.Credentials = auth;
            emailClient.Send(MailMessage);
        }
        catch (Exception ex)
        {
            Global.MAilStatus = 0;
            return 0;
           
            
        }
        Global.MAilStatus = 1;
        return 1;
    }



    public int verifydetailsForHPusers(string resource)
    {
        // 2 = Not HO users
        // 1 = HO users and details validated
        // 0 = No Cell#
        MySqlDataReader dr = null;
        DAL.ConnectionString = ConfigurationManager.AppSettings["myConnectionStringB"].ToString();
        DAL.Provider = EnumProviders.MySQL;
        DAL.CmdTimeout = 1;

        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("_resourceid", resource);

        dr = (MySqlDataReader)DAL.ExecReader("validateresource", System.Data.CommandType.StoredProcedure, param);

        if (dr.Read())
        {
            Global.password = dr["userpassword"].ToString();
            Global.RoleID = dr["roleid"].ToString();

            Dictionary<string, object> param1 = new Dictionary<string, object>();
            param1.Add("resid", resource);
            dr = (MySqlDataReader)DAL.ExecReader("GetCellData", System.Data.CommandType.StoredProcedure, param1);

            if (dr.Read())
            {
                if (dr["CellNo"].ToString() != string.Empty)
                {
                    Global.GetEmail = dr["EmailAddress"].ToString();
                    return 1;
                }
            }
            return 0;
        }
        return 2;
    }
    protected void helpdesk_TextChanged(object sender, EventArgs e)
    {

    }
}

