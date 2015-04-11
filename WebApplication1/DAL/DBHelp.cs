using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Data;

namespace COFCOsubmission
{
    public class DBHelp
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        public static DataTable GetData(string spNameText) 
        {
            //1.创建连接对象
            SqlConnection conn = new SqlConnection(connectString);
            //如果没有打开，我们才打开连接通道
            if (conn.State != ConnectionState.Open)
            {
                
                //2.开启连接通道
                conn.Open();
            }
            //3.SqlCommand 创建命令对象
            SqlCommand cmd = new SqlCommand(spNameText, conn);
            //4.执行命令，并得到数据
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            conn.Close();
            return dt.Tables[0];
        }

        public static int updata(string spNameText) 
        {
            SqlConnection conn = new SqlConnection(connectString);
            
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;

            SqlTransaction transaction;
            transaction = conn.BeginTransaction();

            cmd.Transaction = transaction;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int i = 0;
                cmd.CommandText = spNameText;
                i = cmd.ExecuteNonQuery();

                transaction.Commit();
                return i;
            }
            catch
            {
                transaction.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}