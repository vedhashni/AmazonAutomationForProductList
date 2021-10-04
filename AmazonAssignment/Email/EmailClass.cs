using AmazonAssignment.ActionDo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AmazonAssignment.Email
{
    public class EmailClass:Base.BaseClass
    {
        public static ExcelOperation excel;
        public void ToSendReportThroughEmail()
        {
            excel = new ExcelOperation();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\Nunit_FaceBookProject\Nunit_FaceBookProject\DataForTesting\ExcelData.xlsx");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //we are sending our from mail id
            mail.From = new MailAddress(excel.ReadData(1, "FromMail"));
            //we are adding to mail id
            mail.To.Add(excel.ReadData(1, "ToMail"));
            //Subject of the mail is added
            mail.Subject = "Amazon test mail";
            //Body of the mail is added
            mail.Body = "mail with amazon report attachmement";
            Attachment attachment;
            attachment = new Attachment(@"C:\Users\vedhashni.v\source\repos\AmazonAssignment\AmazonAssignment\Report\index.html");
            if (attachment != null)
            {
                //here we attach the report of the automation
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(excel.ReadData(1, "FromMail"), excel.ReadData(1, "EmailPassword"));
                SmtpServer.EnableSsl = true;
                //Here we click send mail 
                SmtpServer.Send(mail);
                Console.WriteLine("Email sended successfully");
            }
            else
            {
                Console.WriteLine("Email Failed to send");
            }
        }
    }
}
