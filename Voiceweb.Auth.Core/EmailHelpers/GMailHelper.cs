using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.BootKit;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;

namespace Voiceweb.Auth.Core.EmailHelpers
{
    public class GMailHelper : IEmailHelper
    {
        public async Task<string> Send(EmailRequestModel model, IConfiguration config)
        {
            model.From = config.GetSection("Email:From").Value;

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredential.GetApplicationDefault(),
                ApplicationName = "Voiceweb Auth",
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // List labels.
            IList<Label> labels = request.Execute().Labels;
            Console.WriteLine("Labels:");
            if (labels != null && labels.Count > 0)
            {
                foreach (var labelItem in labels)
                {
                    Console.WriteLine("{0}", labelItem.Name);
                }
            }
            else
            {
                Console.WriteLine("No labels found.");
            }

            var response = service.Users.Messages.Send(new Message {
                Payload = new MessagePart {
                    Body = new MessagePartBody {Data = "adfadf" }
                }
            }, model.From);

            return "";
        }

        private UserCredential GetCredential(EmailRequestModel model)
        {
            UserCredential credential;
            string secret = Path.Combine(Database.ContentRootPath, "Settings/google_secret.json");

            using (var stream =
                new FileStream(secret, FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.Combine(Database.ContentRootPath, "Settings/google_credential.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { GmailService.Scope.GmailSend },
                    model.From,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }
    }
}
