﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using COFCOsubmission.DAL;

namespace COFCOsubmission
{
    public partial class _Default : System.Web.UI.Page
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        DAL.LoginDAL loginDAL = new DAL.LoginDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userName.Text ="admin";
            this.userPassword.Text = "1";
        }

        protected void landbutton1_Click(object sender, EventArgs e)
        {
            if (String.Compare(Request.Cookies["yzmcode"].Value,checkImg.Text.ToString(), true) != 0)
            {
                Response.Write("<script>alert('验证码错误!')</script>");
            }
            else
            { 
                Response.Write("<script>alert('验证吗正确!!!')</script>");
                LoginUser user = loginDAL.Verification(userName.Text.Trim(), userPassword.Text.Trim());
                if (user == null)
                {
                    //messag.Text = "*登陆失败：用户名或密码错误";
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            } 
        }


        protected void ChangeCode_Click1(object sender, EventArgs e)
        {

        }
    }
}