using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _24Nov
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (!RadioButton1.Checked && !RadioButton2.Checked && !RadioButton3.Checked)
        //        args.IsValid = false;
        //}

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string str = PassWord.Text;
            if (str.Substring((str.Length - 3), (str.Length)) == ID.Text)
                Response.Write("valid");
            else
                Response.Write("not valid");
        }

        //protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    e.IsValid = CheckBoxList1.;
        //}

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!Regex.Match(Address.Text, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                Console.WriteLine("Invalid address");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                Response.Write("all info is valid");
            else
                Response.Write("all or few info is not valid ");
        }
        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            for (int i = 0; i < AccountType.Items.Count; i++)
            {

                if (AccountType.Items[i].Selected)
                {
                    args.IsValid = true;
                }
            }
        }
    }
}