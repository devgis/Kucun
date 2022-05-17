using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class basicData
    {
        public static DataTable GetCustomer()
        {
            try
            {
                string strSql = string.Format("select id,cust_name from customer");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetCurrentSale(string cust_id)
        {
            try
            {
                string strSql = string.Format("select a.id from users a left join customer b on a.id=b.sale_id where a.sta='Y' and a.role_id=1 and b.id={0} and sta='Y'", cust_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetSale()
        {
            try
            {
                string strSql = string.Format("select id,user_name from users  where role_id=1 and sta='Y' and sta='Y'");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFenhuo()
        {
            try
            {
                string strSql = string.Format("select id,user_name from users  where role_id=2 and sta='Y'");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetProduct()
        {
            try
            {
                string strSql = string.Format("select * from product");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertProduct(string product_name, string orderid)
        {
            try
            {
                string strSql = string.Format("insert product(product_name,orderid) values('{0}','{1}')", product_name, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditProduct(string product_name, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update product set product_name='{0}',orderid='{1}'  where id={2}", product_name, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelProduct(string id)
        {
            try
            {
                string strSql = string.Format("delete product where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDelivery()
        {
            try
            {
                string strSql = string.Format("select * from delivery");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertDelivery(string delivery_typename, string orderid)
        {
            try
            {
                string strSql = string.Format("insert Delivery(delivery_typename,orderid) values('{0}','{1}')", delivery_typename, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditDelivery(string delivery_typename, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update Delivery set delivery_typename='{0}',orderid='{1}'  where id={2}", delivery_typename, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelDelivery(string id)
        {
            try
            {
                string strSql = string.Format("delete Delivery where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string[] GetExpressReceiver()
        {
            try
            {
                string strSql = string.Format("select distinct rec_name from exp_receiver");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                List<string> lstReceiver = new List<string>();
                if (dt != null && dt.Rows.Count > 0)
                { 
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        lstReceiver.Add(dt.Rows[i][0].ToString());
                    }
                }
                return lstReceiver.ToArray() ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPayMode()
        {
            try
            {
                string strSql = string.Format("select * from paymode");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertMode(string paymode, string paymodename, string paymodedesc)
        {
            try
            {
                string strSql = string.Format("insert paymode(paymode,paymodename,paymodedesc) values('{0}','{1}','{2}')", paymode, paymodename, paymodedesc);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditMode(string paymode, string paymodename, string paymodedesc,string id)
        {
            try
            {
                string strSql = string.Format("update paymode set paymode='{0}',paymodename='{1}',paymodedesc='{2}' where id={3}", paymode, paymodename, paymodedesc,id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelMode(string id)
        {
            try
            {
                string strSql = string.Format("delete paymode where id={0}",id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCountry()
        {
            try
            {
                string strSql = string.Format("select * from country order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertCountry(string country_code, string country_name, string country_ename, string orderid)
        {
            try
            {
                string strSql = string.Format("insert Country(country_code,country_name,country_ename,orderid) values('{0}','{1}','{2}','{3}')", 
                    country_code, country_name, country_ename, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditCountry(string country_code, string country_name, string country_ename, string orderid,string id)
        {
            try
            {
                string strSql = string.Format("update Country set country_code='{0}',country_name='{1}',"+
                    "country_ename='{2}',orderid='{3}'  where id={4}", country_code, country_name, country_ename, orderid,id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelCountry(string id)
        {
            try
            {
                string strSql = string.Format("delete Country where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetTrade()
        {
            try
            {
                string strSql = string.Format("select * from trade");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCoin()
        {
            try
            {
                string strSql = string.Format("select * from currency order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertCoin(string cur_name,string rate_RMB, string orderid)
        {
            try
            {
                string strSql = string.Format("insert currency(cur_name,rate_RMB,orderid) values('{0}','{1}','{2}')", cur_name,rate_RMB, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditCoin(string cur_name,string rate_RMB, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update currency set cur_name='{0}',rate_RMB='{1}',orderid='{2}'  where id={3}", cur_name, rate_RMB, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelCoin(string id)
        {
            try
            {
                string strSql = string.Format("delete currency where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetStartCity()
        {
            try
            {
                string strSql = string.Format("select * from startcity order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCustform()
        {
            try
            {
                string strSql = string.Format("select * from custfrom order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertCustfrom(string cust_from, string orderid)
        {
            try
            {
                string strSql = string.Format("insert Custfrom(cust_from,orderid) values('{0}','{1}')", cust_from, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditCustfrom(string cust_from, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update Custfrom set cust_from='{0}',orderid='{1}'  where id={2}", cust_from, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelCustfrom(string id)
        {
            try
            {
                string strSql = string.Format("delete Custfrom where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetInComType()
        {
            try
            {
                string strSql = string.Format("select * from incomtype order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertInComType(string feetype, string orderid)
        {
            try
            {
                string strSql = string.Format("insert incomtype(feetype,orderid) values('{0}','{1}')", feetype, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditInComType(string feetype, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update incomtype set feetype='{0}',orderid='{1}'  where id={2}", feetype, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelInComType(string id)
        {
            try
            {
                string strSql = string.Format("delete incomtype where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBankInfo()
        {
            try
            {
                string strSql = string.Format("select * from bankinfo order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertBankInfo(string bank, string bankno, string orderid)
        {
            try
            {
                string strSql = string.Format("insert bankinfo(bank,bankno,orderid) values('{0}','{1}','{2}')", bank, bankno, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditBankInfo(string bank, string bankno, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update bankinfo set bank='{0}',bankno='{1}',orderid='{2}'  where id={3}", bank, bankno, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelBankInfo(string id)
        {
            try
            {
                string strSql = string.Format("delete bankinfo where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFeeType()
        {
            try
            {
                string strSql = string.Format("select * from feetype order by orderid asc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertFeeType(string feetype, string orderid)
        {
            try
            {
                string strSql = string.Format("insert FeeType(feetype,orderid) values('{0}','{1}')", feetype, orderid);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditFeeType(string feetype, string orderid, string id)
        {
            try
            {
                string strSql = string.Format("update FeeType set feetype='{0}',orderid='{1}'  where id={2}", feetype, orderid, id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelFeeType(string id)
        {
            try
            {
                string strSql = string.Format("delete FeeType where id={0}", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetServer()
        {
            try
            {
                string strSql = string.Format("select * from server");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
