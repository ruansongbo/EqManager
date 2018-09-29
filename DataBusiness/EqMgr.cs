using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DataEntity;
using DataAccess;

namespace DataBusiness
{
    public class EqMgr
    {
        /// <summary>
        /// 资产增长
        /// </summary>
        /// <param name="eq"></param>
        /// <returns>true:成功；false：失败</returns>
        public static bool Add(Equipment eq)
        {
            /***************Equipment表的属性定义**********************************************************************************/
            SqlParameter paramEqNo = new SqlParameter("@eqNo", SqlDbType.VarChar, 50);
            paramEqNo.Value = eq.EqNo;

            SqlParameter paramEqName = new SqlParameter("@eqName", SqlDbType.VarChar, 50);
            paramEqName.Value = eq.EqName;

            SqlParameter paramEduNo = new SqlParameter("@eduNo", SqlDbType.VarChar, 50);
            paramEduNo.Value = eq.EduNo;

            SqlParameter paramAssetNo = new SqlParameter("@assetNo", SqlDbType.VarChar, 50);
            paramAssetNo.Value = eq.AssetNo;

            SqlParameter paramEqType = new SqlParameter("@eqType", SqlDbType.VarChar, 50);
            paramEqType.Value = eq.EqType;

            SqlParameter paramGb = new SqlParameter("@gb", SqlDbType.VarChar, 50);
            paramGb.Value = eq.Gb;

            SqlParameter paramUsage = new SqlParameter("@usage", SqlDbType.VarChar, 50);
            paramUsage.Value = eq.Usage;           

            SqlParameter paramUnit = new SqlParameter("@unit", SqlDbType.VarChar, 50);
            paramUnit.Value = eq.Unit;

            SqlParameter paramDirection = new SqlParameter("@direction", SqlDbType.VarChar, 50);
            paramDirection.Value = eq.Direction;

            SqlParameter paramBuyWay = new SqlParameter("@buyWay", SqlDbType.VarChar, 50);
            paramBuyWay.Value = eq.BuyWay;

            SqlParameter paramGetWay = new SqlParameter("@getWay", SqlDbType.VarChar, 50);
            paramGetWay.Value = eq.GetWay;

            SqlParameter paramGetDate = new SqlParameter("@getDate", SqlDbType.VarChar, 50);
            paramGetDate.Value = eq.GetDate;

            SqlParameter paramAddDate = new SqlParameter("@addDate", SqlDbType.VarChar, 50);
            paramAddDate.Value = eq.AddDate;

            SqlParameter paramPurchaser = new SqlParameter("@purchaser", SqlDbType.VarChar, 50);
            paramPurchaser.Value = eq.Purchaser;

            SqlParameter paramAgent = new SqlParameter("@agent", SqlDbType.VarChar, 50);
            paramAgent.Value = eq.Agent;

            SqlParameter paramBrand = new SqlParameter("@brand", SqlDbType.VarChar, 50);
            paramBrand.Value = eq.Brand;

            SqlParameter paramModel = new SqlParameter("@model", SqlDbType.VarChar, 50);
            paramModel.Value = eq.Model;

            SqlParameter paramCountry = new SqlParameter("@country", SqlDbType.VarChar, 50);
            paramCountry.Value = eq.Country;

            SqlParameter paramMfrs = new SqlParameter("@mfrs", SqlDbType.VarChar, 50);
            paramMfrs.Value = eq.Mfrs;

            SqlParameter paramProductNo = new SqlParameter("@productNo", SqlDbType.VarChar, 50);
            paramProductNo.Value = eq.ProductNo;

            SqlParameter paramBirthday = new SqlParameter("@birthday", SqlDbType.VarChar, 50);
            paramBirthday.Value = eq.Birthday;

            SqlParameter paramSupplier = new SqlParameter("@supplier", SqlDbType.VarChar, 50);
            paramSupplier.Value = eq.Supplier;

            SqlParameter paramPriceType = new SqlParameter("@priceType", SqlDbType.VarChar, 50);
            paramPriceType.Value = eq.PriceType;

            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Decimal);
            if (eq.Price != 0)
                paramPrice.Value = eq.Price;
            else
                paramPrice.Value = System.DBNull.Value;

            SqlParameter paramUsdPrice = new SqlParameter("@usdPrice", SqlDbType.Decimal);
            if (eq.UsdPrice != 0)
                paramUsdPrice.Value = eq.UsdPrice;
            else
                paramUsdPrice.Value = System.DBNull.Value;

            SqlParameter paramEqKeeper = new SqlParameter("@eqKeeper", SqlDbType.VarChar, 50);
            paramEqKeeper.Value = eq.EqKeeper;

            SqlParameter paramDepartment = new SqlParameter("@department", SqlDbType.VarChar, 50);
            paramDepartment.Value = eq.Department;

            SqlParameter paramSvcDate = new SqlParameter("@svcDate", SqlDbType.VarChar, 50);
            paramSvcDate.Value = eq.SvcDate;

            SqlParameter paramCampus = new SqlParameter("@campus", SqlDbType.VarChar, 50);
            paramCampus.Value = eq.Campus;

            SqlParameter paramKeepPlace = new SqlParameter("@keepPlace", SqlDbType.VarChar, 50);
            paramKeepPlace.Value = eq.KeepPlace;

            SqlParameter paramCn = new SqlParameter("@cn", SqlDbType.VarChar, 50);
            paramCn.Value = eq.Cn;

            SqlParameter paramInvNo = new SqlParameter("@invNo", SqlDbType.VarChar, 50);
            paramInvNo.Value = eq.InvNo;

            SqlParameter paramFunds = new SqlParameter("@funds", SqlDbType.VarChar, 50);
            paramFunds.Value = eq.Funds;

            SqlParameter paramRelicLv = new SqlParameter("@relicLv", SqlDbType.VarChar, 50);
            paramRelicLv.Value = eq.RelicLv;

            SqlParameter paramRegAuz = new SqlParameter("@regAuz", SqlDbType.VarChar, 50);
            paramRegAuz.Value = eq.RegAuz;

            SqlParameter paramRegTime = new SqlParameter("@regTime", SqlDbType.VarChar, 50);
            paramRegTime.Value = eq.RegTime;

            SqlParameter paramPatNo = new SqlParameter("@patNo", SqlDbType.VarChar, 50);
            paramPatNo.Value = eq.PatNo;

            SqlParameter paramApvNo = new SqlParameter("@apvNo", SqlDbType.VarChar, 50);
            paramApvNo.Value = eq.ApvNo;

            SqlParameter paramMgtAgency = new SqlParameter("@mgtAgency", SqlDbType.VarChar, 50);
            paramMgtAgency.Value = eq.MgtAgency;

            SqlParameter paramCarUse = new SqlParameter("@carUse", SqlDbType.VarChar, 50);
            paramCarUse.Value = eq.CarUse;

            SqlParameter paramCarBP = new SqlParameter("@CarBP", SqlDbType.VarChar, 50);
            paramCarBP.Value = eq.CarBP;

            SqlParameter paramLicNo = new SqlParameter("@licNo", SqlDbType.VarChar, 50);
            paramLicNo.Value = eq.LicNo;

            SqlParameter paramDspl = new SqlParameter("@dspl", SqlDbType.VarChar, 50);
            paramDspl.Value = eq.Dspl;

