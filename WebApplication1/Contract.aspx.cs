using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using COFCOsubmission.DAL;
using COFCOsubmission.OABMPService;

namespace COFCOsubmission
{
    public partial class Contract : System.Web.UI.Page
    {
        DAL.ContractDAL contractDAL = new DAL.ContractDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.id.Value.ToString();
            if (id == "" || id == null)
            {
                if (Variable.loginUser == null)
                {
                    Response.Redirect("Login.aspx");
            
                }
                //新增
                this.Btn_Details.Visible = false;
                this.Btn_Commit.Visible = false;
                this.Selldb.Value =Variable.loginUser.UserName;
                this.BuyTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                this.SellTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }


            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                DataTable dt = contractDAL.GetData(" xf_contract ", " * ", " id='" + Request.QueryString["id"].ToString() + "'");

                maif.Value = dt.Rows[0]["Seller"].ToString();
                payfang.Value = dt.Rows[0]["Buyer"].ToString();
                hetongNum.Value = dt.Rows[0]["ContractID"].ToString();
                qianyuePlace.Value = dt.Rows[0]["ContractAddress"].ToString();
                jiaohuoTime.Value = dt.Rows[0]["DeliveryTime"].ToString();
                jiaohuoPlace.Value = dt.Rows[0]["DeliveryAddress"].ToString();
                feiyong.Value = dt.Rows[0]["Transcost"].ToString();
                fukuan.Value = dt.Rows[0]["paymentType"].ToString();
                lvxingTime.Value = dt.Rows[0]["PerformPeriod"].ToString();
                Buydb.Value = dt.Rows[0]["BuyerRep"].ToString();
                BuyAdes.Value = dt.Rows[0]["BuyerAddress"].ToString();
                BuyPhone.Value = dt.Rows[0]["BuyerPhone"].ToString();
                Buyfax.Value = dt.Rows[0]["BuyerFax"].ToString();
                Buybank.Value = dt.Rows[0]["BuyerOpebanck"].ToString();
                BuyNumber.Value = dt.Rows[0]["BuyerBankacc"].ToString();
                BuyTime.Value = dt.Rows[0]["BuyerSigtime"].ToString();

                Selldb.Value = dt.Rows[0]["SellerRep"].ToString();
                SellAde.Value = dt.Rows[0]["SellerAddress"].ToString();
                SellPhone.Value = dt.Rows[0]["SellerPhone"].ToString();
                Sellfax.Value = dt.Rows[0]["SellerFax"].ToString();
                Sellbank.Value = dt.Rows[0]["SellerOpebanck"].ToString();
                SellNumber.Value = dt.Rows[0]["SellerBankacc"].ToString();
                SellTime.Value = dt.Rows[0]["SellerSigtime"].ToString();
                this.id.Value = Request.QueryString["id"].ToString();

                //合同状态
                string status = dt.Rows[0]["submitting"].ToString();

                string BuyerAddress = dt.Rows[0]["BuyerAddress"].ToString();
                string BuyerPhone = dt.Rows[0]["BuyerPhone"].ToString();

                DataTable dts = contractDAL.GetData(" xf_supplier ", " custcode ", " custname = '" + dt.Rows[0]["Buyer"].ToString() + "'");
                if (dts.Rows.Count > 0)
                {
                    ViewState["address"] = queryAddress(dts.Rows[0][0].ToString(), BuyerAddress + "|" + BuyerPhone);
                    ViewState["id"] = Request.QueryString["id"].ToString();
                }

