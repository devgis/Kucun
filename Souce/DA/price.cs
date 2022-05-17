using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class price
    {
        public static DataTable GetPrice(string id,string serverid,string product,string startcity,string rec_country,string rec_city,
            string start_weight,string end_weight,string pricestart,string priceend)
        {
            try
            {
                string strSql = string.Format("select a.*,b.name as servername,c.country_name from price a " +
                    " left join server b on a.serverid=b.id left join country c on a.rec_country=c.id  where 1=1 ");
                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and a.id='{0}'", id);
                }
                if (!string.IsNullOrEmpty(serverid) && serverid != "0")
                {
                    strSql += string.Format(" and a.serverid='{0}'", serverid);
                }
                if (!string.IsNullOrEmpty(product))
                {
                    strSql += string.Format(" and a.product like '%{0}%'", product);
                }
                if (!string.IsNullOrEmpty(rec_country) && rec_country != "0")
                {
                    strSql += string.Format(" and a.rec_country='{0}'", rec_country);
                }
                if (!string.IsNullOrEmpty(startcity))
                {
                    strSql += string.Format(" and a.startcity like '%{0}%'", startcity);
                }
                if (!string.IsNullOrEmpty(rec_city))
                {
                    strSql += string.Format(" and a.rec_city like '%{0}%'", rec_city);
                }
                if (!string.IsNullOrEmpty(start_weight))
                {
                    strSql += string.Format(" and a.start_weight >= '{0}'", start_weight);
                }
                if (!string.IsNullOrEmpty(end_weight))
                {
                    strSql += string.Format(" and a.end_weight <= '{0}'", end_weight);
                }
                 if (!string.IsNullOrEmpty(pricestart))
                {
                    strSql += string.Format(" and a.price >= '{0}'", pricestart);
                }
                 if (!string.IsNullOrEmpty(priceend))
                {
                    strSql += string.Format(" and a.price <= '{0}'", priceend);
                }
  

                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertPrice(string serverid, string product, string startcity, string rec_country, string rec_city,
            string start_weight, string end_weight, string price_notax, string price, string remark)
        {
            try
            {
                string strSql = string.Format("insert into price(serverid,product,startcity,rec_country," +
                    "rec_city,start_weight,end_weight,price_notax,price,remark) values"+
                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}') "
                    , serverid, product, startcity, rec_country, rec_city, start_weight, end_weight, price_notax, price,remark);
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

        public static bool DelPrice(string id)
        {
            try
            {
                string strSql = string.Format("delete price where id={0} ", id);
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

        public static bool EditPrice(string serverid, string product, string startcity, string rec_country, string rec_city,
            string start_weight, string end_weight, string price_notax, string price, string remark,string id)
        {
            try
            {
                string strSql = string.Format("update price set serverid='{0}',product='{1}',startcity='{2}',rec_country='{3}'," +
                    "rec_city='{4}',start_weight='{5}',end_weight='{6}',price_notax='{7}',price='{8}',remark='{9}' where id={10}" 
                    , serverid, product, startcity, rec_country, rec_city, start_weight, end_weight, price_notax, price, remark,id);
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

    }
}
