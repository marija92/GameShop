using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class recomended : System.Web.UI.Page
{
    public static Dictionary<string, int> dic = new Dictionary<string, int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<string, int> dic = (Dictionary<string, int>)Session["kosnicka"];

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "Select * from game where game_type=@type";
        komanda.Parameters.AddWithValue("@type", getFavouriteType((string)Session["korisnik"]));
       
        try
        {
            konekcija.Open();
            SqlDataReader reader = komanda.ExecuteReader();

            while (reader.Read())
            {
                string[] path = (reader["pic_location"].ToString()).Split('\\');
                string img = path[path.Count() - 1];
                string name = reader["name"].ToString();
                string id = reader["id"].ToString();
                string price = reader["price"].ToString();
                string description = Truncate(reader["description"].ToString(), 80);

                //glaven div
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv" + id;
                createDiv.Attributes.Add("class", "col-lg-3 col-md-6 hero-feature");

                //image div
                System.Web.UI.HtmlControls.HtmlGenericControl imgDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                imgDiv.ID = "imgDiv" + id;

                imgDiv.Attributes.Add("class", "thumbnail");
                imgDiv.Attributes.Add("style", "height: 377px;");

                //inner div
                System.Web.UI.HtmlControls.HtmlGenericControl inDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                inDiv.ID = "in" + id;
                inDiv.Attributes.Add("class", "caption");

                //new image
                Image imageProduct = new Image();
                imageProduct.ID = "img" + id;
                imageProduct.ImageUrl = "img/" + img;
                imageProduct.Width = 245;
                imageProduct.Height = 153;
                imgDiv.Controls.Add(imageProduct);

                //name, decription, price
                Label lname = new Label();
                lname.ID = "lblname" + id;
                lname.Text = name;
                lname.Font.Bold = true;
                lname.Font.Size = 14;
                inDiv.Controls.Add(lname);
                inDiv.Controls.Add(new LiteralControl("<br />"));

                Label lprice = new Label();
                lprice.ID = "lprice" + id;
                lprice.Text = price + "$";
                inDiv.Controls.Add(lprice);
                inDiv.Controls.Add(new LiteralControl("<br />"));

                Label ldes = new Label();
                ldes.ID = "lbldes" + id;
                ldes.Text = description;
                inDiv.Controls.Add(ldes);
                inDiv.Controls.Add(new LiteralControl("<br />"));

                Button btn = new Button();
                btn.ID = id;
                btn.Text = "Купи";
                btn.Attributes.Add("class", "btn btn-primary");
                btn.Click += new EventHandler(btn_Click);
                inDiv.Controls.Add(btn);


                imgDiv.Controls.Add(inDiv);
                createDiv.Controls.Add(imgDiv);
                cont.Controls.Add(createDiv);

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            konekcija.Close();
        }
    }


    protected void btn_Click(object sender, EventArgs e)
    {
        if (Session["korisnik"] != null)
        {
            Button b = (Button)sender;
            string id = b.ID;
            if (dic.ContainsKey(id))
            {
                dic[id] = dic[id] + 1;
            }
            else
            {
                dic.Add(id, 1);
            }

            Session["kosnicka"] = dic;
            Console.WriteLine(Session["kosnicka"].ToString());
            Response.Redirect("~/cart.aspx");
        }
        else
        {

            String script = "$(document).ready(function(){$(\"#modal\").modal('show')})";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", script, true);

        }

    }

    public string Truncate(string value, int maxChars)
    {
        return value.Length <= maxChars ? value : value.Substring(0, maxChars) + " ...";
    }

    public string getFavouriteType(string user) {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "Select game_type from users where username=@u";
        komanda.Parameters.AddWithValue("@u", user);
        string a = user;
        Console.WriteLine(a);

        string type="";

        try
        {
            konekcija.Open();
            SqlDataReader reader = komanda.ExecuteReader();

            if (reader.Read())
            {
                type = reader[0].ToString();          

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            konekcija.Close();
        }

        return type;
    }

    


    
}