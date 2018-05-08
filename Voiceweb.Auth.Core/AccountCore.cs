using EntityFrameworkCore.BootKit;
using Microsoft.Extensions.Configuration;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Voiceweb.Auth.Core.DbTables;
using Voiceweb.Auth.Core.EmailHelpers;
using Voiceweb.Auth.Core.Utilities;

namespace Voiceweb.Auth.Core
{
    public class AccountCore
    {
        private Database dc;
        private IConfiguration config;
        private static RazorLightEngine engine;

        public AccountCore(Database db, IConfiguration config)
        {
            dc = db;
            this.config = config;
        }

        public async Task CreateUser(TUser user)
        {
            user.Authenticaiton.Salt = PasswordHelper.GetSalt();
            user.Authenticaiton.Password = PasswordHelper.Hash(user.Authenticaiton.Password, user.Authenticaiton.Salt);
            user.Authenticaiton.ActivationCode = Guid.NewGuid().ToString("N");

            dc.Table<TUser>().Add(user);

            dc.Table<TRolesOfUser>().Add(new TRolesOfUser
            {
                RoleId = TRole.AUTH_ROLE_ID,
                UserId = user.Id
            });

            dc.SaveChanges();

            EmailRequestModel model = new EmailRequestModel();

            model.Subject = config.GetSection("UserActivationEmail:Subject").Value;
            model.ToAddresses = user.Email;
            model.Template = config.GetSection("UserActivationEmail:Template").Value;

            if (!String.IsNullOrEmpty(model.Template))
            {
                if (engine == null)
                {
                    engine = new RazorLightEngineBuilder()
                      .UseFilesystemProject(Database.ContentRootPath + $"{Path.DirectorySeparatorChar}App_Data")
                      .UseMemoryCachingProvider()
                      .Build();
                }

                var cacheResult = engine.TemplateCache.RetrieveTemplate(model.Template);

                var emailModel = new { Host = config.GetSection("ClientHost").Value, ActivationCode = user.Authenticaiton.ActivationCode };

                if (cacheResult.Success)
                {
                    model.Body = await engine.RenderTemplateAsync(cacheResult.Template.TemplatePageFactory(), emailModel);
                }
                else
                {
                    model.Body = await engine.CompileRenderAsync(model.Template, emailModel);
                }
            }

            var ses = new CloudRailGmailHelper();
            string emailId = await ses.Send(model, config);

            $"Created user {user.Email}, user id: {user.Id}, sent email: {emailId}.".Log(LogLevel.INFO);
        }
    }
}
