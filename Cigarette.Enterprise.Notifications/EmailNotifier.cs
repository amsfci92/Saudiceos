using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;  
using System.Net.Mail; 

namespace Cigarette.Enterprise.Notifications
{
    public class EmailNotifier
    {
        private string _stmpServer { get; set; }
        private string _mailId { get; set; }
        private string _password { get; set; }
        private int _port { get; set; }

        public EmailNotifier(string stmpServer, string mailId, string password, int port = 587)
        {
            _stmpServer = stmpServer;
            _mailId = mailId;
            _password = password;
            _port = port;
        }
        public bool Send(EmailData emailData)
        { 
            MailMessage message = new MailMessage(emailData.From, emailData.From);

            string mailbody = emailData.Body;
            message.Subject = emailData.Subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(_stmpServer, _port);     
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(_mailId, _password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                return false;
            }

            return true;
        } 
    }

    public class EmailData
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