            SqlParameter paramEngNo = new SqlParameter("@engNo", SqlDbType.VarChar, 50);
            paramEngNo.Value = eq.EngNo;

            SqlParameter paramFormation = new SqlParameter("@formation", SqlDbType.VarChar, 50);
            paramFormation.Value = eq.Formation;

            SqlParameter paramArea = new SqlParameter("@area", SqlDbType.Decimal);
            if (eq.Area != 0)
                paramArea.Value = eq.Area;
            else
                paramArea.Value = System.DBNull.Value; ;


            SqlParameter paramPr = new SqlParameter("@pr", SqlDbType.VarChar, 50);
            paramPr.Value = eq.Pr;

            SqlParameter paramCertNo = new SqlParameter("@certNo", SqlDbType.VarChar, 50);
            paramCertNo.Value = eq.CertNo;

            SqlParameter paramIssueDate = new SqlParameter("@issueDate", SqlDbType.VarChar, 50);
            paramIssueDate.Value = eq.IssueDate;

            SqlParameter paramCertLim = new SqlParameter("@certLim", SqlDbType.VarChar, 50);
            if (eq.CertLim != 0)
                paramCertLim.Value = eq.CertLim;
            else
                paramCertLim.Value = System.DBNull.Value;


            SqlParameter paramCertProve = new SqlParameter("@certProve", SqlDbType.VarChar, 50);
            paramCertProve.Value = eq.CertProve;

            SqlParameter paramAddress = new SqlParameter("@address", SqlDbType.VarChar, 50);
            paramAddress.Value = eq.Address;

            SqlParameter paramCertNature = new SqlParameter("@certNature", SqlDbType.VarChar, 50);
            paramCertNature.Value = eq.CertNature;

            SqlParameter paramTenuArea = new SqlParameter("@tenuArea", SqlDbType.Decimal);
            if (eq.TenuArea != 0)
                paramTenuArea.Value = eq.TenuArea;
            else
                paramTenuArea.Value = System.DBNull.Value;

            SqlParameter paramTenuPrice = new SqlParameter("@tenuPrice", SqlDbType.Decimal);
            if (eq.TenuPrice != 0)
                paramTenuPrice.Value = eq.TenuPrice;
            else
                paramTenuPrice.Value = System.DBNull.Value;

            SqlParameter paramStructure = new SqlParameter("@structure", SqlDbType.VarChar, 50);
            paramStructure.Value = eq.Structure;

            SqlParameter paramBelongTo = new SqlParameter("@belongTo", SqlDbType.VarChar, 50);
            paramBelongTo.Value = "";

            //获取图片路径
            SqlParameter paramPhoto;
            if (eq.Photo == "")
            {
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                paramPhoto.Value = System.DBNull.Value;
            }
            else if (eq.Photo.Substring(0, 5) == "Photo")
            {
                //从数据库获取图片路径
                DataTable dtPhoto = EqMgr.GetPhoto(eq.Photo.Substring(5, eq.Photo.Length - 5));
                if (dtPhoto.Rows[0][0] != System.DBNull.Value)
                {
                    byte[] Photo = (byte[])(dtPhoto.Rows[0][0]);
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                    paramPhoto.Value = Photo;
                }
                else
                {
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                    paramPhoto.Value = System.DBNull.Value;
                }
            }
            else
            {
                byte[] Photo = File.ReadAllBytes(eq.Photo);
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                paramPhoto.Value = Photo;
            }

            SqlParameter paramState = new SqlParameter("@state", SqlDbType.VarChar, 50);
            paramState.Value = eq.State;

            SqlParameter paramRemark = new SqlParameter("@remark", SqlDbType.VarChar, 200);
            paramRemark.Value = eq.Remark;
            /***************Equipment表的属性定义**********************************************************************************/


