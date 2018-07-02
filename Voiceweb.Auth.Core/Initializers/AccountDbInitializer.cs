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
            if (!dc.Table<TbUser>().Any(x => x.UserName == "support@voicecoin.com"))
            {
                string salt = PasswordHelper.GetSalt();
                string password = PasswordHelper.Hash("Voicecoin123", salt);

                dc.Table<TbUser>().AddRange(new TbUser
                {
                    Id = "8da9e1e0-42dc-420a-8016-79b04c1297d0",
                    FirstName = "Voice",
                    LastName = "Bot",
                    Email = "support@voicecoin.com",
                    UserName = "support@voicecoin.com",
                    Authenticaiton = new TbUserAuth
                    {
                        IsActivated = true,
                        Salt = salt,
                        Password = password,
                        ActivationCode = Guid.NewGuid().ToString("N")
                    },
                    Roles = new List<TbRolesOfUser>
                    {
                        new TbRolesOfUser { RoleId = TbRole.ADMIN_ROLE_ID }
                    }
                });
            }

            if (!dc.Table<TbUser>().Any(x => x.UserName == "developer@voicecoin.com"))
            {
                string salt = PasswordHelper.GetSalt();
                string password = PasswordHelper.Hash("Voicebot611", salt);

                dc.Table<TbUser>().AddRange(new TbUser
                {
                    Id = "2914ec4c-bf4e-4b7f-a27c-8b2067f173c3",
                    FirstName = "Developer",
                    LastName = "Voicebot",
                    Email = "developer@voicecoin.com",
                    UserName = "developer@voicecoin.com",
                    Authenticaiton = new TbUserAuth
                    {
                        IsActivated = true,
                        Salt = salt,
                        Password = password,
                        ActivationCode = Guid.NewGuid().ToString("N")
                    },
                    Roles = new List<TbRolesOfUser>
                    {
                        new TbRolesOfUser { RoleId = TbRole.AUTH_ROLE_ID }
                    }
                });
            }
        }
    }
}
