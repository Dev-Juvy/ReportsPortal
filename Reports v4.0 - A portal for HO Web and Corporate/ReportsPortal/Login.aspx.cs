using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TripleDES;
using AESEncrypt;
using MySql.Data.MySqlClient;
using System.IO;


public partial class Login_Login : System.Web.UI.Page
{
    AESEncrypt.AESEncryption EnCrypt = new AESEncrypt.AESEncryption();
    int ReportType;
    Boolean connect = false ;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        ReportType = Convert .ToInt32 ( Request.QueryString["RptType"]);

        if (ReportType == 1)
        {
            FlashControl1.Visible = false;
            radionBut.Visible = true;
            uname.Visible = true;
            Label1.Visible = true;
            Username.Visible = true;
            Password.Visible = true;
            uname.Visible = true;
            pword.Visible = true;
            Button1.Visible = true;
            Label3.Visible = true;
        }
        else
        {
            radionBut.Visible = false;
            uname.Visible = false;
            Label1.Visible = false;
            Username.Visible = false;
            Password.Visible = false;
            uname.Visible = false;
            pword.Visible = false;
            Button1.Visible = false;
            connect = false;
            Label3.Visible = false;
            fplink.Visible = false;
        }       
    }
    private void GETurl()
    {
        
        if (Username.Text == string.Empty || Password.Text == string.Empty)
        {
            Username.Enabled = true;
            Password.Enabled = true;

            if (radionBut.SelectedIndex == 5)
            {
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["FileTransmit"];
                System.Web.HttpContext.Current.Response.Redirect(URLP);
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else
            {
                Response.Write("<script language=javascript>alert(' Please provide username and password ')</script>");
            }
        }
        else
        {
            Username.Enabled = true;
            Password.Enabled = true;

            if (radionBut.SelectedIndex == 0)
            {
                TripleDES.cTripleDES des = new TripleDES.cTripleDES("m1");

                string URLG = string.Empty;
                URLG = ConfigurationManager.AppSettings["Global"];

                string passencode  = EnCrypt.AESEncrypt(Password.Text, "kWuYDGElyQDpGKM9");
                System.Web.HttpContext.Current.Response.Redirect(URLG + "?user=" + Username.Text + "&pass=" + HttpUtility.UrlEncode (passencode) );
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 1)
            {

                TripleDES.cTripleDES des = new TripleDES.cTripleDES("");
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["PartnersUS"];
                string passencode = EnCrypt.AESEncrypt(Password.Text, "kWuYDGElyQDpGKM9");
                System.Web.HttpContext.Current.Response.Redirect(URLP );
                //System.Web.HttpContext.Current.Response.Redirect(URLP + "?user=" + Username.Text + "&pass=" + HttpUtility.UrlEncode(passencode));
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 2)
            {
                TripleDES.cTripleDES des = new TripleDES.cTripleDES("m1");
                string URLD = string.Empty;
                URLD = ConfigurationManager.AppSettings["Domestic"];
                string passencode = EnCrypt.AESEncrypt(Password.Text, "kWuYDGElyQDpGKM9");
                System.Web.HttpContext.Current.Response.Redirect(URLD + "?user=" + Username.Text + "&pass=" + HttpUtility.UrlEncode(passencode));
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 3)
            {

                TripleDES.cTripleDES des = new TripleDES.cTripleDES("");
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["PartnersPhils"];
                string passencode = EnCrypt.AESEncrypt(Password.Text, "kWuYDGElyQDpGKM9");
                System.Web.HttpContext.Current.Response.Redirect(URLP + "?user=" + Username.Text + "&pass=" + HttpUtility.UrlEncode(passencode));
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
           
            else if (radionBut.SelectedIndex == 4)
            {
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["FileUpload"];
                System.Web.HttpContext.Current.Response.Redirect(URLP + "?UserId=" + Username.Text + "&AccountId=" + Password.Text);
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 5)
            {
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["FileTransmit"];
                System.Web.HttpContext.Current.Response.Redirect(URLP);
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 6)
            {
                string usercode = EnCrypt.AESEncrypt(Username.Text, "kWuYDGElyQDpGKM9");
                string k = EnCrypt.AESEncrypt("FileTransmit2", "kWuYDGElyQDpGKM9");
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["FileTransmit2"];
                //System.Web.HttpContext.Current.Response.Redirect(URLP + "?acctid=" + Username.Text + "&acctpass=" + Password.Text);
                System.Web.HttpContext.Current.Response.Redirect(URLP + "?session=" + usercode + "&acctid=" + Username.Text + "&m=" + k + "&acctcode=" + Password.Text + "&065460306");
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else if (radionBut.SelectedIndex == 7)
            {
                string usercode = EnCrypt.AESEncrypt(Username.Text, "kWuYDGElyQDpGKM9");
                string k = EnCrypt.AESEncrypt("FileTransmit3", "kWuYDGElyQDpGKM9");
                string URLP = string.Empty;
                URLP = ConfigurationManager.AppSettings["FileTransmit3"];
                //System.Web.HttpContext.Current.Response.Redirect(URLP + "?acctid=" + Username.Text + "&acctpass=" + Password.Text);
                System.Web.HttpContext.Current.Response.Redirect(URLP + "?session=" + usercode + "&acctid=" + Username.Text + "&m=" + k + "&acctcode=" + Password.Text + "&065460306");
                Username.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else
            {
                Response.Write("<script language=javascript>alert(' Please select Reports to Open ')</script>");
            }
        }

    }

    protected void authenticateuser(string URLP,string _username, string _password) 
    { 
        MySqlCommand cmd  = new MySqlCommand();
        MySqlDataReader dr  = null;
        try
        {
             string Constring = ConfigurationManager.ConnectionStrings["KPFileUploadA"].ConnectionString;
             MySqlConnection mycon = new MySqlConnection(Constring);
             mycon.Open();
             cmd = mycon.CreateCommand();
             cmd.CommandText = "SELECT p.userid,p.password,p.accountid,CONCAT(p.Firstname,' ',p.Lastname) AS Fullname,a.integrationtype,p.RoleID FROM kpadminpartners.partnersusers p INNER JOIN kpadminpartners.accountintegration a ON a.accountid=p.accountid WHERE userid = '" + _username + "' AND password = '" + _password + "' and p.isActive=1 AND SUBSTRING(p.accountid,1,5)!='MLBPP' AND a.integrationtype IN ('2','4') ";
             dr = cmd.ExecuteReader();
             if (dr.HasRows == true)
             {
                 //System.Web.HttpContext.Current.Response.Redirect(URLP + "?user=" + _username + "&pass=" + HttpUtility.UrlEncode(_password));
                 System.Web.HttpContext.Current.Response.Redirect(URLP);
             }
             else 
             {
                 Username.Text = string.Empty;
                 Password.Text = string.Empty;
             }
        }
        catch
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        

        if (IsPostBack)
        {
            GETurl();
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (radionBut.SelectedIndex == 6 || radionBut.SelectedIndex == 7)
            {
                // Specify a name for your top-level folder.
                string folderName = @"c:\FTPUsers";

                System.IO.Directory.CreateDirectory(folderName);

                string[] filesInDir = Directory.GetFiles(folderName, Username.Text + "*");
                foreach (string foundFile in filesInDir) {
                    System.IO.File.Delete(foundFile); 
                }

                // Create a file name for the file you want to create. 
                //string fileName = EnCrypt.AESEncrypt(Username.Text, "kWuYDGElyQDpGKM9") + DateTime.Now.Ticks + ".txt";
                string fileName = Username.Text + EnCrypt.AESEncrypt(Username.Text, "kWuYDGElyQDpGKM9").Replace("\\", "_").Replace("/", "_") + ".txt";

                // This example uses a random string for the name, but you also can specify
                // a particular name.
                //string fileName = "MyNewFile.txt";

                // Use Combine again to add the file name to the path.
                folderName = System.IO.Path.Combine(folderName, fileName);
                // Check that the file doesn't already exist. If it doesn't exist, create
                // the file and write integers 0 - 99 to it.
                // DANGER: System.IO.File.Create will overwrite the file if it already exists.
                // This could happen even with random file names, although it is unlikely.
                string[] lines = { "Username : " + Username.Text, "Password : " + EnCrypt.AESEncrypt(Password.Text, "kWuYDGElyQDpGKM9") };
                if (!System.IO.File.Exists(folderName) )
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(folderName)) { foreach (string line in lines) { file.WriteLine(line); } }
                }
                else
                {
                    return;
                }

                // Read and display the data from your file.
                try
                {
                    byte[] readBuffer = System.IO.File.ReadAllBytes(folderName);
                    foreach (byte b in readBuffer)
                    {
                        Console.Write(b + " ");
                    }
                    Console.WriteLine();
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //// Keep the console window open in debug mode.
                //System.Console.WriteLine("Press any key to exit.");
                //System.Console.ReadKey();

            }
            GETurl();
        }
    }
    protected void Username_TextChanged(object sender, EventArgs e)
    {
      
    }
    public string EncryptPassword(string txtPassword)
    {
        byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
        string encryptPassword = Convert.ToBase64String(passBytes);
        return encryptPassword;
    }

    public string DecryptPassword(string encryptedPassword)
    {
        byte[] passByteData = Convert.FromBase64String(encryptedPassword);
        string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
        return originalPassword;
    }
}
