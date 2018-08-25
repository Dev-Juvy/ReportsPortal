using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Global
/// </summary>
public static class Global
{

    static DataTable _dtsecurequestions;
    static string _resourceid;
    static dynamic _scripts;
    static Dictionary<int, string> _dic;
    static Dictionary<int, string> _updic;
    static string _code;
    static string _emailadd;
    static string _password;
    static string _roleid;
    static int _MAilStatus;
    static int _step = 0;


    #region MAilStatus
    public static int MAilStatus
    {
        get { return _MAilStatus; }
        set { _MAilStatus = value; }
    }
    #endregion


    #region RoleID
    public static string RoleID
    {
        get { return _roleid; }
        set { _roleid = value; }
    }
    #endregion

    #region Password
    public static string password
    {
        get { return _password; }
        set { _password = value; }
    }
    #endregion

    #region Step
    public static int Step
    {
        get 
        {
            return _step;
        }
        set 
        {
            _step = value;
        }
    }
    #endregion

    #region getCode
    public static String getCode
    {
        get
        {
            return _code;
        }
        set
        {
            _code = value;
        }
    }
    #endregion

    #region EmailAddress
    public static String GetEmail
    {
        get
        {
            return _emailadd;
        }
        set
        {
            _emailadd = value;
        }
    }
    #endregion

    #region SecureQuestions
    public static DataTable securequestions
    {
        get
        {
            return _dtsecurequestions;
        }
        set
        {
            _dtsecurequestions = value;
        }
    }
    #endregion
    
    #region Resource ID
    public static string resourceid
    {
        get
        {
            return _resourceid;
        }
        set
        {
            _resourceid = value;
        }
    }
    #endregion
    
    #region Scripts
    public static dynamic scripts
    {
        get
        {
            return _scripts;
        }
        set
        {
            _scripts = value;
        }
    }
    #endregion

    #region securityDictionary
    public static Dictionary<int,string> securityDictionary
    {
        get
        {
            return _dic;
        }
        set
        {
            _dic = value;
        }
    }
    #endregion

    #region updatedsecurityDictionary
    public static Dictionary<int, string> updatedsecurityDictionary
    {
        get
        {
            return _updic;
        }
        set
        {
            _updic = value;
        }
    }
    #endregion
}