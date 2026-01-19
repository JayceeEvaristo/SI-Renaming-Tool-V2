using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Service
{
    public class ZipPdfFilesService
    {
        public string ZipPdfFiles(IEnumerable<string> pdfFiles, string shortName)
        {
            string destinationFolder =
            Model.EmailingFileNameModel.EmailRenamedServiceInvoiceLocation;

            string zipFileName = shortName + "_Service Invoice.zip";
            string zipFilePath = Path.Combine(destinationFolder, zipFileName);

            // ✅ Ensure the DIRECTORY exists (NOT the zip file)
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // ✅ Delete existing zip if present
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }

            // ✅ Create zip properly
            using (ZipArchive zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (string file in pdfFiles)
                {
                    string fullPath = Path.Combine(destinationFolder, file);

                    //Debug.WriteLine(fullPath);
                    if (string.IsNullOrWhiteSpace(fullPath))
                        continue;

                    if (!File.Exists(fullPath))
                        continue;

                    zip.CreateEntryFromFile(
                        fullPath,                      // ✅ use FULL PATH
                        Path.GetFileName(fullPath),    // name inside zip
                        CompressionLevel.Optimal
                    );
                }

                zip.Dispose();
            }
            return zipFilePath;
        }
    }
}