            string sql = "insert into equipment values(@eqNo,@eqName,@eduNo,@assetNo,@EqType,@gb,@usage,@unit,@direction," +
                         "@buyWay,@getWay,@getDate,@addDate,@purchaser,@agent,@brand,@model,@country," +
                         "@mfrs,@productNo,@birthday,@supplier,@priceType,@price,@usdPrice,@eqKeeper,@department," +
                         "@svcDate,@campus,@keepPlace,@cn,@invNo,@funds,@relicLv,@regAuz,@regTime,@patNo," +
                         "@apvNo,@mgtAgency,@carUse,@carBP,@licNo,@dspl,@engNo,@formation,@area,@pr," +
                         "@certNo,@issueDate,@certLim,@certProve,@address,@certNature,@tenuArea,@tenuPrice,@structure," +
                         "@belongTo,@photo,@state,@remark)";
            sqlHandler sh = new sqlHandler();
            try
            {
                int result = sh.ExecuteSQL(sql, paramEqNo, paramEqName, paramEduNo, paramAssetNo, paramEqType, paramGb, paramUsage, paramUnit, paramDirection,
                    paramBuyWay, paramGetWay, paramGetDate, paramAddDate, paramPurchaser, paramAgent, paramBrand, paramModel, paramCountry,
                    paramMfrs, paramProductNo, paramBirthday, paramSupplier, paramPriceType, paramPrice, paramUsdPrice, paramEqKeeper, paramDepartment,
                    paramSvcDate, paramCampus, paramKeepPlace, paramCn, paramInvNo, paramFunds, paramRelicLv, paramRegAuz, paramRegTime, paramPatNo,
                    paramApvNo, paramMgtAgency, paramCarUse, paramCarBP, paramLicNo, paramDspl, paramEngNo, paramFormation, paramArea, paramPr,
                    paramCertNo, paramIssueDate, paramCertLim, paramCertProve, paramAddress, paramCertNature, paramTenuArea, paramTenuPrice, paramStructure, paramBelongTo, paramPhoto,paramState, paramRemark);
                return result > 0;
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// 资产更新
        /// </summary>
        /// <param name="eq"></param>
        /// <returns>true：成功；false：失败</returns>
        public static bool Update(Equipment eq)
        {


            //与Add方法不同的是State和BelongTo三个属性不是预先设置的
            /***************Equipment表的属性定义**********************************************************************************/
            SqlParameter paramEqNo = new SqlParameter("@eqNo", SqlDbType.VarChar, 50);
            paramEqNo.Value = eq.EqNo;

            SqlParameter paramEqName = new SqlParameter("@eqName", SqlDbType.VarChar, 50);
            paramEqName.Value = eq.EqName;

            SqlParameter paramEduNo = new SqlParameter("@eduNo", SqlDbType.VarChar, 50);
            paramEduNo.Value = eq.EduNo;

            SqlParameter paramAssetNo = new SqlParameter("@assetNo", SqlDbType.VarChar, 50);
            paramAssetNo.Value = eq.AssetNo;

            SqlParameter paramEqType = new SqlParameter("@eqType", SqlDbType.VarChar, 50);
            paramEqType.Value = eq.EqType;

            SqlParameter paramGb = new SqlParameter("@gb", SqlDbType.VarChar, 50);
            paramGb.Value = eq.Gb;

            SqlParameter paramUsage = new SqlParameter("@usage", SqlDbType.VarChar, 50);
            paramUsage.Value = eq.Usage;

            SqlParameter paramUnit = new SqlParameter("@unit", SqlDbType.VarChar, 50);
            paramUnit.Value = eq.Unit;

            SqlParameter paramDirection = new SqlParameter("@direction", SqlDbType.VarChar, 50);
            paramDirection.Value = eq.Direction;

            SqlParameter paramBuyWay = new SqlParameter("@buyWay", SqlDbType.VarChar, 50);
            paramBuyWay.Value = eq.BuyWay;

            SqlParameter paramGetWay = new SqlParameter("@getWay", SqlDbType.VarChar, 50);
            paramGetWay.Value = eq.GetWay;

            SqlParameter paramGetDate = new SqlParameter("@getDate", SqlDbType.VarChar, 50);
            paramGetDate.Value = eq.GetDate;

            SqlParameter paramAddDate = new SqlParameter("@addDate", SqlDbType.VarChar, 50);
            paramAddDate.Value = eq.AddDate;

            SqlParameter paramPurchaser = new SqlParameter("@purchaser", SqlDbType.VarChar, 50);
            paramPurchaser.Value = eq.Purchaser;

            SqlParameter paramAgent = new SqlParameter("@agent", SqlDbType.VarChar, 50);
            paramAgent.Value = eq.Agent;

            SqlParameter paramBrand = new SqlParameter("@brand", SqlDbType.VarChar, 50);
            paramBrand.Value = eq.Brand;

            SqlParameter paramModel = new SqlParameter("@model", SqlDbType.VarChar, 50);
            paramModel.Value = eq.Model;

            SqlParameter paramCountry = new SqlParameter("@country", SqlDbType.VarChar, 50);
            paramCountry.Value = eq.Country;

            SqlParameter paramMfrs = new SqlParameter("@mfrs", SqlDbType.VarChar, 50);
            paramMfrs.Value = eq.Mfrs;

            SqlParameter paramProductNo = new SqlParameter("@productNo", SqlDbType.VarChar, 50);
            paramProductNo.Value = eq.ProductNo;

            SqlParameter paramBirthday = new SqlParameter("@birthday", SqlDbType.VarChar, 50);
            paramBirthday.Value = eq.Birthday;

            SqlParameter paramSupplier = new SqlParameter("@supplier", SqlDbType.VarChar, 50);
            paramSupplier.Value = eq.Supplier;

            SqlParameter paramPriceType = new SqlParameter("@priceType", SqlDbType.VarChar, 50);
            paramPriceType.Value = eq.PriceType;

            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Decimal);
            if (eq.Price != 0)
                paramPrice.Value = eq.Price;
            else
                paramPrice.Value = System.DBNull.Value;

            SqlParameter paramUsdPrice = new SqlParameter("@usdPrice", SqlDbType.Decimal);
            if (eq.UsdPrice != 0)
                paramUsdPrice.Value = eq.UsdPrice;
            else
                paramUsdPrice.Value = System.DBNull.Value;

            SqlParameter paramEqKeeper = new SqlParameter("@eqKeeper", SqlDbType.VarChar, 50);
            paramEqKeeper.Value = eq.EqKeeper;

            SqlParameter paramDepartment = new SqlParameter("@department", SqlDbType.VarChar, 50);
            paramDepartment.Value = eq.Department;

            SqlParameter paramSvcDate = new SqlParameter("@svcDate", SqlDbType.VarChar, 50);
            paramSvcDate.Value = eq.SvcDate;

            SqlParameter paramCampus = new SqlParameter("@campus", SqlDbType.VarChar, 50);
            paramCampus.Value = eq.Campus;

            SqlParameter paramKeepPlace = new SqlParameter("@keepPlace", SqlDbType.VarChar, 50);
            paramKeepPlace.Value = eq.KeepPlace;

            SqlParameter paramCn = new SqlParameter("@cn", SqlDbType.VarChar, 50);
            paramCn.Value = eq.Cn;

            SqlParameter paramInvNo = new SqlParameter("@invNo", SqlDbType.VarChar, 50);
            paramInvNo.Value = eq.InvNo;

            SqlParameter paramFunds = new SqlParameter("@funds", SqlDbType.VarChar, 50);
            paramFunds.Value = eq.Funds;

            SqlParameter paramRelicLv = new SqlParameter("@relicLv", SqlDbType.VarChar, 50);
            paramRelicLv.Value = eq.RelicLv;

            SqlParameter paramRegAuz = new SqlParameter("@regAuz", SqlDbType.VarChar, 50);
            paramRegAuz.Value = eq.RegAuz;

            SqlParameter paramRegTime = new SqlParameter("@regTime", SqlDbType.VarChar, 50);
            paramRegTime.Value = eq.RegTime;

            SqlParameter paramPatNo = new SqlParameter("@patNo", SqlDbType.VarChar, 50);
            paramPatNo.Value = eq.PatNo;

            SqlParameter paramApvNo = new SqlParameter("@apvNo", SqlDbType.VarChar, 50);
            paramApvNo.Value = eq.ApvNo;

            SqlParameter paramMgtAgency = new SqlParameter("@mgtAgency", SqlDbType.VarChar, 50);
            paramMgtAgency.Value = eq.MgtAgency;

            SqlParameter paramCarUse = new SqlParameter("@carUse", SqlDbType.VarChar, 50);
            paramCarUse.Value = eq.CarUse;

            SqlParameter paramCarBP = new SqlParameter("@CarBP", SqlDbType.VarChar, 50);
            paramCarBP.Value = eq.CarBP;

            SqlParameter paramLicNo = new SqlParameter("@licNo", SqlDbType.VarChar, 50);
            paramLicNo.Value = eq.LicNo;

            SqlParameter paramDspl = new SqlParameter("@dspl", SqlDbType.VarChar, 50);
            paramDspl.Value = eq.Dspl;

            SqlParameter paramEngNo = new SqlParameter("@engNo", SqlDbType.VarChar, 50);
            paramEngNo.Value = eq.EngNo;

            SqlParameter paramFormation = new SqlParameter("@formation", SqlDbType.VarChar, 50);
            paramFormation.Value = eq.Formation;

            SqlParameter paramArea = new SqlParameter("@area", SqlDbType.Decimal);
            if (eq.Area != 0)
                paramArea.Value = eq.Area;
            else
                paramArea.Value = System.DBNull.Value; ;


            SqlParameter paramPr = new SqlParameter("@pr", SqlDbType.VarChar, 50);
            paramPr.Value = eq.Pr;

            SqlParameter paramCertNo = new SqlParameter("@certNo", SqlDbType.VarChar, 50);
            paramCertNo.Value = eq.CertNo;

            SqlParameter paramIssueDate = new SqlParameter("@issueDate", SqlDbType.VarChar, 50);
            paramIssueDate.Value = eq.IssueDate;

            SqlParameter paramCertLim = new SqlParameter("@certLim", SqlDbType.VarChar, 50);
            if (eq.CertLim != 0)
                paramCertLim.Value = eq.CertLim;
            else
                paramCertLim.Value = System.DBNull.Value;


            SqlParameter paramCertProve = new SqlParameter("@certProve", SqlDbType.VarChar, 50);
            paramCertProve.Value = eq.CertProve;

            SqlParameter paramAddress = new SqlParameter("@address", SqlDbType.VarChar, 50);
            paramAddress.Value = eq.Address;

            SqlParameter paramCertNature = new SqlParameter("@certNature", SqlDbType.VarChar, 50);
            paramCertNature.Value = eq.CertNature;

            SqlParameter paramTenuArea = new SqlParameter("@tenuArea", SqlDbType.Decimal);
            if (eq.TenuArea != 0)
                paramTenuArea.Value = eq.TenuArea;
            else
                paramTenuArea.Value = System.DBNull.Value;

            SqlParameter paramTenuPrice = new SqlParameter("@tenuPrice", SqlDbType.Decimal);
            if (eq.TenuPrice != 0)
                paramTenuPrice.Value = eq.TenuPrice;
            else
                paramTenuPrice.Value = System.DBNull.Value;

            SqlParameter paramStructure = new SqlParameter("@structure", SqlDbType.VarChar, 50);
            paramStructure.Value = eq.Structure;

            SqlParameter paramBelongTo = new SqlParameter("@belongTo", SqlDbType.VarChar, 50);
            paramBelongTo.Value = eq.BelongTo;

            //获取图片路径
            SqlParameter paramPhoto;
            if (eq.Photo == "")
            {
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                paramPhoto.Value = System.DBNull.Value;
            }
            else if (eq.Photo.Substring(0, 5) == "Photo")
            {
                //从数据库获取图片路径
                DataTable dtPhoto = EqMgr.GetPhoto(eq.Photo.Substring(5, eq.Photo.Length - 5));
                if (dtPhoto.Rows[0][0] != System.DBNull.Value)
                {
                    byte[] Photo = (byte[])(dtPhoto.Rows[0][0]);
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                    paramPhoto.Value = Photo;
                }
                else
                {
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                    paramPhoto.Value = System.DBNull.Value;
                }
            }
            else
            {
                byte[] Photo = File.ReadAllBytes(eq.Photo);
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                paramPhoto.Value = Photo;
            }

            SqlParameter paramState = new SqlParameter("@state", SqlDbType.VarChar, 50);
            paramState.Value = eq.State;

            SqlParameter paramRemark = new SqlParameter("@remark", SqlDbType.VarChar, 200);
            paramRemark.Value = eq.Remark;
            /***************Equipment表的属性定义**********************************************************************************/






            string sql = "update equipment set " +
                         "EqName=@eqName,EduNo=@eduNo,AssetNo=@assetNo,EqType=@eqType," +
                         "GB=@gb,Usage=@usage,Unit=@unit,Direction=@direction," +
                        "BuyWay=@buyWay,GetWay=@getWay,GetDate=@getDate,AddDate=@addDate," +
                        "Purchaser=@purchaser,Agent=@agent,Brand=@brand,Model=@model,Country=@country," +
                        "Mfrs=@mfrs,ProductNo=@productNo,Birthday=@birthday,Supplier=@supplier,PriceType=@priceType," +
                        "Price=@price,USDPrice=@usdPrice,EqKeeper=@eqKeeper,Department=@department,SvcDate=@svcDate," +
                        "Campus=@campus,KeepPlace=@keepPlace,CN=@cn,InvNo=@invNo,Funds=@funds," +
                        "RelicLv=@relicLv,RegAuz=@regAuz,RegTime=@regTime,PatNo=@patNo,ApvNo=@apvNo," +
                        "MgtAgency=@mgtAgency,CarUse=@carUse,CarBP=@carBP,LicNo=@licNo,DSPL=@dspl," +
                        "EngNo=@engNo,Formation=@formation,Area=@area,PR=@pr,CertNo=@certNo," +
                        "IssueDate=@issueDate,CertLim=@certLim,CertProve=@certProve,Address=@address,CertNature=@certNature," +
                        "TenuArea=@tenuArea,TenuPrice=@tenuPrice,Structure=@structure,BelongTo=@belongTo,Photo=@photo,State=@state,Remark=@remark where EqNo=@eqNo";
            sqlHandler sh = new sqlHandler();

            
            try
            {
                int result = sh.ExecuteSQL(sql, paramEqName, paramEduNo, paramAssetNo, paramEqType, paramGb, paramUsage, paramUnit, paramDirection,
                    paramBuyWay, paramGetWay, paramGetDate, paramAddDate, paramPurchaser, paramAgent, paramBrand, paramModel, paramCountry,
                    paramMfrs, paramProductNo, paramBirthday, paramSupplier, paramPriceType, paramPrice, paramUsdPrice, paramEqKeeper, paramDepartment,
                    paramSvcDate, paramCampus, paramKeepPlace, paramCn, paramInvNo, paramFunds, paramRelicLv, paramRegAuz, paramRegTime, paramPatNo,
                    paramApvNo, paramMgtAgency, paramCarUse, paramCarBP, paramLicNo, paramDspl, paramEngNo, paramFormation, paramArea, paramPr,
                    paramCertNo, paramIssueDate, paramCertLim, paramCertProve, paramAddress, paramCertNature, paramTenuArea, paramTenuPrice, paramStructure, paramBelongTo,paramPhoto, paramState, paramRemark, paramEqNo);
                return result > 0;
            }
            catch (SqlException e)
            {
                return false;
            }

        }

