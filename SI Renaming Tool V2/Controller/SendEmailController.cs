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

            ////needs email and the recipient, subject and body content
            //var outlookApp = new Outlook.Application();

            //var mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
            //mailItem.To = "jc.evaristo@iemop.ph"; // Replace with the recipient's email address
            //mailItem.Subject = "Service Invoice Renaming Tool"; // Replace with the email subject line
            //mailItem.Body = "Please find the attached file."; // Replace with the email body content
            //mailItem.Attachments.Add(filePath); // Replace with the path to the file you want to attach

            //mailItem.Send();

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("billing@iemop.ph");
                mail.To.Add("jc.evaristo@iemop.ph");
                mail.Subject = "Service Invoice Renaming Tool";
                mail.Body = "Please find the attached file. " + email;
                mail.Attachments.Add(new Attachment(filePath));

                var smtpClient = new SmtpClient("10.180.100.6", 25)
                {
                    Credentials = new NetworkCredential(
                            "billing@iemop.ph",
                            "Iemop1234!"
                        ),
                    EnableSsl = false,
                };

                smtpClient.Send(mail);
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
