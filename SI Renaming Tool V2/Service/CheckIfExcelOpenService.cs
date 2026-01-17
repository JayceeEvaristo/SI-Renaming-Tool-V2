using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Renaming_Tool_V2.Service
{
    public class CheckIfExcelOpenService
    {
        public bool IsFileOpen(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.ReadWrite,
                    FileShare.None))
                {
                    return false; // file is NOT open
                }
            }
            catch (IOException)
            {
                return true; // file IS open
            }
        }

        public bool CheckExcelAvailability(string excelPath)
        {
            if (File.Exists(excelPath) && IsFileOpen(excelPath))
            {
                MessageBox.Show(
                    "The Excel file is currently open.\n\n" +
                    "Please close the file and try again.",
                    "Excel File In Use",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }
    }
}
