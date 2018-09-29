using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataBusiness;
using DataEntity;

namespace MyTCPServerNameSpace
{
        class HRPackage
        {
                public HRPackage()
                {
                        initStrArr(temp,"0");
                }


                /// <summary>
                /// 解释数据包
                /// </summary>
                /// <param name="obj"></param>
                public void AnalyData(HRTCPServer.HRMessagePack msgTran , string ipAddr)
                {
                        if (msgTran.PacketType != 0x1B)
                        {
                                return;
                        }

                        switch (msgTran.Cmd)
                        {
                                case 0x39:
                                        ProcessInventoryReal(msgTran , ipAddr);
                                        break;
                                
                                default:
                                        break;
                        }
                }


                /// <summary>
                /// 盘存监控记录
                /// </summary>
                /// <param name="obj"></param>
                const int BUFFSIZE = 100;
                string[] temp = new string[BUFFSIZE];
                int index=0;
                int counter=0;
                private void ProcessInventoryReal(HRTCPServer.HRMessagePack msgTran , string ipAddr)
                {
                        string strDeviceAddr = "";
                        int lastRecord;                                                               
                        DateTime lastTime;
                        DateTime nowTime = DateTime.Now;

                        if (msgTran.AryData.Length > 3)
                        {
                                try
                                {
                                        int nLength = msgTran.AryData.Length;
                                        int nEpcLength = Convert.ToInt32(msgTran.AryData[0]);

                                        string strEPC = ByteArrayToString(msgTran.AryData, 4, nEpcLength - 4);
                                        string strPC = ByteArrayToString(msgTran.AryData, 2, 2);
                                                                                
                                        strDeviceAddr = string.Format("{0:X2}", msgTran.Opcode);
                                       
                                        string strRSSI = "";
                                        double intRSSI = 0;
                                        int RSSI_M, RSSI_E, rssidBm = 0;

                                        rssidBm = msgTran.AryData[1];
                                        RSSI_M = (rssidBm & 0X07);
                                        RSSI_E = (rssidBm & 0XF8);
                                        intRSSI = -(0X6E - 20 * Math.Log10((2 ^ RSSI_E) * (1 + (RSSI_M / 2 ^ 3))));
                                        strRSSI = Convert.ToString(intRSSI).Substring(0, 3) + "dBm";

                                        byte btAntId = msgTran.AryData[nEpcLength];
                                        string StrTime = "";
                                                                                
                                        StrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//盘点时间
                                        
                                       
                                        string strAntId = (btAntId + 1).ToString();

                                        string temRecord = strDeviceAddr + strEPC + StrTime;
                                        string identity = strDeviceAddr + strEPC;
                                        lastRecord = stringContain(temp,identity,index-1 );


                                        /******************************************************************************************/
                                        /**这一段是写入数据库前的必要操作**/
                                        Record rd = new Record();
                                        string strSerialNo = "";//流水号
                                        string strNow = DateTime.Now.ToString("yyyyMMdd");//获取当前日期
                                        string strFormer = "";
                                        string strLatter = "";
                                        int number;

                                        /**开始获取流水号**/
                                        strSerialNo = RecordMgr.GetLastNo();//监控记录表的最后一位流水号
                                        if (strSerialNo != "")
                                        {
                                            strFormer = strSerialNo.Substring(0, 8);//流水号前8位
                                            strLatter = strSerialNo.Substring(8);//流水号后8位
                                            if (strFormer == strNow)
                                            {
                                                number = Convert.ToInt32(strLatter) + 1;
                                                strLatter = string.Format("{0:00000000}",number);
                                                strSerialNo=strNow+strLatter;
                                            }
                                            else
                                            {
                                                strLatter = "00000001";
                                                strSerialNo = strNow + strLatter;
                                            }
                                        }
                                        //用于第一次记录数据
                                        else
                                        {
                                            strLatter = "00000001";
                                            strSerialNo = strNow + strLatter;
                                        }

                                        //开始获取数据
                                        rd.SerialNo = strSerialNo;
                                        rd.EPC = strEPC;
                                        rd.KeepPlace = "";
                                        rd.MtNo = strDeviceAddr;
                                        rd.Time = StrTime;
                                        rd.Activity = "进入";
                                        rd.Processor = 0000;
                                        
                                        /********************************************************************************************/
                                        if (strEPC != "00 00 00 00 00 00 00 00 00 00 00 00 " && strEPC != "" && -1 == lastRecord )
                                        {
                                                temp[index] = temRecord;
                                                index = (index+1) % BUFFSIZE;
                                                /*
                                                  写入数据库
                                                */
                                                RecordMgr.AddRecord(rd);
                                                
                                        
                                        }
                                        
                                        if (strEPC != "00 00 00 00 00 00 00 00 00 00 00 00 " && strEPC != "" && lastRecord !=-1 )
                                        {
                                                lastTime = Convert.ToDateTime(temp[lastRecord].Substring(strDeviceAddr.Length + strEPC.Length, StrTime.Length));
                                                if (timeErr(nowTime, lastTime) > 3)
                                                {
                                                        /*
                                                        写入数据库
                                                        */
                                                    RecordMgr.AddRecord(rd);

                                                        temp[index] = temRecord;
                                                        index = (index + 1) % BUFFSIZE;
                                                }
                                                else
                                                {
                                                        temp[index] = temRecord;
                                                        index = (index + 1) % BUFFSIZE;
                                                }
                                        }
                                        
                                }

                                catch (System.Exception ex)
                                {
                                        //MessageBox.Show(ex.Message);
                                }
                                
                        }
                }

