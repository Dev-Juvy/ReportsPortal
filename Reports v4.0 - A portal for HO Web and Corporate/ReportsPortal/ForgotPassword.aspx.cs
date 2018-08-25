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

public partial class ForgotPassword : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Global.Step != 3) 
            {
                Response.Redirect("Resource.aspx", false);                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try 
        {
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

            //   CSScript.Evaluator.ReferenceAssembly(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.configuration.dll");
            //CSScript.Evaluator.ReferenceAssembly(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Data.dll");

            string path = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\System.configuration.dll";
            string path1 = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\System.Data.dll";
            //string path = HttpRuntime.AppDomainAppPath + "Bin\\System.configuration.dll";
            //string path1 = HttpRuntime.AppDomainAppPath + "Bin\\System.Data.dll";

          CSScript.Evaluator.ReferenceAssembly(@"" + path + "");
          CSScript.Evaluator.ReferenceAssembly(@"" + path1 + "");

            dynamic resetpass = CSScript.Evaluator
                                   .LoadCode(@"" + m1 + "");

            bool result = false;
            if (this.TextBox1.Text == this.TextBox2.Text)
            {
               result = resetpassword(this.TextBox1.Text, Global.resourceid);
               // result = (bool)resetpass.resetpassword(this.TextBox1.Text,Global.resourceid);
            }
            else
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Password did not match.";
            }

            if (result)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Your password has been reset." + Environment.NewLine +
                                     "Please close the browser window.";

                Response.Redirect("Login.aspx");

            }
        }
        catch(Exception ex)
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }
    }

    public bool resetpassword(string newpassword, string resource)
    {
        try
        {
            DAL.ConnectionString = ConfigurationManager.AppSettings["myConnectionStringA"].ToString();
            DAL.Provider = EnumProviders.MySQL;
            DAL.CmdTimeout = 1;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("_newpassword", newpassword);
            param.Add("_resourceid", resource);

            DAL.ExecNonQuery("resetpassword", System.Data.CommandType.StoredProcedure, param);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
}