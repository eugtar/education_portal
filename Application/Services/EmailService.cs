using System.Net;
using System.Net.Mail;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var smtpCliet = new SmtpClient(_configuration["Smtp:Server"])
        {
            Port = int.Parse(_configuration["Smtp:Port"]!),
            Credentials = new NetworkCredential(
                _configuration["Smtp:Username"],
                _configuration["Smtp:Password"]
                ),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["Smtp:From"]!),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await smtpCliet.SendMailAsync(mailMessage);
    }
}
