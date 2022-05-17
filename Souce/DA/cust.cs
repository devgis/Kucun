using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CY.DA
{
    public class cust
    {
        public static int InsertCust(string cust_code,string cust_shortname,string cust_name,string sale_id,string addr,
            string city, string invoice_title, string website, string invoicetype, string trade,
            string ct_name, string ct_ename, string ct_position, string ct_phone, string ct_tel, string ct_email,
            string ct_fax, string ct_qq, string ct_skype, string remark, string specail, string taxno,string status,string custfrom,string ExportCountry,string wx,string user,string date)
        {
            try
            {
                string strSql = string.Format("insert into customer(cust_code,cust_shortname,cust_name,sale_id,addr," +
                    "city,invoice_title,website,invoicetype,trade," +
                    "ct_name,ct_ename,ct_position,ct_phone,ct_tel,ct_email,ct_fax,ct_qq,ct_skype,remark,specail,taxno,cust_status,cust_from,ExportCountry,wx,createuser,createdate)" +
                    " values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',"+
                    "N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',N'{26}',getdate());",
                    cust_code, cust_shortname, cust_name, sale_id, addr, city, invoice_title, website, invoicetype, trade,
                    ct_name, ct_ename, ct_position, ct_phone, ct_tel, ct_email, ct_fax, ct_qq, ct_skype, remark, specail, taxno, status, custfrom, ExportCountry,wx,user,date);
                //strSql += "select @@identity";
                //int iResult = Convert.ToInt32(SQLHelper.ExecuteDt(strSql).Rows[0][0]);
                //return iResult;
                int iResult =SQLHelper.ExecuteSql(strSql);
                return iResult;
                //if (iResult > 0)
                //    return true;
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateCust(string cust_code, string cust_shortname, string cust_name, string sale_id, string addr,
            string city, string invoice_title, string website, string invoicetype, string trade,
            string ct_name, string ct_ename, string ct_position, string ct_phone, string ct_tel, string ct_email,
            string ct_fax, string ct_qq, string ct_skype, string remark, string specail, string taxno, string cust_id, string status, string custfrom,string ExportCountry
            ,string wx, string user, string date)
        {
            try
            {
                string strSql = string.Format("Update customer set cust_code=N'{0}',cust_shortname=N'{1}',cust_name=N'{2}',sale_id=N'{3}',addr=N'{4}'," +
                    "city=N'{5}',invoice_title=N'{6}',website=N'{7}',invoicetype=N'{8}',trade=N'{9}'," +
                    "ct_name=N'{10}',ct_ename=N'{11}',ct_position=N'{12}',ct_phone=N'{13}',ct_tel=N'{14}',ct_email=N'{15}',ct_fax=N'{16}'," +
                     "ct_qq=N'{17}',ct_skype=N'{18}',remark=N'{19}',specail=N'{20}',taxno=N'{21}', "+
                     "cust_status=N'{22}',cust_from=N'{23}' ,ExportCountry=N'{25}',wx=N'{26}',lastuser=N'{27}',lastdate=N'{28}' where id=N'{24}' ",
                    cust_code, cust_shortname, cust_name, sale_id, addr, city, invoice_title, website, invoicetype, trade,
                    ct_name, ct_ename, ct_position, ct_phone, ct_tel, ct_email, ct_fax, ct_qq, ct_skype, remark, specail, taxno, status, custfrom,
                    cust_id, ExportCountry, wx,user, date);
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

        public static bool DelCust(string cust_id)
        {
            try
            {
                string strSql = string.Format("delete customer where id=N'{0}' ", cust_id);
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

        public static DataTable GetCust(string custName,string custid, string saleid, string trade,string status)
        {
            try
            {
                string strSql = string.Format("select ct_phone+'.'+ct_tel as tel,*,(case when invoicetype='N' then '不开' when invoicetype='P' then '普通发票' else '增值税发票' end) as istax,b.user_name,c.user_name as cuser   from customer a  left join users b on a.sale_id=b.id left join users c on a.createuser=c.id  where 1=1 ");
           
                if (!string.IsNullOrEmpty(custName) )
                {
                    strSql += string.Format(" and (a.cust_name like '%{0}%' ", custName);
                    string CustId = custName;
                    int irst = 0;
                    if (int.TryParse(custName, out irst))
                    {
                        strSql += string.Format(" or a.id = N'{0}')", CustId);
                    }
                    else
                    {
                        strSql += ")";
                    }

                    
                }
                
               

                if (!string.IsNullOrEmpty(custid) && custid!="0")
                {
                    strSql += string.Format(" and a.id=N'{0}'", custid);
                }
                if (!string.IsNullOrEmpty(saleid) && saleid != "0")
                {
                    strSql += string.Format(" and a.sale_id=N'{0}'", saleid);
                }
                if (!string.IsNullOrEmpty(trade))
                {
                    strSql += string.Format(" and a.trade like '%{0}%'", trade);
                }
                if (!string.IsNullOrEmpty(status))
                {
                    strSql += string.Format(" and a.cust_status = N'{0}'", status);
                }
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCustCj(string custName, string custid, string saleid, string start,string end)
        {
            try
            {
                string strSql = string.Format("select u.user_name,cust.cust_name,fm.cust_from,isnull(cj.cnt1,0) cnt1,isnull(je.cnt2,0) as cnt2,last.lastdate from customer cust "+
                    " left join (select exp_custid,count(1) cnt1 from express "+
                    " where exp_arrive_date>=N'{0}' and exp_arrive_date<=N'{1}' "+
                    " group by exp_custid"+
                    " ) cj on cust.id=cj.exp_custid"+
                    " left join"+
                    " ("+
                    " select exp_custid,sum(b.amt) cnt2 from express a inner join needin b on a.id=b.exp_id"+
                    " where exp_arrive_date>=N'{0}' and exp_arrive_date<=N'{1}'"+
                    " group by exp_custid"+
                    " )"+
                    " je on cust.id=je.exp_custid"+
                    " inner join "+
                    " ("+
                    "	select max(exp_arrive_date) lastdate,exp_custid from express "+
                    " where exp_arrive_date>=N'{0}' and exp_arrive_date<=N'{1}'"+
                    " group by exp_custid"+
                    " ) last" +
                    " on cust.id=last.exp_custid"+
                    " left join users u on cust.sale_id=u.id"+
                    " left join custfrom fm on cust.cust_from = fm.id where 1=1 ",start,end);

                if (!string.IsNullOrEmpty(custName))
                {
                    strSql += string.Format(" and cust.cust_name like'%{0}%'", custName);
                }
                if (!string.IsNullOrEmpty(custid) && custid != "0")
                {
                    strSql += string.Format(" and cust.id=N'{0}'", custid);
                }
                if (!string.IsNullOrEmpty(saleid) && saleid != "0")
                {
                    strSql += string.Format(" and cust.sale_id=N'{0}'", saleid);
                }
                strSql += " order by cnt2 desc";
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCustNJ(string custName, string custid, string saleid, string start, string end)
        {
            try
            {
                string strSql = string.Format("select b.cust_from as cf,ct_phone+'.'+ct_tel as tel,*,c.user_name as cuser   from customer a"+
                    "  left join custfrom b on a.cust_from=b.id left join users c on a.sale_id=c.id " +
                    "   where a.id not in(select distinct exp_custid from express where exp_arrive_date>=N'{0}' and  exp_arrive_date<=N'{1}')  ",start,end);

                if (!string.IsNullOrEmpty(custName))
                {
                    strSql += string.Format(" and a.cust_name like'%{0}%'", custName);
                }
                if (!string.IsNullOrEmpty(custid) && custid != "0")
                {
                    strSql += string.Format(" and a.id=N'{0}'", custid);
                }
                if (!string.IsNullOrEmpty(saleid) && saleid != "0")
                {
                    strSql += string.Format(" and a.sale_id=N'{0}'", saleid);
                }
        
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool ChangeSale(List<string> lstCust,string saleid)
        {
            try
            {
                string strSql = "";
                for (int i = 0; i < lstCust.Count; i++)
                {
                    strSql += string.Format("update customer set sale_id=N'{0}' where id=N'{1}';",saleid,lstCust[i]);
                }

                int iResult= SQLHelper.ExecuteSql(strSql);
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
        public static DataTable GetCustomer(string id)
        {
            try
            {
                string strSql = string.Format("select * from customer where 1=1");
                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format("and id=N'{0}'", id);
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
