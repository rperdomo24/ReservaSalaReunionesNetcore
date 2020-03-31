using Microsoft.Extensions.Configuration;
using ReservaSalaReuniones.Util.Extension;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ReservaSalaReuniones.Util.Email
{
    public class SendEmail : ISendEmail
    {

        public bool Send(string To, string Body)
        {
            var configuration = new ConfigurationBuilder().FromAppSettings();
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            bool Resultado = false;
            int _ConfigPortSmtp = emailConfig.Port;
            string _ConfigSmtp = emailConfig.SmtpServer;
            string _FromEmail = emailConfig.From;
            string _FromEmailPswd = emailConfig.Password;
            string _CCEmail = emailConfig.UserName;
            string _ToEmail = To;
            string _SubjectEmail = emailConfig.Subject;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_ConfigSmtp);
                mail.From = new MailAddress(_FromEmail);
                mail.To.Add(_ToEmail);
                mail.CC.Add(_CCEmail);
                mail.Subject = _SubjectEmail;
                SmtpServer.Port = _ConfigPortSmtp;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_FromEmail, _FromEmailPswd);
                SmtpServer.EnableSsl = true;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
                Resultado = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return Resultado;
        }
    }
}
