using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

using System.Reflection;
using System.Threading;

using System.Data;

using System.Drawing;
using System.IO;

namespace Daan.LIMS.Manage
{
    public class CommonFuncLibClient
    {
        public static byte[] ImageToBuffer(string filename, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            Image Image = new Bitmap(filename);
            if (Image == null) { return null; }

            byte[] data = null;

            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                using (Bitmap oBitmap = new Bitmap(Image))
                {


                    oBitmap.Save(oMemoryStream, imageFormat);

                    oMemoryStream.Position = 0;
                    data = new byte[oMemoryStream.Length];
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));

                    oMemoryStream.Flush();

                }
            }
            return data;

        }

        public static Image BufferToImage(byte[] Buffer)
        {

            if (Buffer == null || Buffer.Length == 0) { return null; }

            byte[] data = null;

            Image oImage = null;

            Bitmap oBitmap = null;
            data = (byte[])Buffer.Clone();

            try
            {

                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                oMemoryStream.Position = 0;

                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                oBitmap = new Bitmap(oImage);
                oBitmap.Save(@"c:\1.gif");
            }
            catch
            {

                throw;

            }
            return oBitmap;

        }



        public static string getMd5Hash(string input)
        {
            
            MD5 md5Hasher = MD5.Create();

         
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

          
            StringBuilder sBuilder = new StringBuilder();

          
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

  

            return sBuilder.ToString();
        }


        public static DataRow drCopy(DataRow dr) {
            DataTable dt = dr.Table.Clone();
            dt.Rows.Add(dr.ItemArray);

            return dt.Rows[0];
 
        }

        public static bool Messagebox(string MessageString,string IconType)
        {
            MessageBoxIcon IconTypenew;
            if (IconType == "!")
            {
                IconTypenew = MessageBoxIcon.Warning;
                MessageBox.Show(MessageString, "提示", MessageBoxButtons.OK, IconTypenew);
               

            }
            else if (IconType == "?")
            {
                IconTypenew = MessageBoxIcon.Question;
                if (MessageBox.Show(MessageString, "提示", MessageBoxButtons.YesNo, IconTypenew) == DialogResult.No)
                { return false; }
            }
            else if (IconType == ".")
            {
                IconTypenew = MessageBoxIcon.Information;
                MessageBox.Show(MessageString, "提示", MessageBoxButtons.OK, IconTypenew);
            }
            else if (IconType == "x")
            {
                IconTypenew = MessageBoxIcon.Error;
                MessageBox.Show(MessageString, "提示", MessageBoxButtons.OK, IconTypenew);
            }
            else
            {
                IconTypenew = MessageBoxIcon.Information;
                MessageBox.Show(MessageString, "提示", MessageBoxButtons.OK, IconTypenew);
            }
   
          

            return true;
        }
        public static void Copy(DataRow drSource, DataRow drDest)
        {


            foreach (DataColumn col in drSource.Table.Columns)
                {
                    if (drDest.Table.Columns[col.ColumnName] != null)  //找到名称一样的，准备复制数据
                    {

                        drDest[col.ColumnName] = drSource[col.ColumnName];
                    }

        
            }
        }

        /// <summary>
        /// 复制对象属性到另一个对象相同的属性中
        /// </summary>
        /// <param name="sourceObj">原对象</param>
        /// <param name="destObj">目的对象</param>
        public static void copyObj(Object sourceObj, Object destObj)
        {
            Type sType = sourceObj.GetType();
            Type dType = destObj.GetType();
            foreach (PropertyInfo pSource in sType.GetProperties())
            {
                foreach (PropertyInfo pDest in dType.GetProperties())
                {
                    if (pSource.Name.ToLower() == pDest.Name.ToLower())
                    {
                        if (pDest.GetSetMethod() != null)

                            try
                            {
                                pDest.SetValue(destObj, pSource.GetValue(sourceObj, null), null);
                            }
                            catch (Exception ex)
                            {


                            }
                        break;
                    }
                }
            }
        }







        /// <summary>
        /// 统一设置DataGridView的样式
        /// </summary>
        /// <param name="gr"></param>
        public static void SetDataGridStyle(DataGridView gr)
        {
            gr.AllowUserToAddRows = false;
            gr.AllowUserToResizeRows = false;
            gr.AutoGenerateColumns = false;
            gr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gr.RowHeadersWidth = 20;
            gr.RowTemplate.Height = 23;
            gr.ColumnHeadersHeight = 23;
            gr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gr.MultiSelect = false;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gr.RowsDefaultCellStyle = dataGridViewCellStyle; 
        }

        //公用方法，将DataGridView显示的数据导出到EXCEL
        //参数一：导出的默认文件名
        //参数二：需要导出的数据对象
        public static void ExportGridViewToExcel(string caption, DataGridView gr)
        {
            if (gr.Rows.Count <= 0)
            { 
                CommonFuncLibClient.Messagebox("当前列表没有数据可供导出！", "提示"); 
                return;
            }

            bool sucess = false;
            string fileName = caption + DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                DataExport export = new DataExport();
                sucess = export.ExportExcel(fileName, gr);
            }
            catch (Exception err)
            {
                MessageBox.Show("无法输出Excel。");
            }

            if (sucess) CommonFuncLibClient.Messagebox("导出成功！", "提示"); 
        }



        //public class SpellAndWbCode
        //{
        #region 获取汉字拼音码五笔码
            #region 变量

        /// <summary>
            /// XML文件读取实例
            /// </summary>
            private static XmlReader reader = null;

            /// <summary>
            /// XML文件中数据

            /// </summary>
            private static string[] strXmlData = null;

            //记录XML中五笔码开始位置！
            private static int wbCodeStation = 26;

            //记录XML中结束位置！
            private static int outStation = 100;

            #endregion
            #region 构造函数

            /// <summary>
            /// 构造函数，初始化XMLREADER
            /// </summary>
            public static void SpellAndWbCode()
            {
                string path = Application.StartupPath;
                try
                {
                    reader = XmlReader.Create(path + "\\dict\\CodeConfig.xml");
                    strXmlData = getXmlData();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
                //处理空白文件
                //reader.WhitespaceHandling = WhitespaceHandling.None;  
            }
            #endregion

            #region 私有方法

            /// <summary>
            /// 读取XML文件中数据

            /// </summary>
            /// <returns>返回String[]</returns>
            private static string[] getXmlData()
            {
                //这里本应该开辟52个空间就够了，防止以后添加XML节点，故开辟多些空间                
                StringBuilder[] strValue = new StringBuilder[100];
                string[] result = new string[100];
                int i = 0;
                try
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name != "CodeConfig" && reader.Name != "SpellCode" && reader.Name != "WBCode")
                                {

                                    strValue[i] = new StringBuilder();
                                    strValue[i].Append(reader.Name);
                                }
                                if (reader.Name == "WBCode")
                                {
                                    wbCodeStation = i;
                                }
                                break;
                            case XmlNodeType.Text:
                                strValue[i].Append(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                if (reader.Name != "CodeConfig" && reader.Name != "SpellCode" && reader.Name != "WBCode")
                                {
                                    result[i] = strValue[i].ToString();
                                    i++;
                                }
                                if (reader.Name == "CodeConfig")
                                {
                                    outStation = i;
                                }
                                break;
                        }
                    }
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
                return result;
            }

            /// <summary>
            /// 查找汉字
            /// </summary>
            /// <param name="strName">汉字</param>
            /// <param name="start">搜索的开始位置</param>
            /// <param name="end">搜索的结束位置</param>
            /// <returns>汉语反义成字符串，该字符串只包含大写的英文字母</returns>
            private static string searchWord(string strName, int start, int end)
            {
                SpellAndWbCode();//初始化reader
                strName = strName.Trim().Replace(" ", "");                
                if (string.IsNullOrEmpty(strName))
                {
                    return strName;
                }
                StringBuilder myStr = new StringBuilder();
                foreach (char vChar in strName)
                {
                    // 若是字母或数字则直接输出
                    if ((vChar >= 'a' && vChar <= 'z') || (vChar >= 'A' && vChar <= 'Z') || (vChar >= '0' && vChar <= '9'))
                        myStr.Append(char.ToUpper(vChar));
                    else
                    {
                        // 若字符Unicode编码在编码范围则 查汉字列表进行转换输出

                        string strList = null;
                        int i;
                        for (i = start; i < end; i++)
                        {
                            strList = strXmlData[i];
                            if (strList.IndexOf(vChar) > 0)
                            {
                                myStr.Append(strList[0]);
                                break;
                            }
                        }
                    }
                }
                return myStr.ToString();
            }

            #endregion
            #region 公开方法
            /// <summary>
            /// 获得汉语的拼音码
            /// </summary>
            /// <param name="strName">汉字</param>
            /// <returns>汉语拼音码,该字符串只包含大写的英文字母</returns>
            public static string GetSpellCode(string strName)
            {
                return searchWord(strName, 0, wbCodeStation);
            }
            /// <summary>
            /// 获得汉语的五笔码
            /// </summary>
            /// <param name="strName">汉字</param>
            /// <returns>汉语五笔码,该字符串只包含大写的英文字母</returns>
            public static string GetWBCode(string strName)
            {
                return searchWord(strName, wbCodeStation, outStation);
            }

            #endregion
        //}
        #endregion
        ///


            /// <summary>
            /// 数组转字符串，“，”隔开
            /// </summary>
            /// <param name="Str"></param>
            /// <returns></returns>
            public static string BarcodeArrayToString(string[] barcodes)
            {
                string result = "";
                var enumator = barcodes.GetEnumerator();
                while (enumator.MoveNext())
                {
                    if (enumator.Current == null) continue;
                    if (result != "" && result != null)
                    {
                        result += ", ";
                    }
                    result += string.Format("'{0}'", enumator.Current);
                }
                return result;
            }
            /// 判断是否是数字    
            ///         
            public static bool IsNumeric(string str)
            {
                if (str == null || str.Length == 0)    //验证这个参数是否为空
                    return false;                           //是，就返回False
                 
                try
                {
                    Convert.ToDecimal(str);
                    return true;
                }
                catch
                {
                    return false;
                } 

            }
    }
}
