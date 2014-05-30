using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String currentUser = (String)Session["korisnik"];
        if (currentUser == null || currentUser.Equals("admin"))
        {
            Response.Redirect("~/Welcome.aspx");
        }
        else {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

            Dictionary<string, int> games = (Dictionary<string, int>)Session["kosnicka"];

            if (games != null) {

                int sum = 0;

                for (int i = 0; i < games.Count(); i++)
                {
                    SqlCommand komanda = new SqlCommand();
                    komanda.Connection = konekcija;
                    komanda.CommandText = "Select * from game where id=@id";
                    komanda.Parameters.AddWithValue("@id", games.ElementAt(i).Key);
                    string a = games.ElementAt(i).Key;
                    Console.WriteLine(games.ElementAt(i).Key);

                    try
                    {
                        konekcija.Open();
                        SqlDataReader reader = komanda.ExecuteReader();

                        if (reader.Read())
                        {
                            string[] path = (reader["pic_location"].ToString()).Split('\\');
                            string img = path[path.Count() - 1];
                            string name = reader["name"].ToString();
                            string id = reader["id"].ToString();
                            string price = reader["price"].ToString();
                            string type = reader["game_type"].ToString();
                            int val = games.ElementAt(i).Value;

                            int tmp = Convert.ToInt32(price) * val;
                            sum += tmp;

                            //div row
                            System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            createDiv.ID = "createDiv" + id;
                            createDiv.Attributes.Add("class", "row");

                            //image div
                            System.Web.UI.HtmlControls.HtmlGenericControl imgDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            imgDiv.ID = "imgDiv" + id;
                            imgDiv.Attributes.Add("class", "col-xs-2");


                            //div ime tip
                            System.Web.UI.HtmlControls.HtmlGenericControl inDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            inDiv.ID = "in" + id;
                            inDiv.Attributes.Add("class", "col-xs-4");
                            inDiv.Attributes.Add("style", "width:40%");

                            //div price, value, button
                            System.Web.UI.HtmlControls.HtmlGenericControl bigDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            bigDiv.ID = "big" + id;
                            bigDiv.Attributes.Add("class", "col-xs-6");
                            bigDiv.Attributes.Add("style", "width:40%");

                            //div price
                            System.Web.UI.HtmlControls.HtmlGenericControl priceDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            priceDiv.ID = "p" + id;
                            priceDiv.Attributes.Add("class", "col-xs-6 text-right");

                            //div input
                            System.Web.UI.HtmlControls.HtmlGenericControl inputDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            inputDiv.ID = "i" + id;
                            inputDiv.Attributes.Add("class", "col-xs-4");

                            //div delete
                            System.Web.UI.HtmlControls.HtmlGenericControl deleteDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            deleteDiv.ID = "d" + id;
                            deleteDiv.Attributes.Add("class", "col-xs-2");
                            deleteDiv.Attributes.Add("class", "padding-top:8px");

                            //new image
                            Image imageProduct = new Image();
                            imageProduct.ID = "img" + id;
                            imageProduct.ImageUrl = "img/" + img;
                            imageProduct.Attributes.Add("class", "img-responsive");
                            imgDiv.Controls.Add(imageProduct);

                            //name, 
                            Label lname = new Label();
                            lname.ID = "lblname" + id;
                            lname.Text = name;
                            lname.Font.Bold = true;
                            lname.Attributes.Add("class", "product-name");
                            inDiv.Controls.Add(lname);
                            inDiv.Controls.Add(new LiteralControl("<br />"));

                            //type
                            Label ldes = new Label();
                            ldes.ID = "lbldes" + id;
                            ldes.Text = type;
                            ldes.Font.Size = 10;
                            inDiv.Controls.Add(ldes);
                            inDiv.Controls.Add(new LiteralControl("<br />"));

                            //price

                            Label lprice = new Label();
                            lprice.ID = "lprice" + id;
                            lprice.Text = price+" ден.";
                            lprice.Font.Size = 12;
                            lprice.Attributes.Add("class", "text-muted");
                            priceDiv.Controls.Add(lprice);
                            //inDiv.Controls.Add(new LiteralControl("<br />"));

                            //input value

                            TextBox tbvalue = new TextBox();
                            tbvalue.ID = "tb." + id;
                            tbvalue.Text = val.ToString();
                            tbvalue.TextChanged += new EventHandler(tbvalue_TextChanged);
                            tbvalue.Attributes.Add("class", "quantity form-control input-sm");
                            inputDiv.Controls.Add(tbvalue);


                            Button btn = new Button();
                            btn.ID = id;
                            btn.Text = "X";
                            btn.Font.Bold = true;
                            btn.Attributes.Add("class", "btn btn-danger btn-mini");
                            btn.CausesValidation = false;
                            btn.Click += new EventHandler(btn_Click);                            
                            deleteDiv.Controls.Add(btn);
                            


                            createDiv.Controls.Add(imgDiv);
                            createDiv.Controls.Add(inDiv);

                            bigDiv.Controls.Add(priceDiv);
                            bigDiv.Controls.Add(inputDiv);
                            bigDiv.Controls.Add(deleteDiv);

                            createDiv.Controls.Add(bigDiv);
                            div.Controls.Add(createDiv);
                            div.Controls.Add(new LiteralControl("<br />"));

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
                lblVkupno.Text = sum.ToString();
            }
        
            
            
            }

            
    }

    private void tbvalue_TextChanged(object sender, EventArgs e)
    {
        Dictionary<string, int> games = (Dictionary<string, int>)Session["kosnicka"];
        TextBox b = (TextBox)sender;
        string[] id = (b.ID).Split('.');
        string i = id[id.Count() - 1];
        if (games.ContainsKey(i))
        {
            games[i] = Convert.ToInt32(b.Text);
        }
        Session["kosnicka"] = games;
        Response.Redirect("cart.aspx");

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        if (Session["korisnik"] != null)
        {
            Dictionary<string, int> games = (Dictionary<string, int>)Session["kosnicka"];
            Button b = (Button)sender;
            string id = b.ID;
            if (games.ContainsKey(id))
            {
                games.Remove(id);
            }
            Session["kosnicka"] = games;
            Response.Redirect("cart.aspx");
        }
        else { 
        

        
        }

        
    }


    protected void btnKupi_Click(object sender, EventArgs e)
    {
        Dictionary<string, int> games = new Dictionary<string, int>();
        Session["kosnicka"] = games;
        //alert za uspesno kupuvanje
        String script = "$(document).ready(function(){$(\"#modal\").modal('show')})";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", script, true);
        Response.Redirect("cart.aspx");
    }
}