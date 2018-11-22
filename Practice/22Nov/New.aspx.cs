using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _22Nov
{
    public partial class New : System.Web.UI.Page
    {
        ////protected void Page_LoadComplete(object sender, EventArgs e)
        ////{
        ////    Response.Write("Checking for posibilities");
        ////}
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    Validation(sender, e);
        //}
        //protected void Validation(object sender, EventArgs e)
        //{
        //    //if (TextBox1 == null)
        //    //    Response.Write("it should not be null");
        //    //else
        //    Response.Write(TextBox1.Text);
        //}
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //Response.Write(" koteshwaran\n");
        //}
        ////protected new void Load(object sender, EventArgs e)
        ////{
        ////    Response.Write(TextBox1.Text+" of new");
        ////}

        //protected void Render(object sender, EventArgs e)
        //{
        //    Response.Write(TextBox1.Text);
        //}

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"], then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreInit";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "Init";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "InitComplete";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back and you have set or not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) will always have post back data.
            //E.g: If you string str = Convert.ToString(ViewState["value"]), then str will contain post back values.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreLoad";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "Load";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "btnSubmit_Click";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "LoadComplete";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreRender";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            //Work and It will assign the values to label.
            //But "SaveStateComplete" values will not be available during post back. i.e. View state.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "SaveStateComplete";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //Work and it will not effect label contrl values, view state and post back data.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "UnLoad";
            lblname.Text = Convert.ToString(ViewState["value"]);
        }
    }
}