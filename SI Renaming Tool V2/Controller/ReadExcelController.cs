using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using SI_Renaming_Tool_V2.Model;
using SI_Renaming_Tool_V2.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class ReadExcelController
    {
        ExcelModel _excelModel = new ExcelModel();

        public string worksheet = GlobalVarModel.WorksheetName;

        //public ReadExcelController(ExcelModel excelModel)
        //{
        //    _excelModel = excelModel;
        //}

        public void OpenExcel()
        {
            
            var originalFile = Model.UploadModel.MasterFileLocation;
            
            
            //Model.ExcelModel excelModel = new Model.ExcelModel();
            _excelModel.Workbook = new XLWorkbook(originalFile);            
        }

        public string Search(string SINumber)
        {
            string MFNumber = "";
            ExcelModel excelModel = new Model.ExcelModel();
            var workSheet = excelModel.Workbook.Worksheet(worksheet);

            int column = GetColumnNumber(workSheet);

            foreach (var cell in workSheet.CellsUsed())
            {
                if (cell.Value.ToString().StartsWith("SI-" + SINumber))
                {
                    int row = cell.WorksheetRow().RowNumber();
                    MFNumber = workSheet.Cell(row, column).GetString();
                }
            }
            return MFNumber;
        }

        public void GetRange()
        {
            var workSheet = _excelModel.Workbook.Worksheet(worksheet);

            foreach (var cell in workSheet.CellsUsed())
            {
                if (cell.Value.ToString().Contains("Row Labels"))
                {
                    int row = cell.WorksheetRow().RowNumber();
                    int col = cell.WorksheetColumn().ColumnNumber();

                    int lastRow = workSheet.LastRowUsed().RowNumber();


                    //from below the row labels to the bottom
                    int totalCountCellColumn = workSheet
                        .Range(row + 1, col, lastRow, col)
                        .Cells()
                        .Count();

                    string firstVal = workSheet.Cell(row + 1, col).Value.ToString();
                    string lastVal = workSheet.Cell(lastRow, col).Value.ToString();

                    List<int> sortedNumbers = workSheet
                    .Range(row + 1, col, lastRow, col)
                    .CellsUsed()
                    .Select(c => Regex.Replace(c.GetString(), @"\D", ""))
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Select(s => int.TryParse(s, out var n) ? (int?)n : null)
                    .Where(n => n.HasValue)
                    .Select(n => n.Value)
                    .OrderBy(n => n)
                    .ToList();

                    Debug.WriteLine("Minimum FS: " + sortedNumbers[0]);

                    Debug.WriteLine("Maximum FS: " + sortedNumbers[sortedNumbers.Count - 1]);

                    int minFS = sortedNumbers[0];
                    int maxFS = sortedNumbers[sortedNumbers.Count - 1];


                    //AMSDATA from oracle
                    AmsDataController amsDataController = new AmsDataController();
                    List<AmsDataModel> amsData = amsDataController.GetData(minFS, maxFS);

                    ReadPdfController readPdfController = new ReadPdfController();
                    readPdfController.ReadPdf(amsData);






                  
                }

            }

        }

        public void Dispose()
        {
            _excelModel.Workbook.Dispose();
        }

        public string GetBillingPeriod(string remark)
        {
            string date = "";
            var regex = new Regex(
                    @"(?i)(billing period|period)\s+(
                    (([A-Za-z]+\.*\s+\d{1,2},?\s*\d{4})|(\d{1,2}\s+[A-Za-z]+\s+\d{4}))
                    \s*-\s*
                    (([A-Za-z]+\.*\s+\d{1,2},?\s*\d{4})|(\d{1,2}\s+[A-Za-z]+\s+\d{4}))
                    )",
                    RegexOptions.IgnorePatternWhitespace
                );

            foreach (Match match in regex.Matches(remark))
            {
                string keyword = match.Groups[1].Value;
                string dateRange = match.Groups[2].Value;

                Console.WriteLine($"Keyword: {keyword}");
                Console.WriteLine($"Date: {dateRange}");
                Console.WriteLine();

                date = dateRange;
            }

            return date;

        }

        public int GetColumnNumber(IXLWorksheet xLWorksheet)
        {
            int column = 0;
            foreach (var cell in xLWorksheet.CellsUsed())
            {
                if (cell.Value.ToString().Contains("Row Labels"))
                {
                    column = cell.WorksheetColumn().ColumnNumber();
                }
            }
            return column;
        }

        //public Array GetWorkSheets()
        //{
        //    var worksheets = _excelModel.Workbook.Worksheets;
        //    Array worksheetNames = worksheets.Select(ws => ws.Name).ToArray();
        //    return worksheetNames;
        //}
    }
}
