using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data.Common;
using System.Configuration;
using MySql.Data.MySqlClient;
using CSScriptLibrary;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;
public partial class SecurityQuestions : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    Dictionary<int, string> dic = new Dictionary<int, string>();
    string resourceid = string.Empty;
    public String RandomCode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            
            if (string.IsNullOrEmpty(Global.resourceid))
            {
                Response.Redirect("Resource.aspx", false);
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
            

            dynamic rnd = CSScript.Evaluator
                                   .LoadCode(@"" + m1 + "");
            
            dic = rnd.randomquestions();

            this.drp1.DataSource = dic;
            this.drp1.DataTextField = "Value";
            this.drp1.DataValueField = "Key";
            this.drp1.DataBind();

            this.drp2.DataSource = dic;
            this.drp2.DataTextField = "Value";
            this.drp2.DataValueField = "Key";
            this.drp2.DataBind();

            this.drp3.DataSource = dic;
            this.drp3.DataTextField = "Value";
            this.drp3.DataValueField = "Key";
            this.drp3.DataBind();

            this.drp4.DataSource = dic;
            this.drp4.DataTextField = "Value";
            this.drp4.DataValueField = "Key";
            this.drp4.DataBind();

            this.drp5.DataSource = dic;
            this.drp5.DataTextField = "Value";
            this.drp5.DataValueField = "Key";
            this.drp5.DataBind();

            this.drp6.DataSource = dic;
            this.drp6.DataTextField = "Value";
            this.drp6.DataValueField = "Key";
            this.drp6.DataBind();

            this.drp7.DataSource = dic;
            this.drp7.DataTextField = "Value";
            this.drp7.DataValueField = "Key";
            this.drp7.DataBind();

            this.drp8.DataSource = dic;
            this.drp8.DataTextField = "Value";
            this.drp8.DataValueField = "Key";
            this.drp8.DataBind();

            this.drp9.DataSource = dic;
            this.drp9.DataTextField = "Value";
            this.drp9.DataValueField = "Key";
            this.drp9.DataBind();

            this.drp10.DataSource = dic;
            this.drp10.DataTextField = "Value";
            this.drp10.DataValueField = "Key";
            this.drp10.DataBind();

            Global.securityDictionary = dic;
            Global.updatedsecurityDictionary = dic;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if (this.ans1.Text == string.Empty & this.ans2.Text == string.Empty & this.ans3.Text == string.Empty & this.ans4.Text == string.Empty
                & this.ans5.Text == string.Empty & this.ans6.Text == string.Empty & this.ans7.Text == string.Empty & this.ans8.Text == string.Empty
                & this.ans9.Text == string.Empty & this.ans10.Text == string.Empty)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "You must have to answer all security questions.";
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


                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add(drp1.Text, ans1.Text);
                _dic.Add(drp2.Text, ans2.Text);
                _dic.Add(drp3.Text, ans3.Text);
                _dic.Add(drp4.Text, ans4.Text);
                _dic.Add(drp5.Text, ans5.Text);
                _dic.Add(drp6.Text, ans6.Text);
                _dic.Add(drp7.Text, ans7.Text);
                _dic.Add(drp8.Text, ans8.Text);
                _dic.Add(drp9.Text, ans9.Text);
                _dic.Add(drp10.Text, ans10.Text);

                foreach (KeyValuePair<string, string> r in _dic)
                {
                    bool result = (bool)pass.insertselectedquestions(Convert.ToInt32(Global.resourceid), r.Key, r.Value);
                }

                //Generate random password
                string _randomcode = pass.generaterandompassword();
                Global.getCode = _randomcode;

                //insert generated code to database
                bool _return = (bool)pass.insertsecuritycode(Convert.ToInt32(Global.resourceid), _randomcode);

                //get message format
                string _msg = pass.getMessageFormat(Convert.ToInt32(Global.resourceid));

                //get contact number of a user
                string _cellno = pass.getcontactno(Global.resourceid);

                // Send code via Email
                if (radiobutton.SelectedValue == "Email")
                {
                    String Emaill = Global.GetEmail;
                    SendEmail(Emaill.Trim());
                    //int eml = pass.SendEmail(Emaill.Trim()); 

                    Response.Redirect("SecurityCode.aspx", false);
                }

                // Send code via Cellphone
                if (radiobutton.SelectedValue == "Cel No.")
                {
                    smsservice.ServiceSoapClient sms = new smsservice.ServiceSoapClient();
                    sms.SendMessage(_cellno, _msg);

                    Global.Step = 2;
                    Response.Redirect("SecurityCode.aspx", false);
                }
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
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential(__username,_password);
            string URLP = string.Empty;
            String IPaddress = ConfigurationManager.AppSettings["MailServerIPaddress"];
            emailClient.Host = IPaddress;
            emailClient.UseDefaultCredentials = true;
            emailClient.Credentials = auth;
            emailClient.Send(MailMessage);
        }
        catch (Exception ex)
        {
            return 0;
        }
        return 1;
    }
}