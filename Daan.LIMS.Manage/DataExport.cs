using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Daan.LIMS.Manage
{
    public class DataExport
    {
        /// <summary>
        /// 导出DataGridView数据为Excel
        /// </summary>
        /// <param name="fileName">保存文件名</param>
        /// <param name="grid">DataGridView对象</param>
        /// <returns>导出成功:true</returns>
        //public bool ExportExcel(string fileName, DataGridView grid)
        //{
        //    if (grid.Rows.Count <= 0)
        //        return false;

        //    SaveFileDialog dialog = new SaveFileDialog();
        //    dialog.CreatePrompt = true;
        //    dialog.OverwritePrompt = true;
        //    dialog.RestoreDirectory = true;
        //    dialog.CheckFileExists = true;
        //    dialog.ValidateNames = false;
        //    dialog.FilterIndex = 2;
        //    dialog.DefaultExt = "xls";
        //    dialog.Filter = "导出Excel (*.xls)|*.xls";
        //    dialog.Title = "导出文件保存路径";
        //    dialog.FileName = fileName;
        //    DialogResult result = dialog.ShowDialog();

        //    string saveFileName = dialog.FileName;

        //    //当保存文件名称不为空、保存弹出窗口响应OK    两个条件成立才执行导出
        //    if (!string.IsNullOrEmpty(fileName) && result == DialogResult.OK)
        //    {
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        System.Reflection.Missing miss = System.Reflection.Missing.Value;

        //        excel.Application.Workbooks.Add(true);
        //        excel.Visible = false;

        //        Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;// excel.Workbooks;
        //        Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)books.Add(miss);//books.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
        //        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;//(Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[1];
        //        sheet.Name = "sheet1";
        //        try
        //        {
        //            //导出grid表头
        //            int colIndex = 0;
        //            foreach (DataGridViewColumn column in grid.Columns)
        //            {
        //                if (column.Visible)
        //                {
        //                    colIndex++;

        //                    excel.Cells[1, colIndex] = column.HeaderText.ToString();
        //                }
        //            }

        //            //导出行列数据
        //            for (int r = 0; r < grid.Rows.Count; r++)
        //            {
        //                for (int c = 0; c < grid.Columns.Count; c++)
        //                {
        //                    if (grid.Columns[c].Visible)
        //                    {
        //                        if (grid[c, r].Value != null)
        //                        {
        //                            string cValue = grid[c, r].Value.ToString();

        //                            if (grid[c, r].ValueType == typeof(string))
        //                                excel.Cells[r + 2, c + 1] = "'" + cValue;
        //                            else
        //                                excel.Cells[r + 2, c + 1] = cValue;
        //                        }
        //                    }
        //                }
        //            }
        //            sheet.Columns.EntireColumn.AutoFit();

        //            //book.Saved = true;
        //            //book.SaveCopyAs(saveFileName);
        //            //保存
        //            sheet.SaveAs(saveFileName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);


        //            //GC.Collect();
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //        finally
        //        {
        //            book.Close(false, miss, miss);
        //            books.Close();
        //            excel.Quit();

        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        //            GC.Collect();
        //        }

        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public bool ExportExcel(string fileName, DataGridView dataGridview1)
        {
            if (dataGridview1.Rows.Count <= 0)
                return false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl  files  (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";

            DateTime now = DateTime.Now;
            saveFileDialog.FileName = fileName;// now.Year.ToString().PadLeft(2) + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + "-" + now.Hour.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0') + now.Second.ToString().PadLeft(2, '0');
            //  saveFileDialog.ShowDialog();

            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.CreatePrompt = false;
          //  saveFileDialog.CheckFileExists = true;
            DialogResult result = saveFileDialog.ShowDialog();
            

            string saveFileName = saveFileDialog.FileName;

            //当保存文件名称不为空、保存弹出窗口响应OK    两个条件成立才执行导出
            if (!string.IsNullOrEmpty(fileName) && result == DialogResult.OK)
            {




                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
                string str = "";
                try
                {
                    //写标题    
                    for (int i = 0; i < dataGridview1.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += dataGridview1.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);
                    //写内容 
                    for (int j = 0; j < dataGridview1.Rows.Count; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < dataGridview1.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                tempStr += "\t";
                            }
                            if (dataGridview1.Rows[j].Cells[k].Value == null)
                            {
                                tempStr += "";
                            }
                            else
                            {
                                //alter bao 2012-09-13 去掉文字中的换行符
                                tempStr += dataGridview1.Rows[j].Cells[k].Value.ToString().Replace((char)13, (char)0).Replace((char)10, (char)0);
                            }
                        }
                        sw.WriteLine(tempStr);
                    }
                    sw.Close();
                    myStream.Close();
                    //  MessageBox.Show("导出成功");
                }
                catch (Exception e)
                {
                    return false;
                    // MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
                return true;
            }
            else
                return false;
        }

    }
}
