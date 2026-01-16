using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using SI_Renaming_Tool_V2;
using SI_Renaming_Tool_V2.Controller;
using SI_Renaming_Tool_V2.Model;
using SI_Renaming_Tool_V2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Renaming_Tool_V2_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GlobalVarModel.isTesting = true;
            cb_test.Checked = GlobalVarModel.isTesting;
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            var loadingForm = new frm_loading();
            loadingForm.Show();
            loadingForm.Refresh();
            //ReadPdfController readPdfController = new ReadPdfController();



            //readExcelController.OpenExcel();
            //readPdfController.ReadPdf();
            await Task.Run(() =>
            {
                ReadExcelController readExcelController = new ReadExcelController();
                readExcelController.OpenExcel();
                readExcelController.GetRange();
            });

            loadingForm.Close();

            MessageBox.Show("Process Completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //AmsDataController amsDataController = new AmsDataController();
            //amsDataController.GetData();
        }

        private void btn_select_loc_mf_Click(object sender, EventArgs e)
        {
            UploadController _uploadController = new UploadController(this);
            _uploadController.UploadLocate(true);


        }

        private void btn_select_location_si_Click(object sender, EventArgs e)
        {
            UploadController _uploadController = new UploadController(this);
            _uploadController.UploadLocate(false);
        }

        public void SetLabelLocationText(string text, bool isMasterFile)
        {
            if (isMasterFile)
            {
                lbl_masfile_loc.Text = text;
                cb_worksheet.Enabled = true;

                cb_worksheet.Items.Clear();

                XLWorkbook workbook = new XLWorkbook(text);

                Array worksheet = workbook.Worksheets.Select(ws => ws.Name).ToArray();
                foreach (var item in worksheet)
                {
                    cb_worksheet.Items.Add(item);
                }
                //cb_worksheet.Items = readExcelController.GetWorkSheets;
            }
            else
            {
                lbl_ser_inv_loc.Text = text;
            }
        }

        public void EmailingSetLabelLocationText(string text, bool isMasterFile)
        {
            if (isMasterFile)
            {
                lbl_email_masfile_loc.Text = text;
            }
            else
            {
                lbl_renamed_si_loc.Text = text;
            }
        }

        public void EnableButton()
        {
            if (CanStartModel.hasSinv && CanStartModel.hasMfile && CanStartModel.hasSelectWorksheet)
            {
                btn_start.Enabled = true;
            }
            else
            {
                btn_start.Enabled = false;
            }
        }

        public void EmailEnableButton()
        {
            if (CanStartModel.hasEmailMfile && CanStartModel.hasRenamedSinv)
            {
                btn_start_emailing.Enabled = true;
            }
            else
            {
                btn_start_emailing.Enabled = false;
            }
        }

        public bool CheckConnection()
        {
            bool isConnected = false;
            string connString = DBConfig.GetConnectionString();
            try
            {
                var con = new OracleConnection(connString);
                con.Open();

                con.Close();
                isConnected = true;
            }
            catch (Exception ex)
            {
                isConnected = false;
                MessageBox.Show("Failed to connect to database. Please check your connection settings.\n\n" + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isConnected;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var isConnected = CheckConnection();
            if (!isConnected)
            {
                btn_start.Enabled = false;
                btn_select_loc_mf.Enabled = false;
                btn_select_location_si.Enabled = false;

                Form1 form1 = this;
                form1.Close();
            }
        }

        private void cb_worksheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVarModel.WorksheetName = cb_worksheet.SelectedItem.ToString();
            CanStartModel.hasSelectWorksheet = true;
            EnableButton();
        }

        private void btn_email_masfile_Click(object sender, EventArgs e)
        {
            UploadController uploadController = new UploadController(this);
            uploadController.EmailUploadLocate(true);
        }

        private void btn_renamed_SI_Click(object sender, EventArgs e)
        {
            UploadController uploadController = new UploadController(this);
            uploadController.EmailUploadLocate(false);
        }

        private async void btn_start_emailing_Click(object sender, EventArgs e)
        {
            if (!GlobalVarModel.isTesting)
            {
                DialogResult result = MessageBox.Show("" +
                    "By selecting OK, you certify that all participant email addresses have been thoroughly reviewed, validated, and are correct.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {   
                    Confirmed();
                }

            }
            else
            {
                Confirmed();
            }
            


        }

        public string GetTsType(string fileName)
        {
            var match = Regex.Match(
                fileName,
                @"[A-Z]{2}-[A-Z]{2}"
                );
            return match.Success ? match.Value : null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVarModel.isTesting = !GlobalVarModel.isTesting;

            Debug.WriteLine("isTesting: " + GlobalVarModel.isTesting);
        }

        public async void Confirmed()
        {
            var loadingForm = new frm_loading();
            loadingForm.Show();

            ZipPdfFilesService zipPdfFilesService = new ZipPdfFilesService();
            SendEmailController sendEmailController = new SendEmailController();
            TestToExcelController TesToExcelController = new TestToExcelController();

            Dictionary<string, List<EmailListModel>> emailLists = null;
            ReadExcelEmailController ReadExcelEmailController = new ReadExcelEmailController();
            ReadExcelEmailController.OpenExcel();
            emailLists = ReadExcelEmailController.GetEmailList();

            var energyEmails = emailLists["ENERGY"];
            var reserveEmails = emailLists["RESERVE"];

            List<string> fileArray = new List<string>();

            List<LogEmailModel> logEmailTestList = new List<LogEmailModel>();

            string fileFolder = EmailingFileNameModel.EmailRenamedServiceInvoiceLocation;

            await Task.Run(() =>
            {
                foreach (var SInvoice in Directory.EnumerateFiles(fileFolder))
                {
                    fileArray.Add(Path.GetFileName(SInvoice));
                    /*
                    string fileName = Path.GetFileName(SInvoice);
                    string filePath = Path.GetFullPath(SInvoice);

                    var parts = ReadPdfController.SliceFilename(fileName);

                    string shortName = null;
                    string reserveType = null;

                    foreach (var part in parts)
                    {
                        // 🔹 ShortName: letters + numbers, no dash
                        if (shortName == null &&
                            Regex.IsMatch(part, @"^[A-Z0-9]{3,}$"))
                        {
                            shortName = part;
                        }

                        // 🔹 Reserve / Energy type (TS-WF, TS-RF, etc.)
                        if (reserveType == null &&
                            Regex.IsMatch(part, @"^[A-Z]{2,3}-[A-Z]{2}$"))
                        {
                            reserveType = part;
                        }

                        Debug.WriteLine($"ShortName   : {shortName}");
                        Debug.WriteLine($"ReserveType: {reserveType}");
                        Debug.WriteLine("--------------------------------");
                    } */
                }

                string[] shortNames = fileArray
                    .Select(f => f.Split('_')[0])
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray();

                foreach (var shortName in shortNames)
                {
                    string[] matchedFiles = fileArray
                        .Where(f => f.StartsWith(shortName + "_", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (matchedFiles.Length == 0)
                        continue; // nothing to process

                    string tsType = GetTsType(Path.GetFileName(matchedFiles[0]));

                    var zipPath = zipPdfFilesService.ZipPdfFiles(matchedFiles, shortName);

                    var emailList = tsType == "TS-RF" ? reserveEmails : energyEmails;

                    var emailEntries = emailList
                    .Where(entry =>
                        string.Equals(entry.ShortName, shortName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                    Debug.WriteLine("Processing ShortName: " + shortName + "        ReserveType: " + tsType);
                    Debug.WriteLine("   ZipFile Location: " + zipPath);

                    foreach (var emailEntry in emailEntries)
                    {
                        Debug.WriteLine($"          Sending to: {emailEntry.Email}");

                        if (GlobalVarModel.isTesting)
                        {
                            logEmailTestList.Add(new LogEmailModel
                            {
                                ShortName = shortName,
                                Email = emailEntry.Email,
                                ZipPath = zipPath
                            });
                        }
                        else
                        {
                            sendEmailController.SendEmail(zipPath, emailEntry.Email);
                            Task.Delay(1000).Wait();
                        }
                    }

                    File.Delete(zipPath);

                    Task.Delay(2500).Wait();
                }
                if (GlobalVarModel.isTesting)
                {
                    TesToExcelController.TestExcel(logEmailTestList, fileFolder);
                }
            });

            loadingForm.Close();

        }
    }
}
