using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Identity.ServicesLibrary
{
    public class SendEmailService
    {
        #region 发送方信息
        private static readonly string smtpServer = "smtp.163.com"; //SMTP服务器
        private static readonly string mailFrom = "m18146611430@163.com"; //登陆用户名
        private static readonly string userPassword = "li3963li2072";//登陆密码
        private static readonly int port = 25; //设置邮箱端口，pop3端口:110, smtp端口是:25
        #endregion

        private MailAddress _from;
        private string _username;
        private string _password;
        private string _host;
        private int _port;

        private readonly MailAddressCollection _toAddressCollection;
        private readonly string _subject;
        private readonly string _body;

        public SendEmailService(string to, string subject, string body)
        {
            _toAddressCollection = new MailAddressCollection() { new MailAddress(to) };
            _subject = subject;
            _body = body;
            Init();
        }

        public SendEmailService(MailAddressCollection toAddressCollection, string subject, string body)
        {
            _subject = subject;
            _body = body;
            _toAddressCollection = toAddressCollection;
            Init();
        }

        private void Init()
        {
            _username = mailFrom;
            _password = userPassword;
            _port = port;
            _host = smtpServer;
            _from = new MailAddress(mailFrom);
        }

        public void SendEmail()
        {
            var client = new SmtpClient
            {
                Port = _port,
                Host = _host,
                EnableSsl = true,
                Timeout = 100000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_username, _password)
            };

            var message = new MailMessage()
            {
                Subject = _subject,
                Body = _body,
                IsBodyHtml = true,
                From = _from,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            foreach (var to in _toAddressCollection)
            {
                message.To.Add(new MailAddress(to.Address));
            }

            client.Send(message);
        }

    }
}
