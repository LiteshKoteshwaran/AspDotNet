using _26Nov.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL 
{
    public class ProductDAL
    {
        bool Result;
        public string Name { get; set; }
        public string Name2 { get; set; }
        SqlConn sqlConn = new SqlConn();
        public bool Record()
        {
            string str ="insert into Products(Name) values('" + Name + "')";
            Result=sqlConn.Conn(str);
            return Result;
        }
        public bool UpdateRecord()
        {
            
            string str = "update Products set Name =('" + Name2 + "') where Name=('"+Name+"')"; 
            return Result = sqlConn.Conn(str);
        }
        public bool DeleteRecord()
        {
            string str = "DELETE FROM Products WHERE Name=('" + Name + "')";
            return Result = sqlConn.Conn(str);
        }
    }
}
