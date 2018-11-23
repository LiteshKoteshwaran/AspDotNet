using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _21Nov
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["FirstName"] = Convert.ToString(TextBox1s.Text);
            Session["CourseName"] = Convert.ToString(TextBox4c.Text);
            Response.Cookies["ContactNo"].Value = Convert.ToString(TextBox2s.Text);
            Response.Cookies["ID"].Value = Convert.ToString(TextBox3s.Text);

            Response.Redirect("DisplayDetails");
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Session["CourseName"] = Convert.ToString(TextBox4c.Text);
        //    //Session["CourseDuration"] = Convert.ToString(TextBox5c.Text);
        //    //Session["CourseFee"] = Convert.ToString(TextBox6c.Text);

        //    Response.Redirect("DisplayDetails");
        //}
    }
}