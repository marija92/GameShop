using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {        
        SqlConnection konekcija = new SqlConnection();
        
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "INSERT INTO users(first_name,last_name,username, email, password, game_type) VALUES (@fn,@ln,@un,@em,@ps,@gt) ";
        komanda.Parameters.AddWithValue("@fn", txtName.Text);
        komanda.Parameters.AddWithValue("@ln", txtLastName.Text);
        komanda.Parameters.AddWithValue("@un", txtUserName.Text);
        komanda.Parameters.AddWithValue("@ps", txtPassword.Text);
        komanda.Parameters.AddWithValue("@em", txtEmail.Text);
        komanda.Parameters.AddWithValue("@gt", txtType.Text);

        int ef = 0; ;
        try
        {
            konekcija.Open();
           ef= komanda.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            lblPoraka.Text = ex.Message;
        }
        finally
        {
            konekcija.Close();
        }

        if (ef != 0)
        {
            lblPoraka.Text = "Успешно се регистриравте";
            txtConfirm.Text = "";
            txtEmail.Text = "";
            txtLastName.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtType.Text = "";
            txtUserName.Text = "";
        }
         
    }
}