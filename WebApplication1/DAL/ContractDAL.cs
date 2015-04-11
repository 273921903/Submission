﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using COFCOsubmission.OABMPService;

namespace COFCOsubmission.DAL
{
    public class ContractDAL
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();

        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <param name="tableName">表明</param>
        /// <param name="strName">字段名</param>
        /// <param name="whereStr">条件</param>
        /// <returns></returns>
        public DataTable GetData(string tableName,string strName,string whereStr )
        {
            SqlConnection conn = new SqlConnection(connectString);
            
            DataTable dt = new DataTable();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "select " + strName + " from " + tableName + " where " + whereStr;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;
        }
        /// <summary>
        /// 对合同主表的信息进行增行或者修改的操作
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="info">数据</param>
        /// <returns></returns>
         public int AddOrUpdateContract(string type,ContractInfo info)
         {
             SqlConnection conn = new SqlConnection(connectString);

             SqlCommand com = new SqlCommand();
             com.Connection = conn;
             
             if (conn.State == ConnectionState.Closed)
             {
                 conn.Open();
             }
             SqlTransaction transaction = conn.BeginTransaction();
             com.Transaction = transaction;

             try
             {
                 if (type == "Add")
                 {
                     string contractId = GetContractNo(com);
                     com.CommandText = "insert into xf_contract(id,contractId,contractAddress,seller,buyer,deliveryTime,deliveryAddress,transcost,paymentType,performPeriod,buyerRep,buyerAddress,buyerPhone,buyerFax,buyerOpebanck,buyerBankacc,buyerSigtime,sellerRep,sellerAddress,sellerPhone,sellerFax,sellerOpebanck,sellerBankacc,sellerSigtime,userId,submitting,examine) ";
                     com.CommandText += "values(@id,@contractId,@contractAddress,@seller,@buyer,@deliveryTime,@deliveryAddress,@transcost,@paymentType,@performPeriod,@buyerRep,@buyerAddress,@buyerPhone,@buyerFax,@buyerOpebanck,@buyerBankacc,@buyerSigtime,@sellerRep,@sellerAddress,@sellerPhone,@sellerFax,@sellerOpebanck,@sellerBankacc,@sellerSigtime,@userId,@submitting,@examine)";
                     com.Parameters.AddWithValue("@id", info.ID);
                     com.Parameters.AddWithValue("@contractId", contractId);    //合同号
                     com.Parameters.AddWithValue("@contractAddress", info.ContractAddress);
                     com.Parameters.AddWithValue("@seller", info.Seller);
                     com.Parameters.AddWithValue("@buyer", info.Buyer);
                     com.Parameters.AddWithValue("@deliveryTime", info.DeliveryTime);
                     com.Parameters.AddWithValue("@deliveryAddress", info.DeliveryAddress);
                     com.Parameters.AddWithValue("@transcost", info.Transcost);
                     com.Parameters.AddWithValue("@paymentType", info.paymentType);
                     com.Parameters.AddWithValue("@performPeriod", info.PerformPeriod);
                     com.Parameters.AddWithValue("@buyerRep", info.BuyerRep);
                     com.Parameters.AddWithValue("@buyerAddress", info.BuyerAddress);
                     com.Parameters.AddWithValue("@buyerPhone", info.BuyerPhone);
                     com.Parameters.AddWithValue("@buyerFax", info.BuyerFax);
                     com.Parameters.AddWithValue("@buyerOpebanck", info.BuyerOpebanck);
                     com.Parameters.AddWithValue("@buyerBankacc", info.BuyerBankacc);
                     com.Parameters.AddWithValue("@buyerSigtime", info.BuyerSigtime);
                     com.Parameters.AddWithValue("@sellerRep", info.SellerRep);
                     com.Parameters.AddWithValue("@sellerAddress", info.SellerAddress);
                     com.Parameters.AddWithValue("@sellerPhone", info.SellerPhone);
                     com.Parameters.AddWithValue("@sellerFax", info.SellerFax);
                     com.Parameters.AddWithValue("@sellerOpebanck", info.SellerOpebanck);
                     com.Parameters.AddWithValue("@sellerBankacc", info.SellerBankacc);
                     com.Parameters.AddWithValue("@sellerSigtime", info.SellerSigtime);
                     //com.Parameters.AddWithValue("@amountMoney", info.AmountMoney);
                     com.Parameters.AddWithValue("@userId", info.UserId);
                     com.Parameters.AddWithValue("@submitting", info.Submitting);
                     com.Parameters.AddWithValue("@examine", info.Examine);
                 }
                 else if (type == "Update")
                 {
                     com.CommandText = "update xf_contract set id=@id,contractId=@contractId,contractAddress=@contractAddress,seller=@seller,buyer=@buyer,deliveryTime=@deliveryTime,";
                     com.CommandText += "deliveryAddress=@deliveryAddress,transcost=@transcost,paymentType=@paymentType,performPeriod=@performPeriod,buyerRep=@buyerRep,";
                     com.CommandText += "buyerAddress=@buyerAddress,buyerPhone=@buyerPhone,buyerFax=@buyerFax,buyerOpebanck=@buyerOpebanck,buyerBankacc=@buyerBankacc,buyerSigtime=@buyerSigtime,";
                     com.CommandText += "sellerRep=@sellerRep,sellerAddress=@sellerAddress,sellerPhone=@sellerPhone,sellerFax=@sellerFax,sellerOpebanck=@sellerOpebanck,sellerBankacc=@sellerBankacc,";
                     com.CommandText += "sellerSigtime=@sellerSigtime,userId=@userId,submitting=@submitting,examine=@examine where id=@id ";
                     
                     com.Parameters.AddWithValue("@id", info.ID);
                     com.Parameters.AddWithValue("@contractId", info.ContractID);
                     com.Parameters.AddWithValue("@contractAddress", info.ContractAddress);
                     com.Parameters.AddWithValue("@seller", info.Seller);
                     com.Parameters.AddWithValue("@buyer", info.Buyer);
                     com.Parameters.AddWithValue("@deliveryTime", info.DeliveryTime);
                     com.Parameters.AddWithValue("@deliveryAddress", info.DeliveryAddress);
                     com.Parameters.AddWithValue("@transcost", info.Transcost);
                     com.Parameters.AddWithValue("@paymentType", info.paymentType);
                     com.Parameters.AddWithValue("@performPeriod", info.PerformPeriod);
                     com.Parameters.AddWithValue("@buyerRep", info.BuyerRep);
                     com.Parameters.AddWithValue("@buyerAddress", info.BuyerAddress);
                     com.Parameters.AddWithValue("@buyerPhone", info.BuyerPhone);
                     com.Parameters.AddWithValue("@buyerFax", info.BuyerFax);
                     com.Parameters.AddWithValue("@buyerOpebanck", info.BuyerOpebanck);
                     com.Parameters.AddWithValue("@buyerBankacc", info.BuyerBankacc);
                     com.Parameters.AddWithValue("@buyerSigtime", info.BuyerSigtime);
                     com.Parameters.AddWithValue("@sellerRep", info.SellerRep);
                     com.Parameters.AddWithValue("@sellerAddress", info.SellerAddress);
                     com.Parameters.AddWithValue("@sellerPhone", info.SellerPhone);
                     com.Parameters.AddWithValue("@sellerFax", info.SellerFax);
                     com.Parameters.AddWithValue("@sellerOpebanck", info.SellerOpebanck);
                     com.Parameters.AddWithValue("@sellerBankacc", info.SellerBankacc);
                     com.Parameters.AddWithValue("@sellerSigtime", info.SellerSigtime);
                     //com.Parameters.AddWithValue("@amountMoney", info.AmountMoney);
                     com.Parameters.AddWithValue("@userId", info.UserId);
                     com.Parameters.AddWithValue("@submitting", info.Submitting);
                     com.Parameters.AddWithValue("@examine", info.Examine);
                 }

                 int i = com.ExecuteNonQuery();

                 transaction.Commit();
                 return i;
             }
             catch(Exception ex)
             {
                 ex.ToString();
                 transaction.Rollback();
                 return -1;
             }
             finally
             {
                 if (conn.State == ConnectionState.Open)
                 {
                     conn.Close();
                 }
             }
         }

