using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Dynamic.Core;
using EntityFrameworkCore.BootKit;
using Voiceweb.Auth.Core.DbTables;
using Voiceweb.Auth.Core.JwtHelper;
using Voiceweb.Auth.Core.Utilities;
using Voicebot.Auth.RestApi.ViewModels;

namespace Voiceweb.Auth.RestApi
{
    /// <summary>
    /// User authentication
    /// </summary>
    public class AuthenticationController : CoreController
    {
        /// <summary>
        /// Get user token
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/token")]
        [ProducesResponseType(typeof(String), 200)]
        public IActionResult Token([FromBody] VmUserLogin userModel)
        {
            if (String.IsNullOrEmpty(userModel.UserName) || String.IsNullOrEmpty(userModel.Password))
            {
                return new BadRequestObjectResult("Username and password should not be empty.");
            }

            // validate from local
            var user = (from usr in dc.Table<TbUser>()
                        join auth in dc.Table<TbUserAuth>() on usr.Id equals auth.UserId
                        where usr.Email == userModel.UserName
                        select auth).FirstOrDefault();

            if (user != null)
            {
                if (!user.IsActivated)
                {
                    return BadRequest("Account hasn't been activated, please check your email to activate it.");
                }
                else
                {
                    // validate password
                    string hash = PasswordHelper.Hash(userModel.Password, user.Salt);
                    if (user.Password == hash)
                    {
                        return Ok(JwtToken.GenerateToken(Database.Configuration, user.UserId));
                    }
                    else
                    {
                        return BadRequest("Authorization Failed.");
                    }
                }
            }
            else
            {
                return BadRequest("Account doesn't exist");
            }
        }
    }
}
