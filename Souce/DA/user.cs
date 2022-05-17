using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace CY.DA
{
    public class user
    {
        public static string getMd5(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return "";
            }
            byte[] result = Encoding.Default.GetBytes(pwd);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            pwd = BitConverter.ToString(output).Replace("-", "").ToLower();  //tbMd5pass为输出加密文本的文本框
            return pwd;
        }
        public static DataSet Login(string user, string pwd)
        {
            try
            {
                //string s = "select uid from air_users order by uid asc";
                //DataSet dsu = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, s, null);
                //s = "";
                //for (int i = 373; i < 2000; i++)
                //{
                //    s+= string.Format("insert air_users(uid) values({0});",i+1); 
                //}
                //int ir = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text,s,null);

                pwd = getMd5(pwd);
                string sql = string.Format("select aid,adminname from air_admin_client where adminname='{0}' and adminpwd='{1}'", user, pwd);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetUname(string uid)
        {
            try
            {
                string sql = string.Format("select uname from dg_users where uid='{0}'", uid);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, sql, null);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    return "";
                }
                else
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

        public static DataTable GetUser(string user_name,string id)
        {
            try
            {
                string strSql = string.Format("select * from air_admin_client where 1=1  ");
                if (!string.IsNullOrEmpty(user_name))
                {
                    strSql += string.Format(" and adminname like '%{0}%'", user_name);
                }
                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and aid = '{0}'", id);
                }
                DataSet ds= MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public static bool InsertUser(string adminname, string adminpwd)
        {
            try
            {
                adminpwd=getMd5(adminpwd);
                string strSql = string.Format("insert into air_admin_client(adminname,adminpwd,state)" +
                    " values('{0}','{1}',{2});",
                    adminname, adminpwd, 1);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
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

        public static bool UpdateUser(string adminname, string adminpwd,string state,string aid)
        {
            try
            {
                string strSql = string.Format("update air_admin_client set adminname='{0}',adminpwd='{1}',state='{2}'  where aid='{3}'",
                    adminname, adminpwd, state, aid);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
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

        public static bool DelUser(string id)
        {
            try
            {
                string strSql = string.Format("delete from air_admin_client where aid='{0}'", id);
                int iResult = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString, CommandType.Text, strSql, null);
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

        public static DataTable GetUserPer(string User_id)
        {
            try
            {
                string strSql = string.Format("select * from air_admin_client a inner join usermenu b on a.aid=b.aid inner join menu c on b.menuid=c.id where 1=1  ");
                if (!string.IsNullOrEmpty(User_id))
                {
                    strSql += string.Format(" and b.aid = '{0}'", User_id);
                }
                else if (string.IsNullOrEmpty(User_id))
                {
                    strSql = string.Format("select * from menu ");
                }
                strSql+= "order by c.orders asc ";
                DataSet ds= MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString,CommandType.Text,strSql,null);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return new DataTable();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetMenu(string aid)
        {
            try
            {
                string strSql = string.Format("select *,'true' as chk from menu where id in(select menuid from usermenu where aid='{0}') union select *,'false' as chk from menu where id not in(select menuid from usermenu where aid='{0}') order by orders asc", aid);
                DataSet ds = MySqlHelper.ExecuteDataSet(MySqlHelper.DBConnectionString,CommandType.Text,strSql,null);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SavePerm(string aid, DataTable dtMenu)
        {
            try
            {
                string strSql = string.Format("delete from usermenu where aid='{0}';", aid);
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    strSql += string.Format("insert into usermenu(menuid,aid) values('{0}','{1}');", dtMenu.Rows[i]["id"].ToString(), aid);
                }
                int iInsert = MySqlHelper.ExecuteNonQuery(MySqlHelper.DBConnectionString,CommandType.Text,strSql,null);
                if (iInsert > 0)
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
