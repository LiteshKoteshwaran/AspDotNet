using _26Nov.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class ProductDAL
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        bool Result;
        public string Name { get; set; }
        public string Name2 { get; set; }
        SqlConn sqlConn = new SqlConn();
        public bool Record()
        {
            string str = "insert into Products(Name) values('" + Name + "')";
            Result = sqlConn.Conn(str);
            return Result;
        }
        public bool UpdateRecord()
        {

            string str = "update Products set Name =('" + Name2 + "') where Name=('" + Name + "')";
            return Result = sqlConn.Conn(str);
        }
        public bool DeleteRecord()
        {
            string str = "DELETE FROM Products WHERE Name=('" + Name + "')";
            return Result = sqlConn.Conn(str);
        }
        public string SelectStat()
        {
            //string str1 = "select * from Products";
            string str1 = "SELECT Name FROM dbo.Products where Name=('" + Name + "')";
            //string str2 = "SELECT EmployeeID, LastName FROM dbo.Employees";
            string name = sqlConn.GetResult(str1);
            return name;
        }
        //public List<object> SelectStat()
        //{
        //    string str1 = "select * from Products";
        //    List<object> productDAL = new List<object>();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(str1, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        reader.Read();
        //        //productDAL.Add[] = reader["Name"].ToString();

        //        while (reader.Read())
        //        {
        //            //productDAL.Name = reader["Name"].ToString();
        //            //str[i] = productDAL.Name;
        //            productDAL.Add(reader["Name"]);
        //            productDAL.Add(reader["ID"]);
        //            productDAL.Add(reader["Location"]);
        //        }

        //    }
        //    return productDAL;
    
        public string ForProc()
        {
            string str;
            return str=sqlConn.GetResultUsingProc();
        }
    }
}
