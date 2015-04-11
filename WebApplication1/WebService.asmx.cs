using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Script;
using System.Web.Script.Services;
using System.Data.SqlClient;

namespace COFCOsubmission
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 查询存货
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        public string Getdata(string str)
            {
            string style;
            DataTable dt = DBHelp.GetData("select top 20 pk_material,rMecodeName,rMeSpecName from xf_rMaterial where rMecodeName like '%" + str + "%' order by rMecodeName desc");
            
            string Html= "<script src='Scripts/jquery-1.7.1.min.js'></script>";
            Html = Html + "<script src='Scripts/proTable.js'></script>";
            Html = Html + "<table id='productInfo' style='color:#333333;font-size:50px;width:100%;border-collapse:collapse;' border='0' cellpadding='4' cellspacing='0'>";
            Html=Html+"<tr style='color:White;background-color:#507CD1;font-weight:bold;'>";
            Html = Html + "<th style='display: none;' scope='col'>编号</th>";
            Html = Html + "<th class='productN' scope='col' style='width:70%;'>存货名称</th>";
            Html = Html + "<th scope='col'>规格</th><th scope='col'>确认</th></tr>";

            for (int i = 1;i<= dt.Rows.Count; i++)
            {
                
                if (i % 2 == 0)
                {
                    style = "background-color:White;";
                }
                else
                {
                    style = "background-color:#EFF3FB;";
                }

                Html = Html + "<tr style='" + style + "'>";
                Html = Html + "<td style='display: none;'>"+dt.Rows[i-1][0].ToString()+"</td><td style='width: 55%;'>"+dt.Rows[i-1][1].ToString()+"</td>";
                Html = Html + "<td style='width: 15%;'>" + dt.Rows[i-1][2] + "</td>";
                Html = Html + "";
                Html = Html + "<td><a id='Confi'><img style='height:40%;' class='Confirmation' id='Confirmation' alt='' src='img/my-slbsxtbB-(hui).png' /></a></td></tr>";              
            }

            Html = Html + "</table>";
            

            return Html;
        }

        /// <summary>
        ///客商查询
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetMerInfo(string str)
        {
            string style;
            DataTable dt = DBHelp.GetData("select top 20 pk_supplier,custname from xf_supplier where custname like '%" + str + "%' order by custname asc");

            string Html = "<script src='Scripts/jquery-1.7.1.min.js'></script>";
            Html = Html = "<script src='Scripts/MenuTable.js'></script>";
            Html = Html + "<table id='MenuTable'>";
            Html = Html + "<tr style='color:White;background-color:#507CD1;font-weight:bold;'>";
            Html = Html + "<th scope='col'>编码</th><th scope='col'>客商名称</th></tr>";

            for (int i=1;i<=dt.Rows.Count;i++ )
            {
                if (i % 2 == 0)
                {
                    style = "background-color:White;";
                }
                else
                {
                    style = "background-color:#EFF3FB;";
                }

                //Html = Html + "<tr style='" + style + "'><td>0001R810000000020QC1</td><td>";
                //Html=Html+"<input id='MerCheckbox' type='checkbox'></td>";
                //Html = Html + "<td>" + dt.Rows[i - 1]["custname"].ToString() + "</td></tr>";

                Html = Html + "<tr style='" + style + "'><td>" + dt.Rows[i - 1][0].ToString() + "</td>";
                Html = Html + "<td>" + dt.Rows[i - 1][1].ToString() + "</td></tr>";
            }
            Html = Html + "</table>";
            return Html;
        }

        /// <summary>
        /// 存储卖方编码
        /// </summary>
        /// <param name="str"></param>
        [WebMethod]
        public void savePayNum(string str) 
        {
            Variable.payNum = str;
        }


        /// <summary>
        /// 修改或则增加合同主表
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        [WebMethod]
        public string MainInfo(string contract)
        {
            string[] param = contract.Split('￥');
            string maninTnum = "";
            string sqlstr;
            string errs;

            SqlConnection conn = new SqlConnection(DBHelp.connectString);
            SqlCommand cmd;

            if (Variable.mainTNum == "")
            {

                maninTnum = GenerateCheckCode(32);
                

                sqlstr = "insert into xf_contract values(@id,@contractId,@contractAddress,@seller,@buyer,@deliveryTime,";
                sqlstr = sqlstr + "@deliveryAddress,@transcost,@paymentType,@performPeriod,@buyerRep,@buyerAddress,@buyerPhone,";
                sqlstr = sqlstr + "@buyerFax,@buyerOpebanck,@buyerBankacc,@buyerSigtime,@sellerRep,@sellerAddress,@sellerPhone,";
                sqlstr = sqlstr + "@sellerFax,@sellerOpebanck,@sellerBankacc,@sellerSigtime,@amountMoney,@userId)";

                cmd=new SqlCommand(sqlstr,conn);

                cmd.Parameters.AddWithValue("@id", maninTnum);
                cmd.Parameters.AddWithValue("@userId", Variable.pk_user);
                cmd.Parameters.AddWithValue("@amountMoney", "");
            }
            else
            {
                sqlstr = "update xf_contract set contractId=@contractId,contractAddress=@contractAddress,seller=@seller,buyer=@buyer,deliveryTime=@deliveryTime,";
                sqlstr = sqlstr + "deliveryAddress=@deliveryAddress,transcost=@transcost,paymentType=@paymentType,performPeriod=@performPeriod,buyerRep=@buyerRep,buyerAddress=@buyerAddress,buyerPhone=@buyerPhone,";
                sqlstr = sqlstr + "buyerFax=@buyerFax,buyerOpebanck=@buyerOpebanck,buyerBankacc=@buyerBankacc,buyerSigtime=@buyerSigtime,sellerRep=@sellerRep,sellerAddress=@sellerAddress,sellerPhone=@sellerPhone,";
                sqlstr = sqlstr + "sellerFax=@sellerFax,sellerOpebanck=@sellerOpebanck,sellerBankacc=@sellerBankacc,sellerSigtime=@sellerSigtime where id=@id";

                cmd=new SqlCommand(sqlstr,conn);

                cmd.Parameters.AddWithValue("@id", Variable.mainTNum);
            }


            cmd.Parameters.AddWithValue("@contractId",param[2]);
            cmd.Parameters.AddWithValue("@contractAddress", param[3]);
            cmd.Parameters.AddWithValue("@seller", param[0]);
            cmd.Parameters.AddWithValue("@buyer", param[1]);
            cmd.Parameters.AddWithValue("@deliveryTime", param[4]);
            cmd.Parameters.AddWithValue("@deliveryAddress", param[5]);
            cmd.Parameters.AddWithValue("@transcost", param[6]);
            cmd.Parameters.AddWithValue("@paymentType", param[7]);
            cmd.Parameters.AddWithValue("@performPeriod", param[8]);
            cmd.Parameters.AddWithValue("@sellerRep", param[16]);
            cmd.Parameters.AddWithValue("@sellerAddress", param[17]);
            cmd.Parameters.AddWithValue("@sellerPhone", param[18]);
            cmd.Parameters.AddWithValue("@sellerFax", param[19]);
            cmd.Parameters.AddWithValue("@sellerOpebanck", param[20]);
            cmd.Parameters.AddWithValue("@sellerBankacc", param[21]);
            cmd.Parameters.AddWithValue("@sellerSigtime", param[22]);
            cmd.Parameters.AddWithValue("@buyerRep", param[9]);
            cmd.Parameters.AddWithValue("@buyerAddress", param[10]);
            cmd.Parameters.AddWithValue("@buyerPhone", param[11]);
            cmd.Parameters.AddWithValue("@buyerFax", param[12]);
            cmd.Parameters.AddWithValue("@buyerOpebanck", param[13]);
            cmd.Parameters.AddWithValue("@buyerBankacc", param[14]);
            cmd.Parameters.AddWithValue("@buyerSigtime", param[15]);


                /*
                cmd.Parameters.AddWithValue("@contractId", contract[1].ContractID);
                cmd.Parameters.AddWithValue("@contractAddress", contract[1].SigningAddress);
                cmd.Parameters.AddWithValue("@seller", contract[1].Seller);
                cmd.Parameters.AddWithValue("@buyer", contract[1].Buyer);
                cmd.Parameters.AddWithValue("@deliveryTime", contract[1].DeliveryTime);
                cmd.Parameters.AddWithValue("@deliveryAddress", contract[1].DeliveryAddress);
                cmd.Parameters.AddWithValue("@transcost", contract[1].Transport);
                cmd.Parameters.AddWithValue("@paymentType", contract[1].PaymetType);
                cmd.Parameters.AddWithValue("@performPeriod", contract[1].PerformTime);
                cmd.Parameters.AddWithValue("@buyerRep", contract[1].BuyerRep);
                cmd.Parameters.AddWithValue("@buyerAddress", contract[1].BuyerAddress);
                cmd.Parameters.AddWithValue("@buyerPhone", contract[1].BuyerPhone);
                cmd.Parameters.AddWithValue("@buyerFax", contract[1].BuyerFax);
                cmd.Parameters.AddWithValue("@buyerOpebanck", contract[1].BuyerOpebank);
                cmd.Parameters.AddWithValue("@buyerBankacc", contract[1].BuyerBankId);
                cmd.Parameters.AddWithValue("@buyerSigtime", contract[1].BuyersigTime);
                cmd.Parameters.AddWithValue("@sellerRep", contract[1].SellerRep);
                cmd.Parameters.AddWithValue("@sellerAddress", contract[1].SellerAddress);
                cmd.Parameters.AddWithValue("@sellerPhone", contract[1].SellerPhone);
                cmd.Parameters.AddWithValue("@sellerFax", contract[1].SellerFax);
                cmd.Parameters.AddWithValue("@sellerOpebanck", contract[1].SellerOpebank);
                cmd.Parameters.AddWithValue("@sellerBankacc", contract[1].SellerBankId);
                cmd.Parameters.AddWithValue("@sellerSigtime", contract[1].SellersigTime);
            */

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    if (Variable.mainTNum == "")
                    {
                        Variable.mainTNum = maninTnum;
                    }
                    
                    errs = "";
                }
                catch (Exception err)
                {
                    Variable.mainTNum = "";
                    errs = err.ToString();
                }
                finally
                {
                    conn.Close();
                }

                return errs;

        }


        private int rep = 0;
       /// <summary>
       /// 生成随机字符串
       /// </summary>
       /// <param name="codeCount">待生成字符串长度</param>
       /// <returns>生成的字符串</returns>
        private string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + this.rep;
            this.rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this.rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }


        /// <summary>
        /// 将选中的存货添加到子表
        /// </summary>
        /// <param name="producId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        [WebMethod]
        public int insertDetail(string producId, string num)
        {
            string strsql;
            string sid = GenerateCheckCode(32);

            DataTable dt = DBHelp.GetData("select * from xf_salebill_b where mid='" + Variable.mainTNum + "' and invname='" + producId + "'");

            int i=0;
            if (dt.Rows.Count <= 0)
            {
                strsql = "insert into xf_salebill_b(sid,mid,invname,num) values('" + sid + "','" + Variable.mainTNum + "','" + producId + "','" + num + "')";
                i = DBHelp.updata(strsql);
            }

            
            return i;
        }

        /// <summary>
        /// 检验查询出来的存货在当前合同内是否存在
        /// </summary>
        /// <param name="producId"></param>
        /// <returns></returns>
        [WebMethod]
        public string  GetCheck(string producId)
        {
            
            string [] longstr = producId.Split('@');

            string sumstr = "";

            for(int i=0;i<longstr.Length;i++)
            {
                DataTable dt = DBHelp.GetData("select * from xf_salebill_b where mid='" + Variable.mainTNum + "' and invname='" + longstr[i].ToString() + "'");
                if(dt.Rows.Count>0)
                {
                    if (sumstr.Length<= 0)
                    {
                        sumstr = sumstr + i.ToString();
                    }
                    else
                    {
                        sumstr = sumstr + "@" + i.ToString();
                    }
                    
                }
            }

            return sumstr;
            
        }

        /// <summary>
        /// 查询子表详情
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string DetailHtml() 
        {
            string str = "";
            string style = "";
            DataTable dt = DBHelp.GetData("select a.sid,b.pk_material,b.rMeCodeName,a.num from xf_salebill_b as a,xf_rMaterial as b where a.invname = b.pk_material and a.mid = '" + Variable.mainTNum + "' ");

            if (dt.Rows.Count != 0)
            {
                str = str + " <div><script src='Scripts/jquery-1.7.1.min.js'></script>";
                str = str + "<script src='Scripts/'></script>";
                str = str + "<table id='SureGiv' style='color:#333333;width:100%;border-collapse:collapse;' border='0' cellpadding='4' cellspacing='0'>";
                str = str + "<tr style=' font-size:13px;color:White;background-color:#507CD1;font-weight:bold;'>";
                str = str + "<th style='display: none;' scope='col'>Sid</th><th scope='col'>存货名称</th><th scope='col'>数量</th><th scope='col'>单价</th><th scope='col'>总价</th></tr>";

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        style = "background-color:White;";
                    }
                    else
                    {
                        style = "background-color:#EFF3FB;";
                    }

                    str = str + "<tr style='" + style + "'><td style='display: none;'>" + dt.Rows[i - 1]["sid"].ToString() + "</td><td style='display: none;'>" + dt.Rows[i - 1]["pk_material"].ToString() + "</td>";
                    str = str + "<td style='width: 55%; text-align: left;'>" + dt.Rows[i - 1]["rMeCodeName"].ToString() + "</td>";
                    str = str + "<td style='text-align: center; width: 15%;'><input style='width:100%;' id='proNum' value='"+dt.Rows[i-1]["num"].ToString()+"' type='text'></td>";
                    str = str + "<td style='text-align: center; width: 15%;'><input style='width:100%;' id='prace' type='text'></td><td style='text-align: center; width: 15%;' >0.00</td></tr>";
                    
                }
                str = str + "</table></div>";

            }

            return str;
        }

        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="invname"></param>
        /// <param name="num"></param>
        /// <param name="price"></param>
        /// <param name="allprice"></param>
        /// <returns></returns>
        [WebMethod]
        public bool sureDetail(string str)
        {

            string[] line = str.Split('#');
            string strsql="";
            SqlConnection conn = new SqlConnection(DBHelp.connectString);
            SqlCommand cmd = conn.CreateCommand();

            conn.Open();
            cmd.Connection=conn;
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();
            cmd.Transaction=transaction;

            try
            {
                int allprice=0;
                for (int i = 0; i < line.Length; i++)
                {
                    string[] linetwo = line[i].Split('￥');

                    strsql = "update xf_salebill_b set invname='" + linetwo[1] + "',num='" + linetwo[2] + "',price='" + linetwo[3] + "',nmoney='" + linetwo[4] + "' where sid='" + linetwo[0] + "'";
                    cmd.CommandText = strsql;
                    allprice = allprice + Convert.ToInt32(linetwo[4]);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();

                string str1 = "update xf_contract set amountMoney='" + allprice + "' where id='"+Variable.mainTNum+"'";
                DBHelp.updata(strsql);

                Variable.mainTNum = "";
                return true;
            }catch
            {
                transaction.Rollback();
                return false;
            }finally
            {
                conn.Close();
            }
            

             

            
        }


        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getName()
        {
            string strsql = "select * from xf_user where pk_user='" + Variable.pk_user + "'";

            DataTable dt = DBHelp.GetData(strsql);

            return dt.Rows[0][2].ToString();
        }

        /// <summary>
        /// 获取已下订单
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetContract() 
        {
            string strsql = "select id,buyer,contractAddress from xf_contract where userId='" + Variable.pk_user + "'";

            DataTable dt = DBHelp.GetData(strsql);

            string style = "";
            string Html = "";
            Html = Html + "<script src='Scripts/jquery-1.7.1.min.js'></script><script src='Scripts/JavaScript1.js'></script>";
            Html = Html + "<div><table id='myGiv' style='color: #333333; width: 100%; border-collapse: collapse; font-size:12px;'  border='0' cellpadding='4' cellspacing='0'>";
            Html = Html + "<tbody><tr style='color: White; background-color: #507CD1; font-weight: bold;'>";
            Html = Html + "<th style='display: none;' scope='col'>Sid</th>";
            Html = Html + "<th scope='col'>合同编号</th><th scope='col'>买方</th><th scope='col'>签约地点</th></tr>";
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    style = "background-color:White;";
                }
                else
                {
                    style = "background-color:#EFF3FB;";
                }

                Html = Html + "<tr style='" + style + "'>";
                Html = Html + "<td style='display:none;'></td>";
                Html = Html + "<td style='width:35%;'>"+dt.Rows[i-1][0].ToString()+"</td>";
                Html = Html + "<td style='width:35%;'>" + dt.Rows[i - 1][1].ToString() + "</td>";
                Html = Html + "<td style='width:30%;'>" + dt.Rows[i - 1][2].ToString() + "</td></tr>";
            }

            Html = Html + "</tbody></table></div>";

            return Html;
        }


        /// <summary>
        /// 根据所选客商获取客商传真号码
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getFax()
        {
            string fax = "";
            string sqlstr = "select remark from xf_supplier where custname='" + Variable.payNum.Trim() + "'";
            DataTable dt = DBHelp.GetData(sqlstr);

            if (dt.Rows.Count > 0)
            {
                fax = dt.Rows[0][0].ToString();
            }

            return fax;
        }
    }
}
