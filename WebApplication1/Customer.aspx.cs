using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using COFCOsubmission.DAL;
using System.Web.Script.Services;
using System.Web.Script;
using System.Web.Services;

namespace COFCOsubmission
{
    public partial class Custter : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 搜索框文本发生改变时模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchText_TextChanged(object sender, EventArgs e)
        {
            CustGiv.DataSource= CustomerDAL.QueryCustInfo(SearchText.Text.Trim());
            CustGiv.DataBind();
           
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            CustGiv.DataSource = CustomerDAL.QueryCustInfo(SearchText.Text.Trim());
            CustGiv.DataBind();
        }


        /// <summary>
        /// 绑定客商地址
        /// </summary>
        /// <param name="custcode"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet=true)]
        public static string queryAddress(string custcode){

            DataTable dt = CustomerDAL.QueryCustAdressByCustCode(custcode);

            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = "<option value=''>选择地址</option>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string addrname;
                    if (dt.Rows[i]["addrname"].ToString().Length > 18)
                    {
                        addrname = dt.Rows[i]["addrname"].ToString().Substring(0, 18) + "...";
                    }
                    else
                    {
                        addrname = dt.Rows[i]["addrname"].ToString();
                    }
                    string addrnameall = dt.Rows[i]["addrname"].ToString();
                    string linkname=dt.Rows[i]["linkname"].ToString();
                    string phone=dt.Rows[i]["phone"].ToString();
                    str += "<option title='" + addrnameall + "' value='" + addrnameall + "|" + linkname + "|" + phone + "'>" + addrname + "</option>";
                }
            }
            
            return str;
        }
    }
}