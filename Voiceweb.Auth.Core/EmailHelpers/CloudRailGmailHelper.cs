/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Com.CloudRail.SI;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.ServiceCode.Commands.CodeRedirect;
using Com.CloudRail.SI.Services;
using Microsoft.Extensions.Configuration;

namespace Voiceweb.Auth.Core.EmailHelpers
{
    public class CloudRailGmailHelper : IEmailHelper
    {
        public async Task<string> Send(EmailRequestModel model, IConfiguration config)
        {
            model.From = config.GetSection("Email:From").Value;
            CloudRail.AppKey = config.GetSection("CloudRail:AppKey").Value;
            
            IEmail gmail = new MailJet(
                new LocalReceiver(8082),
                config.GetSection("MailJet:Key").Value,
                config.GetSection("MailJet:Secret").Value
            );

            gmail.SendEmail(
                model.From,
                config.GetSection("Email:Name").Value,
                model.ToAddresses.Split(',').ToList(),
                model.Subject,
                String.Empty,
                model.Body,
                new List<string>(),
                new List<string>(),
                new List<Com.CloudRail.SI.Types.Attachment>()
            );

            return "";
        }
    }
}*/
