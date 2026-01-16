using ClosedXML.Excel;
using SI_Renaming_Tool_V2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class TestToExcelController
    {
        public void TestExcel(List<LogEmailModel> logEmails, string fileFolder)
        {
            string filePath = fileFolder + "log/log.xlsx";
            using (var workbook = File.Exists(filePath)
                ? new XLWorkbook(filePath) : new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.FirstOrDefault()
                                ?? workbook.Worksheets.Add("Email Test Log");
                int i = 1;
                foreach(var log in logEmails)
                {

                    worksheet.Cell(i, 1).Value = log.ShortName;
                    worksheet.Cell(i, 2).Value = log.Email;
                    worksheet.Cell(i, 3).Value = log.ZipPath;
                    i++;
                }

                workbook.SaveAs(filePath);
            }
                
            
            

            
        }
    }
}
