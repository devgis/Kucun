using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;


namespace CY.Controls
{
    public class pubCtr
    {
        public static void setcmb(ref bxyztSkin.CControls.CCombox cob,bool bFirst)
        {
            cob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
        
            switch (cob.Name)
            {
                case "cobCust":
                    dt = CY.DA.basicData.GetCustomer();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "cust_name";
                    dr = dt.NewRow();
                    dr["id"] = "0";
                    dr["cust_name"] = "";
                    break;
                case "cobDelivery":
                    dt = CY.DA.basicData.GetDelivery();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "delivery_typename";
                    dr = dt.NewRow();
                    dr["id"] = "0";
                    dr["delivery_typename"] = "";
                    break;
                case "cobPaymode":
                     dt = CY.DA.basicData.GetPayMode();
                     dr = dt.NewRow();
                     cob.ValueMember = "paymode";
                     cob.DisplayMember = "paymodename";
                     dr["paymode"] = "0";
                     dr["paymodename"] = "";
                     break;
                case "cobProduct":
                    dt = CY.DA.basicData.GetProduct();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "product_name";
                    dr["id"] = "0";
                    dr["product_name"] = "";
                    break;
                case "cobCountry":
                    dt = CY.DA.basicData.GetCountry();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "country_name";
                    dr["id"] = "0";
                    dr["country_name"] = "";
                    break;
             
                case "cobSale":
                    dt = CY.DA.basicData.GetSale();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "user_name";
                    dr["id"] = "0";
                    dr["user_name"] = "";
                    break;
                case "cobSale1":
                    dt = CY.DA.basicData.GetSale();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "user_name";
                    dr["id"] = "0";
                    dr["user_name"] = "";
                    break;
                case "cobCoin":
                    dt = CY.DA.basicData.GetCoin();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "cur_name";
                    dr["id"] = "0";
                    dr["cur_name"] = "";
                    break;
                case "cobShip":
                    dt = CY.DA.basicData.GetStartCity();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "startcity";
                    dr["id"] = "0";
                    dr["startcity"] = "";
                    break;
                case "cobCustFrom":
                    dt = CY.DA.basicData.GetCustform();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "cust_from";
                    dr["id"] = "0";
                    dr["cust_from"] = "";
                    break;
                case "cobIncomType":
                    dt = CY.DA.basicData.GetInComType();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "feetype";
                    dr["id"] = "0";
                    dr["feetype"] = "";
                    break;
                case "cobBankInfo":
                    dt = CY.DA.basicData.GetBankInfo();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "bank";
                    dr["id"] = "0";
                    dr["bank"] = "";
                    break;
                case "cobFeeType":
                    dt = CY.DA.basicData.GetFeeType();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "feetype";
                    dr["id"] = "0";
                    dr["feetype"] = "";
                    break;
                case "cobServer":
                    dt = CY.DA.basicData.GetServer();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "name";
                    dr["id"] = "0";
                    dr["name"] = "";
                    break;
                case "cobFenhuo":
                    dt = CY.DA.basicData.GetFenhuo();
                    dr = dt.NewRow();
                    cob.ValueMember = "id";
                    cob.DisplayMember = "user_name";
                    dr["id"] = "0";
                    dr["user_name"] = "";
                    break;
            }
            if (bFirst)
                dt.Rows.InsertAt(dr, 0);
            cob.DataSource = dt;
            //cob.SelectedIndex = 0;
         
        }

        public static  void WriteExcel(DataTable dt, string[] strExportCol, string[] strcolName, string[] strNum, string path)
        {
            try
            {
                //path += "导出列表.xls";
                long totalCount = dt.Rows.Count;
                System.Threading.Thread.Sleep(1000);
                long rowRead = 0;
                //float percent = 0;

                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < strcolName.Length; k++)
                {
                    sb.Append(strcolName[k] + "\t");
                }
                sb.Append(Environment.NewLine);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowRead++;
                    //percent = ((float)(100 * rowRead)) / totalCount;

                    System.Windows.Forms.Application.DoEvents();
                    for (int j = 0; j < strExportCol.Length; j++)
                    {
                        //if (strNum.Contains(strExportCol[j]))
                        //{
                        //    dt.Rows[i][strExportCol[j]] = dt.Rows[i][strExportCol[j]];
                        //}
                        sb.Append(dt.Rows[i][strExportCol[j]].ToString().Replace("\t", "") + "\t");

                    }
                    sb.Append(Environment.NewLine);
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
