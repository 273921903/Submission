using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace COFCOsubmission
{
    public partial class ContractList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.ContractDAL contract = new DAL.ContractDAL();
            string userid = Variable.loginUser.UserCode;

            DataTable dt = contract.GetData(" xf_contract ", " id,buyer,deliveryTime,amountMoney,submitting ", " userId='" + userid + "' ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        /// <summary>
        /// 判断提交状态1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Handler(string str)
        {
            string rStr = "";
            if (str == "0")
            {
                rStr = "";
            }
            else if (str == "1")
            {
                rStr = "未完成";
            }
            else
            {
                rStr = "已完成";
            }
            return rStr;
        }
    }
}