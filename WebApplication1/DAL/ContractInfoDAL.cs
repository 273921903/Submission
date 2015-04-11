using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace COFCOsubmission.DAL
{
    public class ContractInfoDAL
    {
        //connectString 用于储存数据库连接信息
        public static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["conName"].ToString();


        /// <summary>
        /// 查询指定合同子表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData(string mid)
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
                com.CommandText = "select * from xf_contract_b where mid = '" + mid + "'";

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                return null;

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
        /// 将选中的存货添加到合同子表
        /// </summary>
        /// <param name="contract_b"></param>
        /// <returns></returns>
        public static int AddContract_b(DAL.Contract_b contract_b)
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

                com.CommandText = "insert into xf_contract_b (sid,mid,invcode,invname,invspec,measname,measrate) values(@sid,@mid,@invcode,@invname,@invspec,@measname,@measrate)";
                com.Parameters.AddWithValue("@sid", contract_b.Sid);
                com.Parameters.AddWithValue("@mid", contract_b.Mid);
                com.Parameters.AddWithValue("@invcode", contract_b.Invcode);
                com.Parameters.AddWithValue("@invname", contract_b.Invname);
                com.Parameters.AddWithValue("@invspec", contract_b.Invspec);
                com.Parameters.AddWithValue("@measname", contract_b.Measname);
                com.Parameters.AddWithValue("@measrate", contract_b.Measrate);

                int i = com.ExecuteNonQuery();

                transaction.Commit();
                return i;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据子表编号删除记录
        /// </summary>
        /// <param name="code"></param>
        public static void DeletInfoByCode(string code)
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
                com.CommandText = "delete from xf_contract_b where sid='" + code + "'";
                com.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 修改合同明细
        /// </summary>
        /// 
        public static int UpdateContract_b(Contract_b[] subVOS)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            try
            {
                conn=new SqlConnection(connectString);
                SqlCommand com = new SqlCommand();
                com.Connection = conn;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                transaction = conn.BeginTransaction();
                com.Transaction = transaction;

                string sql = "update xf_contract_b set ";
                sql += "num=@num,";
                sql += "price=@price,";
                sql += "nmoney=@nmoney ";
                sql += "where sid=@sid ";

                com.CommandText = sql;
                foreach (Contract_b vo in subVOS)
                {
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@num", vo.Num);
                    com.Parameters.AddWithValue("@price", vo.Price);
                    com.Parameters.AddWithValue("@nmoney", vo.Nmoney);
                    com.Parameters.AddWithValue("@sid", vo.Sid);
                    com.ExecuteNonQuery();
                }
                //查询主表主键
                com.Parameters.Clear();
                com.CommandText = "select mid from xf_contract_b where sid=@sid";
                com.Parameters.AddWithValue("@sid", subVOS[0].Sid);
                string id = com.ExecuteScalar().ToString();
                
                //修改主表状态为保存
                com.Parameters.Clear();
                com.CommandText = "update xf_contract set submitting=1 where id=@id ";
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();

                transaction.Commit();
                return 1;
            } catch (Exception ex)
            {
                transaction.Rollback();
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}