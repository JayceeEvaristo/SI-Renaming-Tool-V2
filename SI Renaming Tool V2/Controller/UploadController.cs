using SI_Renaming_Tool_V2.Model;
using SI_Renaming_Tool_V2.Service;
using SI_Renaming_Tool_V2_V2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Renaming_Tool_V2.Controller
{
    public class UploadController
    {
        private Form1 _form1;
        private string masterFileLocation = "";
        private string serviceInvoiceLocation = "";

        private string emailMasterFileLocation = "";
        private string emailRenamedServiceInvoiceLocation = "";

        public UploadController(Form1 form1)
        {
            _form1 = form1;
        }

        #region RenameFunctions
        public void UploadLocate(bool isMasterFile)
        {
            if (isMasterFile)
            {
                UploadMasterFile();
            }
            else
            {
                LocateServiceInvoice();
            }
        }

        public void UploadMasterFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            CheckIfExcelOpenService checkIfExcelOpenService = new CheckIfExcelOpenService();
            openFileDialog.Filter =  "Excel Files|*.xlsx;*.xls;*.xlsm";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (!checkIfExcelOpenService.CheckExcelAvailability(filePath))
                {
                    return;
                }
                else
                {
                    Debug.WriteLine("Selected file path: " + filePath);
                    Model.UploadModel.MasterFileLocation = filePath;
                    masterFileLocation = filePath;
                    CanStartModel.hasMfile = true;
                    _form1.EnableButton();
                    _form1.SetLabelLocationText(filePath, true);
                }

               
            }
        }

        public void LocateServiceInvoice()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";
                folderDialog.ShowNewFolderButton = false;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;

                    Debug.WriteLine("Selected folder path: " + folderPath);
                    Model.UploadModel.ServiceInvoiceLocation = folderPath;
                    serviceInvoiceLocation = folderPath;
                    CanStartModel.hasSinv = true;
                    _form1.EnableButton();
                    _form1.SetLabelLocationText(folderPath, false);
                }
            }
        }
        #endregion

        #region EmailFunctions
        public void EmailUploadLocate(bool isMasterFile)
        {
            if (isMasterFile)
            {
                UploadEmailMasterFile();
            }
            else
            {
                LocateRenamedServiceInvoice();
            }
        }

        public void UploadEmailMasterFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            CheckIfExcelOpenService checkIfExcelOpenService = new CheckIfExcelOpenService();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if(!checkIfExcelOpenService.CheckExcelAvailability(filePath))
                {
                    return;
                }
                else
                {
                    Debug.WriteLine("Selected file path: " + filePath);
                    Model.EmailingFileNameModel.EmailMasterFileNameLocation = filePath;
                    emailMasterFileLocation = filePath;
                    CanStartModel.hasEmailMfile = true;
                    _form1.EmailEnableButton();
                    _form1.EmailingSetLabelLocationText(filePath, true);
                }
            }
        }

        public void LocateRenamedServiceInvoice()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";
                folderDialog.ShowNewFolderButton = false;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;

                    Debug.WriteLine("Selected folder path: " + folderPath);
                    Model.EmailingFileNameModel.EmailRenamedServiceInvoiceLocation = folderPath;
                    emailRenamedServiceInvoiceLocation = folderPath;
                    CanStartModel.hasRenamedSinv = true;
                    _form1.EmailEnableButton();
                    _form1.EmailingSetLabelLocationText(folderPath, false);
                }
            }
        }
        #endregion
    }
}