        /// <summary>
        /// 根据单号更新资产
        /// </summary>
        /// <param name="eq"></param>
        /// <returns>true：成功；false：失败</returns>
        public static bool UpdateByAsset(Equipment eq, string ID)
        {


            //与Add方法不同的是State和BelongTo三个属性不是预先设置的
            /***************Equipment表的属性定义**********************************************************************************/
            SqlParameter paramEqNo = new SqlParameter("@eqNo", SqlDbType.VarChar, 50);
            paramEqNo.Value = eq.EqNo;

            SqlParameter paramEqName = new SqlParameter("@eqName", SqlDbType.VarChar, 50);
            paramEqName.Value = eq.EqName;

            SqlParameter paramEduNo = new SqlParameter("@eduNo", SqlDbType.VarChar, 50);
            paramEduNo.Value = eq.EduNo;



            SqlParameter paramAssetNo = new SqlParameter("@assetNo", SqlDbType.VarChar, 50);
            paramAssetNo.Value = eq.AssetNo;

            SqlParameter paramEqType = new SqlParameter("@eqType", SqlDbType.VarChar, 50);
            paramEqType.Value = eq.EqType;

            SqlParameter paramGb = new SqlParameter("@gb", SqlDbType.VarChar, 50);
            paramGb.Value = eq.Gb;

            SqlParameter paramUsage = new SqlParameter("@usage", SqlDbType.VarChar, 50);
            paramUsage.Value = eq.Usage;

            SqlParameter paramUnit = new SqlParameter("@unit", SqlDbType.VarChar, 50);
            paramUnit.Value = eq.Unit;

            SqlParameter paramDirection = new SqlParameter("@direction", SqlDbType.VarChar, 50);
            paramDirection.Value = eq.Direction;

            SqlParameter paramBuyWay = new SqlParameter("@buyWay", SqlDbType.VarChar, 50);
            paramBuyWay.Value = eq.BuyWay;

            SqlParameter paramGetWay = new SqlParameter("@getWay", SqlDbType.VarChar, 50);
            paramGetWay.Value = eq.GetWay;

            SqlParameter paramGetDate = new SqlParameter("@getDate", SqlDbType.VarChar, 50);
            paramGetDate.Value = eq.GetDate;

            SqlParameter paramAddDate = new SqlParameter("@addDate", SqlDbType.VarChar, 50);
            paramAddDate.Value = eq.AddDate;

            SqlParameter paramPurchaser = new SqlParameter("@purchaser", SqlDbType.VarChar, 50);
            paramPurchaser.Value = eq.Purchaser;

            SqlParameter paramAgent = new SqlParameter("@agent", SqlDbType.VarChar, 50);
            paramAgent.Value = eq.Agent;

            SqlParameter paramBrand = new SqlParameter("@brand", SqlDbType.VarChar, 50);
            paramBrand.Value = eq.Brand;

            SqlParameter paramModel = new SqlParameter("@model", SqlDbType.VarChar, 50);
            paramModel.Value = eq.Model;

            SqlParameter paramCountry = new SqlParameter("@country", SqlDbType.VarChar, 50);
            paramCountry.Value = eq.Country;

            SqlParameter paramMfrs = new SqlParameter("@mfrs", SqlDbType.VarChar, 50);
            paramMfrs.Value = eq.Mfrs;

            SqlParameter paramProductNo = new SqlParameter("@productNo", SqlDbType.VarChar, 50);
            paramProductNo.Value = eq.ProductNo;

            SqlParameter paramBirthday = new SqlParameter("@birthday", SqlDbType.VarChar, 50);
            paramBirthday.Value = eq.Birthday;

            SqlParameter paramSupplier = new SqlParameter("@supplier", SqlDbType.VarChar, 50);
            paramSupplier.Value = eq.Supplier;

            SqlParameter paramPriceType = new SqlParameter("@priceType", SqlDbType.VarChar, 50);
            paramPriceType.Value = eq.PriceType;

            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Decimal);
            if (eq.Price != 0)
                paramPrice.Value = eq.Price;
            else
                paramPrice.Value = System.DBNull.Value;

