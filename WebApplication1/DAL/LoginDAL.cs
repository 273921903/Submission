using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script;

namespace COFCOsubmission.DAL
{
    public class LoginDAL
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        public LoginUser Verification(string userName,string passWord)
        {
            LoginUser loginUser = new LoginUser();
            SqlConnection conn = new SqlConnection(connectString);
            try {

                if (conn.State == ConnectionState.Closed )
                {
                    conn.Open();
                }
                SqlCommand com = new SqlCommand();
                com.CommandText = "select * from xf_user where usercode='" + userName + "' and userpwd='" + passWord + "' and dr=0 ";
                com.Connection = conn;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    loginUser.UserCode = dt.Rows[0]["usercode"].ToString();
                    loginUser.UserName = dt.Rows[0]["username"].ToString();
                    loginUser.OaAccount = dt.Rows[0]["usernode"].ToString().Split('@')[0];
                    loginUser.OaAccountName = dt.Rows[0]["usernode"].ToString().Split('@')[1];

                    //作为全局变量
                    Variable.loginUser = loginUser;
                    return loginUser;
                }
            }catch (Exception ex) {
                //记录错误日志
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