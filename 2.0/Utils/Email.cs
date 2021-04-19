using System;
using System.Text;
using System.Net.Mail;

namespace Pripev.Utils
{
    public static class Email
    {
        /// <summary>
        /// Sends mail to admin (registry key "AdminMail")
        /// </summary>
        /// <param name="subj">Subject</param>
        /// <param name="body">Body</param>
        public static void AdminMail(String subj, String body)
        {
            SendMail(Registry.GetString("AdminMail"), "", Registry.GetString("AdminMail"), "", subj, body, false);
        }

        /// <summary>
        /// Sends mail to admin (registry key "AdminMail")
        /// </summary>
        /// <param name="subj">Subject</param>
        /// <param name="body">Body</param>
        public static void AdminMail(String subj, StringBuilder body)
        {
            AdminMail(subj, body.ToString());
        }

        /// <summary>
        /// Sends mail to error email (registry key "ErrorMail")
        /// </summary>
        /// <param name="subj">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="bHtml">Body is HTML formatted</param>
        public static void ErrorMail(String subj, String body, bool bHtml = true )
        {
            SendMail(Registry.GetString("ErrorMail"), "", Registry.GetString("ErrorMail"), "", subj, body, bHtml);
        }

        /// <summary>
        /// Sends email
        /// </summary>
        /// <param name="from">From address</param>
        /// <param name="fromName">From name</param>
        /// <param name="to">To address</param>
        /// <param name="toName">To name</param>
        /// <param name="subj">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="bHtml">Body is HTML formatted</param>
        public static void SendMail(String from, String fromName, String to, String toName, String subj, String body, bool bHtml)
        {
            if (!Registry.GetBoolean("EnableSMTP")) return;

            try
            {
                //var mail = new SmtpClient { Host = Registry.GetString("Mail/SMTPServer"), UseDefaultCredentials = false, Credentials = new NetworkCredential(Registry.GetString("Mail/SMTPUser"), Registry.GetString("Mail/SMTPPassword")) };
                var mail = new SmtpClient { Host = Registry.GetString("Mail/SMTPServer") };

                //var enc = Encoding.GetEncoding("windows-1251");
                var enc = Encoding.UTF8;

                var mailFrom = new MailAddress(from, fromName, enc);
                var mailTo = new MailAddress(to, toName, enc);
                var msg = new MailMessage(mailFrom, mailTo) {Subject = subj, IsBodyHtml = bHtml, Body = body, HeadersEncoding=enc, SubjectEncoding = enc, BodyEncoding = enc};
                mail.Send(msg);
            }
            catch { }
        }
    }
}
