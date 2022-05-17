using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CY.DA
{
    public class server
    {
        public static bool InsertServer(string name,string website,string trade,string bank,string bankno,string bankuser,string remark,
        string ct_name,string ct_ename,string ct_position,string ct_phone,string ct_tel,string ct_email,
        string ct_fax,string ct_qq,string ct_skype,string ct_addr,string ct_city,string ct_name1,
        string ct_ename1,string ct_position1,string ct_phone1,string ct_tel1,
        string ct_email1,string ct_fax1,string ct_qq1,string ct_skype1,string ct_addr1,string ct_city1,string code,string product_id)
        {
            try
            {
                string strSql = string.Format(
                    "insert into server(name,website,trade,bank,bankno," +
                    "bankuser,remark,ct_name,ct_ename,ct_position," +
                    "ct_phone,ct_tel,ct_email,ct_fax,ct_qq," +
                    "ct_skype,ct_addr,ct_city,ct_name1,ct_ename1," +
                    "ct_position1,ct_phone1,ct_tel1,ct_email1,ct_fax1," +
                    "ct_qq1,ct_skype1,ct_addr1,ct_city1,code,product_id)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}'" +
                    ",'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}')",
                    name,website,trade,bank,bankno,
                    bankuser,remark,ct_name,ct_ename,ct_position,
                    ct_phone,ct_tel,ct_email,ct_fax,ct_qq,
                    ct_skype,ct_addr,ct_city,ct_name1,ct_ename1,
                    ct_position1,ct_phone1,ct_tel1,ct_email1,ct_fax1,
                    ct_qq1, ct_skype1, ct_addr1, ct_city1, code, product_id);
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
        public static bool UpdateServer(string name, string website, string trade, string bank, string bankno, string bankuser, string remark,
        string ct_name, string ct_ename, string ct_position, string ct_phone, string ct_tel, string ct_email,
        string ct_fax, string ct_qq, string ct_skype, string ct_addr, string ct_city, string ct_name1,
        string ct_ename1, string ct_position1, string ct_phone1, string ct_tel1,
        string ct_email1, string ct_fax1, string ct_qq1, string ct_skype1, string ct_addr1, string ct_city1, string code, string id,string product_id)
        {
            try
            {
                string strSql = string.Format("update server set name='{0}',website='{1}',trade='{2}',bank='{3}',bankno='{4}'," +
                    "bankuser='{5}',remark='{6}',ct_name='{7}',ct_ename='{8}',ct_position='{9}'," +
                    "ct_phone='{10}',ct_tel='{11}',ct_email='{12}',ct_fax='{13}',ct_qq='{14}'," +
                    "ct_skype='{15}',ct_addr='{16}',ct_city='{17}',ct_name1='{18}',ct_ename1='{19}'," +
                    "ct_position1='{20}',ct_phone1='{21}',ct_tel1='{22}',ct_email1='{23}',ct_fax1='{24}'," +
                    "ct_qq1='{25}',ct_skype1='{26}',ct_addr1='{27}',ct_city1='{28}',code='{29}', product_id='{31}' where id={30} ",
                    name, website, trade, bank, bankno,
                    bankuser, remark, ct_name, ct_ename, ct_position,
                    ct_phone, ct_tel, ct_email, ct_fax, ct_qq,
                    ct_skype, ct_addr, ct_city, ct_name1, ct_ename1,
                    ct_position1, ct_phone1, ct_tel1, ct_email1, ct_fax1,
                    ct_qq1, ct_skype1, ct_addr1, ct_city1, code, id, product_id);
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
        public static DataTable GetServer(string id,string server,  string trade,string product_id)
        {
            try
            {
                string strSql = string.Format("select a.*,b.product_name from server a left join product b on a.product_id=b.id  where 1=1  ");
                if (!string.IsNullOrEmpty(id))
                {
                    strSql += string.Format(" and a.id={0}", id);
                }
                if (!string.IsNullOrEmpty(server))
                {
                    strSql += string.Format(" and a.name like '%{0}%'", server);
                }
                if (!string.IsNullOrEmpty(trade))
                {
                    strSql += string.Format(" and a.ct_city like '%{0}%' or ct_city1 like '%{0}%'", trade);
                }
                if (!string.IsNullOrEmpty(product_id) && product_id != "0")
                {
                    strSql += string.Format(" and a.product_id = '{0}' ", product_id);
                
                }

                return SQLHelper.ExecuteDt(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DelServer(string server_id)
        {
            try
            {
                string strSql = string.Format("delete server where id='{0}' ", server_id);
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
