using MailKit.Net.Smtp;
using MimeKit;
using BussinessLogic.Models;

namespace BussinessLogic.MailService
{
    public class SendMailService
    {
        public SendMailService() { }
        public bool SendMail(EmailData _emailData)
        {
            try
            {
                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; line-height: 1.6;'>
            <h2>Mã xác minh của bạn</h2>
            <p style='font-size: 16px; color: #333;'>
                Mã xác minh của bạn là <br><strong>{_emailData.Body}</strong>.<br>
                Vui lòng không cung cấp mã này cho bất kỳ ai.
            </p>
        </div>";
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_emailData.From));
                email.To.Add(MailboxAddress.Parse(_emailData.To));
                email.Subject = _emailData.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailData.From, _emailData.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
