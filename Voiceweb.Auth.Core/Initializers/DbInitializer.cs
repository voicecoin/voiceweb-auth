using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voiceweb.Auth.Core.Utilities;

namespace Voiceweb.Auth.Core.Initializers
{
    public class DbInitializer : IInitializationLoader
    {
        public int Priority => 1;

        public void Initialize()
        {
            var dc = new DefaultDataContextLoader().GetDefaultDc();

            var instances = TypeHelper.GetInstanceWithInterface<IHookDbInitializer>(Database.Assemblies).OrderBy(x => x.Priority).ToList();

            for (int idx = 0; idx < instances.Count; idx++)
            {
                DateTime start = DateTime.UtcNow;
                Console.WriteLine($"{instances[idx].ToString()} P:{instances[idx].Priority} started at {DateTime.UtcNow}");
                int effected = dc.DbTran(() => instances[idx].Load(dc));
                Console.WriteLine($"{instances[idx].ToString()} effected [{effected}] records in {(DateTime.UtcNow - start).TotalMilliseconds} ms");
            }
        }
    }
}
