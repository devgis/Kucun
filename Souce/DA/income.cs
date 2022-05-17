using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class income
    {
        public static bool InsertNeedIn(string exp_id, string type, string amt, string remark, string bibie, string bibieje, string bibiehl)
        {
            try
            {
                string strSql = string.Format("insert needin(exp_id,typeid,amt,paidamt,isover,remark,bibie,bibieje,bibiehl)"+
                    " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}') ", exp_id, type, amt, "0", "N", remark, bibie, bibieje, bibiehl);
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
        public static bool EditNeedIn(string id, string type, string amt, string remark, string bibie, string bibieje, string bibiehl)
        {
            try
            {
                string strSql = string.Format("update needin set typeid=N'{0}',amt=N'{1}',paidamt=N'{2}',isover=N'{3}',"+
                    "remark=N'{4}',bibie=N'{5}',bibieje=N'{6}',bibiehl=N'{7}' where id=N'{8}'" , type, amt, "0", "N", remark, bibie, bibieje, bibiehl,id);
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
        public static bool UpdateNeedIn(string id, string paidamt, string isover)
        {
            try
            {
                string strSql = string.Format("update needin set paidamt={0},isover='{1}' where id={2}"
                    , paidamt, isover,id);
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
        public static bool UpdateIncome(string id)
        {
            try
            {
                string strSql = string.Format("update income set isover='Y' where id={0}",id);
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
        public static bool InsertInCome(string cust_id, string bankid, string amt,string date, string remark,string bibie,string bibieje,string bibiehl)
        {
            try
            {
                string strSql = string.Format("insert income(cust_id,bankid,amt,date,remark,bibie,bibieje,bibiehl)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ", cust_id, bankid, amt, date, remark,bibie,bibieje,bibiehl);
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
        public static DataTable GetIncome(string cust_id, string sale_id, string dtpStart, string dtpEnd,string isOver)
        {
            try
            {
                string strSql = string.Format("select a.*,b.*,c.*,(bi.bank+'-'+bi.bankno) as bank,case when isover='Y' then '是' else '否' end as is_over "
                    +" from income a left join customer b on a.cust_id=b.id left join users c on b.sale_id=c.id left join bankinfo bi on a.bankid=bi.id  where 1=1 ");
                if (!string.IsNullOrEmpty(cust_id) && cust_id != "0")
                {
                    strSql += string.Format(" and cust_id='{0}'", cust_id);
                }
                if (!string.IsNullOrEmpty(sale_id) && sale_id != "0")
                {
                    strSql += string.Format(" and b.sale_id = '{0}'", sale_id);
                }
                if (!string.IsNullOrEmpty(dtpStart))
                {
                    strSql += string.Format(" and a.date>='{0}'", dtpStart);
                }
                if (!string.IsNullOrEmpty(dtpEnd))
                {
                    strSql += string.Format(" and a.date<='{0}'", dtpEnd);
                }
                if (!string.IsNullOrEmpty(isOver))
                {
                    strSql += string.Format(" and a.isover='{0}'", isOver);
                }
                strSql += string.Format(" order by a.date desc;");
                strSql+="update needin set isover='Y'  where isover='N' and amt=paidamt and amt<>0";
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelInCome(string id)
        {
            try
            {
                string strSql = string.Format("delete income where id={0}", id);
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

        public static bool DelNeedIn(string id)
        {
            try
            {
                string strSql = string.Format("delete needin where id={0}",id);
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
        public static bool UpdateNeedIn(string exp_id, double amt,double amtcoin,double rate)
        {
            try
            {
                string strSql = string.Format("update needin set amt={1},bibieje={2},bibiehl='{3}' where exp_id={0} and typeid=1", exp_id, amt,amtcoin,rate);
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

        public static bool UpdateNeedIn(string exp_id, double amt, double amtcoin, double rate,string coin)
        {
            try
            {
                string strSql = string.Format("update needin set amt={1},bibieje={2},bibiehl='{3}',bibie='{4}' where exp_id={0} and typeid=1", exp_id, amt, amtcoin, rate,coin);
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

        public static DataTable GetNeedIn(string exp_id, string exp_no, string cust_id, string sale_id, string isOver, string start, string end)
        {
            try
            {
                string strSql = string.Format("select bibie,typeid,feetype,cust_name,c.exp_no,c.exp_volweight,c.exp_weight,exp_predict_postdate,c.exp_arrive_date,bibieje,cur_name,bibiehl,amt,a.remark, " +
                    "case when isover='Y' then '是' else '否' end as is_over,f.user_name,paidamt,(amt-paidamt) as stillamt,a.id from  needin a " +
                    "inner join incomtype b on a.typeid=b.id inner join express c on a.exp_id=c.id"+
                    " inner join customer d on c.exp_custid=d.id inner join users f on c.exp_sale_id=f.id left join currency g on g.id=a.bibie where 1=1 ");
                if (!string.IsNullOrEmpty(exp_id))
                {
                    strSql += string.Format(" and exp_id='{0}'",exp_id);
                }
                if (!string.IsNullOrEmpty(exp_no))
                {
                    strSql += string.Format(" and exp_no like '%{0}%'", exp_no);
                }
                if (!string.IsNullOrEmpty(cust_id) && cust_id!="0")
                {
                    strSql += string.Format(" and c.exp_custid='{0}'", cust_id);
                }
                if (!string.IsNullOrEmpty(sale_id)&&sale_id!="0")
                {
                    strSql += string.Format(" and c.exp_sale_id='{0}'", sale_id);
                }
                if (!string.IsNullOrEmpty(isOver))
                {
                    strSql += string.Format(" and a.isover='{0}' ", isOver);
                }
                if (!string.IsNullOrEmpty(start))
                {
                    strSql += string.Format(" and c.exp_arrive_date>='{0}' ", start);
                }
                if (!string.IsNullOrEmpty(end))
                {
                    strSql += string.Format(" and c.exp_arrive_date<='{0}' ", end);
                }
               
                strSql += string.Format("order by c.exp_arrive_date desc");
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
