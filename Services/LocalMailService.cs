using System.Net;
using System.Net.Mail;

namespace CityInfoApi.Services
{
    public class LocalMailService
    {
        string _mailTo = "mrtofxn@gmail.com";
        string _mailFrom = "najm@test.com";
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail From {_mailFrom} To {_mailTo}, with {nameof(LocalMailService)} , ");
            Console.WriteLine($"Subejt : {subject}");
            Console.WriteLine($"Message : {message}");
        }
        static void Email(string htmlString, string subject, string to)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("From");
                message.To.Add(new MailAddress(to));
                message.Subject =subject;
                message.IsBodyHtml = true;
                message.Body = htmlString;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("From", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch { }
        }
    }
}
