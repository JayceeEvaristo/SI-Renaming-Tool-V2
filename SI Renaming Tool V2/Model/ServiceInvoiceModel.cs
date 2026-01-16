using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Model
{
    public class ServiceInvoiceModel
    {
        public string ServiceInvoiceNumber { get; set; } = string.Empty;
        public string LongName { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
    }
}
