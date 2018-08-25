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


public partial class SecurityCode : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (string.IsNullOrEmpty(Global.resourceid))
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


            string path = HttpRuntime.AppDomainAppPath + "Bin\\System.configuration.dll";
            string path1 = HttpRuntime.AppDomainAppPath + "Bin\\System.Data.dll";
            CSScript.Evaluator.ReferenceAssembly(@"" + path + "");
            CSScript.Evaluator.ReferenceAssembly(@"" + path1 + "");

            dynamic pass = CSScript.Evaluator
                                   .LoadCode(@"" + m1 + "");

            bool IsExpired = (bool)pass.IsCodeExpire(DateTime.Now);

            bool IsMatch = (bool)pass.comparecode(Convert.ToInt32(Global.resourceid), this.securitycodeid.Text);

            if (IsExpired)
            {
                if (IsMatch)
                {
                    //Connect to MasterA to tag a code was used.
                    DAL.ConnectionString = ConfigurationManager.AppSettings["myConnectionStringA"].ToString();
                    DAL.Provider = EnumProviders.MySQL;
                    DAL.CmdTimeout = 1;

                    //Adding parameter to the stored procedure 
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("_resourceid",Global.resourceid);

                    //Execute update 
                    DAL.ExecNonQuery("codeisused", System.Data.CommandType.StoredProcedure,param);

                    Response.Redirect("ForgotPassword.aspx", false);
                }
                else
                {
                    this.ConfirmSave.Visible = true;
                    this.popupmsg.Text = "You have entered an invalid code.";
                }
            }
            else 
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Your code has expired.";
            }
            Global.Step = 3;
        }
        catch (Exception ex) 
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }


        
    } 

    

}

