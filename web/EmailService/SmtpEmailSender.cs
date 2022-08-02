using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace web.EmailService
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host { get; set; }
        private int _port { get; set; }
        private bool _enableSsl { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }
        public SmtpEmailSender(string host, int port, bool enableSsl, string username, string password)
        {
            this._host = host;
            this._port = port;
            this._enableSsl = enableSsl;
            this._username = username;
            this._password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(this._host, this._port)
            {
                Credentials = new NetworkCredential(this._username, this._password),
                EnableSsl = this._enableSsl
            };
            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                }
            );
        }
    }
}