                //状态为提交态
                if (Int32.Parse(status) == 2)
                {
                    this.Btn_Save.Visible = false;
                    this.Btn_Commit.Visible = false;
                }
            }
     }
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="str"></param>
        public void message(string str)
        {
            Response.Write("<script>alert('"+str+"')</script>");
        }

        public static string queryAddress(string custcode,string defaultValue)
        {
            DataTable dt = CustomerDAL.QueryCustAdressByCustCode(custcode);

            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = "<option value=''>选择地址</option>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string addrname;
                    if (dt.Rows[i]["addrname"].ToString().Length > 10)
                    {
                        addrname = dt.Rows[i]["addrname"].ToString().Substring(0, 10) + "...";
                    }
                    else
                    {
                        addrname = dt.Rows[i]["addrname"].ToString();
                    }

                    string addrnameall = dt.Rows[i]["addrname"].ToString();
                    string linkname = dt.Rows[i]["linkname"].ToString();
                    string phone = dt.Rows[i]["phone"].ToString();

                    string newValue = addrnameall + "|" + linkname + "|" + phone;
                    string selected = "";
                    if (newValue == defaultValue)
                    {
                        selected = "selected";
                    }
                    str += "<option value='" +newValue + "'" + selected + ">" + addrname + "</option>";
                }
            }
            return str;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            string id = this.id.Value.ToString();
            string custcode = this.custcode.Value.ToString();

            ContractInfo info = new ContractInfo();
            info.Seller = maif.Value.ToString();
            info.Buyer = payfang.Value.ToString();
            info.ContractID = hetongNum.Value.ToString();
            info.ContractAddress = qianyuePlace.Value.ToString();
            info.DeliveryTime = jiaohuoTime.Value.ToString();
            info.DeliveryAddress = jiaohuoPlace.Value.ToString();
            info.Transcost = feiyong.Value.ToString();
            info.paymentType = fukuan.Value.ToString();
            info.PerformPeriod = lvxingTime.Value.ToString();
            info.BuyerRep = Buydb.Value.ToString();
            info.BuyerAddress = BuyAdes.Value.ToString();
            info.BuyerPhone = BuyPhone.Value.ToString();
            info.BuyerFax = Buyfax.Value.ToString();
            info.BuyerOpebanck = Buybank.Value.ToString();
            info.BuyerBankacc = BuyNumber.Value.ToString();
            info.BuyerSigtime = BuyTime.Value.ToString();

            info.SellerRep = Selldb.Value.ToString();
            info.SellerAddress = SellAde.Value.ToString();
            info.SellerPhone = SellPhone.Value.ToString();
            info.SellerFax = Sellfax.Value.ToString();
            info.SellerOpebanck = Sellbank.Value.ToString();
            info.SellerBankacc = SellNumber.Value.ToString();
            info.SellerSigtime = SellTime.Value.ToString();
            info.UserId = Variable.loginUser.UserCode.ToString();
            info.Submitting = 1;
            info.Examine = 0;

            if (id == "")
            {
                //info.ID = DAL.ContractInfoDAL.GenerateCheckCode(15).ToString();
                info.ID = Guid.NewGuid().ToString("N");
                DataTable dt = contractDAL.GetData(" xf_contract ", " * ", " id='" + id + "'");
                if (dt.Rows.Count < 1)
                {
                    int i = new DAL.ContractDAL().AddOrUpdateContract("Add", info);
                    if (i > 0)
                    {
                        this.id.Value = info.ID;
                        Btn_Details.Visible = true;
                        Btn_Commit.Visible = true;
                        //保存之后赋值
                        ViewState["address"] = queryAddress(custcode, info.BuyerAddress + "|" + info.BuyerPhone);
                        ViewState["id"] = info.ID;
                    }
                    else
                    {
                        message("保存失败！");
                    }
                }
            }
            else
            {
                //修改
                info.ID = id;
                int i = new DAL.ContractDAL().AddOrUpdateContract("Update", info);
                Btn_Details.Visible = true;
                Btn_Commit.Visible = true;
            }
        }
        /// <summary>
        /// 提交数据到OA相应表单(销售订单申请表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Commit_Click(object sender, EventArgs e)
        {
            string id = this.id.Value.ToString();
            BPMSrvPortTypeClient client = new BPMSrvPortTypeClient("BPMSrvHttpSoap11Endpoint");
            DataVO data=contractDAL.GetOAData(id);
            //OA登录账户与姓名
            string oaLoginAccount = Variable.loginUser.OaAccount;
            string oaLoginName = Variable.loginUser.OaAccountName;
            string oaTitle = "销售订单申请表(" + oaLoginName + ")";
            ResponseVO res = client.launchForm(oaLoginAccount, oaTitle, data);
            if (res.colId != -1)
            {
                //更新合同状态为已提交
                new DAL.ContractDAL().updateContractStatus(id);
                //message("合同申请单提交OA成功！");
                this.Btn_Commit.Visible = false;
                this.Btn_Save.Visible = false;
            }
        }

        protected void Btn_Details_Click(object sender, EventArgs e)
        {

        }

    }
}