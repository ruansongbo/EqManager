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
         /// �ʲ�����
         /// </summary>
         /// <param name="eq"></param>
         /// <returns>true:�ɹ���false��ʧ��</returns>
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
         /// �õ��ʲ���ȫ����Ϣ
         /// </summary>
         /// <returns></returns>
         public static DataTable GetAll()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select �ʲ����=eqno,�ʲ�����=type,�ʲ�����=name,Ʒ��=label,����=count,��λ=unit,����=price,����ʱ��=birthday,�ͺ�=model,����=plus,������ʽ=addtype,����ص�=keepplace,������=keeper,Ԥ������=usetime,�Ǽ���=booker,�Ǽ�ʱ��=booddate,��������=maker from Equipment";
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
         }
         /// <summary>
         /// �õ���ӵ����һ���ʲ����ʲ����
         /// </summary>
         /// <returns>"":û���ҵ���dt.Rows[0][0].ToString()�����һ���ʲ��ı��</returns>
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
