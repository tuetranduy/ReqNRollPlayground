using System;
using Microsoft.Extensions.Configuration;

namespace ReqnRollPlayground.Services;

public class MailService
{
    private IConfiguration _configuration;
    
    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void SendMail(string subject, string body)
    {
        Console.WriteLine($"Sending mail from {_configuration["MailSettings:Mail.From"]} to {_configuration["MailSettings:Mail.To"]} using {_configuration["MailSettings:Mail.Server"]}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body: {body}");
    }
}