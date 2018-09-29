using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataEntity;
using DataAccess;

namespace Equipment_Manager
{
     public class EpMgr
    {
         /// <summary>
         /// 资产增长
         /// </summary>
         /// <param name="eq"></param>
         /// <returns>true:成功；false：失败</returns>
        public static bool Add(Equipment eq)
        {
            string eqNo = eq.EqNo;
            string name = eq.Name;
            string type = eq.Type;
            string addtype = eq.AddType;
            int count = eq.Count;
            double price = eq.Price;
            string plus = eq.Plus;
            string lable = eq.Lable;
            string uintt = eq.Unit;
            DateTime birth =eq.Birthday;
            string keeper = eq.Keeper;
            string keepplace = eq.KeepPlace;
            string maker = eq.Maker;
            string model = eq.Model;
            string usetime = eq.UseTime;
            string booker = eq.Booker;
            DateTime bookdate = eq.BookDate;

            sqlHandler sh=new sqlHandler();
            string sql=string.Format("insert into equipment values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",eqNo,type,name,lable,model, plus,count,uintt , price,maker,birth,addtype,keepplace,keeper,usetime,booker,bookdate);
            return sh.ExecuteNonQuery(sql);                                                                                                                                                                                              

        }
         public static bool Update(Equipment eq)
         {
             string eqNo = eq.EqNo;
             string name = eq.Name;
             string type = eq.Type;
             string addtype = eq.AddType;
             int count = eq.Count;
             double price = eq.Price;
             string plus = eq.Plus;
             string lable = eq.Lable;
             string uintt = eq.Unit;
             DateTime birth = eq.Birthday;
             string keeper = eq.Keeper;
             string keepplace = eq.KeepPlace;
             string maker = eq.Maker;
             string model = eq.Model;
             string usetime = eq.UseTime;
             string booker = eq.Booker;
             DateTime bookdate = eq.BookDate;

             sqlHandler sh = new sqlHandler();
             string sql = string.Format("update equipment set type='{0}',name='{1}',label='{2}',model='{3}',plus='{4}',count={5},unit='{6}',price={7},maker='{8}',birthday='{9}',addtype='{10}',keepplace='{11}',keeper='{12}',usetime='{13}',booker='{14}',boodDate='15' where eqno='{16}'", type, name, lable, model, plus, count, uintt, price, maker, birth, addtype, keepplace, keeper, usetime, booker, bookdate, eqNo);
             return sh.ExecuteNonQuery(sql);       
 
         }
         /// <summary>
         /// 得到资产的全部信息
         /// </summary>
         /// <returns></returns>
         public static DataTable GetAll()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select 资产编号=eqno,资产类型=type,资产名称=name,品牌=label,数量=count,单位=unit,单价=price,生产时间=birthday,型号=model,配置=plus,增长方式=addtype,保存地点=keepplace,保管人=keeper,预计寿命=usetime,登记人=booker,登记时间=booddate,生产厂家=maker from Equipment";
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
         }
         /// <summary>
         /// 得到添加的最后一笔资产的资产编号
         /// </summary>
         /// <returns>"":没有找到；dt.Rows[0][0].ToString()：最后一笔资产的编号</returns>
         public static string GetLastEqNo()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select top 1 eqNo from Equipment order by eqno desc";
             DataTable dt = sh.GetData(sql);
             if (dt != null)
             {
                 if (dt.Rows.Count != 0)
                 {
                     return dt.Rows[0][0].ToString();
                 }
                 else
                 {
                     return "";
                 }
             }
             else
             {
                 return "";
             }
         }

    }
}
