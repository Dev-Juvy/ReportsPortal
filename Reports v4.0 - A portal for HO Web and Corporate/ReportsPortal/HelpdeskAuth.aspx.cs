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

public partial class HelpdeskAuth : System.Web.UI.Page
{
    DAL.DataAccess DAL = new DAL.DataAccess();
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if(this.password.Text == string.Empty)
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Please enter password.";
                return;
            }

            if (this.password.Text == Global.password)
            {
                Session["helpdeskUser"] = Global.password;
                Response.Redirect("Helpdesk.aspx", false);
            }
            else 
            {
                this.ConfirmSave.Visible = true;
                this.popupmsg.Text = "Access denied.";
            }
        }
        catch (Exception ex) 
        {
            this.ConfirmSave.Visible = true;
            this.popupmsg.Text = ex.Message;
        }
        
    }
}

