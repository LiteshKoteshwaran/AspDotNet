using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using DAL;
using System.Data;

namespace _26Nov.DAL
{
    public class SqlConn 
    {
        static string OutputForProc;

        public string Name { set; get; }
        public string Location { set; get; }
        public int ID { set; get; }
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public  bool Conn(string str)
        {
           
            bool isSuccess = true;
            using (var conn=new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = str;
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1)
                    {
                        throw new Exception("Could not process the data");
                    }

                }
                catch (Exception ex)
                {
                    //Write exception to log
                    isSuccess = false;
                    LogFilePath();
                }
                finally
                {
                    conn.Close();
                }
                return isSuccess;
            }
        }
        //public List<object> GetResult(string str1)
        public string GetResult(string str1)
        {
            ProductDAL productDAL = new ProductDAL();
            //List<object> productDAL = new List<object>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(str1, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                //productDAL.Add[] = reader["Name"].ToString();

                productDAL.Name = reader["Name"].ToString();

                //while (reader.Read())
                //{
                //    //productDAL.Name = reader["Name"].ToString();
                //    //str[i] = productDAL.Name;
                //    productDAL.Add(reader["Name"]);
                //    productDAL.Add(reader["ID"]);
                //    productDAL.Add(reader["Location"]);
                //}

            }
            return productDAL.Name;
        }


        //reader.GetString(1)

        public string GetResultUsingProc()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {

                conn = new SqlConnection(ConnectionString);
                conn.Open();


                SqlCommand cmd = new SqlCommand(
                    "GetProducts", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", Name));

                rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    OutputForProc = rdr["Name"].ToString()+", "+rdr["ID"].ToString()+", "+rdr["Location"].ToString();
                    
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
            return OutputForProc;
        }






        public void LogFilePath()
        {
            string Path= "D:log";
             Exception e = new Exception();
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(e.Message);
            }
        }
    }
}