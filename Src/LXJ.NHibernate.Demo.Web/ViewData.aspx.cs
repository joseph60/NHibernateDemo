using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LXJ.NHibernate.Demo.Model.Auth;

public partial class ViewData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetList();
        }
    }

    private void GetList()
    {
        this.GridView1.DataSource = LXJ.NHibernate.Demo.BLL.Auth.UserManager.GetList();
        this.GridView1.DataBind();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string user_id = this.txtUSER_ID.Text;
        string user_name = this.txtUSER_NAME.Text;
        string password = this.txtPASSWORD.Text;
        if (LXJ.NHibernate.Demo.BLL.Auth.UserManager.Exists(user_id))
        {
            this.labelMSG.Text = "存在此USER_ID:" + user_id;
        }
        else
        {
            UserInfo user = new UserInfo();
            user.USER_ID = user_id;
            user.USER_NAME = user_name;
            user.PASSWORD = password;

            if (LXJ.NHibernate.Demo.BLL.Auth.UserManager.Insert(user))
            {
                labelMSG.Text = "新增成功";
                this.txtUSER_ID.Text = "";
                this.txtUSER_NAME.Text = "";
                this.txtPASSWORD.Text = "";

                this.GetList();
            }
            else
            {
                labelMSG.Text = "新增失败";
            }
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        this.GetList();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string user_id = this.GridView1.Rows[e.RowIndex].Cells[0].Text;
        string user_name = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].FindControl("txtROW_USER_NAME")).Text;

        UserInfo user = new UserInfo();
        user.USER_ID = user_id;
        user.USER_NAME = user_name;

        if (LXJ.NHibernate.Demo.BLL.Auth.UserManager.Update(user))
        {
            labelMSG.Text = "更新成功";
            this.GridView1.EditIndex = -1;
            this.GetList();
        }
        else
        {
            labelMSG.Text = "更新失败";
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        this.GetList();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string user_id = this.GridView1.Rows[e.RowIndex].Cells[0].Text;
        LXJ.NHibernate.Demo.BLL.Auth.UserManager.Delete(user_id);
        this.GetList();
        labelMSG.Text = "";
    }
}
