using EntityFrameworkCore.BootKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voiceweb.Auth.Core;
using Voiceweb.Auth.Core.DbTables;
using Voiceweb.Auth.RestApi.ViewModels;

namespace Voiceweb.Auth.RestApi
{
    /// <summary>
    /// User account
    /// </summary>
    public class AccountController : CoreController
    {
        /// <summary>
        /// Sign up a new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] VmUserRegister account)
        {
            var existedUser = dc.Table<TbUser>().Any(x => x.Email.ToLower() == account.Email.ToLower() ||
                x.UserName.ToLower() == account.Email.ToLower());

            if (existedUser) return BadRequest("Account already existed");

            var user = new TbUser
            {
                Authenticaiton = new TbUserAuth { Password = account.Password },
                Email = account.Email,
                UserName = account.Email,
                FirstName = account.FullName.Split(' ').First(),
                LastName = account.FullName.Split(' ').Last()
            };

            dc.DbTran(async delegate {
                var userCore = new AccountCore(dc, Database.Configuration);
                await userCore.CreateUser(user);
            });

            return Ok("Register successfully. Please active your account through email.");
        }

        [HttpGet("/account")]
        public Object Account()
        {
            var user = dc.Table<TbUser>().Find(CurrentUserId);

            return new
            {
                user.Id,
                Avatar = "",
                user.Description,
                user.Email,
                user.FirstName,
                user.LastName,
                user.UserName
            };
        }
    }
}
