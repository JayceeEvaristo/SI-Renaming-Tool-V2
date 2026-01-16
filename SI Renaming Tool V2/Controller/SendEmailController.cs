using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace SI_Renaming_Tool_V2.Controller
{
    public class SendEmailController
    {
        public void SendEmail(string filePath, string email)
        {
            try
            {
                var message = "Dear Sir/Madam:        \r\n       \r\nIn compliance with BIR Revenue Regulations No. 011-2025, we would like to inform you that the attached Market Fee (MF) for the billing month of December 2025 serves as the official electronic invoice for the Market Fee transaction for the said period.\r\n\r\nPlease note that the attached files are password-protected. The password format is “iemopBILLINGID”.\r\n     \r\nFor concerns regarding your Preliminary, Final, Additional Compensation and Adjustment Allocations and data, please email us at billing@iemop.ph or call us thru (02) 53189376 local 230 and 255.    \r\n   \r\nFor Margin Call and Collection and Payment concerns, please email finance.amu@iemop.ph or call (02) 53189376 local 272.  \r\n   \r\nAs we strive to provide efficient, competitive, and transparent electricity and ancillary markets, we acknowledge the invaluable support of our participants and stakeholders who have joined us in contributing to the objectives of the electricity market. In pursuit of these objectives, may we request a few minutes of your time to answer our short survey in the link below.\r\n\r\nhttps://bit.ly/ITS-Participant-Support\r\n\r\nThank you and regards,  \r\nIEMOP Billing Team";

                var outlookApp = new Outlook.Application();
                var mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = "jc.evaristo@iemop.ph";
                mailItem.Subject = "Service Invoice";
                mailItem.Body = message;
                mailItem.Attachments.Add(filePath);
                mailItem.Send();

                /*var mail = new MailMessage();
                mail.From = new MailAddress("billing@iemop.ph");
                mail.To.Add("jc.evaristo@iemop.ph");
                mail.Subject = "Service Invoice Renaming Tool";
                mail.Body = $"Please find the attached file. {email}";
                mail.Attachments.Add(new Attachment(filePath));

                var smtpClient = new SmtpClient("10.180.100.6", 25)
                {
                    Credentials = new NetworkCredential(
                            "billing@iemop.ph",
                            "Iemop1234!"
                        ),
                    EnableSsl = false,
                };

                smtpClient.Send(mail);*/
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
