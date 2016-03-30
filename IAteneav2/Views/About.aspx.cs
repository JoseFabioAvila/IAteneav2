using Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2
{
    public partial class About : Page
    {

        Logic.AnalzarDisco inst = new Logic.AnalzarDisco();

        protected void Page_Load(object sender, EventArgs e)
        {

            string path = @"D:\Datos importantes fabio";
            TextBox1.Text = inst.GetFilesFromDirectory(path);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string extractPath = Server.MapPath("~/Files/");
            using (ZipFile zip = ZipFile.Read(FileUpload1.PostedFile.InputStream))
            {
                zip.ExtractAll(extractPath, ExtractExistingFileAction.DoNotOverwrite);
                GridView1.DataSource = zip.Entries;
                GridView1.DataBind();
            }
        }


        //    if (!IsPostBack)
        //    {
        //        GetTreeViewItems();
        //    }
        //}


        //private void GetTreeViewItems()
        //{
        //    string cs = "Data Source = DESKTOP - O5SA35M; Initial Catalog = BD_Conocimiento; Integrated Security = True";
        //    SqlConnection con = new SqlConnection(cs);

        //    SqlDataAdapter da = new SqlDataAdapter("select * from tableDir", con);
        //    con.Open();

        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"],
        //        ds.Tables[0].Columns["ParentId"]);

        //    foreach (DataRow level1DataRow in ds.Tables[0].Rows)
        //    {
        //        if (string.IsNullOrEmpty(level1DataRow["ParentId"].ToString()))
        //        {
        //            TreeNode parentTreeNode = new TreeNode();
        //            parentTreeNode.Text = level1DataRow["TreeViewText"].ToString();
        //            parentTreeNode.NavigateUrl = level1DataRow["NavigateURL"].ToString();
        //            GetChildRows(level1DataRow, parentTreeNode);
        //            Treeview1.Nodes.Add(parentTreeNode);
        //        }
        //    }
        //    con.Close();
        //}

        //private void GetChildRows(DataRow dataRow, TreeNode treeNode)
        //{
        //    DataRow[] childRows = dataRow.GetChildRows("ChildRows");
        //    foreach (DataRow row in childRows)
        //    {
        //        TreeNode childTreeNode = new TreeNode();
        //        childTreeNode.Text = row["TreeViewText"].ToString();
        //        childTreeNode.NavigateUrl = row["NavigateURL"].ToString();
        //        treeNode.ChildNodes.Add(childTreeNode);

        //        if (row.GetChildRows("ChildRows").Length > 0)
        //        {
        //            GetChildRows(row, childTreeNode);
        //        }
        //    }
        //}

    }
}