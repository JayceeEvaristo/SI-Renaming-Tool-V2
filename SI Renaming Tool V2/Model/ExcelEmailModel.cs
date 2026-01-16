using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Model
{
    public class ExcelEmailModel
    {
        public XLWorkbook Workbook { get; set; } = new XLWorkbook(EmailingFileNameModel.EmailMasterFileNameLocation);
    }
}
