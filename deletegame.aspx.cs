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

        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "UPDATE game SET  name=@ImeNaKompanija,  pic_location=@c, game_type=@g, description=@d,  price=@p,  num_avail=@n WHERE id=@id";
    
        com.Parameters.AddWithValue("@ImeNaKompanija", name.Text);
        com.Parameters.AddWithValue("@c", pic_location.Text);             
        com.Parameters.AddWithValue("@g", game_type.Text);
        com.Parameters.AddWithValue("@d", description.Text);
        com.Parameters.AddWithValue("@p", price.Text);
        com.Parameters.AddWithValue("@n", num_avail.Text);
        com.Parameters.AddWithValue("@id", id);

        
       
        int ef = 0;
        try
        {
            con.Open();
            ef = com.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            gridView.EditIndex = -1;
        }
        finally
        {

            con.Close();
        }
        if (ef != 0)
        {
            loadGames();
            lblmsg.Text = "Успешно апдејтиравте игра!";
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