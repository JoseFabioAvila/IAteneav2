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

public partial class SqlTreeChart : System.Web.UI.Page
{
    private BusinessLogics businessLogics = new BusinessLogics();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindTree();
        }
    }

    private void BindTree()
    {
        TreeNode _TreeNode = null;
        TreeNode _TreeObjectNode = null;

        DataSet _DataSet = businessLogics.GetAllDatabases();

        for (int i = 0; i < _DataSet.Tables[0].Rows.Count; i++)
        {
            _TreeNode = new TreeNode();
            _TreeNode.Text = _DataSet.Tables[0].Rows[i][0].ToString();
            _TreeNode.Value = _DataSet.Tables[0].Rows[i][1].ToString();
            _TreeNode.Expanded = false;
            SqlTree.Nodes.Add(_TreeNode);

            //Tables
            _TreeObjectNode = new TreeNode();
            _TreeObjectNode.Text = "Tables";
            _TreeObjectNode.Value = "Tables";
            _TreeNode.ChildNodes.Add(_TreeObjectNode);

            //Tables under DB
            TreeNode _TableTree = null;
            string strTableQuery = "SELECT * FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".SYS.TABLES";
            DataSet _DataSetTables = businessLogics.GetAllTables(strTableQuery);

            for (int j = 0; j < _DataSetTables.Tables[0].Rows.Count; j++)
            {
                _TableTree = new TreeNode();
                _TableTree.Text = _DataSetTables.Tables[0].Rows[j][0].ToString();
                _TableTree.Value = _DataSetTables.Tables[0].Rows[j][1].ToString();
                _TreeObjectNode.ChildNodes.Add(_TableTree);

                //Columns under tables

                TreeNode _TabColumnsTree = null;
                string strTabColumnsQuery = "SELECT  name,(SELECT TOP 1 ST.name FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".SYS.TYPES ST WHERE ST.system_type_id = SC.system_type_id) AS [Type] FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".SYS.COLUMNS SC WHERE object_ID =" + _DataSetTables.Tables[0].Rows[j][1].ToString();
                DataSet _DataSetTabColumns = businessLogics.GetAllTables(strTabColumnsQuery);

                for (int a = 0; a < _DataSetTabColumns.Tables[0].Rows.Count; a++)
                {
                    _TabColumnsTree = new TreeNode();
                    _TabColumnsTree.Text = _DataSetTabColumns.Tables[0].Rows[a][0].ToString() + " " + _DataSetTabColumns.Tables[0].Rows[a][1].ToString();
                    _TabColumnsTree.Value = _DataSetTabColumns.Tables[0].Rows[a][0].ToString();
                    _TableTree.ChildNodes.Add(_TabColumnsTree);
                }
            }

            //Views
            _TreeObjectNode = new TreeNode();
            _TreeObjectNode.Text = "Views";
            _TreeObjectNode.Value = "Views";
            _TreeNode.ChildNodes.Add(_TreeObjectNode);

            //Views under DB
            TreeNode _ViewsTree = null;
            string strViewsQuery = "SELECT * FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".SYS.VIEWS";
            DataSet _DataSetViews = businessLogics.GetAllTables(strViewsQuery);

            for (int k = 0; k < _DataSetViews.Tables[0].Rows.Count; k++)
            {
                _ViewsTree = new TreeNode();
                _ViewsTree.Text = _DataSetViews.Tables[0].Rows[k][0].ToString(); ;
                _ViewsTree.Value = _DataSetViews.Tables[0].Rows[k][1].ToString(); ;
                _TreeObjectNode.ChildNodes.Add(_ViewsTree);
            }

            //Stored Procedures
            _TreeObjectNode = new TreeNode();
            _TreeObjectNode.Text = "Stored Procedures";
            _TreeObjectNode.Value = "SP";
            _TreeNode.ChildNodes.Add(_TreeObjectNode);

            //SP under DB
            TreeNode _SPsTree = null;
            string strSPsQuery = "SELECT * FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".SYS.procedures";
            DataSet _DataSetSPs = businessLogics.GetAllTables(strSPsQuery);

            for (int m = 0; m < _DataSetSPs.Tables[0].Rows.Count; m++)
            {
                _SPsTree = new TreeNode();
                _SPsTree.Text = _DataSetSPs.Tables[0].Rows[m][0].ToString();
                _SPsTree.Value = _DataSetSPs.Tables[0].Rows[m][1].ToString();
                _TreeObjectNode.ChildNodes.Add(_SPsTree);
            }

            //Triggers
            _TreeObjectNode = new TreeNode();
            _TreeObjectNode.Text = "Triggers";
            _TreeObjectNode.Value = "Triggers";
            _TreeNode.ChildNodes.Add(_TreeObjectNode);

            //Triggers under DB
            TreeNode _TriggersTree = null;
            string strTriggersQuery = "SELECT * FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".sys.triggers";
            DataSet _DataSetTriggers = businessLogics.GetAllTables(strTriggersQuery);

            for (int n = 0; n < _DataSetTriggers.Tables[0].Rows.Count; n++)
            {
                _TriggersTree = new TreeNode();
                _TriggersTree.Text = _DataSetTriggers.Tables[0].Rows[n][0].ToString();
                _TriggersTree.Value = _DataSetTriggers.Tables[0].Rows[n][1].ToString();
                _TreeObjectNode.ChildNodes.Add(_TriggersTree);
            }

            //Functions
            _TreeObjectNode = new TreeNode();
            _TreeObjectNode.Text = "Functions";
            _TreeObjectNode.Value = "Functions";
            _TreeNode.ChildNodes.Add(_TreeObjectNode);

            //Functions under DB
            TreeNode _FunctionsTree = null;
            string strFunctionsQuery = "SELECT * FROM " + _DataSet.Tables[0].Rows[i][0].ToString() + ".information_schema.routines where routine_type='function'";
            DataSet _DataSetFunctions = businessLogics.GetAllTables(strFunctionsQuery);

            for (int p = 0; p < _DataSetFunctions.Tables[0].Rows.Count; p++)
            {
                _FunctionsTree = new TreeNode();
                _FunctionsTree.Text = _DataSetFunctions.Tables[0].Rows[p][0].ToString();
                _FunctionsTree.Value = _DataSetFunctions.Tables[0].Rows[p][1].ToString();
                _FunctionsTree.ChildNodes.Add(_FunctionsTree);
            }


        }
    }
}
