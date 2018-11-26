using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace _26Nov.DAL
{
    public class SqlConn 
    {
        public  bool Conn(string str)
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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