         /// <summary>
         /// 生成合同单号
         /// </summary>
         /// <param name="com"></param>
         /// <returns></returns>
         public string GetContractNo(SqlCommand com)
         {
             string prefix = DateTime.Now.ToString("yyyyMMdd");
             DataTable dt=new DataTable();
             try
             {
                 com.CommandText = "select count(*) from xf_contract ";
                 SqlDataAdapter da = new SqlDataAdapter(com);
                 da.Fill(dt);

                 string rowIndex = string.Format("{0:0000}", Int32.Parse(dt.Rows[0][0].ToString())+1);
                 return "06" + prefix + rowIndex;
             }
             catch (Exception ex)
             {
             }
             return "";
         }

        /// <summary>
        /// 创建OA表单服务所需要的数据对象
        /// </summary>
        /// <param name="id">合同主表ID</param>
        /// <returns></returns>
         public DataVO GetOAData(string id)
         {
             OABMPService.DataVO oaData = new DataVO();

             SqlConnection conn = new SqlConnection(connectString);
             DataTable dt = new DataTable();
             try
             {
                 if (conn.State == ConnectionState.Closed)
                 {
                     conn.Open();
                 }
                 SqlCommand com = new SqlCommand();
                 com.Connection = conn;
                 com.CommandText = "select * from xf_contract where id=@id ";
                 com.Parameters.AddWithValue("@id",id);
                 SqlDataAdapter da = new SqlDataAdapter();
                 da.SelectCommand = com;
                 da.Fill(dt);

                 if(dt.Rows.Count>0)
                 {
                     DataRow dr=dt.Rows[0];
                     oaData.@operator = Variable.loginUser.OaAccountName;     //制表人,OA人员
                     oaData.operatTime = DateTime.Now.ToString("yyyy-MM-dd"); //制表时间,当前日期
                     oaData.contractID = dr["contractId"].ToString();
                     oaData.signingAddress = dr["contractAddress"].ToString();
                     oaData.seller = dr["seller"].ToString();
                     oaData.buyer = dr["buyer"].ToString();
                     oaData.deliveryTime = dr["deliveryTime"].ToString();
                     oaData.deliveryAddress = dr["deliveryAddress"].ToString();
                     oaData.transport = dr["transcost"].ToString();
                     oaData.paymentType = dr["paymentType"].ToString();
                     oaData.performTime = dr["performPeriod"].ToString();
                     oaData.buyerRep = dr["buyerRep"].ToString();
                     oaData.buyerAddress = dr["buyerAddress"].ToString();

                     oaData.buyerPhone = dr["buyerPhone"].ToString();
                     oaData.buyerFax = dr["buyerFax"].ToString();
                     oaData.buyerOpebank = dr["buyerOpebanck"].ToString();
                     oaData.buyerBankId = dr["buyerBankacc"].ToString();
                     oaData.buyersigTime = dr["buyerSigtime"].ToString();
                     oaData.sellerRep = dr["sellerRep"].ToString();

                     oaData.sellerAddress = dr["sellerAddress"].ToString();
                     oaData.sellerPhone = dr["sellerPhone"].ToString();
                     oaData.sellerFax = dr["sellerFax"].ToString();
                     oaData.sellerOpebank = dr["sellerOpebanck"].ToString();
                     oaData.sellerBankId = dr["sellerBankacc"].ToString();

                     oaData.sellersigTime = dr["sellerSigtime"].ToString();
                     //oaData.userId = dr["userId"].ToString();
                     //oaData.Submitting = Boolean.Parse(dr["submitting"].ToString());
                     //oaData.Examine = Boolean.Parse(dr["examine"].ToString());

                     //明细表
                     dt.Clear();
                     com.Parameters.Clear();
                     com.CommandText = "select * from xf_contract_b where mid=@mid";
                     com.Parameters.AddWithValue("@mid", id);
                     da.SelectCommand = com;
                     da.Fill(dt);

                     SubVo[] vos = new SubVo[dt.Rows.Count];
                     for (int i = 0; i < dt.Rows.Count;i++ )
                     {
                         DataRow row = dt.Rows[i];
                         SubVo subVO = new SubVo();
                         subVO.sid = row["sid"].ToString();
                         subVO.mid = row["mid"].ToString();
                         subVO.invcode = row["invcode"].ToString();
                         subVO.invname = row["invname"].ToString();
                         subVO.invspec = row["invspec"].ToString();
                         subVO.measname = row["measname"].ToString();
                         subVO.measrate = row["measrate"].ToString();
                         subVO.num = row["num"].ToString();
                         subVO.price = row["price"].ToString();
                         subVO.nmoney = row["nmoney"].ToString();
                         subVO.def1 = row["def1"].ToString();
                         subVO.def2 = row["def2"].ToString();
                         subVO.def3 = row["def3"].ToString();
                         vos[i] = subVO;
                     }
                     oaData.subs=vos;
                 }
             }
             catch (Exception ex)
             {
                 if (conn.State == ConnectionState.Open)
                 {
                     conn.Close();
                 }
             }
             return oaData;
         }
    }
}