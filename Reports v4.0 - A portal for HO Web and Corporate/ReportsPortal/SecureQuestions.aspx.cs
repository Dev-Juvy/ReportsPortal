using System;
using System.Data;
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


public partial class SecureQuestions : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    Dictionary<int, string> dic = new Dictionary<int, string>();
    string resourceid = string.Empty;
    DataTable dtresult = new DataTable();
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

            dtresult = rnd.getrandomquestions(Global.resourceid);

            Global.securequestions = dtresult;

            this.drp1.Items.Insert(0, dtresult.Rows[0][1].ToString());
            this.drp2.Items.Insert(0, dtresult.Rows[1][1].ToString());
            this.drp3.Items.Insert(0, dtresult.Rows[2][1].ToString());
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try 
        {
            if (this.ans1.Text == string.Empty & this.ans2.Text == string.Empty & this.ans3.Text == string.Empty) 
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "You must have to answer all security questions.";
                return;
            }

            if (this.ans1.Text == Global.securequestions.Rows[0][2].ToString() & this.ans2.Text == Global.securequestions.Rows[1][2].ToString() & this.ans3.Text == Global.securequestions.Rows[2][2].ToString())
            {
                Response.Redirect("ForgotPassword.aspx", false);
            }
            else
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Please verify your answers.";
            }
            Global.Step = 3;
        }
        catch(Exception ex)
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }
        
    }



}