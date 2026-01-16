using SI_Renaming_Tool_V2.Model;
using SI_Renaming_Tool_V2.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class CopyAndRenameController
    {
        public void CopyAndRenameFile(string sourcefile, string SINumber, AmsDataModel amsData)
        {
            //filename <TP shortname>TS-<WF/RF/WAD>-<BP><P/F>-<INVOICE NO.><MF#/RMF#>.PDF
            ReadRemarksController readRemarksController = new ReadRemarksController();
            EncryptPdfService encryptPdfService = new EncryptPdfService();

            bool isIemms = readRemarksController.IsIemms(amsData.REMARKS);

            string shortName = amsData.SHORT_NAME;
            //string remarkType = "WF";
            string remarkType = readRemarksController.GetRemarkType(amsData.STL_RUN); // to fix
            //string billingPeriod = "01-01-2022 to 31-12-2022";
            int billingPeriod = amsData.BILLING_PERIOD;
            string stlRun = readRemarksController.GetStlRun(amsData.STL_RUN, remarkType, isIemms); // to fix
            string MFNumber = readRemarksController.GetMarketFeeType(isIemms, remarkType, amsData.STL_RUN);// to fix

            string fileName = shortName + "_TS-" + remarkType + "-" + billingPeriod + "" + stlRun + "-" + SINumber + "_" + MFNumber + ".PDF";

            string targetFolder = Model.UploadModel.ServiceInvoiceLocation + "\\Renamed SI\\";
            Directory.CreateDirectory(targetFolder);

            string destinationfile = Path.Combine(targetFolder, fileName);

            Debug.WriteLine(destinationfile);

            int parseToIntSInvoice = int.Parse(SINumber);

            Debug.WriteLine(parseToIntSInvoice);

            encryptPdfService.EncryptPdf(sourcefile, destinationfile, shortName, parseToIntSInvoice);



            //File.Copy(sourcefile, destinationfile, true);

            //SendEmailController sendEmailController = new SendEmailController();
            //sendEmailController.SendEmail(destinationfile);
        }

    }
}
