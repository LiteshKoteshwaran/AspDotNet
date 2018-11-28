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
        public string Location { set; get; }
        public int ID { set; get; }
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
            sqlConn.Name = Name;
            return str=sqlConn.GetResultUsingProc();
        }

        public bool InsertByDataSet()
        {
            sqlConn.Name = Name;
            sqlConn.ID = ID;
            sqlConn.Location = Location;
            return Result = sqlConn.InsertUsingDataSet();   
        }

        public DataSet ForGridView()
        {
            return sqlConn.UsingGridView();
        }
        public DataSet GetProducts()
        {
            string Query = "select ID,Name,Location from Products";
            
            return sqlConn.GetDataSet(Query);
        }

        public bool UpdateProduct(Product product)
        {
            bool isSuccess;
            List<ProcParameters> procParams = new List<ProcParameters>();
            procParams.Add(new ProcParameters("@ID", product.Id.ToString(), DbType.Int32, ParameterDirection.Input));
            procParams.Add(new ProcParameters("@Name", product.Name, DbType.String, ParameterDirection.Input));
            isSuccess = sqlConn.UpdateRecord("Products_CRUD", procParams);

            return isSuccess;
        }
    }
}
