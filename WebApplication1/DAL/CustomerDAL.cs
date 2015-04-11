using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace COFCOsubmission.DAL
{
    public class CustomerDAL
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        /// <summary>
        /// 根据关键字获取客商信息
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public static DataTable QueryCustInfo(string customerName)
        {
            SqlConnection conn = new SqlConnection(connectString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "select pk_supplier,custcode,custname,remark from xf_supplier where custname like '%" + customerName + "%' and dr=0 ";

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return null ;
        }

        public static DataTable QueryCustAdressByCustCode(string custcode)
        {
            SqlConnection conn = new SqlConnection(connectString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "select addrname,linkname,phone from xf_supplier_addr where custcode = '" + custcode + "'";

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return null;
        }
    }
}