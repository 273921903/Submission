using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COFCOsubmission.DAL;

namespace COFCOsubmission
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 搜索框文本发生改变时查询存货信息并绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchText_TextChanged(object sender, EventArgs e)
        {
            CustGiv.DataSource = ProductInfoDAL.QueryProductInfo(SearchText.Text.Trim());
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

    }
}