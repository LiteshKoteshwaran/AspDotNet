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
    public class ProcParameters
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DbType DataType { get; set; }
        public ParameterDirection Direction { get; set; }

        public ProcParameters(string Name, string Value, DbType DataType, ParameterDirection Direction)
        {
            this.Name = Name;
            this.Value = Value;
            this.DataType = DataType;
            this.Direction = Direction;
        }
    }
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


        //    public void UpdateRecord()
        //    {
        //        DataSet ds;
        //    SqlCommandBuilder cmdBuilder;
        //        using (SqlConnection conn = new SqlConnection(ConnectionString))
        //        {
        //            //SqlCommand cmd = new SqlCommand("select * from Products", conn);
        //            SqlDataAdapter sqlda = new SqlDataAdapter("select * from Products;select * from aspnetusers", conn);
        //cmdBuilder = new SqlCommandBuilder(sqlda);

        //ds = new DataSet();
        //sqlda.Fill(ds);

        //            //ds.Tables[0].Rows[0]["Name"] = "Jack1";
        //            DataRow dr = ds.Tables["Products"].NewRow();
        //dr["Name"] = "Tabs";
        //            ds.Tables[0].Rows.Add(dr);

        //            sqlda.Update(ds, ds.Tables["Products"].ToString());
        //        }
        //    }


        public bool InsertUsingDataSet()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter;

                var sqlQuery = "select * from Products";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                var newRow = dataSet.Tables[0].NewRow();
                newRow["Name"] = Name;
                newRow["ID"] = ID;
                newRow["Location"] = Location;
                dataSet.Tables[0].Rows.Add(newRow);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet);
            }
            return true;
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



        public DataSet UsingGridView()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter;

                var sqlQuery = "select * from Products";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }


        public DataSet GetDataSet(string Query)
        {
            // Improvise this to manage exceptions
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataAdapter sadp = new SqlDataAdapter(cmd);
                sadp.Fill(ds);
            }
            return ds;
        }
        public bool UpdateRecord(string ProcName, List<ProcParameters> ProcParams)
        //public bool UpdateRecord(string ProcName, int Id, string Name)
        {
            bool isSucess = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ProcName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SqlParameter TParam1 = new SqlParameter("@Operation", 3);
                    //TParam1.Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add(TParam1);

                    foreach (ProcParameters param in ProcParams)
                    {
                        SqlParameter TParam = new SqlParameter(param.Name, param.Value);
                        TParam.Direction = param.Direction;
                        cmd.Parameters.Add(TParam);
                    }

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1) isSucess = false;
                }
            }
            catch (Exception e)
            {
                isSucess = false;
            }

            return isSucess;
        }
    }
}