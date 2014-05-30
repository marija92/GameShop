using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;

public partial class addgame : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        String currentUser = (String)Session["korisnik"];
        if (currentUser != "admin") {
            Response.Redirect("~/Welcome.aspx");
        }
    }

    protected void ReadPic(string name)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "Select pic_location from game where name=@name";
        komanda.Parameters.AddWithValue("@name", name);

        try
        {
            konekcija.Open();
            SqlDataReader reader = komanda.ExecuteReader();
            if (reader.Read())
            {
                Image1.ImageUrl = reader["pic_location"].ToString();

            }
        }
        catch (Exception ex)
        {
            lblPoraka.Text = ex.Message;
        }
        finally
        {
            konekcija.Close();
        }

    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "INSERT INTO game(name,pic_location,game_type,description,price,num_avail) VALUES (@fn,@ln,@un,@em,@ps,@e) ";
        komanda.Parameters.AddWithValue("@fn", txtName.Text);
        string filename = lblPicName.Text;
        string path = Server.MapPath("~/") + filename;
        komanda.Parameters.AddWithValue("@ln", path);
        komanda.Parameters.AddWithValue("@un", txtUserName.Text);
        komanda.Parameters.AddWithValue("@ps", txtPassword.Text);
        komanda.Parameters.AddWithValue("@em", txtEmail.Text);
        komanda.Parameters.AddWithValue("@e", txtConfirm.Text);



        int ef = 0; ;
        try
        {
            konekcija.Open();
            ef = komanda.ExecuteNonQuery();
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
            lblPoraka.Text = "Успешно додадовте игра!";
        }

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                {
                    if (FileUploadControl.PostedFile.ContentLength < 1002400)
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("~/") + filename);

                        StatusLabel.Text = "Upload status: File uploaded! ";
                        lblPicName.Text = FileUploadControl.FileName;
                    }
                    else
                        StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                }
                else
                    StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }

}