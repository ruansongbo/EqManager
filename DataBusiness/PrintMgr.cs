using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DataBusiness
{
    public class PrintMgr
    {

        public static void PrintLabel(DataTable dt,int count)
        {
            PrintLab.OpenPort("POSTEK TX2r");//打开打印机端口
            

            uint copynumber = Convert.ToUInt16(count);
            string eqNo = "";
            string eqName = "";
            string buyDate = "";
            string depart = "";

            for (int i = 0; i <dt.Rows.Count; i++)
            {
                PrintLab.PTK_ClearBuffer();           //清空缓冲区
                PrintLab.PTK_SetPrintSpeed(4);        //设置打印速度
                PrintLab.PTK_SetDarkness(10);         //设置打印黑度
                PrintLab.PTK_SetLabelHeight(320, 16, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
                PrintLab.PTK_SetLabelWidth(560);      //设置标签的宽度

                eqNo = dt.Rows[i]["资产编码"].ToString();
                eqName = dt.Rows[i]["资产名称"].ToString();
                buyDate = dt.Rows[i]["取得日期"].ToString();
                depart = dt.Rows[i]["使用部门"].ToString();

                // 画矩形
                PrintLab.PTK_DrawRectangle(8, 8, 10, 552, 312);

                // 画表格分割线
                PrintLab.PTK_DrawLineOr(8, 88, 544, 5);
                PrintLab.PTK_DrawLineOr(8, 144, 544, 5);
                PrintLab.PTK_DrawLineOr(8, 200, 368, 5);
                PrintLab.PTK_DrawLineOr(8, 256, 368, 5);
                PrintLab.PTK_DrawLineOr(140, 88, 5, 224);
                PrintLab.PTK_DrawLineOr(376, 144, 5, 168);

                // 打印标签样式
                //PrintLab.PTK_DrawTextTrueTypeW(120, 18, 40, 0, "Arial", 1, 400, false, false, false, "company", "深圳大学师范学院");
                PrintLab.PTK_DrawTextTrueTypeW(20, 98, 30, 0, "宋体", 1, 400, false, false, false, "EqName", "资产名称");
                PrintLab.PTK_DrawTextTrueTypeW(20, 154, 30, 0, "宋体", 1, 400, false, false, false, "EqNo", "资产编码");
                PrintLab.PTK_DrawTextTrueTypeW(20, 210, 30, 0, "宋体", 1, 400, false, false, false, "BuyDate", "购置年月");
                PrintLab.PTK_DrawTextTrueTypeW(20, 266, 30, 0, "宋体", 1, 400, false, false, false, "Depart", "使用部门");

                PrintLab.PTK_DrawTextTrueTypeW(150, 98, 30, 0, "宋体", 1, 400, false, false, false, "sEqName", eqName);
                PrintLab.PTK_DrawTextTrueTypeW(150, 154, 30, 0, "宋体", 1, 400, false, false, false, "sEqNo", eqNo);
                PrintLab.PTK_DrawTextTrueTypeW(150, 210, 30, 0, "宋体", 1, 400, false, false, false, "sBuyDate", buyDate);
                PrintLab.PTK_DrawTextTrueTypeW(150, 266, 30, 0, "宋体", 1, 400, false, false, false, "sDepart", depart);

                // 打印QR码
                PrintLab.PTK_DrawBar2D_QR(400, 180, 180, 180, 0, 5, 2, 0, 0, eqNo);


                // 打印PCX图片 方式一
                PrintLab.PTK_PcxGraphicsDel("PCX");
                PrintLab.PTK_PcxGraphicsDownload("PCX", "logo.pcx");
                PrintLab.PTK_DrawPcxGraphics(18, 20, "PCX");

                

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, copynumber);

            }
            PrintLab.ClosePort();//关闭打印机端口
            
        }
    }
}

public class PrintLab
{
    [DllImport("WINPSK.dll")]
    public static extern int OpenPort(string printname);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetPrintSpeed(uint px);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetDarkness(uint id);
    [DllImport("WINPSK.dll")]
    public static extern int ClosePort();
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PrintLabel(uint number, uint cpnumber);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PrintPCX(uint px, uint py, string filename);

    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawTextTrueTypeW
                                        (int x, int y, int FHeight,
                                        int FWidth, string FType,
                                        int Fspin, int FWeight,
                                        bool FItalic, bool FUnline,
                                        bool FStrikeOut,
                                        string id_name,
                                        string data);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBarcode(uint px,
                                    uint py,
                                    uint pdirec,
                                    string pCode,
                                    uint pHorizontal,
                                    uint pVertical,
                                    uint pbright,
                                    char ptext,
                                    string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetLabelHeight(uint lheight, uint gapH, int gapOffset, bool bFlag);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetLabelWidth(uint lwidth);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_ClearBuffer();
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawRectangle(uint px, uint py, uint thickness, uint pEx, uint pEy);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawLineOr(uint px, uint py, uint pLength, uint pH);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBar2D_QR(uint x, uint y, uint w, uint v, uint o, uint r, uint m, uint g, uint s, string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBar2D_Pdf417(uint x, uint y, uint w, uint v, uint s, uint c, uint px, uint py, uint r, uint l, uint t, uint o, string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PcxGraphicsDel(string pid);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PcxGraphicsDownload(string pcxname, string pcxpath);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawPcxGraphics(uint px, uint py, string gname);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawText(uint px, uint py, uint pdirec, uint pFont, uint pHorizontal, uint pVertical, char ptext, string pstr);


}