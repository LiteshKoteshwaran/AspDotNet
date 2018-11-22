using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _22Nov
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"], then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreInit";
            Label1.Text = "";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "Init";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back or first time call and you have not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) is always empty.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "InitComplete";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            //Work and It will assign the values to label.
            //Note : If page is post back and you have set or not set any values to ViewState["value"] in privious events, then
            //Convert.ToString(ViewState["value"]) will always have post back data.
            //E.g: If you string str = Convert.ToString(ViewState["value"]), then str will contain post back values.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreLoad";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "Load";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "btnSubmit_Click";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "LoadComplete";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //Work and It will assign the values to label.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "PreRender";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            //Work and It will assign the values to label.
            //But "SaveStateComplete" values will not be available during post back. i.e. View state.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "SaveStateComplete";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //Work and it will not effect label contrl values, view state and post back data.
            ViewState["value"] = Convert.ToString(ViewState["value"]) + "<br/>" + "UnLoad";
            lblName.Text = Convert.ToString(ViewState["value"]);
        }
    }
}