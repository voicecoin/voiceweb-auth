using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.BootKit;
using Voiceweb.Auth.Core.DbTables;

namespace Voiceweb.Auth.Core.Initializers
{
    public class RoleDbInitializer : IHookDbInitializer
    {
        public int Priority => 1;

        public void Load(Database dc)
        {
            if (!dc.Table<TRole>().Any())
            {
                dc.Table<TRole>().AddRange(new TRole
                {
                    Id = TRole.ADMIN_ROLE_ID,
                    Name = "Admin User"
                },
                new TRole
                {
                    Id = TRole.AUTH_ROLE_ID,
                    Name = "Authenticated User"
                });
            }
        }
    }
}
