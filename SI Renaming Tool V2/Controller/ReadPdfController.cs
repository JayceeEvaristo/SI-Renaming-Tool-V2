using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using ClosedXML.Excel;
using SI_Renaming_Tool_V2.Model;
using System.IO;
using System.Windows.Forms;

namespace SI_Renaming_Tool_V2.Controller
{
    public class ReadPdfController
    {
        public void ReadPdf(List<AmsDataModel> amsData)
        {
            ReadExcelController readExcelController = new ReadExcelController();
            CopyAndRenameController copyAndRenameController = new CopyAndRenameController();
            FileNameModel fileNameModel = new FileNameModel();

            Regex pattern = new Regex(
                    @"S\.I\.\s*Number(\d+)",
                    RegexOptions.IgnoreCase
                );

            foreach (var ServiceInvoice in Directory.EnumerateFiles(Model.UploadModel.ServiceInvoiceLocation))
            {
                string filePath = Path.GetFullPath(ServiceInvoice);
                if (!IsValidPdf(filePath)) continue;

                try
                {
                    var document = PdfDocument.Open(ServiceInvoice);
                    foreach (var page in document.GetPages())
                    {
                        try
                        {
                            var match = pattern.Match(page.Text);
                            if (match.Success)
                            {
                                string number = match.Groups[1].Value;
                                Debug.WriteLine(number);
                                string MFNumber = readExcelController.Search(number);
                                Debug.WriteLine("MF Number: " + MFNumber);

                                SearchFromAmsDataUsingSIN searchFromAmsDataUsingSIN = new SearchFromAmsDataUsingSIN();
                                searchFromAmsDataUsingSIN.SearchData(amsData, MFNumber, number, filePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }


                //Debug.WriteLine(filePath);
                //Debug.WriteLine(fileNameModel.SINumber);
                //Debug.WriteLine(fileNameModel.ShortName);
                //Debug.WriteLine(fileNameModel.MFNumber + "\n");

                //copyAndRenameController.CopyAndRenameFile(filePath, fileNameModel);   
            }

            readExcelController.Dispose();
        }

        public static bool IsValidPdf(string filePath)
        {
            // 1️⃣ File must exist
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return false;

            // 2️⃣ Extension must be .pdf
            if (!Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                return false;

            // 3️⃣ File must be large enough
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length < 5)
                return false;

            // 4️⃣ Check PDF header
            try
            {
                var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[5];
                fs.Read(buffer, 0, 5);

                string header = Encoding.ASCII.GetString(buffer);
                return header == "%PDF-";
            }
            catch
            {
                return false;
            }
        }

        public static List<string> SliceFilename(string input)
        {
            var matches = Regex.Matches(
                input,
                @"[A-Z]{2,3}-[A-Z]{2}|[A-Za-z0-9]+"
            );

            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }
    }
}
