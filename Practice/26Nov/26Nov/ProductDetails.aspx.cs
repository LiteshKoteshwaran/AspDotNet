using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace _26Nov
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(User.IsInRole("Admin")||User.IsInRole("ProductManger")))
            {
                Response.Redirect("UnAuthorised");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBox1.Text;
            if (!product.Record())
            {
                Response.Write("Product could not be processed");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBox2.Text;
            product.Name2 =TextBox4.Text;
            if (!product.UpdateRecord())
            {
                Response.Write("Product could not be processed");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBox3.Text;
            if (!product.DeleteRecord())
            {
                Response.Write("Product could not be processed");
            }
        }
    }
}