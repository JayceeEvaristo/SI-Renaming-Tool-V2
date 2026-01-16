using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Model
{
    public class FileNameModel
    {
        public string ShortName { get; set; } = string.Empty;
        public string RemarkType { get; set; } = string.Empty;
        public string BillingPeriod { get; set; } = string.Empty;
        public string PrelimFinal { get; set; } = string.Empty;
        public string SINumber { get; set; } = string.Empty;
        public string MFNumber { get; set; } = string.Empty;
    }
}
