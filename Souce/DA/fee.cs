using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class fee
    {
        public static DataTable GetFee(string exp_id,string exp_no, string type_id, string stardate, string enddate,string server)
        {
            try
            {
                string strSql = string.Format("select a.exp_no,a.exp_weight,a.exp_volweight,a.exp_unitprice,b.*,c.*,d.*,g.name from express a inner join fee b on a.id=b.exp_id " +
                    "  left join currency c on b.coin_id=c.id left join feetype d on b.type_id=d.id left join server g on a.serverid=g.id where 1=1  ");
                //and a.exp_exp_no='{0}' and a.exp_sale_id='{1}' and exp_arrive_date>'{2}' and exp_arrive_date<'{3}'; ",ExpNo,saleid,startDate,endDate);
                if (!string.IsNullOrEmpty(exp_id))
                {
                    strSql += string.Format(" and a.id = '{0}'", exp_id);
                }
                if (!string.IsNullOrEmpty(exp_no))
                {
                    strSql += string.Format(" and a.exp_no like '%{0}%'", exp_no);
                }
                if (!string.IsNullOrEmpty(type_id) && type_id != "0")
                {
                    strSql += string.Format(" and b.type_id='{0}'", type_id);
                }
                if (!string.IsNullOrEmpty(stardate) && stardate != "0")
                {
                    strSql += string.Format(" and b.date>='{0}'", stardate);
                }
                if (!string.IsNullOrEmpty(enddate) && enddate != "0")
                {
                    strSql += string.Format(" and b.date<='{0}'", enddate);
                }
                if (!string.IsNullOrEmpty(server))
                {
                    strSql += string.Format(" and g.name like '%{0}%'", server);
                }
                strSql += string.Format("order by b.date desc");
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFeeF(string name,string rqleft,string rqright,string daoh,string yifu)
        {
            try
            {
                string strSql = string.Format("select distinct a.exp_no,exp_weight,exp_volweight,isnull(a.closedate,'') closedate ,serverjine, " +
                                              "e.daoh,a.exp_arrive_date,b.name,isnull(c.amt,'0') amt, " + 
                                               "isnull(c.rate,'0') rate,isnull(c.amt_rmb,'0') amt_rmb,isnull(c.date,'') date,isnull(d.cur_name,'') cur_name from express a " +
                                           "inner join server b on a.serverid=b.id left join fee c on a.id=c.exp_id left join currency d on  c.coin_id=d.id left join "+
                                            " (select case when closedate='' or isnull(closedate,'')='' then '否' else '是' end as daoh,exp_no from express) as e on e.exp_no=a.exp_no "+
                                           // " left join (select id,case when id not in (select exp_id from fee) then '否' else '是' end as yifu from express) as f on f.id=a.id " +
                                            "where 1=1 ");
                                          
                if (!string.IsNullOrEmpty(name))
                {
                    strSql += string.Format("and name like '%{0}%' ", name);
                }
                if (!string.IsNullOrEmpty(rqleft) && rqleft != "0")
                {
                    strSql += string.Format("and a.exp_arrive_date>='{0}' ", rqleft);
                }
                if (!string.IsNullOrEmpty(rqright) && rqright != "0")
                {
                    strSql += string.Format("and a.exp_arrive_date<='{0}' ", rqright);
                }
                if (!string.IsNullOrEmpty(daoh))
                {
                    strSql += string.Format("and daoh='{0}' ", daoh);
                }
                if (!string.IsNullOrEmpty(yifu))
                {
                    strSql += string.Format("and serverjine='{0}' ", yifu);
                }
                strSql += string.Format("order by a.exp_arrive_date desc");
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                return dt;
                //""
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertFee(string exp_id, string type_id, string amt, string coin_id, string rate,
            string amt_rmb, string date, string userid, string remark)
        {
            try
            {
                string strSql = string.Format("insert fee(exp_id,type_id,amt,coin_id,rate,amt_rmb,date,userid,remark)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}') ", exp_id, type_id, amt, coin_id, rate, amt_rmb, date, userid, remark);
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

        public static bool DelFee(string id)
        {
            try
            {
                string strSql = string.Format("delete fee where id={0}", id);
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

        public static double GetBaoxian(string exp_id)
        {
            try
            {
                string strSql = string.Format("select amt from needin a left join incomtype b on a.typeid=b.id where feetype='保险费' and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double GetBaoxianC(string exp_id)
        {
            try
            {
                string strSql = string.Format("select bibieje from needin a left join incomtype b on a.typeid=b.id where feetype='保险费' and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double GetMuJia(string exp_id)
        {
            try
            {
                string strSql = string.Format("select amt from needin a left join incomtype b on a.typeid=b.id where feetype='打木架费' and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double GetMuJiaC(string exp_id)
        {
            try
            {
                string strSql = string.Format("select bibieje from needin a left join incomtype b on a.typeid=b.id where feetype='打木架费' and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double GetOther(string exp_id)
        {
            try
            {
                string strSql = string.Format("select sum(amt) from needin a left join incomtype b on a.typeid=b.id"+
                    " where feetype not in('打木架费','保险费','运费') and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetOtherDetail(string exp_id)
        {
            try
            {
                string strSql = string.Format("select feetype,bibieje,cur_name,amt from needin a left join incomtype b on a.typeid=b.id left join currency c on a.bibie=c.id "+
                     " where feetype not in('打木架费','保险费','运费') and exp_id={0}  order by exp_id ", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string str = "其他费用详细：";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    { 
                        DataRow dr=dt.Rows[i];
                        if(dr["bibieje"].ToString()!=dr["amt"].ToString())
                        {
                            str += dr["feetype"].ToString() + ":" + dr["bibieje"].ToString() + dr["cur_name"].ToString() + "(合" + dr["amt"].ToString() + "元)；";
                        }
                        else
                        {
                            str += dr["feetype"].ToString() + ":" + dr["amt"].ToString() + "元；";
                        }
                    }
                    if (str.Length > 1)
                        str = str.Substring(0, str.Length - 1);
            
                    return str;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double GetOtherC(string exp_id)
        {
            try
            {
                string strSql = string.Format("select sum(bibieje) from needin a left join incomtype b on a.typeid=b.id" +
                    " where feetype not in('打木架费','保险费','运费') and exp_id={0}", exp_id);
                DataTable dt = SQLHelper.ExecuteDt(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")
                        return 0;
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNeedinT(string exp_id, string cust_name, string dtpStart,string dtpEnd)
        {
            try
            {
                string strSql = string.Format("select * from express a left join "+
"(select exp_id,amt as amt_yf from needin where typeid=1) b on a.id=b.exp_id left join "+
"(select exp_id,amt as amt_bxf from needin where typeid=3) c on a.id=c.exp_id left join "+
"(select exp_id,sum(amt) amt_other from needin where typeid <> 10 and typeid<>3 group by exp_id) d on a.id=d.exp_id "+
"left join exp_receiver e on e.exp_id=a.id  left join customer f on f.id=exp_custid "+
" left join country g on e.rec_countryid=g.id left join product h on a.exp_product_id=h.id left join delivery j on j.id=a.exp_delivery "+
" left join server k on k.id=a.serverid  left join (select id,user_name  ywy from users where id in(select exp_sale_id from express)) as m on m.id=a.exp_sale_id "+
" left join users l on l.id=a.fh_user left join paymode  n on n.paymode=a.exp_paymode where 1=1");
                if (!string.IsNullOrEmpty(exp_id))
                {
                    strSql += string.Format("and a.exp_no='{0}'",exp_id);
                }
                if (!string.IsNullOrEmpty(cust_name))
                {
                    strSql += string.Format("and f.cust_name='{0}'", cust_name);
                }
                if (!string.IsNullOrEmpty(dtpStart))
                {
                    strSql += string.Format("and a.createdate>='{0}'", dtpStart);
                }
                if (!string.IsNullOrEmpty(dtpEnd))
                {
                    strSql += string.Format("and a.createdate<='{0}'", dtpEnd);
                }
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
