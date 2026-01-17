using ClosedXML.Excel;
using SI_Renaming_Tool_V2.Model;
using SI_Renaming_Tool_V2.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class ReadExcelEmailController
    {
        ExcelEmailModel _excelModel = new ExcelEmailModel();

        public void OpenExcel()
        {
            try
            {
                _excelModel.Workbook = new XLWorkbook(Model.EmailingFileNameModel.EmailMasterFileNameLocation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error opening Excel file: " + ex.Message);
                throw;
            }
            
        }

        public Dictionary<string, List<EmailListModel>> GetEmailList()
        {
            var emailGroups = new Dictionary<string, List<EmailListModel>>(StringComparer.OrdinalIgnoreCase)
                {
                    { "ENERGY", new List<EmailListModel>() },
                    { "RESERVE", new List<EmailListModel>() }
                };

            foreach (var sheet in _excelModel.Workbook.Worksheets)
            {
                string sheetName = sheet.Name.ToUpper();

                string groupKey = null;

                if (sheetName.Contains("ENERGY"))
                    groupKey = "ENERGY";
                else if (sheetName.Contains("RESERVE"))
                    groupKey = "RESERVE";
                else
                    continue; // ignore other sheets

                foreach (var cell in sheet.CellsUsed())
                {
                    string value = cell.GetString().Trim();

                    if (!value.Contains("@") || !value.Contains(".") || value.Contains(" "))
                        continue;

                    int emailColumn = cell.WorksheetColumn().ColumnNumber();
                    var shortNameCell = sheet.Cell(cell.WorksheetRow().RowNumber(), emailColumn - 1);

                    var email = new EmailListModel
                    {
                        ShortName = shortNameCell.GetString(),
                        Email = value
                    };

                    // ✅ Allow duplicates
                    emailGroups[groupKey].Add(email);
                }
            }

            return emailGroups;
        }

    }
}
