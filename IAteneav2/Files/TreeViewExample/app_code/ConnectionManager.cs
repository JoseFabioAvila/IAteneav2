using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for DBConnector
/// </summary>
public class ConnectionManager
{
    private static ConnectionManager _ConnectionManager = null;
    private static SqlConnection _sqlConnection = null;

    private ConnectionManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static ConnectionManager GetConnectionInstance()
    {
        if (_ConnectionManager == null)
        {
            _ConnectionManager = new ConnectionManager();
        }

        return _ConnectionManager;
    }

    public SqlConnection GetConnection()
    {
        string _sqlConnectionString = ConfigurationManager.ConnectionStrings["ExamplesConnectionString"].ToString();
        _sqlConnection = new SqlConnection(_sqlConnectionString);

        if (_sqlConnection.State != ConnectionState.Open)
        {
            _sqlConnection.Open();
        }

        return _sqlConnection;
    }
}
