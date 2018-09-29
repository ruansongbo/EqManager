using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Drawing;
using System.IO;

namespace MyTCPServerNameSpace
{
        public delegate void AnalyDataCallback(HRTCPServer.HRMessagePack msgTran , string ipAddr);

        class MySocket
        {
                public HRTCPServer.HRMessagePack MyHRMessagePack;

                public AnalyDataCallback AnalyCallback;

                public Label lb5;
                public ListView li1;
                // public CustomControl.LogRichTextBox lrtxtDataTran;
                //public CustomControl.LogRichTextBox logRichTxt;

                private TcpListener server;

                //记录未处理的接收数据，主要考虑接收数据分段
                byte[] m_btAryBuffer = new byte[8192];
                //记录未处理数据的有效长度
                int m_nLenth = 0;

                //是否显示收发数据
                public bool m_bDisplayLog = false;

                int client_num = 0;
                private Hashtable hb;


                /// <summary>
                /// TCP_Server接到新连接之后的处理线程，专门接收新连接发来的数据
                /// </summary>
                /// <param name="obj"></param>
                private void ThreadFunc(object obj)
                {
                        //通过hash表hb得到client的socket
                        Socket s = hb[obj] as Socket;
                        IPEndPoint ep = (IPEndPoint)s.RemoteEndPoint;
                        string ipAddr = Convert.ToString(ep.Address);
                        while(true)
                        {
                                try
                                {
                                        int len = s.Available;
                                        if (len > 0)
                                        {
                                                byte[] recv_buf = new byte[1024];
                                                int nBytesRec = s.Receive(recv_buf);

                                                byte[] byReturn = new byte[nBytesRec];
                                                Array.Copy(recv_buf, byReturn, nBytesRec);

                                                
                                                RunReceiveDataCallback(byReturn,ipAddr);
                                        }

                                }
                                catch (SocketException)
                                {
                                        hb.Remove(obj);

                                        /**************************
                                        
                                           修改读卡器信息(读卡器编号是否为空，空则删除该读卡器)

                                        ***************************/

                                        Thread.CurrentThread.Abort();
                                        client_num -= 1;
                                        
                                }
                        }
                }

                /// <summary>
                /// 启动TCP_Server，监听连接；
                /// </summary>
                /// <param name="_addr"></param>
                /// <param name="TCP_Port"></param>
                public void ServerStart(IPAddress _ipAddr, int TCP_Port)
                {
                        
                        hb = new Hashtable();
                        server = new TcpListener(_ipAddr, TCP_Port);
                        server.Start();
                        
                        client_num = 0;

                        while (true)
                        {
                                if (server.Pending())
                                {
                                        Socket newclient = server.AcceptSocket();
                                        String clientName = string.Format("{0}:{1}", ((IPEndPoint)newclient.RemoteEndPoint).Address.ToString(),
                                           ((IPEndPoint)newclient.RemoteEndPoint).Port.ToString());

                                        /**************************
                                        
                                           修改读卡器信息(读卡器是否已经录入数据库)

                                        ***************************/

                                        client_num += 1;
                                        
                                        //将新连接加如hash表，方便后面有选择的发送消息（server一对多通信）
                                        hb.Add(clientName, newclient);
                                                                              
                                        Thread clientThread = new Thread(new ParameterizedThreadStart(ThreadFunc));
                                        clientThread.IsBackground = true;
                                        clientThread.Start(clientName);
                                }

                        }

                }

                /// <summary>
                /// 关闭Server,释放资源
                /// </summary>
                public void ServerStop()
                {
                        if (server != null)
                        {
                                server.Stop();
                        }
                        //关闭客户端,关闭接收线程的事情在ThreadFunc里做
                        if (hb.Count != 0)
                        {
                                foreach (Socket session in hb.Values)
                                {
                                        session.Shutdown(SocketShutdown.Both);
                                }
                                hb.Clear();
                                hb = null;
                                li1.Items.Clear();
                                lb5.Text = "当前连接数:0";
                        }
                }



                public void RunReceiveDataCallback(byte[] btAryReceiveData , string ipAddr)
                {
                        byte[] temp = new byte[1];
                        try
                        {
                                int nCount = btAryReceiveData.Length;
                                byte[] btAryBuffer = new byte[nCount + m_nLenth];
                                Array.Copy(m_btAryBuffer, btAryBuffer, m_nLenth);
                                Array.Copy(btAryReceiveData, 0, btAryBuffer, m_nLenth, btAryReceiveData.Length);

                                //分析接收数据，以0x1B为数据起点，以协议中数据长度为数据终止点
                                int nIndex = 0;//当数据中存在1B时，记录数据的终止点
                                int nMarkIndex = 0;//当数据中不存在1B时，nMarkIndex等于数据组最大索引
                                for (int nLoop = 0; nLoop < btAryBuffer.Length; nLoop++)
                                {
                                        if (btAryBuffer.Length > nLoop + 6)
                                        {
                                                if (btAryBuffer[nLoop] == 0x1B || btAryBuffer[nLoop] == 0x43)
                                                {
                                                        int nLen = Convert.ToInt32(btAryBuffer[nLoop + 4] + btAryBuffer[nLoop + 5] * 256) + 6;
                                                        if (nLoop + nLen < btAryBuffer.Length)
                                                        {
                                                                byte[] btAryAnaly = new byte[nLen + 1];
                                                                Array.Copy(btAryBuffer, nLoop, btAryAnaly, 0, nLen + 1);

                                                                HRTCPServer.HRMessagePack msgTran = new HRTCPServer.HRMessagePack(btAryAnaly);
                                                                if (AnalyCallback != null)
                                                                {
                                                                        AnalyCallback(msgTran,ipAddr);
                                                                }
                                                                nLoop += nLen;
                                                                nIndex = nLoop + 1;
                                                        }
                                                        else
                                                        {
                                                                nLoop += nLen;
                                                        }
                                                }
                                                else
                                                {
                                                        nMarkIndex = nLoop;
                                                }
                                        }
                                }

                                if (nIndex < nMarkIndex)
                                {
                                        nIndex = nMarkIndex + 1;
                                }

                                if (nIndex < btAryBuffer.Length)
                                {
                                        m_nLenth = btAryBuffer.Length - nIndex;
                                        Array.Clear(m_btAryBuffer, 0, 8192);
                                        Array.Copy(btAryBuffer, nIndex, m_btAryBuffer, 0, btAryBuffer.Length - nIndex);
                                }
                                else
                                {
                                        m_nLenth = 0;
                                }

                        }
                        catch (System.Exception ex)
                        {
                        }
                }

                
        }
}