                /// <summary>
                /// 从指定位置开始倒序循环寻找string型数组中第一个包含特定字符串子集的元素,有则返回该元素的索引，否则返回-1
                /// </summary>
                /// <param name="strArr"></param>
                /// <param name="strSubset"></param>
                /// <param name="origin"></param>
                /// <returns><index>
                public int stringContain(string[] strArr, string strSubset , int origin)
                {
                        int index = -1;

                        for (int i = 0 ;  i<strArr.Length ; i++ )
                        { 
                                origin = (origin + strArr.Length)%strArr.Length ;
                                if (strArr[origin].Contains(strSubset))
                                {
                                        index = origin;
                                        break;
                                }
                                origin--;
                        }
                        
                        return index;
                }

                /// <summary>
                /// 计算两个DateTime类型的时间差
                /// </summary>
                /// <param name="DateTime1"></param>
                /// <param name="DateTime2"></param>
                /// <returns><secErr>
                private int timeErr(DateTime DateTime1, DateTime DateTime2)
                {
                        int secErr = 0;
                        TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                        TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                        TimeSpan ts = ts1.Subtract(ts2).Duration();
                        secErr = ts.Days * 86400 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
                        return secErr;
                }

                /// <summary>
                /// 把string数组全部初始化为特定字符串
                /// </summary>
                /// <param name="strArr"></param>
                /// <param name="initStr"></param>
                /// <returns><returns>
                private void initStrArr(string[] strArr,string initStr)
                {
                        for (int i = 0; i < strArr.Length; i++)
                        {
                                strArr[i] = initStr;
                        }
                }


                /// <summary>
                /// 16进制字符数组转成字符串
                /// </summary>
                /// <param name="btAryHex"></param>
                /// <param name="nIndex"></param>
                /// <param name="nLen"></param>
                /// <returns></returns>
                public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
                {
                        if (nIndex + nLen > btAryHex.Length)
                        {
                                nLen = btAryHex.Length - nIndex;
                        }

                        string strResult = string.Empty;

                        for (int nloop = nIndex; nloop < nIndex + nLen; nloop++)
                        {
                                string strTemp = string.Format(" {0:X2}", btAryHex[nloop]);

                                strResult += strTemp;
                        }

                        return strResult;
                }

        }
}
