using Cafe.EmailSender;
using Cafe.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

public class MailKitEmailSender : IEmailSender
{


    public MailKitEmailSender(IOptions<MailKitEmailSenderOptions> options)
    {
        this.Options = options.Value;

    }

    public MailKitEmailSenderOptions Options { get; set; }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        string responce=Execute(email, subject, message).Result;
        Console.WriteLine(responce);
        return Task.FromResult(true);
    }

    public Task<string> Execute(string to, string subject, string message)
    {
        string responce="";
        // create message
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(Options.Sender_EMail);
        if (!string.IsNullOrEmpty(Options.Sender_Name))
            email.Sender.Name = Options.Sender_Name;
        email.From.Add(email.Sender);
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = message };

        // send email
        using (var smtp = new SmtpClient())
        {
            try
            {
                smtp.Connect(Options.Host_Address, Options.Host_Port, Options.Host_SecureSocketOptions);
            }
            catch (SmtpCommandException ex)
            {
                responce = "Error trying to connect:" + ex.Message + " StatusCode: " + ex.StatusCode;
               return Task.FromResult(responce);
            }
            catch (SmtpProtocolException ex)
            {
                responce = "Protocol error while trying to connect:" + ex.Message;
                return Task.FromResult(responce);
            }

            // Note: Not all SMTP servers support authentication, but GMail does.
            if (smtp.Capabilities.HasFlag(SmtpCapabilities.Authentication))
            {
                try
                {
                    smtp.Authenticate(Options.Host_Username, Options.Host_Password);
                }
                catch (AuthenticationException ex)
                {
                    responce = "Invalid user name or password. "+ex.Message;
                    return Task.FromResult(responce);
                }
                catch (SmtpCommandException ex)
                {
                    responce = "Error trying to authenticate:" + ex.Message + " StatusCode: " + ex.StatusCode;
                    return Task.FromResult(responce);
                }
                catch (SmtpProtocolException ex)
                {
                    responce = "Protocol error while trying to authenticate:" + ex.Message;
                    return Task.FromResult(responce);
                }
            }

            try
            {
                smtp.Send(email);
            }
            catch (SmtpCommandException ex)
            {
                responce = "Error sending message: " + ex.Message + " StatusCode: " + ex.StatusCode;

                switch (ex.ErrorCode)
                {
                    case SmtpErrorCode.RecipientNotAccepted:
                        responce +=" Recipient not accepted: "+ex.Mailbox;
                        break;
                    case SmtpErrorCode.SenderNotAccepted:
                        responce += " Sender not accepted: " + ex.Mailbox;
                        Console.WriteLine("\tSender not accepted: {0}", ex.Mailbox);
                        break;
                    case SmtpErrorCode.MessageNotAccepted:
                        responce += " Message not accepted.";
                        break;
                }
            }
            catch (SmtpProtocolException ex)
            {
                responce="Protocol error while sending message:"+ ex.Message;
            }
            smtp.Disconnect(true);
        }
        if(responce == "") responce= "success";

        return Task.FromResult(responce);
    }
}