            SqlParameter paramUsdPrice = new SqlParameter("@usdPrice", SqlDbType.Decimal);
            if (eq.UsdPrice != 0)
                paramUsdPrice.Value = eq.UsdPrice;
            else
                paramUsdPrice.Value = System.DBNull.Value;

            SqlParameter paramEqKeeper = new SqlParameter("@eqKeeper", SqlDbType.VarChar, 50);
            paramEqKeeper.Value = eq.EqKeeper;

            SqlParameter paramDepartment = new SqlParameter("@department", SqlDbType.VarChar, 50);
            paramDepartment.Value = eq.Department;

            SqlParameter paramSvcDate = new SqlParameter("@svcDate", SqlDbType.VarChar, 50);
            paramSvcDate.Value = eq.SvcDate;

            SqlParameter paramCampus = new SqlParameter("@campus", SqlDbType.VarChar, 50);
            paramCampus.Value = eq.Campus;

            SqlParameter paramKeepPlace = new SqlParameter("@keepPlace", SqlDbType.VarChar, 50);
            paramKeepPlace.Value = eq.KeepPlace;

            SqlParameter paramCn = new SqlParameter("@cn", SqlDbType.VarChar, 50);
            paramCn.Value = eq.Cn;

            SqlParameter paramInvNo = new SqlParameter("@invNo", SqlDbType.VarChar, 50);
            paramInvNo.Value = eq.InvNo;

            SqlParameter paramFunds = new SqlParameter("@funds", SqlDbType.VarChar, 50);
            paramFunds.Value = eq.Funds;

            SqlParameter paramRelicLv = new SqlParameter("@relicLv", SqlDbType.VarChar, 50);
            paramRelicLv.Value = eq.RelicLv;

            SqlParameter paramRegAuz = new SqlParameter("@regAuz", SqlDbType.VarChar, 50);
            paramRegAuz.Value = eq.RegAuz;

            SqlParameter paramRegTime = new SqlParameter("@regTime", SqlDbType.VarChar, 50);
            paramRegTime.Value = eq.RegTime;

            SqlParameter paramPatNo = new SqlParameter("@patNo", SqlDbType.VarChar, 50);
            paramPatNo.Value = eq.PatNo;

            SqlParameter paramApvNo = new SqlParameter("@apvNo", SqlDbType.VarChar, 50);
            paramApvNo.Value = eq.ApvNo;

            SqlParameter paramMgtAgency = new SqlParameter("@mgtAgency", SqlDbType.VarChar, 50);
            paramMgtAgency.Value = eq.MgtAgency;

            SqlParameter paramCarUse = new SqlParameter("@carUse", SqlDbType.VarChar, 50);
            paramCarUse.Value = eq.CarUse;

            SqlParameter paramCarBP = new SqlParameter("@CarBP", SqlDbType.VarChar, 50);
            paramCarBP.Value = eq.CarBP;

            SqlParameter paramLicNo = new SqlParameter("@licNo", SqlDbType.VarChar, 50);
            paramLicNo.Value = eq.LicNo;

            SqlParameter paramDspl = new SqlParameter("@dspl", SqlDbType.VarChar, 50);
            paramDspl.Value = eq.Dspl;

            SqlParameter paramEngNo = new SqlParameter("@engNo", SqlDbType.VarChar, 50);
            paramEngNo.Value = eq.EngNo;

            SqlParameter paramFormation = new SqlParameter("@formation", SqlDbType.VarChar, 50);
            paramFormation.Value = eq.Formation;

            SqlParameter paramArea = new SqlParameter("@area", SqlDbType.Decimal);
            if (eq.Area != 0)
                paramArea.Value = eq.Area;
            else
                paramArea.Value = System.DBNull.Value; ;


            SqlParameter paramPr = new SqlParameter("@pr", SqlDbType.VarChar, 50);
            paramPr.Value = eq.Pr;

            SqlParameter paramCertNo = new SqlParameter("@certNo", SqlDbType.VarChar, 50);
            paramCertNo.Value = eq.CertNo;

            SqlParameter paramIssueDate = new SqlParameter("@issueDate", SqlDbType.VarChar, 50);
            paramIssueDate.Value = eq.IssueDate;

            SqlParameter paramCertLim = new SqlParameter("@certLim", SqlDbType.VarChar, 50);
            if (eq.CertLim != 0)
                paramCertLim.Value = eq.CertLim;
            else
                paramCertLim.Value = System.DBNull.Value;


            SqlParameter paramCertProve = new SqlParameter("@certProve", SqlDbType.VarChar, 50);
            paramCertProve.Value = eq.CertProve;

            SqlParameter paramAddress = new SqlParameter("@address", SqlDbType.VarChar, 50);
            paramAddress.Value = eq.Address;

            SqlParameter paramCertNature = new SqlParameter("@certNature", SqlDbType.VarChar, 50);
            paramCertNature.Value = eq.CertNature;

            SqlParameter paramTenuArea = new SqlParameter("@tenuArea", SqlDbType.Decimal);
            if (eq.TenuArea != 0)
                paramTenuArea.Value = eq.TenuArea;
            else
                paramTenuArea.Value = System.DBNull.Value;

            SqlParameter paramTenuPrice = new SqlParameter("@tenuPrice", SqlDbType.Decimal);
            if (eq.TenuPrice != 0)
                paramTenuPrice.Value = eq.TenuPrice;
            else
                paramTenuPrice.Value = System.DBNull.Value;

            SqlParameter paramStructure = new SqlParameter("@structure", SqlDbType.VarChar, 50);
            paramStructure.Value = eq.Structure;

