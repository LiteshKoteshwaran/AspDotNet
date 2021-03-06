﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Final
{
    public partial class CanteenRequestForm : System.Web.UI.Page
    {
        string Email { set; get; }
        string Password { set; get; }
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(ConnectionString);
        static string AlertSuccesMessage = "Request has been made";
        static string AlertFailureMessage = "Try again some other time!!!";
        int CountOfGuest = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                AutoFillForDepart();
                FillLocation();
                AutoFillEmpName();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("S.No"), new DataColumn("GuestName"), new DataColumn("Name"), new DataColumn("MobileNo") });
                ViewState["Guest"] = dt;
                this.BindGrid();
            }
            if (Context.User.IsInRole("HR"))
            {
                TableForHr.Visible = true;
                TableForSnacks.Visible = true;
            }
            else
            {
                TableForHr.Visible = false;
                TableForSnacks.Visible = false;
            }
        }

        protected void BindGrid()
        {
            GridView1.DataSource = (DataTable)ViewState["Guest"];
            GridView1.DataBind();
        }

        void Insert()
        {
            DataTable dt = (DataTable)ViewState["Guest"];
            dt.Rows.Add(CountOfGuest, txtGuestName.Text.Trim(), txtOrgName.Text.Trim(), txtMobileNo.Text.Trim());
            ViewState["Guest"] = dt;
            this.BindGrid();
            lblCount.Text = CountOfGuest++.ToString();
            txtGuestName.Text = string.Empty;
            txtOrgName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
        }
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            string SubjectForVipRequest = "Vip Food Request";
            string SubjectForFoodRequest = "Food Request Info";
            
            Mail mail = new Mail();
            string Sender = ddlEmpName.SelectedItem.Text;
            string EmailBody = txtMailBody.Text;
            try
            {
                ForManagerEmail();
                if (ddlCanteenType.Text == "VIP")
                {
                    string Admin = ConfigurationManager.AppSettings["FromMail"].ToString();
                    string AdminPassword = ConfigurationManager.AppSettings["Password"].ToString();
                    mail.SendVIPMail(Admin, SubjectForVipRequest, EmailBody, Sender, AdminPassword);
                    mail.SendToManager(Email, SubjectForFoodRequest, EmailBody, Sender, Password);
                    Response.Write("<script>alert('" + AlertSuccesMessage + "');</script>");
                }
                mail.SendToManager(Email, SubjectForFoodRequest, EmailBody, Sender, Password);
            }
            catch
            {
                Response.Write("<script>alert('" + AlertFailureMessage + "');</script>");
            }
            AssignValues();
        }
        void AssignValues()
        {
            ForSqlOp forSqlOp = new ForSqlOp();
            forSqlOp.GName = txtGuestName.Text;
            forSqlOp.OrgName = txtOrgName.Text;
            forSqlOp.MobileNo = txtMobileNo.Text;
            forSqlOp.EmpId = txtEmpId.Text;
            forSqlOp.DepartID = ddlDeptID.SelectedItem.Text;
            forSqlOp.LocId = ddlLocation.SelectedValue;
            forSqlOp.CanteenID = ddlCanteen.SelectedValue;
            forSqlOp.FromDate = lblFromdate.Text;
            forSqlOp.ToDate = lblToDate.Text;
            forSqlOp.AddDetails = txtAddDetails.Text;
            forSqlOp.FoodType = ddlMealType.SelectedValue;
            string RequestID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 15);
            string Token = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 15);
            forSqlOp.RequestForm(RequestID, Token);
            forSqlOp.InsertionForGuest(RequestID, Token);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Insert();
        }


        void ForManagerEmail()
        {
            string str = "select Manager.Email, Manager.Password from Manager join Department on Department.ID = Manager.DepartmentID where DepartmentID =('" + ddlDeptID.SelectedValue + "')";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(str))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            Email = sdr["Email"].ToString();
                            Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
        }

        void AutoFillEmpName()
        {
            ddlEmpName.Items.Add(new ListItem("Select Name", ""));
            ddlEmpName.AppendDataBoundItems = true;
            String strQuery = "select UserName, Id from AspNetUsers";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlEmpName.DataSource = cmd.ExecuteReader();
                ddlEmpName.DataTextField = "UserName";
                ddlEmpName.DataValueField = "Id";
                ddlEmpName.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        void AutoFillForDepart()
        {
            ddlDeptID.Items.Add(new ListItem("Select Department", ""));
            ddlDeptID.AppendDataBoundItems = true;
            String strQuery = "select Name, Id from Department";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlDeptID.DataSource = cmd.ExecuteReader();
                ddlDeptID.DataTextField = "Name";
                ddlDeptID.DataValueField = "Id";
                ddlDeptID.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        
        protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = ddlEmpName.SelectedValue;
        }

        protected void btnReqSubmit_Click(object sender, EventArgs e)
        {

        }
        private void FillLocation()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT LocationID, LocationName FROM Location";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = objDs.Tables[0];
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationID";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, "--Select--");
            }
        }
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CanteenID, CanteenName FROM Canteen WHERE LocationId ="+ ddlLocation.SelectedValue;
           // cmd.Parameters.AddWithValue("@LocationID", ddlLocation.SelectedValue);
            DataSet Ds = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(Ds);
            con.Close();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlCanteen.DataSource = Ds.Tables[0];
                ddlCanteen.DataTextField = "CanteenName";
                ddlCanteen.DataValueField = "CanteenID";
                ddlCanteen.DataBind();
                ddlCanteen.Items.Insert(0, "--Select--");
            }
        }

        protected void ddlCanteen_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Item.ItemID, Item.ItemName from Item join CanteenItem on Item.ItemID = CanteenItem.ItemID join Canteen on Canteen.CanteenID = CanteenItem.CanteenID where Canteen.CanteenID="+114;
            cmd.Parameters.AddWithValue("@ID", ddlCanteen.SelectedValue);
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                ddlMealType.DataSource = objDs.Tables[0];
                ddlMealType.DataTextField = "ItemName";
                ddlMealType.DataValueField = "ItemID";
                ddlMealType.DataBind();
                ddlMealType.Items.Insert(0, "--Select--");
            }
        }

    }
}


