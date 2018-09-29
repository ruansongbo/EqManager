using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class MaintainerMgr
    {
        /// <summary>
        /// 得到所有维修商信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from View_Maintainer order by 编号";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 添加维修商信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Add(string name, string address, string contracts, string tel)
        {
            string sql = string.Format("insert into Maintainer values('{0}','{1}','{2}','{3}')", name, address, contracts, tel);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 修改维修商信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Update(int id, string name, string address, string contracts, string tel)
        {
            string sql = string.Format("update Maintainer set name='{1}', address='{2}',contracts='{3}',tel='{4}' where id={0}", 
                id, name,address,contracts,tel);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 删除维修商信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from Maintainer where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 根据编号获取维修商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetInfoById(int id)
        {
            string sql = string.Format("select * from View_Maintainer where 编号 ={0} order by 编号",id);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据名称获取维修商信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataTable GetInfoByName(string name)
        {
            string sql = string.Format("select * from View_Maintainer where 名称 ='{0}' order by 编号", name);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据地址获取维修商信息
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static DataTable GetInfoByAddress(string address)
        {
            string sql = string.Format("select * from View_Maintainer where 地址 ='{0}' order by 编号", address);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据联系人获取维修商信息
        /// </summary>
        /// <param name="contracts"></param>
        /// <returns></returns>
        public static DataTable GetInfoByContracts(string contracts)
        {
            string sql = string.Format("select * from View_Maintainer where 联系人 ='{0}' order by 编号", contracts);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据联系电话获取维修商信息
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static DataTable GetInfoByTel(string tel)
        {
            string sql = string.Format("select * from View_Maintainer where 联系电话 ='{0}' order by 编号", tel);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}
