using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.BootKit;
using Voiceweb.Auth.Core.DbTables;
using Voiceweb.Auth.Core.Utilities;

namespace Voiceweb.Auth.Core.Initializers
{
    public class AccountDbInitializer : IHookDbInitializer
    {
        public int Priority => 10;

        public void Load(Database dc)
        {
            if (!dc.Table<TUser>().Any())
            {
                string salt = PasswordHelper.GetSalt();
                string password = PasswordHelper.Hash("Voicecoin123", salt);

                dc.Table<TUser>().AddRange(new TUser
                {
                    Id = "8da9e1e0-42dc-420a-8016-79b04c1297d0",
                    FirstName = "Voice",
                    LastName = "Bot",
                    Email = "support@voicecoin.com",
                    UserName = "support@voicecoin.com",
                    Authenticaiton = new TUserAuth
                    {
                        IsActivated = true,
                        Salt = salt,
                        Password = password,
                        ActivationCode = Guid.NewGuid().ToString("N")
                    },
                    Roles = new List<TRolesOfUser>
                    {
                        new TRolesOfUser { RoleId = TRole.ADMIN_ROLE_ID }
                    }
                });
            }
        }
    }
}
