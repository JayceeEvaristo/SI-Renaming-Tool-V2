using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Model
{
    public class AmsDataModel
    {
        public int INVOICE_CODE { get; set; }
        public string INVOICE_NO { get; set; } = string.Empty;
        public int BILLING_PERIOD { get; set; }
        public string STL_RUN { get; set; } = string.Empty;
        public string REMARKS { get; set; } = string.Empty;
        public string SHORT_NAME { get; set; } = string.Empty;
    }
}
