using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _21Nov
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1D.Text = Session["FirstName"].ToString();

            Label2D.Text = Request.Cookies["ContactNo"].Value.ToString();
            Label123.Text = Request.Cookies["LASTVISIT"].Value;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Response.Cookies["LASTVISIT"].Value = Convert.ToString(DateTime.Now);
            
        }
    }
}