using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["korisnik"] == null) {
            Response.Redirect("Welcome.aspx");
        }

        else if (!IsPostBack) {

            Session["korisnik"] = null;

            HttpCookie cookie = Request.Cookies["rememberme"];
            if (cookie != null) {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.SetCookie(cookie);
            }

            Response.Redirect("Welcome.aspx");
        
        }
    }
}