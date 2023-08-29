using StockQuote.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StockQuote.Services
{
    public class MailSenderService
    {
        private string _from;
        private string _to;
        private int _smtpPort;
        private string _smtpHost;
        private string _smtpPassword;

        public MailSenderService(string from, string to, int smtpPort, string smtpHost, string smtpPassword)
        {
            bool isFromMailValid = MailValidator.IsValid(from);
            if (!isFromMailValid)
            {
                throw new ConfigurationException("O email que está configurado para enviar a mensagem não é valido.");
            };

            bool isToMailValid = MailValidator.IsValid(to);
            if (!isToMailValid)
            {
                throw new ConfigurationException("O email que está configurado para receber a mensagem não é valido.");
            };

            _from = from;
            _to = to;
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpPassword = smtpPassword;
        }

        public void SendMail(string subject, string body)
        {
            using var mailMessage = new MailMessage(_from, _to, subject, body);
            using (var smtpClient = new SmtpClient(_smtpHost, _smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_from, _smtpPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 15000;

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine($"E-mail para {_to} enviado com sucesso");
                }
                catch (Exception e)
                {
                    throw new Exception($"Erro ao enviar email: {e.Message}");
                }
            }

        }

    }
}
