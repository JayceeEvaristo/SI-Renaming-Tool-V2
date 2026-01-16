using SI_Renaming_Tool_V2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class SearchFromAmsDataUsingSIN
    {
        public void SearchData(List<AmsDataModel> amsData, string MFNumber, string SINumber, string filePath)
        {
            CopyAndRenameController copyAndRenameController = new CopyAndRenameController();
            FileNameModel fileNameModel = new FileNameModel();
            var item = amsData.FirstOrDefault(x => x.INVOICE_NO == MFNumber);

            if (item != null)
            {
                copyAndRenameController.CopyAndRenameFile(filePath, SINumber, item);
                
            }
        }
    }
}
