using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Model
{
    public static class GlobalVarModel
    {
        public static string WorksheetName { get; set; }
        public static string TempMasterFileLoc { get; set; }
        public static bool isTesting { get; set; } = true;
    }
}