            SqlParameter paramBelongTo = new SqlParameter("@belongTo", SqlDbType.VarChar, 50);
            paramBelongTo.Value = eq.BelongTo;

            //获取图片路径
            SqlParameter paramPhoto;
            if (eq.Photo == "")
            {
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                paramPhoto.Value = System.DBNull.Value;
            }
            else if (eq.Photo.Substring(0, 5) == "Photo")
            {
                //从数据库获取图片路径
                DataTable dtPhoto = EqMgr.GetPhoto(eq.Photo.Substring(5, eq.Photo.Length - 5));
                if (dtPhoto.Rows[0][0] != System.DBNull.Value)
                {
                    byte[] Photo = (byte[])(dtPhoto.Rows[0][0]);
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                    paramPhoto.Value = Photo;
                }
                else
                {
                    paramPhoto = new SqlParameter("@photo", SqlDbType.Image, 0);
                    paramPhoto.Value = System.DBNull.Value;
                }
            }
            else
            {
                byte[] Photo = File.ReadAllBytes(eq.Photo);
                paramPhoto = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                paramPhoto.Value = Photo;
            }

            SqlParameter paramState = new SqlParameter("@state", SqlDbType.VarChar, 50);
            paramState.Value = eq.State;

            SqlParameter paramRemark = new SqlParameter("@remark", SqlDbType.VarChar, 200);
            paramRemark.Value = eq.Remark;
            /***************Equipment表的属性定义**********************************************************************************/






            string sql = "update equipment set " +
                         "EqName=@eqName,EduNo=@eduNo,EqType=@eqType," +
                         "GB=@gb,Usage=@usage,Unit=@unit,Direction=@direction," +
                        "BuyWay=@buyWay,GetWay=@getWay,GetDate=@getDate,AddDate=@addDate," +
                        "Purchaser=@purchaser,Agent=@agent,Brand=@brand,Model=@model,Country=@country," +
                        "Mfrs=@mfrs,ProductNo=@productNo,Birthday=@birthday,Supplier=@supplier,PriceType=@priceType," +
                        "Price=@price,USDPrice=@usdPrice,EqKeeper=@eqKeeper,Department=@department,SvcDate=@svcDate," +
                        "Campus=@campus,KeepPlace=@keepPlace,CN=@cn,InvNo=@invNo,Funds=@funds," +
                        "RelicLv=@relicLv,RegAuz=@regAuz,RegTime=@regTime,PatNo=@patNo,ApvNo=@apvNo," +
                        "MgtAgency=@mgtAgency,CarUse=@carUse,CarBP=@carBP,LicNo=@licNo,DSPL=@dspl," +
                        "EngNo=@engNo,Formation=@formation,Area=@area,PR=@pr,CertNo=@certNo," +
                        "IssueDate=@issueDate,CertLim=@certLim,CertProve=@certProve,Address=@address,CertNature=@certNature," +
                        "TenuArea=@tenuArea,TenuPrice=@tenuPrice,Structure=@structure,BelongTo=@belongTo,Photo=@photo,Remark=@remark,State=@state where AssetNo=@assetNo";
            sqlHandler sh = new sqlHandler();


            try
            {
                int result = sh.ExecuteSQL(sql, paramEqName, paramEduNo, paramEqType, paramGb, paramUsage, paramUnit, paramDirection,
                    paramBuyWay, paramGetWay, paramGetDate, paramAddDate, paramPurchaser, paramAgent, paramBrand, paramModel, paramCountry,
                    paramMfrs, paramProductNo, paramBirthday, paramSupplier, paramPriceType, paramPrice, paramUsdPrice, paramEqKeeper, paramDepartment,
                    paramSvcDate, paramCampus, paramKeepPlace, paramCn, paramInvNo, paramFunds, paramRelicLv, paramRegAuz, paramRegTime, paramPatNo,
                    paramApvNo, paramMgtAgency, paramCarUse, paramCarBP, paramLicNo, paramDspl, paramEngNo, paramFormation, paramArea, paramPr,
                    paramCertNo, paramIssueDate, paramCertLim, paramCertProve, paramAddress, paramCertNature, paramTenuArea, paramTenuPrice, paramStructure, paramBelongTo,paramPhoto, paramRemark, paramState, paramAssetNo);
                return result > 0;
            }
            catch (SqlException e)
            {
                return false;
            }

        }


        public static Equipment SetEq(List<string> list)
        {
            Equipment eq = new Equipment();

            eq.EqNo = string.Format("{0:D6}", (getAllEqCount() + 1));
            eq.EqNo = DateTime.Now.Year + eq.EqNo;
            eq.State = "入库";

            eq.EqName = list[0];
            eq.EduNo = list[1];
            eq.AssetNo = list[2];
            eq.EqType = list[3];
            eq.Gb = list[4];
            eq.Campus = list[5];
            eq.Department = DepartMgr.GetIdFromName(list[6]);
            //若没有部门的话，暂时分配到"待分配目录下"
            if (eq.Department == "")
                eq.Department = "99999";
            eq.KeepPlace = list[7];
            eq.EqKeeper = list[8];
            eq.Purchaser = list[9];
            eq.Agent = list[10];
            if (eq.Agent == "")
                eq.Agent = "sa";
            eq.Unit = list[11];
            eq.Funds = list[12];
            eq.PriceType = list[13];

            if(IsNumber(list[14]))
                eq.Price = int.Parse(list[14]);
            if(IsNumber(list[15]))
                eq.UsdPrice = int.Parse(list[15]);

            eq.Brand = list[16];
            eq.Model = list[17];
            eq.Country = list[18];
            eq.Mfrs = list[19];
            eq.ProductNo = list[20];

            if(IsDate(list[21]))
                eq.Birthday = list[21];
            eq.Supplier = list[22];
            if(IsDate(list[23]))
                eq.GetDate = list[23];
            if (IsDate(list[24]))
                eq.AddDate = list[24];
            if (eq.AddDate == "")
                eq.AddDate = DateTime.Now.ToShortDateString();
            if (IsDate(list[25]))
                eq.SvcDate = list[25];

            eq.Usage = list[26];
            eq.Direction = list[27];
            eq.BuyWay = list[28];
            eq.GetWay = list[29];
            eq.Cn = list[30];
            eq.InvNo = list[31];
            eq.RelicLv = list[32];
            eq.RegAuz = list[33];
            if (IsDate(list[34]))
                eq.RegTime = list[34];
            eq.PatNo = list[35];
            eq.ApvNo = list[36];
            eq.MgtAgency = list[37];
            eq.CarUse = list[38];
            eq.CarBP = list[39];
            eq.LicNo = list[40];
            eq.Dspl = list[41];
            eq.EngNo = list[42];
            eq.Formation = list[43];
            if(IsNumber(list[44]))
                eq.Area = int.Parse(list[44]);
            eq.Pr = list[45];
            eq.CertNo = list[46];

            if (IsDate(list[47]))
                eq.IssueDate = list[47];
            if(IsNumber(list[48]))
                eq.CertLim = int.Parse(list[48]);
            eq.CertProve = list[49];
            eq.Address = list[50];
            eq.CertNature = list[51];
            if (IsNumber(list[52]))
                eq.TenuArea = int.Parse(list[52]);
            if (IsNumber(list[53]))
                eq.TenuPrice = int.Parse(list[53]);
            eq.Structure = list[54];
            eq.Remark = list[55];


            return eq;
        }

