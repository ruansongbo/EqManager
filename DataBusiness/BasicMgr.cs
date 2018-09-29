using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class BasicMgr
    {

        /// <summary>
        /// 获取辅助表格的信息
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DataTable GetBasicInfo(string source)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            
            

            switch (source)
            {
                case "车辆产地": sql = "select id as 编号, discrip as 基本描述 from CarBP order by id"; break;
                case "车辆用途": sql = "select id as 编号, discrip as 基本描述 from CarUse order by id"; break;
                case "编制情况": sql = "select id as 编号, discrip as 基本描述 from Formation order by id"; break;
                case "权属性质": sql = "select id as 编号, discrip as 基本描述 from CertNature order by id"; break;
                case "产权形式": sql = "select id as 编号, discrip as 基本描述 from Pr order by id"; break;
                case "建筑结构": sql = "select id as 编号, discrip as 基本描述 from Structure order by id"; break;
                case "文物等级": sql = "select id as 编号, discrip as 基本描述 from RelicLv order by id"; break;
                case "采购形式": sql = "select id as 编号, discrip as 基本描述 from BuyWay order by id"; break;
                case "取得方式": sql = "select id as 编号, discrip as 基本描述 from GetWay order by id"; break;
                case "使用方向": sql = "select id as 编号, discrip as 基本描述 from Direction order by id"; break;
                case "经费科目": sql = "select id as 编号, discrip as 基本描述 from Funds order by id"; break;
                case "价值类型": sql = "select id as 编号, discrip as 基本描述 from PriceType order by id"; break;
                case "计量单位": sql = "select id as 编号, discrip as 基本描述 from Unit order by id"; break;
                case "清理方式": sql = "select id as 编号, discrip as 基本描述 from ClearType order by id"; break;
                case "使用情况": sql = "select id as 编号, discrip as 基本描述 from Usage order by id"; break;
                case "校区": sql = "select id as 编号, discrip as 基本描述 from Campus order by id"; break;
                default: return null;
                
            }
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
            
        }

        /// <summary>
        /// 新增基本项目
        /// </summary>
        /// <param name="table"></param>
        /// <param name="discrip"></param>
        /// <returns></returns>
        public static bool AddBasic(string table, string discrip)
        {
            string sql = string.Format("insert into {0} values('{1}')", table,discrip);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteBasic(string table, int id)
        {
            string sql = string.Format("delete from {0} where id={1}", table, id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 修改基本项目
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <param name="discrip"></param>
        /// <returns></returns>
        public static bool UpdateBasic(string table, int id,string discrip)
        {
            string sql = string.Format("update {0} set discrip='{2}' where id={1}", table, id,discrip);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 通过中文名返回对应的表名
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetTableName(string table)
        {
            switch (table)
            {
                case "车辆产地": return "CarBP";
                case "车辆用途": return "CarUse";
                case "编制情况": return "Formation";
                case "权属性质": return "CertNature";
                case "产权形式": return "Pr";
                case "建筑结构": return "Structure";
                case "文物等级": return "RelicLv";
                case "采购形式": return "BuyWay";
                case "取得方式": return "GetWay";
                case "使用方向": return "Direction";
                case "经费科目": return "Funds";
                case "价值类型": return "PriceType";
                case "计量单位": return "Unit";
                case "清理方式": return "ClearType";
                case "使用情况": return "Usage";
                case "校区": return "Campus";
                default: return "";
            }
        }
    }
}
