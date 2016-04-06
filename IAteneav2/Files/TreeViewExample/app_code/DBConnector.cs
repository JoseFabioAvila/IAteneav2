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
public class DBConnector
{
    private ConnectionManager _ConnectionManager = null;
    private SqlConnection _sqlConnection = null;

    public DBConnector()
    {
        //
        // TODO: Add constructor logic here
        //
        _ConnectionManager = ConnectionManager.GetConnectionInstance();
        _sqlConnection = _ConnectionManager.GetConnection();
    }

    public int ExecuteSqlQuery(string sql)
    {
        SqlCommand _sqlCommand = new SqlCommand(sql, _sqlConnection);
        int iReturn = _sqlCommand.ExecuteNonQuery();
        return iReturn;
    }

    public SqlDataReader ExecuteQueryReader(string sql)
    {
        SqlCommand _sqlCommand = new SqlCommand(sql, _sqlConnection);
        SqlDataReader qlDataReader = _sqlCommand.ExecuteReader();
        return qlDataReader;
    }

    public DataSet ExecuteDataSet(string sql)
    {
        SqlCommand _sqlCommand = new SqlCommand(sql, _sqlConnection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return dataSet;
    }
}
