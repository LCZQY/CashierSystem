using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Npoi.Core.HSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace QP.Cashier_Service
{
    public static class ExportExecl
    {
         /// <summary>
         /// 导出Eexecl
         /// </summary>
         /// <param name="_hostingEnvironment"></param>
         /// <param name="table">填充数据集</param>
         /// <returns>优化思路： 没有给表格添加样式？</returns>
        public static string CrateExecl(IHostingEnvironment _hostingEnvironment, DataTable table)
        {        
            
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                //添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("aspnetcore");
                
                var i = 0;
                List<string> Enum = new List<string>() {
                    "A","B","C","D","E","F","G","H",
                    "I","J","K","L","M","N","O","P",
                    "Q","R","S","T","U","V","W","X",
                    "Y","Z"
                };
                //遍历列名
                foreach (DataColumn column in table.Columns)
                {
                    i += 1;
                    worksheet.Cells[1, i].Value = column.ColumnName;
                }
                //填充表数据
                for (int l = 0; l < table.Rows.Count; l++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        worksheet.Cells[Enum[k].ToString() + (l + 2).ToString()].Value = table.Rows[l][k].ToString();
                    }
                }
                package.Save();
            }
            return sFileName;
        }
    }
}
