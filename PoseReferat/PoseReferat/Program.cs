using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace PoseReferat
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage();
            var builder = new BodyBuilder();
            builder.HtmlBody = "<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                "<style>" +
                "h1 {background-color:blue; }" +
                "</style>" +
                "</head>" +
                "<body>" +
                "<h1> Test </h1>" +
                "</body>" +
                "</html>";
            builder.Attachments.Add("test.txt");
            message.From.Add(new MailboxAddress("Sender", "posereferatsender@gmail.com"));
            message.Subject = "Email Test";
            message.To.Add(new MailboxAddress("Empfaenger1", "posereferatempfaenger1@gmail.com"));
            message.To.Add(new MailboxAddress("Empfaenger2", "posereferatempfaenger2@gmail.com"));
            message.Body = builder.ToMessageBody();
            var client = new SmtpClient();
            //465 true ssl encryption, 587 false plain text
            client.Connect("smtp.gmail.com", 587, false);
            // email adress + password
            // activate: Zugriff durch weniger sichere Apps
            client.Authenticate("posereferatsender@gmail.com", "Pose1234");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
