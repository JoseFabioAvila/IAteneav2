using System;
using System.Data;
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
/// Summary description for BusinessLogics
/// </summary>
public class BusinessLogics
{
	private DBConnector _DBConnector = null;
    
    /// <summary>
    /// constrctor
    /// </summary>
    public BusinessLogics()
	{
		//
		// TODO: Add constructor logic here
		//
        _DBConnector = new DBConnector();
	}

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>    
    public DataSet GetAllDatabases()
    {
        DataSet dataSet = null;

        try
        {
            string strRetrievalQuery = "SELECT * FROM SYS.DATABASES";
            dataSet = new DataSet();
            dataSet = _DBConnector.ExecuteDataSet(strRetrievalQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataSet;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>    
    public DataSet GetAllTables(string strRetrievalQuery)
    {
        DataSet dataSet = null;

        try
        {
            dataSet = new DataSet();
            dataSet = _DBConnector.ExecuteDataSet(strRetrievalQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataSet;
    }
}
