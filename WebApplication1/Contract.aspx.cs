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
                this.BuyTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.SellTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //this.hetongNum.Value = GetContractNo("06");
            }
     }
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="str"></param>
        public void message(string str)
        {
            //string html = "<script  Language='JavaScript'>alert('" + str + "')</script>";
            //Response.Write(html);
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

                    string addrnameall=addrname = dt.Rows[i]["addrname"].ToString();
                    string linkname = dt.Rows[i]["linkname"].ToString();
                    string phone = dt.Rows[i]["phone"].ToString();

                    string newValue = addrname + "|" + linkname + "|" + phone;
                    string selected = "";
                    if (newValue == defaultValue)
                    {
                        selected = "selected";
                    }
                    str += "<option title='" + addrnameall + "' value='" + addrnameall + "|" + linkname + "|" + phone + "'" + selected + ">" + addrname + "</option>";
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
            info.Submitting = false;
            info.Examine = false;

            if (id == "")
            {
                //info.ID = DAL.ContractInfoDAL.GenerateCheckCode(15).ToString();
                info.ID = Guid.NewGuid().ToString("N");
                int i = new DAL.ContractDAL().AddOrUpdateContract("Add", info);
                if (i > 0)
                {
                    this.id.Value = info.ID;
                    //message("保存成功！");
                    //this.aa.Visible = true;
                    Btn_Details.Visible = true;
                    //保存之后赋值
                    ViewState["address"] = queryAddress(custcode, info.BuyerAddress + "|" + info.BuyerPhone);
                    ViewState["id"] = info.ID;
                }
                else
                {
                    message("保存失败！");
                }

            }
            else
            {
                //修改
                info.ID = id;
                int i = new DAL.ContractDAL().AddOrUpdateContract("Update", info);
            }
        }

    }
}