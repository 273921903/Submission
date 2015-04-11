using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COFCOsubmission
{
    public class ContractInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractID { get; set; }
        /// <summary>
        /// 签约地点
        /// </summary>
        public string ContractAddress { get; set; }
        /// <summary>
        /// 卖家
        /// </summary>
        public string Seller { get; set; }
        /// <summary>
        /// 买家
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 交货时间
        /// </summary>
        public string DeliveryTime{get;set;}
        /// <summary>
        /// 交货地点
        /// </summary>
        public string DeliveryAddress{get;set;}
        /// <summary>
        /// 运费、运输
        /// </summary>
        public string Transcost{get;set;}
        /// <summary>
        /// 付款方式
        /// </summary>
        public string paymentType{get;set;}
        /// <summary>
        /// 履行期限
        /// </summary>
        public string PerformPeriod{get;set;}
        /// <summary>
        /// 买方签约代表
        /// </summary>
        public string BuyerRep{get;set;}
        /// <summary>
        /// 买方地址
        /// </summary>
        public string BuyerAddress{get;set;}
        /// <summary>
        /// 买方电话
        /// </summary>
        public string BuyerPhone{get;set;}
        /// <summary>
        /// 买方传真
        /// </summary>
        public string BuyerFax{get;set;}
        /// <summary>
        /// 买方开户银行
        /// </summary>
        public string BuyerOpebanck{get;set;}
        /// <summary>
        /// 买方银行账号
        /// </summary>
        public string BuyerBankacc{get;set;}
        /// <summary>
        /// 买方签约时间
        /// </summary>
        public string BuyerSigtime{get;set;}
        /// <summary>
        /// 卖方签约代表
        /// </summary>
        public string SellerRep{get;set;}
        /// <summary>
        /// 卖方地址
        /// </summary>
        public string SellerAddress{get;set;}
        /// <summary>
        /// 卖方电话
        /// </summary>
        public string SellerPhone{get;set;}
        /// <summary>
        /// 卖方传真
        /// </summary>
        public string SellerFax{get;set;}
        /// <summary>
        /// 卖方开户银行
        /// </summary>
        public string SellerOpebanck{get;set;}
        /// <summary>
        /// 卖方银行账号
        /// </summary>
        public string SellerBankacc{get;set;}
        /// <summary>
        /// 卖方签约时间
        /// </summary>
        public string SellerSigtime{get;set;}
        /// <summary>
        /// 合同金额
        /// </summary>
        public string AmountMoney{get;set;}
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserId{get;set;}
        /// <summary>
        /// 是否已提交
        /// </summary>
        public bool Submitting{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        public bool Examine{get;set;}
        /// <summary>
        /// 审核人
        /// </summary>
        public string Audit{get;set;}
        /// <summary>
        /// 审核时间
        /// </summary>
        public string AuditTime{get;set;}

        public string Colid{get;set;}

        public string Def1{get;set;}

        public string Def2{get;set;}

        public string Def3 { get; set; }
    }
}