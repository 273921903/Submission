using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;
using COFCOsubmission.DAL;
using System.Data;
using System.Data.SqlClient;

namespace COFCOsubmission
{
    public partial class ContractInfo1 : System.Web.UI.Page
    {
        public static string mainId;
        //public int[] index;
        protected void Page_Load(object sender, EventArgs e)
        
        {
           
                mainId = Request["id"];
                string from = Request["from"];
                if (from == "main")
                {
                    Session["id"] = mainId;
                    TextBox1.Text = mainId;
                    DataTable dt = new DataTable();
                    dt = ContractInfoDAL.GetData(mainId);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    mainId = Session["id"].ToString();
                    TextBox1.Text = mainId;
                    string param = Request["param"];
                    AddProductInData(param);
                }
           
            
        }

        /// <summary>
        /// 将选中的存货增加到合同子表并刷新合同详细页面
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public void AddProductInData(string str)
        {
            try
            {
                DAL.Contract_b contract_b = new DAL.Contract_b();
            string [] items  = str.Split('@');
            contract_b.Sid = Guid.NewGuid().ToString("N");
            contract_b.Mid = mainId;
            contract_b.Invcode = items[0].ToString();
            contract_b.Invname = items[1].ToString();
            contract_b.Invspec = items[4].ToString();
            contract_b.Measname = items[2].ToString();
            contract_b.Measrate = items[3].ToString();
            //contract_b.Num = "";
            //contract_b.Price = "";
            //contract_b.Nmoney = "";
            //contract_b.Def1 = "";
            //contract_b.Def2 = "";
            //contract_b.Def3 = "";

            
            
            if (ContractInfoDAL.AddContract_b(contract_b) > 0)
            {
                DataTable dt = new DataTable();
                dt = ContractInfoDAL.GetData(mainId);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
                
            }
            }catch(Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// 给每行绑定单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["style"] = "cursor:hand";
            //    String evt = Page.ClientScript.GetPostBackClientHyperlink(sender as GridView, "Select$" + e.Row.RowIndex.ToString());
            //    e.Row.Attributes.Add("onclick", evt);
                
            //}
        }



        
        /// <summary>
        /// 删除已选行
        /// </summary>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static void btnDelet_Click(string code)
         {
             ContractInfo1 contracts = new ContractInfo1();
             GridView gdv = new GridView();
             gdv = contracts.GridView1;
             
             ContractInfoDAL.DeletInfoByCode(code);
               
         }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0;i < GridView1.Rows.Count; i++)
            {
                for (int y = 5; y < 8; y++)
                {
                    TextBox str = ((TextBox)GridView1.Rows[i].Cells[5].FindControl("textNum"));
                    string tex = str.Text;
                    
                }
                
            }

            int x = 1;
        }


       
    }
}