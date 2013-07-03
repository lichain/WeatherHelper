using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace WeatherAPIServices.MailService
{
    public abstract class MailBase
    {
        public const string USER_NAME = "##USERNAME##";
        public const string DATA = "##DATA##";
        public const string BOOTSTRAPCSS = "##BOOTSTRAPCSS##";

        protected string MailType { get; set; }
        public string MailAddress { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        private SMTP SmtpConfig;

        public virtual void Initialize()
        {
            try
            {
                MailType = "General";
                SmtpConfig = new SMTP();

                SmtpConfig.Host = ConfigurationManager.AppSettings["SMTPHost"];
                SmtpConfig.Account = ConfigurationManager.AppSettings["SMTPAccount"];
                SmtpConfig.Password = ConfigurationManager.AppSettings["SMTPPassword"];
                SmtpConfig.AdminName = ConfigurationManager.AppSettings["SMTPAdminName"];
                SmtpConfig.AdminMail = ConfigurationManager.AppSettings["SMTPAdminMail"];
            }
            catch(Exception ex){
                throw ex;
            }
        }

        public virtual void Execute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MailAddress))
                    throw new ArgumentNullException("MailAddress");

                if (SmtpConfig == null)
                    throw new ArgumentNullException("SmtpConfig");

                // Mail Message Setting
                MailAddress from = new MailAddress(SmtpConfig.AdminMail, SmtpConfig.AdminName, Encoding.UTF8);
                MailMessage mail = new MailMessage(from, new MailAddress(MailAddress));
                mail.Subject = MailSubject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Body = MailBody;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                // SMTP Setting
                SmtpClient client = new SmtpClient();
                client.Host = SmtpConfig.Host;
                client.Port = 587;
                client.Credentials = new NetworkCredential(SmtpConfig.Account, SmtpConfig.Password);
                client.EnableSsl = true;

                // Send Mail
                //client.SendAsync(mail, mail);
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
