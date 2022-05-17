using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class Express
    {
        public static DataRow GetUname(string uid)
        {
            try
            {
                string sql = string.Format("select uname,usersite  from air_users where uid='{0}'", uid);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0].Rows[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getExp(string kid,string expno, string uname, string op,int imodify, int istart, int iend, int pageNow, int pageSize)
        {
            try
            {
                string strSql = "select * from air_awb where 1=1 ";
                if (!string.IsNullOrEmpty(kid))
                {
                    strSql += string.Format(" and kid = '{0}' ", kid);
                }
                if (!string.IsNullOrEmpty(expno))
                {
                    strSql += string.Format(" and awb like '%{0}%' ",expno);
                }

                if (!string.IsNullOrEmpty(uname))
                {
                    strSql += string.Format(" and (custname like '%{0}%' or uid like '%{0}%') ", uname);
                }

                if (!string.IsNullOrEmpty(op))
                {
                    strSql += string.Format(" and username like '%{0}%' ", op);
                }
                if (istart!=0)
                {
                    strSql += string.Format(" and adddate >= '{0}' ", istart);
                }
                if (iend != 0)
                {
                    strSql += string.Format(" and adddate <= '{0}' ", iend);
                }
                if(imodify>0)
                {
                    if (imodify == 2)
                        imodify = 0;
                    strSql+=string.Format(" and revise='{0}'",imodify);
                }


                int inow = (pageNow - 1) * pageSize;
                string strSqlOld = strSql.Replace("*", "count(1)");
               

                strSql += string.Format(" order by kid desc limit {0},{1} ", inow, pageSize);


                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                if (pageNow == 1)
                {
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetTime()
        {
            System.DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        public static bool Insert_SgAir(string custname, string uid, string kdnameid, string kdname, string awb, string ctns, string nwkg,
            string gwkg, string cbm, string l, string w, string h, string usersite,string uname)
        {
            try
            {
                double d_nwkg = Convert.ToDouble(nwkg);
                double d_gwkg = Convert.ToDouble(gwkg);
                string chakg = "0";
                if (d_nwkg > d_gwkg)
                    chakg = nwkg;
                else
                    chakg = gwkg;

                string avgkg = "0";
                if (d_nwkg > (d_nwkg + d_gwkg) / 2)
                    avgkg = nwkg;
                else
                    avgkg = Convert.ToString((d_nwkg + d_gwkg) / 2);

                int time = GetTime();
                string sql = string.Format("insert air_awb(" +
                                          "username,custname,uid," +
                                          "type,adddate,kdname," +
                                          "kdnameid,awb,ctns,nwkg,gwkg," +
                                          "cbm,l,w,h,usersite,chakg,avgkg) " +
                                          "values('{0}','{1}','{2}','{3}'," +
                                          "'{4}','{5}','{6}','{7}','{8}'," +
                                          "'{9}','{10}','{11}','{12}','{13}'," +
                                          "'{14}','{15}','{16}','{17}') ",
                                          uname, custname, uid,
                                          "1", time, kdname,
                                          kdnameid, awb, ctns, nwkg, gwkg,
                                          cbm, l, w, h, usersite, chakg, avgkg);

                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);

                if (custname != "疑问件" && custname != "查无此人")
                {
                    if (iResult > 0)
                    {
                        DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, string.Format("select telcode,tel  from air_users where uid='{0}'", uid));
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Rows[0];
                        string msg = string.Format("Dear{0},\r\n China air shipment warehouse have received your package\r\n {1}:{2}.\r\n If you need more information Pls contact us." +
                                "\r\n亲,{0} 中国空运仓库已收到您的包裹{1}:{2}.\r\n如需更多信息，请联系我们.{3}", custname, kdname, awb, "www.cn2sg.com");
                        sql = string.Format("insert air_sms(addtime,uname,uid,telcode,tel,info) values({0},'{1}','{2}','{3}','{4}','{5}')",
                            time, custname, uid, dr["telcode"].ToString(), dr["tel"].ToString(), msg);
                        iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);



                    }
                }


                //if (iResult > 0)
                //{
                //     sql = string.Format("insert air_warehouse(" +
                //                           "username,custname,uid," +
                //                           "type,mg,adddate,goodsname,kdname," +
                //                           "kdnameid,awb,ctns,nwkg,gwkg," +
                //                           "cbm,l,w,h) " +
                //                           "values('{0}','{1}','{2}','{3}','{4}'," +
                //                           "'{5}','{6}','{7}','{8}','{9}'," +
                //                           "'{10}','{11}','{12}','{13}','{14}'," +
                //                           "'{15}','{16}') ",
                //                           pub.uname, custname, uid,
                //                           "1", mg, time, "", kdname,
                //                           kdnameid, awb, ctns, nwkg, gwkg,
                //                           cbm, l, w, h);
                //}
                //iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);


                return iResult > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool Insert_HY(string custname, string uid, string kdnameid, string kdname, string awb, string ctns, string nwkg,
           string gwkg, string cbm, string l, string w, string h, string usersite, string uname)
        {
            try
            {
                //double d_nwkg = Convert.ToDouble(nwkg);
                //double d_gwkg = Convert.ToDouble(gwkg);
                //string chakg = "0";
                //if (d_nwkg > d_gwkg)
                //    chakg = nwkg;
                //else
                //    chakg = gwkg;

                //string avgkg = "0";
                //if (d_nwkg > (d_nwkg + d_gwkg) / 2)
                //    avgkg = nwkg;
                //else
                //    avgkg = Convert.ToString((d_nwkg + d_gwkg) / 2);

                //gwkg
                nwkg = "99.99";
                string chakg = "99.99";
                string avgkg = "99.99";

                int time = GetTime();
                string sql = string.Format("insert air_awb(" +
                                          "username,custname,uid," +
                                          "type,adddate,kdname," +
                                          "kdnameid,awb,ctns,nwkg,gwkg," +
                                          "cbm,l,w,h,usersite,chakg,avgkg) " +
                                          "values('{0}','{1}','{2}','{3}'," +
                                          "'{4}','{5}','{6}','{7}','{8}'," +
                                          "'{9}','{10}','{11}','{12}','{13}'," +
                                          "'{14}','{15}','{16}','{17}') ",
                                          uname, custname, uid,
                                          "2", time, kdname,
                                          kdnameid, awb, ctns, nwkg, gwkg,
                                          cbm, l, w, h, usersite, chakg, avgkg);

                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);

                if (custname != "疑问件" && custname != "查无此人")
                {
                    if (iResult > 0)
                    {
                        DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, string.Format("select telcode,tel  from air_users where uid='{0}'", uid));
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Rows[0];
                        string msg = string.Format("Dear{0},\r\n China air shipment warehouse have received your package\r\n {1}:{2}.\r\n If you need more information Pls contact us." +
                                "\r\n亲,{0} 中国空运仓库已收到您的包裹{1}:{2}.\r\n如需更多信息，请联系我们.{3}", custname, kdname, awb, "www.cn2sg.com");
                        sql = string.Format("insert air_sms(addtime,uname,uid,telcode,tel,info) values({0},'{1}','{2}','{3}','{4}','{5}')",
                            time, custname, uid, dr["telcode"].ToString(), dr["tel"].ToString(), msg);
                        iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                    }
                }

                return iResult > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertBank(string banknameid,string admin,DateTime transfertime,
            string debit,string credit,string balance,string payid,string receipturl,string action,string adminmark,string revise)
        {
            try
            {
                string strTime = transfertime.ToString("yyyy-MM-dd");
                double d_debit = Convert.ToDouble(debit);
                double d_credit = Convert.ToDouble(credit);
                d_debit = d_debit - d_credit;
                string strSql = string.Format("insert air_bank(banknameid,addtime,admin,transfertime,debit,"+
                    "credit,balance,payid,receipturl,action,"+
                    "adminmark,revise) " +
                    " select   '{0}',now() ,'{1}',CONCAT('{2} ',DATE_FORMAT(now(), ' %H:%i:%s')),'{3}','{4}',balance+{10},'{5}','{6}','{7}','{8}','{9}'  from air_bank where banknameid='{0}'  order by transfertime  desc,bid desc limit 1;",
               banknameid, admin, strTime, debit, credit, payid, receipturl, action, adminmark, revise, d_debit);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //withdrawphoto,state,successtime,
        //bankid,adminmark,admin,wdid
        public static bool InsertWithDraw(string withdrawphoto, 
           string bankid, string adminmark, string admin, string wdid)
        {
            try
            {

                string strSql = string.Format("update air_withdraw set withdrawphoto=concat('http://photo.ea-ex.com/','{0}'),state='2',bankid='{1}',adminmark='{2}',admin='{3}'," +
                    "successtime=unix_timestamp() where wdid='{4}'",
                    withdrawphoto, bankid, adminmark, admin, wdid);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool InsertDaifu(string withdrawphoto, 
        string bankid, string adminmark, string admin, string wdid,string payid)
        {
            try
            {

                string strSql = string.Format("update air_daifu set daifuphoto=concat('http://photo.ea-ex.com/','{0}'),state='2',bankid='{1}',adminmark='{2}',admin='{3}'," +
                    "successtime=unix_timestamp(),bankid='{5}' where dfid='{4}'",
                    withdrawphoto, bankid, adminmark, admin, wdid, payid);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool UpdateBank(string bid, string banknameid, string admin, DateTime transfertime,
           string debit, string credit, double balance, string payid, string receipturl, string action, string adminmark, string revise, 
            double dChange,DateTime pre_time,string prebankid)
        {
            try
            {
                balance = balance + dChange;
                string strSql = string.Format("update air_bank set banknameid='{0}',updatetime=now(),admin='{2}',transfertime='{3}',debit='{4}'," +
                    "credit='{5}',payid='{7}',receipturl='{8}',action='{9}'," +
                    "adminmark='{10}',revise='{11}',balance=balance+{13}   where bid='{12}';",
                banknameid, "updatetime", admin, transfertime, debit,
                credit, "", payid, receipturl, action,
                adminmark, revise, bid, dChange);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);

                bool bResult= RefreshBank(banknameid);
                if(banknameid != prebankid)
                {
                    bResult =RefreshBank(banknameid);
                }

                return bResult;
                //strSql=string.Format("select balance from air_bank  "+
                //                    "where transfertime <'{0}' and banknameid='{1}' and bid<>'{2}' order by transfertime desc,bid desc limit 1 ",pre_time,banknameid,bid);
                //DataSet ds1 = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
                //DataTable dt1 = new DataTable();
                //dt1 = ds1.Tables[0];
                //if (dt1.Rows.Count > 0)
                //{
                //    balance = Convert.ToDouble(dt1.Rows[0][0]);
                //}

                //strSql = string.Format("select bid,debit,credit,balance from air_bank where transfertime >='{0}' and banknameid='{1}'  order by transfertime,bid asc ", pre_time, banknameid, bid);
                //DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
                //DataTable dt = new DataTable();
                //dt = ds.Tables[0];
                //strSql = "";
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        balance = balance + Convert.ToDouble(dt.Rows[i]["debit"]) - Convert.ToDouble(dt.Rows[i]["credit"]);
                //        strSql += string.Format("update air_bank set balance={0} where bid='{1}';", balance, dt.Rows[i]["bid"].ToString());

                //    }
                //}
                //if (strSql.Length > 0)
                //    iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                //return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool InsertBalance(string YM_last, string YM, string sdate, string edate, string admin,string banknameid)
        {
            try
            {

                string strSql = string.Format("select count(1) as cnt from air_bankbalance where ym='{0}' and banknameid='{1}'", YM_last, banknameid);
                DataSet ds=MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString,CommandType.Text,strSql);
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) < 1)
                {
                    throw new Exception("该月的上个月还没有月结！");
                }

                strSql = string.Format("select count(1) as cnt from air_bank where addtime between '{0}' and '{1}' and banknameid='{2}'", sdate, edate, banknameid);
                ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) < 1)
                {
                    throw new Exception("该月无有交易数据，无法月结！");
                }

                strSql = string.Format("insert air_bankbalance(balance,ym,admin,addtime,banknameid)" +
                    " select sum(balance) as balance,'{1}','{4}',NOW(),'{5}' from (select balance from air_bankbalance where ym='{0}' union " +
                    "select sum(debit-credit)   from air_bank where addtime between '{2}' and '{3}' " +
                    ") as tb;update air_bank set isclose='Y' where addtime between '{2}' and '{3}';", YM_last, YM, sdate, edate, admin, banknameid);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool CloseBank(string dt, string banknameid)
        {
            dt = dt + " 23:59:59";
            string strSql = string.Format("update air_bank set isclose='Y' where transfertime<='{0}' and banknameid='{1}';", dt, banknameid);
            int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
            return iResult > 0;
        }

        public static bool RefreshBank(string banknameid)
        {
            double balance = 0;
            string strSql = string.Format("select balance from air_bank  " +
                                   "where isclose='Y' and banknameid='{0}'  order by transfertime desc limit 1 ", banknameid);
            DataSet ds1 = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables[0];
            if (dt1.Rows.Count > 0)
            {
                balance = Convert.ToDouble(dt1.Rows[0][0]);
            }

            strSql = string.Format("select bid,debit,credit,balance from air_bank where isclose<>'Y' and banknameid='{0}'  order by transfertime  asc,bid asc ", banknameid);
            DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            strSql = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    balance = balance + Convert.ToDouble(dt.Rows[i]["debit"]) - Convert.ToDouble(dt.Rows[i]["credit"]);
                    strSql += string.Format("update air_bank set balance={0} where bid='{1}';", balance, dt.Rows[i]["bid"].ToString());

                }
            }
            int iResult = 0;
            if (strSql.Length > 0)
                iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
            return iResult > 0;
        }

        public static DataTable getBalance()
        {
            try
            {
                string sql = string.Format("select a.*,b.adminname,c.bankname from air_bankbalance a left join air_admin_client b on a.admin =b.aid " +
                    " left join air_bankname c on a.banknameid=c.bid order by ym desc ");
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime getMaxTranTime(string bankid)
        { 
            try
            {
                string sql = string.Format("select max(transfertime) from air_bank where banknameid='{0}' and isclose='Y'",bankid);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1 ||ds.Tables[0].Rows[0][0]==null || ds.Tables[0].Rows[0][0].ToString()=="")
                {
                    return DateTime.Now.AddYears(-50);
                }
                else
                {
                    return Convert.ToDateTime(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }       


        //public static DataTable getBalance()
        //{
        //    try
        //    {
        //        string sql = string.Format("select * from air_bankname");
        //        DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
        //        if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return ds.Tables[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DataTable getBankName(string uid)
        {
            try
            {
                string sql = string.Format("select c.* from air_admin_client a inner join air_bankusers b on a.aid=b.userID "+
                "inner join air_bankname c on b.bankID=c.bid  where aid='{0}'  order by orderby asc",uid);
                if (string.IsNullOrEmpty(uid))
                {
                    sql = "select * from air_bankname";
                }
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable getAction()
        {
            try
            {
                string sql = string.Format("select * from air_bankaction order by bankactionby ");
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable getBank(string payid, string bank, string bid, string actionid, string admin, int revise, 
            DateTime istart, DateTime iend, int pageNow, int pageSize,
            string uid)
        {
            try
            {
                string strSql = "select concat(b.bankname,'-',a.bid) as bankname,a.*,c.bankactionname,d.adminname  from air_bank a " +
                "left join air_bankname b on a.banknameid=b.bid left join  air_bankaction c on a.action=c.bid "+
                "left join air_admin_client d on a.admin =d.aid  where 1=1 ";

                if (!string.IsNullOrEmpty(uid))
                {
                    strSql += string.Format(" and banknameid in (select c.bid from air_admin_client a inner join air_bankusers b on a.aid=b.userID " +
                "inner join air_bankname c on b.bankID=c.bid  where aid='{0}')", uid);
                }
                if (!string.IsNullOrEmpty(bank) && bank != "0")
                {
                    bank = bank.Replace(",", "','");
                    strSql += string.Format(" and a.banknameid in ('{0}') ", bank);
                }
                
                if (!string.IsNullOrEmpty(bid) && bid != "0")
                {
                    strSql += string.Format(" and a.bid = '{0}' ", bid);
                }

                if (!string.IsNullOrEmpty(payid))
                {
                    strSql += string.Format(" and a.payid like  '%{0}%' ", payid);
                }

                if (!string.IsNullOrEmpty(actionid) && actionid != "0")
                {
                    actionid = actionid.Replace(",", "','");
                    strSql += string.Format(" and  a.action in ('{0}')  ", actionid);
                }

                if (!string.IsNullOrEmpty(admin) && admin != "0")
                {
                    strSql += string.Format(" and a.admin = '{0}' ", admin);
                }
                if (revise > 0)
                {
                    if (revise == 2)
                        revise = 0;
                    strSql += string.Format(" and a.revise='{0}'", revise);
                }

                if (istart!=DateTime.Now.AddYears(-50))
                {
                    strSql += string.Format(" and transfertime >= '{0}' ", istart);
                }
                if (iend != DateTime.Now.AddYears(-50))
                {
                    strSql += string.Format(" and transfertime <= '{0}' ", iend);
                }
               


                int inow = (pageNow - 1) * pageSize;
                string strSqlOld = strSql.Replace("concat(b.bankname,'-',a.bid) as bankname,a.*,c.bankactionname", "count(1)");


                strSql += string.Format(" order by transfertime desc ,bid  desc limit {0},{1} ", inow, pageSize);


                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                if (pageNow == 1)
                {
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetExpressType1()
        {
            try
            {
                string sql = string.Format("select kdname,kdnameid from air_awbname order by  kdid asc");
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static DataTable GetExpressType()
        {
            try
            {
                string sql = string.Format("select kdname,kdnameid from air_kdairname order by  kdid asc");
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertExp(
               string awb, string cbm, string ctns, string gwkg, string l,
               string w, string h, string kdname, string kdnameid, string nwkg,
               string place, string revise, string mg, string type, string uid,
               string avgkg, string chakg, string custname, string remark,string kid
               )
        {
            try
            {
                string strSql = string.Format(" update air_awb set awb='{0}',cbm='{1}',ctns='{2}',gwkg='{3}',l='{4}', "+
                    "w='{5}', h='{6}', kdname='{7}', kdnameid='{8}', nwkg='{9}',"+
                    "place='{10}', revise='{11}', mg='{12}', type='{13}', uid='{14}',"+
                    "avgkg='{15}', chakg='{16}', custname='{17}' where kid='{18}' " ,  
               awb, cbm, ctns, gwkg, l,
               w, h, kdname, kdnameid, nwkg,
               place, revise, mg, type, uid,
               avgkg, chakg, custname,kid);

                int iResult=MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetHis(string kid)
        {
            try
            {
                string sql = string.Format("select * from awb_history where kid='{0}' order by createdate asc",kid);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return null;
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertHis(string username,string content,string reason,string kid)
        {
            try
            {
                string strSql = string.Format("insert awb_history(username,createdate,content,reason,kid) values('{0}',now() ,'{1}','{2}','{3}') ",
               username,content,reason,kid);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
                return iResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int GetTime(DateTime time)
        {
            //System.DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public static DataTable getOp()
        {
            try
            {
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, "select aid,adminname from air_admin_client where state='1'");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getWebsite()
        {
            try
            {
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, "select uwid,cnname from air_userswebs");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getrecordaction()
        {
            try
            {
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, "select actionno,cnname from air_recordaction");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getUserMoney(string uid)
        {
            try
            {
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text,
                    "select  moneysg,sgdin,sgdout,sgdin-sgdout as sgdbalance  from air_users  where uid="+uid);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getRecord(string recordid, string uname, string uid, string website, string addtimes, string addtimee, int pageNow, int pageSize, string actionno)
        {
            try
            {
                string strSql = string.Format("select a.recordid,FROM_UNIXTIME(a.addtime) as addtime,a.uname,a.uid,b.cnname,c.cnname,concat(c.idname,'-',d.idname,'-',detail) as action,d.cnname as actionanme,rmmoneybalance, " +
                "case d.actiontype when 0 then moneysg else '' end as moneysg0,case d.actiontype when 1 then moneysg else '' end as moneysg1,sgmoneybalance,'' AS adminmake  from air_record a  " +
                "left join air_userswebs b on a.usersite=b.uwno  " +
                "left join air_userswebs c on a.website=c.uwno  " +
                "left join air_recordaction d on a.action=d.actionno where 1=1 ");
                
                

                //recordid,uname,	uid,website,addtime
                if (!string.IsNullOrEmpty(recordid))
                    strSql += string.Format(" and a.detail like '%{0}%'", recordid);
                if (!string.IsNullOrEmpty(uname))
                    strSql += string.Format(" and a.uname like '%{0}%'", uname);
                if (!string.IsNullOrEmpty(uid))
                    strSql += string.Format(" and a.uid like '%{0}%'", uid);
                if (!string.IsNullOrEmpty(website)&&website!="0")
                    strSql += string.Format(" and website='{0}'", website);
                if (!string.IsNullOrEmpty(addtimes))
                    strSql += string.Format(" and addtime>={0}", addtimes);
                if (!string.IsNullOrEmpty(addtimee))
                    strSql += string.Format(" and addtime<={0}", addtimee);

                if (!string.IsNullOrEmpty(actionno) && actionno != "0")
                    strSql += string.Format(" and actionno='{0}'", actionno);

                int inow = (pageNow - 1) * pageSize;
                strSql += string.Format(" order by recordid desc  limit {0},{1}  ", inow, pageSize);

                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);
               

                if (pageNow == 1)
                {
                    int iIndex = strSql.IndexOf("air_record");
                    string strSqlOld = "select count(1) from " + strSql.Substring(iIndex);
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getWithDraw(string id, int state, string uname, string websites, long sdate, long edate, int pageNow, int pageSize)
        {
            try
            {
                string strSql = string.Format("select wdid,uid,CONCAT(b.idname,'-WD-',wdid) as id, "+
                "case state when 1 then '等待处理' when 2 then '提现成功' end as state, "+
                "case state when 2 then admin else '' end as admin, "+
                 "case a.addtime when 0 then '' else  FROM_UNIXTIME(a.addtime) end as addtime,uname,b.cnname as usersite, " +
                "c.cnname as websites,bankname,accountname, " +
                "accountno,moneysg,case moneyrm when 0 then '' else moneyrm end as moneyrm, "+
                " case a.successtime when 0 then '' else  FROM_UNIXTIME(a.successtime) end as updatatime,bankid,a.mark,a.adminmark,withdrawphoto  " +
                "  from air_withdraw a "+
                "left join air_userswebs b on a.usersite=b.uwid "+
                "left join air_userswebs c on a.websites=c.uwid "+
                "  where 1=1 ");

                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and a.wdid like '%{0}%' ", id);
                }
                if (state>0)
                {
                    strSql += string.Format(" and a.state = '{0}' ", state);
                }
                if (!string.IsNullOrEmpty(uname))
                {
                    strSql += string.Format(" and (a.uid like '%{0}%' or uname like '%{0}%') ", uname);
                }
                if (websites != "" && websites != "0")
                {
                    strSql += string.Format(" and a.websites = '{0}' ", websites);
                }
                strSql += string.Format(" and successtime>={0}", sdate);
                strSql += string.Format(" and successtime<={0}", edate);

                int inow = (pageNow - 1) * pageSize;
                strSql += string.Format(" order by wdid desc  limit {0},{1}  ", inow, pageSize);

                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);

                if (pageNow == 1)
                {
                    int iIndex = strSql.IndexOf("air_withdraw");
                    string strSqlOld = "select count(1) from " + strSql.Substring(iIndex);
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getRecharge(string id, int state, string uname, string websites, long sdate, long edate, int pageNow, int pageSize)
        {
            #region 有问题
            //try
            //{
            //    string strSql = string.Format("select tpid,uid,CONCAT(b.idname,'-WD-',tpid) as id, " +
            //    "case state when 1 then '等待处理' when 2 then '充值成功' end as state, " +
            //    "case state when 2 then admin else '' end as admin, " +
            //     "case a.addtime when 0 then '' else  FROM_UNIXTIME(a.addtime) end as addtime,uname,b.cnname as usersite, " +
            //    "c.cnname as websites,bankname,accountname, " +
            //    "accountno,moneysg,case moneyrm when 0 then '' else moneyrm end as moneyrm, " +
            //    " case a.successtime when 0 then '' else  FROM_UNIXTIME(a.successtime) end as updatatime,bankid,a.mark,a.adminmark,withdrawphoto  " +
            //    "  from air_topup a " +
            //    "left join air_userswebs b on a.usersite=b.uwid " +
            //    "left join air_userswebs c on a.websites=c.uwid " +
            //    "  where 1=1 ");

            //    if (!string.IsNullOrEmpty(id))
            //    {
            //        strSql += string.Format(" and a.tpid like '%{0}%' ", id);
            //    }
            //    if (state > 0)
            //    {
            //        strSql += string.Format(" and a.state = '{0}' ", state);
            //    }
            //    if (!string.IsNullOrEmpty(uname))
            //    {
            //        strSql += string.Format(" and (a.uid like '%{0}%' or uname like '%{0}%') ", uname);
            //    }
            //    if (websites != "" && websites != "0")
            //    {
            //        strSql += string.Format(" and a.websites = '{0}' ", websites);
            //    }
            //    strSql += string.Format(" and successtime>={0}", sdate);
            //    strSql += string.Format(" and successtime<={0}", edate);

            //    int inow = (pageNow - 1) * pageSize;
            //    strSql += string.Format(" order by tpid desc  limit {0},{1}  ", inow, pageSize);

            //    DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);

            //    if (pageNow == 1)
            //    {
            //        int iIndex = strSql.IndexOf("air_topup");
            //        string strSqlOld = "select count(1) from " + strSql.Substring(iIndex);
            //        DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
            //        ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
            //    }
            //    return ds.Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            #endregion

            try
            {
                string strSql = string.Format("select tpid,uid,CONCAT(b.idname,'-WD-',tpid) as id, " +
                "case state when 1 then '等待处理' when 2 then '充值成功' end as state, " +
                "case state when 2 then adminmark else '' end as admin, " +
                 "case a.addtime when 0 then '' else  FROM_UNIXTIME(a.addtime) end as addtime,uname,b.cnname as usersite, " +
                "c.cnname as websites,'' as bankname,'' as accountname, " +
                "'' as accountno,moneysg,case moneyrm when 0 then '' else moneyrm end as moneyrm, " +
                " case a.successtime when 0 then '' else  FROM_UNIXTIME(a.successtime) end as updatatime,bankid,'' as mark,a.adminmark,topupphoto  " +
                "  from air_topup a " +
                "left join air_userswebs b on a.usersite=b.uwid " +
                "left join air_userswebs c on a.website=c.uwid " +
                "  where 1=1 ");

                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and a.tpid like '%{0}%' ", id);
                }
                if (state > 0)
                {
                    strSql += string.Format(" and a.state = '{0}' ", state);
                }
                if (!string.IsNullOrEmpty(uname))
                {
                    strSql += string.Format(" and (a.uid like '%{0}%' or uname like '%{0}%') ", uname);
                }
                if (websites != "" && websites != "0")
                {
                    strSql += string.Format(" and a.website = '{0}' ", websites);
                }
                strSql += string.Format(" and successtime>={0}", sdate);
                strSql += string.Format(" and successtime<={0}", edate);

                int inow = (pageNow - 1) * pageSize;
                strSql += string.Format(" order by tpid desc  limit {0},{1}  ", inow, pageSize);

                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);

                if (pageNow == 1)
                {
                    int iIndex = strSql.IndexOf("air_topup");
                    string strSqlOld = "select count(1) from " + strSql.Substring(iIndex);
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static DataTable getDaifuAction()
        {
            try
            {
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text,
                    "Select dfno,cnname from air_daifuaction" );
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getDaifu(string id, int state, string uname, string websites,string dfsite,string dfaction, long sdate, long edate, int pageNow, int pageSize)
        {
            try
            {
                string strSql = string.Format("select a.dfid as wdid,uid,CONCAT(b.idname,'-DF-',a.dfid) as id,case state when 1 then '等待处理' when 2 then '已处理' end as state,admin, " +
                "case addtime when 0 then '' else  FROM_UNIXTIME(addtime) end as addtime	,uname	,b.cnname as  usersite	, "+
                "c.cnname as websites,	d.cnname as daifutype	,daifualipay,	daifudetail	,moneyrmb	, "+
                "rate,	moneysg	,case moneyrm when 0 then '' else moneyrm end as moneyrm	,case successtime when 0 then '' else  FROM_UNIXTIME(successtime) end as successtime,bankid	,adminmark	,DAIFUphoto from air_daifu a  " +
                "left join air_userswebs b on a.usersite=b.uwid  "+
                "left join air_userswebs c on a.website=c.uwid  "+
                "left join air_daifuaction d on a.daifutype=d.dfno " +
                "  where 1=1 ");

                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and a.dfid like '%{0}%' ", id);
                }
                if (state > 0)
                {
                    strSql += string.Format(" and a.state = '{0}' ", state);
                }
                if (!string.IsNullOrEmpty(uname))
                {
                    strSql += string.Format(" and (a.uid like '%{0}%' or uname like '%{0}%') ", uname);
                }
                if (dfsite != "" && dfsite != "0")
                {
                    strSql += string.Format(" and a.website = '{0}' ", dfsite);
                }
                if (websites != "" && websites != "0")
                {
                    strSql += string.Format(" and a.usersite = '{0}' ", websites);
                }
                if (dfaction != "" && dfaction != "0")
                {
                    strSql += string.Format(" and a.daifutype = '{0}' ", dfaction);
                }

                
                strSql += string.Format(" and successtime>={0}", sdate);
                strSql += string.Format(" and successtime<={0}", edate);

                int inow = (pageNow - 1) * pageSize;
                strSql += string.Format(" order by a.dfid desc  limit {0},{1}  ", inow, pageSize);

                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql);

                if (pageNow == 1)
                {
                    int iIndex = strSql.IndexOf("air_daifu");
                    string strSqlOld = "select count(1) from " + strSql.Substring(iIndex);
                    DataSet dsTotal = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSqlOld);
                    ds.Tables[0].TableName = dsTotal.Tables[0].Rows[0][0].ToString();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