        /// <summary>
        /// 得到某一笔资产的本身属性（基本信息）
        /// </summary>
        /// <param name="eqno"></param>
        /// <returns></returns>
        public static DataTable GetOneBaseInfo(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from Equipment where EqNo='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 得到添加的最后一笔资产的资产编码
        /// </summary>
        /// <returns>"":没有找到；dt.Rows[0][0].ToString()：最后一笔资产的编号</returns>
        public static string GetLastEqNo()
        {
            sqlHandler sh = new sqlHandler();
            string yy = DateTime.Now.Year.ToString();//获取当前年份
            string sql = "select top 1 EqNo from Equipment where EqNo like '" + yy + "%'" + " order by eqno desc";
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
        /// <summary>
        /// 得到某一笔资产的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOneInfo(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select eqno,type,name,label,price,birthday,model,plus,keepplace,keeper,maker from Equipment where eqno='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// 统计所有资产的折旧信息
        /// </summary>
        /// <returns></returns>
        public static DataTable BecomeOld()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select * from view_BecomeOld";
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 得到各比资产的利用率
        /// </summary>
        /// <returns></returns>
        public static DataTable eqUing()
        {
            string sql = "select * from view_EqUseing";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// 得到某一笔资产的详细信息(从视图)
        /// </summary>
        /// <param name="eqno"></param>
        /// <returns></returns>
        public static DataTable GetOneEqViewInfo(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 资产编码='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }

        /// <summary>
        /// 得到某一笔资产的详细信息(从主表)
        /// </summary>
        /// <param name="eqno"></param>
        /// <returns></returns>
        public static DataTable GetOneEqInfo(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from Equipment where EqNo='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }


        public static DataTable GetAssetInfo(string assetno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 单号='{0}'", assetno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }


        /// <summary>
        /// 得到资产信息的总条数
        /// </summary>
        /// <returns></returns>
        public static int EqCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select count(*) from Equipment";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());

            }

            return result;
        }

        /// <summary>
        /// 得到某笔资产的数量
        /// </summary>
        /// <param name="assetno"></param>
        /// <returns></returns>
        public static int AssetCount(string assetno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from Equipment where AssetNo='{0}'",assetno);
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());

            }

            return result;
        }

        public static DataTable getAllEq(string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
                sql = "select * from View_Equipment order by 资产编码";
            else if (power == "2")
                sql = string.Format("select * from View_Equipment where 部门编号 like '{0}%'order by 资产编码", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_Equipment where 部门编号='{0}'order by 资产编码", departId);
            
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
        /// 得到资产信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getEqList(int start, int max, string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
                sql = "select * from View_Equipment order by 资产编码";
            else if (power == "2")
                sql = string.Format("select * from View_Equipment where 部门编号 like '{0}%'order by 资产编码", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_Equipment where 部门编号='{0}'order by 资产编码", departId);

            DataTable dt = sh.GetDataTable_Page(sql, start, max);
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
        /// 得到审核信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getAuditList(int start, int max, string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
            {
                sql = "select distinct AssetNo, EqName, AddDate, Agent, Department from Equipment where EqNo like 'TE%'";
                DataTable dt = sh.GetDataTable_Page(sql, start, max);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                MessageBox.Show("无权限");
                return null;
            }
            
        }
        /// <summary>
        /// 得到待审核信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(int start, int max, string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select distinct AssetNo, EqName, AddDate, Agent, Department, State from Equipment where EqNo like 'TE%' AND Agent='{0}'", agent);
            DataTable dt = sh.GetDataTable_Page(sql, start, max);
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
        /// 得到临时单数
        /// </summary>
        /// <returns></returns>
        public static int getTempAssetCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            sql = "select count(*) from (select distinct AssetNo from Equipment where AssetNo like 'TA%') AS M";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }

        /// <summary>
        /// 更新设备号和单号
        /// </summary>
        /// <returns></returns>
        public static bool changeEqNo(string eqno, string newEqNo, string newAssetNo)
        {
            string sql = string.Format("update Equipment set EqNo='{1}', AssetNo='{2}', State='入库' where EqNo='{0}'", eqno, newEqNo, newAssetNo);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 拒绝新增单
        /// </summary>
        /// <returns></returns>
        public static bool failChangeEqNo(string eqno)
        {
            string sql = string.Format("update Equipment set State='新增审核未通过' where EqNo='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }


        public static DataTable GetInfobyFactor(string factorname,string factor,string departId,string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
                sql = string.Format("select * from View_Equipment where {0}='{1}'", factorname, factor);
            else if (power == "2")
                sql = string.Format("select * from View_Equipment where 部门编号 like '{0}%' AND {1}='{2}' ORDER BY 资产编码",
                    departId.Substring(0, 2), factorname, factor);
            else
                sql = string.Format("select * from View_Equipment where 部门编号='{0}' AND {1}='{2}' ORDER BY 资产编码",
                    departId, factorname, factor);



            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }


        /// <summary>
        /// 按编号查询资产信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInfobyEqno(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 资产编码='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }

       

        /// <summary>
        /// 按资产状态查询资产信息
        /// </summary>
        /// <param name="state">类别名称</param>
        /// <returns></returns>
        public static DataTable GetInfobyState(string state)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 状态='{0}'", state);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }

        /// <summary>
        /// 按资产类别查询资产信息
        /// </summary>
        /// <param name="type">类别名称</param>
        /// <returns></returns>
        public static DataTable GetInfobyType(string type)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 资产类别='{0}'", type);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// 按使用部门查询资产信息
        /// </summary>
        /// <param name="depart">资产名称</param>
        /// <returns></returns>
        public static DataTable GetInfobyDepart(string depart)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 使用部门='{0}'", depart);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;


        }
        /// <summary>
        /// 按资产增长方式查询资产信息
        /// </summary>
        /// <param name="name">资产名称</param>
        /// <returns></returns>
        public static DataTable GetInfobyGetWay(string addtype)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 取得方式='{0}'", addtype);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 按资产保存地点查询资产信息
        /// </summary>
        /// <param name="name">保存地点</param>
        /// <returns></returns>
        public static DataTable GetInfobyKeepplace(string place)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 存放地点='{0}'", place);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 按资产登记人查询资产信息
        /// </summary>
        /// <param name="name">资产名称</param>
        /// <returns></returns>
        public static DataTable GetInfobyBooker(string booker)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Equipment where 保存地点='{0}'", booker);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;


        }

        public static DataTable GetPhoto(string eqno)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select Photo from Equipment where EqNo='{0}'", eqno);
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }

        
        /// <summary>
        /// 得到筛选资产信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getSortEqList(int start, int max, string departId, string power, List<string> SelectedColumns, Dictionary<String, String> SortsString, string OrderString)
        {
            string selectItem = "";
            foreach (string field in SelectedColumns)
            {
                if (field.Contains("/") || field.Contains("("))
                {
                    selectItem += "[" + field + "]" + ", ";
                }
                else
                {
                    selectItem += field + ", ";
                }
            }
            selectItem = selectItem.Substring(0, selectItem.Length - 2);
            string sortSet = "";
            int index = 0;
            foreach (KeyValuePair<string, string> kvp in SortsString)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                    continue;
                if (index == 0)
                    sortSet = kvp.Value;
                else
                    sortSet = sortSet + " and " + kvp.Value;
                index++;
            }
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (string.IsNullOrEmpty(sortSet))
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_Equipment order by 资产编码", selectItem);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_Equipment where 部门编号 like '{0}%'order by 资产编码", departId.Substring(0, 2), selectItem);
                    else
                        sql = string.Format("select {1} from View_Equipment where 部门编号='{0}'order by 资产编码", departId, selectItem);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_Equipment order by {1}", selectItem, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_Equipment where 部门编号 like '{0}%'order by {2}", departId.Substring(0, 2), selectItem, OrderString);
                    else
                        sql = string.Format("select {1} from View_Equipment where 部门编号='{0}'order by {2}", departId, selectItem, OrderString);
                }

            }
            else
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_Equipment where {1} order by 资产编码", selectItem, sortSet);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_Equipment where 部门编号 like '{0}%' and {2} order by 资产编码", departId.Substring(0, 2), selectItem, sortSet);
                    else
                        sql = string.Format("select {1} from View_Equipment where 部门编号='{0}'and {2} order by 资产编码", departId, selectItem, sortSet);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_Equipment where {1} order by {2}", selectItem, sortSet, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_Equipment where 部门编号 like '{0}%' and {2} order by {3}", departId.Substring(0, 2), selectItem, sortSet, OrderString);
                    else
                        sql = string.Format("select {1} from View_Equipment where 部门编号='{0}' and {2} order by {3}", departId, selectItem, sortSet, OrderString);
                }

            }

            DataTable dt = sh.GetDataTable_Page(sql, start, max);
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
        /// 得到筛选后某列的所有值
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getEqRowList(string departId, string power, string Column, Dictionary<String, String> SortsString)
        {
            string sortSet = "";
            int index = 0;
            foreach (KeyValuePair<string, string> kvp in SortsString)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                    continue;
                if (index == 0)
                    sortSet = kvp.Value;
                else
                    sortSet = sortSet + " and " + kvp.Value;
                index++;
            }
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (string.IsNullOrEmpty(sortSet))
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_Equipment order by {0}", Column);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_Equipment where 部门编号 like '{0}%'order by {1}", departId.Substring(0, 2), Column);
                else
                    sql = string.Format("select distinct {1} from View_Equipment where 部门编号='{0}'order by {1}", departId, Column);

            }
            else
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_Equipment where {1} order by {0}", Column, sortSet);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_Equipment where 部门编号 like '{0}%' and {2} order by {1}", departId.Substring(0, 2), Column, sortSet);
                else
                    sql = string.Format("select distinct {1} from View_Equipment where 部门编号='{0}'and {2} order by {1}", departId, Column, sortSet);
            }

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
        /// 得到审核信息
        /// </summary>
        /// <param name="departId">部门</param>
        /// <param name="power">权限</param>
        /// <returns></returns>
        public static DataTable getAuditList()
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Audit where 状态 = '新增待审核'");
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
        /// 得到审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getAuditListCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_Audit where 状态 = '新增待审核') AS M");
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 得到待审核信息
        /// </summary>
        /// <param name="agent">用户</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_Audit where 经办人='{0}'", agent);
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
        /// 得到待审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getUnAuditListCount(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_Audit where 经办人='{0}') AS M", agent);
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }

        public static List<string> GetEqNoByAssetNo(string assetno)
        {
            List<string> list = new List<string>();
            string eqno;
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select EqNo from Equipment where AssetNo='{0}'", assetno);
            DataTable dt = sh.GetData(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                eqno=dt.Rows[i][0].ToString();
                list.Add(eqno);
            }

            if (list.Count != 0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到所有单数
        /// </summary>
        /// <returns></returns>
        public static int getAllAssetCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            sql = "select count(*) from (select distinct AssetNo from Equipment) AS M";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 得到设备数
        /// </summary>
        /// <returns></returns>
        public static int getAllEqCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            sql = "select count(*) from (select distinct EqNo from Equipment where state IN ('入库','维修','借出','注销')) AS M";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        #region 加载更新资产
        /// <summary>
        /// 得到审核信息
        /// </summary>
        /// <param name="departId">部门</param>
        /// <param name="power">权限</param>
        /// <returns></returns>
        public static DataTable getUpdateAuditList(string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
            {
                sql = "select * from View_UpdateEquipment where 状态 = '更新待审核'";
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
            else
            {
                MessageBox.Show("无权限");
                return null;
            }

        }
        /// <summary>
        /// 得到审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getUpdateAuditListCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_UpdateEquipment where 状态 = '更新待审核') AS M");
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 得到更新待审核信息
        /// </summary>
        /// <param name="agent">用户</param>
        /// <returns></returns>
        public static DataTable getUpdateUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select * from View_UpdateEquipment where 资产编码 LIKE '_{0}%'", agent);
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
        /// 得到待审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getUpdateUnAuditListCount(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_UpdateEquipment where 资产编码 LIKE '_{0}%') AS M", agent);
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 更新审核通过
        /// </summary>
        /// <param name="EqNo">流水号</param>
        /// <returns></returns>
        public static bool agreeUpdateAudit(string tempEqNo)
        {
            string EqNo = tempEqNo.Substring(21, 10);
            string sql = string.Format("DELETE Equipment WHERE EqNo='{0}'", EqNo);
            sqlHandler sh = new sqlHandler();
            int flag = sh.ExecuteNonQuery(sql);
            sql = string.Format("update Equipment set state='入库',EqNo='{1}' where EqNo='{0}'", tempEqNo, EqNo);
            sh = new sqlHandler();
            return flag > 0 && sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 更新审核未通过
        /// </summary>
        /// <param name="EqNo">流水号</param>
        /// <returns></returns>
        public static bool disagreeUpdateAudit(string EqNo)
        {
            string sql = string.Format("update Equipment set state='更新审核未通过' where EqNo='{0}'", EqNo);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 删除更新信息
        /// </summary>
        /// <param name="EqNo">资产编码</param>
        /// <returns></returns>
        public static bool deleteUpdateAudit(string EqNo)
        {
            string sql = string.Format("DELETE Equipment WHERE EqNo='{0}'", EqNo);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        #endregion 加载更新资产

        #region 状态更新
        /// <summary>
        /// 删除新增信息
        /// </summary>
        /// <param name="ID">单号</param>
        /// <returns></returns>
        public static bool deleteByAssetNo(string ID)
        {
            string sql = string.Format("DELETE Equipment WHERE AssetNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 设备借出
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <returns></returns>
        public static bool BorrowEq(string eqno)
        {
            string sql = string.Format("update Equipment set State='借出' where EqNo='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 设备送修
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <returns></returns>
        public static bool FixEq(string eqno)
        {
            string sql = string.Format("update Equipment set State='维修' where EqNo='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 设备归还
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <returns></returns>
        public static bool ReturnEq(string eqno)
        {
            string sql = string.Format("update Equipment set State='入库' where EqNo='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 设备注销
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <returns></returns>
        public static bool ClearEq(string eqno)
        {
            string sql = string.Format("update Equipment set State='注销' where EqNo='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        private static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        /// <summary>
        /// 判断字符串是否为日期格式
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        private static bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion 状态更新

    }
}
