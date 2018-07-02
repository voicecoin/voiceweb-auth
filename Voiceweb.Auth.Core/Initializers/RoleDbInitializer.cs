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
            if (!dc.Table<TbRole>().Any())
            {
                dc.Table<TbRole>().AddRange(new TbRole
                {
                    Id = TbRole.ADMIN_ROLE_ID,
                    Name = "Admin User"
                },
                new TbRole
                {
                    Id = TbRole.AUTH_ROLE_ID,
                    Name = "Authenticated User"
                });
            }
        }
    }
}
