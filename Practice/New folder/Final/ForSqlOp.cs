﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final
{
    public class ForSqlOp
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string GName { get; set; }
        public string OrgName { get; set; }
        public string MobileNo { get; set; }
        public string Query { get; set; }

        public string EmpId { get; set; }
        public string DepartID { get; set; }
        public string LocId { get; set; }
        public string CanteenID { get; set; }
        public string FoodType { get; set; }
        public string OrderQuanty { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AddDetails { get; set; }

        ConnectionManger connectionManger = new ConnectionManger();
        bool Result;

        internal bool InsertionForGuest(string RequestID, string Token)
        {
            string str = "insert into Guest values('" + GName + "','" + OrgName + "','" + MobileNo + "','" + Token + "','" + RequestID + "')";
            Result = connectionManger.ConnMan(str);
            return Result;
        }
        internal void RequestForm(string RequestID, string Token)
        {
            string str = "insert into Request values('" + RequestID + "','" + EmpId  + "','" + DepartID + "','" + LocId + "','" + CanteenID + "','" + FoodType + "','" + FromDate + "','" + ToDate + "','" + AddDetails + "')";
            Result = connectionManger.ConnMan(str);
        }

    }
}