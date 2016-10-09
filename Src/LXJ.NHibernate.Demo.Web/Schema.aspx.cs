using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NHibernate;
using NHibernate.Tool.hbm2ddl;

public partial class Schema : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateSchema_Click(object sender, EventArgs e)
    {
        if (LXJ.NHibernate.Demo.BLL.SchemaManager.Create())
        {
            LXJ.NHibernate.Demo.BLL.SchemaManager.Init();
            Status.Text = "Schema created";
        }
        else
        {
            Status.Text = "Create schema failure";
        }
    }

    protected void DropSchema_Click(object sender, EventArgs e)
    {
        try
        {
            if (LXJ.NHibernate.Demo.BLL.SchemaManager.Drop())
            {
                Status.Text = "Schema dropped";
            }
            else
            {
                Status.Text = "Dropp schema failure";
            }
        }
        catch (Exception ex)
        {
            Status.Text = ex.Message;
        }
    }
}
