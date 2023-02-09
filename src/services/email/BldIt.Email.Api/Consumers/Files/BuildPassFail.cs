using BldIt.Email.Contracts.Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BldIt.Email.Api.Consumers.Files;

public class BuildPassFail
{
    private readonly IPublishEndpoint _emailPublishEndpoint;

    public BuildPassFail(IPublishEndpoint emailPublishEndpoint)
    {
        _emailPublishEndpoint = emailPublishEndpoint;
    }
    
    public async Task Consume(ConsumeContext<EmailSend> context)
    {
        var message = context.Message;

        if (message is null) return;

        await SendEmailBuildPassFail(message.userID,message.message, message.sendTo, message.userName);
    }

    static async Task SendEmailBuildPassFail(Guid userId, string message, string sendTo, string userName)
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("eterrazasjaquez@oakland.edu", "Bldit Team"),
            Subject = "Bldit - Build Pass/Fail",
            PlainTextContent = message
        };
        msg.AddTo(new EmailAddress(sendTo, userName));
        var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}