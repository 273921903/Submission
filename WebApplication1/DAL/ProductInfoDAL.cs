using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace COFCOsubmission.DAL
{
    public class ProductInfoDAL
    {

        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        /// <summary>
        /// 根据关键字获取存货信息
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public static DataTable QueryProductInfo(string ProductName)
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
                string strsql = "select rMeCode,rMeCodeName,'吨' as measname,1 as mainmeasrate,";
                strsql += "rMeSpecName from xf_rMaterial ";
                strsql += "where rMeCodeName like '%" + ProductName + "%' ";
                strsql += "union all ";
                strsql += "select ";
                strsql += "rMeCode,rMeCodeName,m.measname,m.mainmeasrate ,rMeSpecName from xf_rMaterial r ";
                strsql += "inner join xf_measdoc m ";
                strsql += "on r.rMeCode=m.invcode ";
                strsql += "where rMeCodeName like '%" + ProductName + "%' ";
                strsql += "order by rMeCode";
                com.CommandText = strsql;

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