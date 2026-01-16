using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Service
{
    public class EncryptPdfService
    {
        public void EncryptPdf(string origFilePath, string renamedFilePath, string shortName, int parsedSI) {
            try
            {
                using (PdfReader reader = new PdfReader(origFilePath))
                {
                    // Optional: skip already encrypted PDFs
                    if (reader.IsEncrypted())
                    {
                        Debug.WriteLine("PDF already encrypted. Skipped.");
                        return;
                    }

                    using (FileStream fs = new FileStream(renamedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        PdfEncryptor.Encrypt(
                            reader,
                            fs,
                            true, // strength128Bits
                            "iemop" + shortName + parsedSI, // user password
                            "Iemop43667",        // owner password
                            PdfWriter.ALLOW_PRINTING // permissions
                        );
                    }
                }

                Debug.WriteLine("✅ PDF encrypted successfully.");
            }
            catch (Exception ex)
            { 
                Debug.WriteLine("❌ Encryption failed:");
                Debug.WriteLine(ex.ToString());
            }

        }
    }
}
