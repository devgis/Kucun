using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class Track
    {
        public static DataTable GetTrackList()
        {
            try
            {
                string strSql = string.Format("select * from tracklist");
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetTrackMain(string ExpNo, string cust_id, string startDate, string endDate)
        {
            try
            {
                string strSql = string.Format("select *,shipcity scity from express a left join exp_receiver b on a.id=b.exp_id " +
               " left join exp_receiver c on a.id=c.exp_id left join product d on a.exp_product_id=d.id " +
               " left join country e on b.rec_countryid=e.id left join users f on a.exp_sale_id=f.id " +
               " left join customer g on a.exp_custid=g.id " +
               " left join (select * from track where id in(select max(id) from track group by exp_id)) h on a.id=h.exp_id" +
               "  where 1=1");
                if (!string.IsNullOrEmpty(ExpNo))
                {
                    strSql += string.Format(" and a.exp_no like '%{0}%'", ExpNo);
                }
                if (!string.IsNullOrEmpty(cust_id) && cust_id != "0")
                {
                    strSql += string.Format(" and a.exp_custid='{0}'", cust_id);
                }
                //if (!string.IsNullOrEmpty(saleid) && saleid != "0")
                //{
                //    strSql += string.Format(" and a.exp_sale_id='{0}'", saleid);
                //}
                if (!string.IsNullOrEmpty(startDate))
                {
                    strSql += string.Format(" and a.exp_arrive_date>='{0}'", startDate);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    strSql += string.Format(" and a.exp_arrive_date<='{0}'", endDate);
                }
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetTrackDetail(string exp_id)
        {
            try
            {
                string strSql = string.Format("select * from track where exp_id='{0}'", exp_id);
                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertTrackDetail(string exp_id, string date, string desc, string descen, string descru, string user)
        {
            try
            {
                string strSql = string.Format("insert track(exp_id,trackdate,trackdesc,tracken,trackru,trackuser) values('{0}','{1}','{2}','{3}','{4}','{5}')", exp_id, date, desc, descen, descru, user);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateTrackDetail(string exp_id, string date, string desc, string descen, string descru, string user)
        {
            try
            {
                string strSql = string.Format("update track set trackdate='{0}',trackdesc='{1}',tracken='{4}',trackru='{5}',trackuser='{2}' where id='{3}'", date, desc, user, exp_id, descen, descru);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelTrackDetail(string exp_id)
        {
            try
            {
                string strSql = string.Format("delete track   where id='{0}'", exp_id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditTrackList(DataTable dt)
        {
            try
            {
                string strSql = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["id"].ToString() != "")
                    {
                        strSql += string.Format("update tracklist set trackdesc='{0}',parentid='{1}',tracken='{3}',trackru='{4}' where id='{2}';",
                            dr["trackdesc"].ToString(), dr["parentid"].ToString(), dr["id"].ToString(), dr["tracken"].ToString(), dr["trackru"].ToString());
                    }
                    else
                    {
                        strSql += string.Format("insert tracklist(trackdesc,parentid,tracken,trackru) values('{0}','{1}','{2}','{3}');",
                            dr["trackdesc"].ToString(), dr["parentid"].ToString(), dr["tracken"].ToString(), dr["trackru"].ToString());
                    }
                }
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DelTrackList(string id)
        {
            try
            {
                string strSql = string.Format("delete tracklist where id='{0}'", id);
                int iResult = SQLHelper.ExecuteSql(strSql);
                if (iResult > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
