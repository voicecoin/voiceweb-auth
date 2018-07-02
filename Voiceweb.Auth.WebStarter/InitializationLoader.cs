using EntityFrameworkCore.BootKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voiceweb.Auth.Core.Initializers;
using Voiceweb.Auth.Core.Utilities;

namespace Voiceweb.Auth.WebStarter
{
    public class InitializationLoader
    {
        public IHostingEnvironment Env { get; set; }
        public IConfiguration Config { get; set; }

        public void Load()
        {
            var appsLoaders = TypeHelper.GetInstanceWithInterface<IHookDbInitializer>("Voiceweb.Auth.Core");
            var dc = new DefaultDataContextLoader().GetDefaultDc();

            appsLoaders.OrderBy(x => x.Priority)
                .ToList()
                .ForEach(loader =>
                {
                    dc.DbTran(() => loader.Load(dc));
                });
        }
    }
}
