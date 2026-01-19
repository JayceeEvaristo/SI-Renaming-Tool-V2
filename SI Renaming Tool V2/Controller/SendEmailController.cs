using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace SI_Renaming_Tool_V2.Controller
{
    public class SendEmailController
    {
        public void SendEmail(string filePath, string email, string shortName)
        {
            byte[] zipBytes = File.ReadAllBytes(filePath);
            try
            {
                var fileName = Path.GetFileName(filePath);
                var stream = new MemoryStream(zipBytes);
                var attachment = new Attachment(stream, fileName, "application/zip");

                var message = "Dear Sir/Madam:        \r\n       \r\nIn compliance with BIR Revenue Regulations No. 011-2025, we would like to inform you that the attached Market Fee (MF) for the billing month of December 2025 serves as the official electronic invoice for the Market Fee transaction for the said period.\r\n\r\nPlease note that the attached files are password-protected. The password format is “iemopBILLINGID”.\r\n     \r\nFor concerns regarding your Preliminary, Final, Additional Compensation and Adjustment Allocations and data, please email us at billing@iemop.ph or call us thru (02) 53189376 local 230 and 255.    \r\n   \r\nFor Margin Call and Collection and Payment concerns, please email finance.amu@iemop.ph or call (02) 53189376 local 272.  \r\n   \r\nAs we strive to provide efficient, competitive, and transparent electricity and ancillary markets, we acknowledge the invaluable support of our participants and stakeholders who have joined us in contributing to the objectives of the electricity market. In pursuit of these objectives, may we request a few minutes of your time to answer our short survey in the link below.\r\n\r\nhttps://bit.ly/ITS-Participant-Support\r\n\r\nThank you and regards,  \r\nIEMOP Billing Team";

                //20260116
                var date = DateTime.Now.ToString("yyyyMMdd");

                var outlookApp = new Outlook.Application();
                var mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                Outlook.Account senderAccount = null;

                foreach (Outlook.Account account in outlookApp.Session.Accounts)
                {
                    if (account.SmtpAddress.ToLower().Contains("billing@iemop.ph"))
                    {
                        senderAccount = account;
                        break;
                    }
                }

                if (senderAccount == null)
                {
                    MessageBox.Show("billing@iemop.ph account not found.");
                    return;
                }
                else
                {
                    mailItem.SendUsingAccount = senderAccount;

                    mailItem.To = email;
                    //mailItem.CC = "evaristojc3@gmail.com";
                    //mailItem.Bcc = "jc.evaristo@iemop.ph";
                    mailItem.CC = "edmin.arellano@iemop.ph";
                    mailItem.Bcc = "billing@iemop.ph";
                    mailItem.Bcc = "billing_division@iemop.ph";
                    mailItem.Subject = date + "_" + shortName + "_Market Fee Statements for the month of December 2025";
                    mailItem.Body = message;
                    mailItem.Attachments.Add(filePath);
                    mailItem.Send();

                    //Thread.Sleep(2000);
                    //File.Delete(filePath);

                }

                
                //var mail = new MailMessage();
                //mail.From = new MailAddress("billing@iemop.ph");
                //mail.To.Add(email);

                //mail.Subject = date + "_" + shortName + "_Market Fee Statements for the month of December 2025";
                //mail.Body = message;

                //mail.CC.Add("edmin.arellano@iemop.ph");
                //mail.Bcc.Add("billing@iemop.ph");
                //mail.Bcc.Add("billing_division@iemop.ph");

                //this is for testing
                //mail.CC.Add("evaristojc3@gmail.com");
                //mail.Bcc.Add("jc.evaristo@iemop.ph");

                //mail.Attachments.Add(attachment);

                //var smtpClient = new SmtpClient("10.180.100.6", 25)
                //{
                //    Credentials = new NetworkCredential(
                //            "billing@iemop.ph",
                //            "Iemop1234!"
                //        ),
                //    EnableSsl = false,
                //};

                //smtpClient.Send(mail);
            }
            catch (SmtpException ex)
            {
                Debug.WriteLine("❌ SMTP Exception:");
                Debug.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Debug.WriteLine("🔍 Inner Exception:");
                    Debug.WriteLine(ex.InnerException.Message);
                }

                throw;
            }


        }
    }
}
