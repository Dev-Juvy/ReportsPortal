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



public partial class Resource : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            

            if(this.resourceid.Text == string.Empty)
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

            Global.scripts = pass;

            Global.resourceid = this.resourceid.Text;

            //int result1 = pass.IsFormClose(this.resourceid.Text);
            int result1 = IsFormClose(this.resourceid.Text);

            if(result1 == 0)
            {
                Response.Redirect("SecurityCode.aspx", false);
                return;
            }

     
            int result = verifydetails(this.resourceid.Text);
         

            if(Global.RoleID.ToUpper() != string.Empty )
            {
                if (Global.RoleID.ToUpper() == "KP-HELPDESK" | Global.RoleID.ToUpper() == "KP-MISHELPDESK")
                {
                    Response.Redirect("HelpdeskAuth.aspx", false);
                    return;
                }
            }

            if (result == 2) 
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Access denied."; 
            }
            else if (result== 0)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Please contact MIS Helpdesk for support.";
            }
            else
            {
                bool _hasq = (bool)pass.hasquestions(this.resourceid.Text);
                if (_hasq)
                {
                    Global.resourceid = this.resourceid.Text;
                    Response.Redirect("SecureQuestions.aspx", false);
                }
                else
                {
                    Global.resourceid = this.resourceid.Text;
                    Response.Redirect("SecurityQuestions.aspx", false);
                }
            };
            Global.Step = 1;
        }
        catch (Exception ex) 
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }
    }

    public int IsFormClose(string resourceid)
    {
        try 
        {
            MySqlDataReader dr = null;
            string m1 = string.Empty;
            DAL.ConnectionString = ConfigurationManager.AppSettings["myConnectionStringB"].ToString();
            DAL.Provider = EnumProviders.MySQL;
            DAL.CmdTimeout = 1;

            dr = (MySqlDataReader)DAL.ExecScalar("SELECT IsUsed FROM securitycode WHERE resourceid=" + resourceid + "", CommandType.Text);

            if (dr.Read())
            {
                return Convert.ToInt16(dr["IsUsed"]);
            }
            else 
            {
                return 1;
            }
        }
        catch(Exception ex)
        {
            return 1;
        }
        return 1;
    }

    public int verifydetails(string resource)
    {

        try
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

                if (Global.RoleID == null)
                { Global.RoleID = string.Empty; }

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
            if (Global.RoleID == null)
            { Global.RoleID = string.Empty; }
            return 2;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        { }
    }
    
}

