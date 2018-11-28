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
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //if(!(User.IsInRole("Admin")||User.IsInRole("ProductManger")))
        //    //{
        //    //    Response.Redirect("UnAuthorised");
        //    //}

        //    ProductDAL product = new ProductDAL();
        //    GridView2.DataSource = product.ForGridView();
        //    GridView2.DataBind();
        //}

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

        protected void Button4_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBoxForSelect.Text;
            Output.Text = product.SelectStat().ToString();
        }

        protected void Output1_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBoxForProc.Text;
            LabelForProc.Text= product.ForProc();
        }

        protected void ButtonForDataSetOp_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.Name = TextBoxForProductName.Text;
            product.ID = Convert.ToInt32(TextBoxForID.Text);
            product.Location = TextBoxForLocation.Text;
            product.InsertByDataSet();
        }

        //protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        //{

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                BindGridView();

        }

        public void BindGridView()
        {
            ProductDAL product = new ProductDAL();
            GridView2.DataSource = product.GetProducts();
            GridView2.DataBind();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Product product = new Product();

            GridViewRow row = GridView2.Rows[e.RowIndex];
            product.Id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            product.Name = (row.FindControl("TextBox5") as TextBox).Text;

            ProductDAL productDAL = new ProductDAL();
            productDAL.UpdateProduct(product);

            GridView2.EditIndex = -1;
            BindGridView();
        }

        //protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}