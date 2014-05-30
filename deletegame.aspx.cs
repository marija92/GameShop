using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class deletegame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGames();
        }
    }

    protected void loadGames()
    {
        String currentUser = (String)Session["korisnik"];
        if (currentUser != "admin")
        {
            Response.Redirect("~/Welcome.aspx");
        }
        else {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            con.Open();

           
            SqlCommand cmd = new SqlCommand("Select * from game", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Game");
            int count = ds.Tables[0].Rows.Count;
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gridView.DataSource = ds;
                gridView.DataBind();
                int columncount = gridView.Rows[0].Cells.Count;
                lblmsg.Text = " No data found !!!";
            }
        }
        
    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridView.EditIndex = e.NewEditIndex;
        loadGames();
    }
    protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        //marta
       // con.ConnectionString = "Data Source=dell-PC\\SQLEXPRESS;Integrated Security=True";


        string id = gridView.DataKeys[e.RowIndex].Values["id"].ToString();
        TextBox name = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtname");
        TextBox pic_location = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtlocation");
        TextBox game_type = (TextBox)gridView.Rows[e.RowIndex].FindControl("txttype");
        TextBox description = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtdes");
        TextBox price = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtprice");
        TextBox bought = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtb");
        TextBox num_avail = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtnum");


        try
        {
            con.Open();
             SqlCommand cmd = new SqlCommand("update game set name='" + name.Text + "', pic_location='" + pic_location.Text + "', game_type='" + game_type.Text + "', description='" + description.Text + "', price='" + price.Text + "', bought='" + bought.Text + "', num_avail='" + num_avail.Text + "' where id=" + id, con);

            cmd.ExecuteNonQuery();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = id + "        Успешно направена промена!!!    ";
            gridView.EditIndex = -1;
            loadGames();
        }
        catch (Exception err) {
            lblmsg.Text = err.Message;
        }
        finally
        {
            con.Close();
        }

       
    }
    protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridView.EditIndex = -1;
        loadGames();
    }
    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        //marta
       // con.ConnectionString = "Data Source=dell-PC\\SQLEXPRESS;Integrated Security=True";

        string id = gridView.DataKeys[e.RowIndex].Values["id"].ToString();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from game where id=" + id, con);

        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            loadGames();
            lblmsg.BackColor = Color.Red;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = id + "      Успeшно избришана игра!!!    ";
        }
    }
    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + id + "')");
            }
        }
    }
    
}