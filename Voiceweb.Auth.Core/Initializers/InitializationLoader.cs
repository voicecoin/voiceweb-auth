using EntityFrameworkCore.BootKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Voiceweb.Auth.Core.Utilities;

namespace Voiceweb.Auth.Core.Initializers
{
    public class InitializationLoader
    {
        public IHostingEnvironment Env { get; set; }
        public IConfiguration Config { get; set; }

        public void Load()
        {
            var appsLoaders = TypeHelper.GetInstanceWithInterface<IHookDbInitializer>("Voiceweb.Auth.Core");
            var dc = new DefaultDataContextLoader().GetDefaultDc();

            appsLoaders.ForEach(loader => {
                dc.DbTran(() => loader.Load(dc));
            });
        }
    }
}
