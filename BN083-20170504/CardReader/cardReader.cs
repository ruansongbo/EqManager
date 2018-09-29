using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Data;


namespace MyTCPServerNameSpace
{
        public class cardReader
        {
                /// <summary>
                /// 读卡器构造函数，启动TCP服务器服务
                /// </summary>
                /// <param name="obj"></param>
                MySocket SocketConnet;
                Thread thread1;
                public cardReader()
                {
                        SocketConnet = new MySocket();
                        HRPackage HRPack = new HRPackage();
                        SocketConnet.MyHRMessagePack = new HRTCPServer.HRMessagePack();
                        SocketConnet.AnalyCallback = HRPack.AnalyData;

                        //// 启动TCP服务器
                        //必须启动单独的线程来开始接下来工作，否则界面卡死在这
                        thread1 = new Thread(th1);
                        thread1.IsBackground = true;
                        thread1.Start();
                }

                /// <summary>
                /// 监听服务线程函数
                /// </summary>
                /// <param name="obj"></param>
               
                //private IPAddress _ipAddr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                private IPAddress _ipAddr = IPAddress.Parse("192.168.1.6");
                private int TCP_Port = 20058;

                


                private void th1()
                {
                        SocketConnet.ServerStart(_ipAddr, Convert.ToInt32(TCP_Port));
                }

                /// <summary>
                /// 添加新的读卡器
                /// </summary>
                /// <param name="obj"></param>
                public bool addReader()
                {
                        return true;
                }

                /// <summary>
                /// 删除读卡器
                /// </summary>
                /// <param name="obj"></param>
                public bool delReader()
                {
                        return true;
                }

                /// <summary>
                /// 得到所有未知读卡器
                /// </summary>
                /// <param name="obj"></param>
                public DataTable getUnknownReader()
                {
                        return null;
                }

                /// <summary>
                /// 得到所有读卡器的信息（包括未知读卡器）
                /// </summary>
                /// <param name="obj"></param>
                public DataTable getAllReader()
                {
                        return null;
                }

                /// <summary>
                /// 修改读卡器信息（已知）
                /// </summary>
                /// <param name="obj"></param>设备编号作为索引
                public bool editReader()
                {
                        return true ;
                }

                /// <summary>
                /// 修改读卡器信息（未知）
                /// </summary>
                /// <param name="obj"></param>IP地址作为索引
                public bool editUnknownReader()
                {
                        return true;
                }


        }
}
