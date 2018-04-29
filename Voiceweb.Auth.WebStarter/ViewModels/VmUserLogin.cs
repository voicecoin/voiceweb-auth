using System;
using System.Collections.Generic;
using System.Text;

namespace Voicebot.RestApi.ViewModels
{
    /// <summary>
    /// User login view model
    /// </summary>
    public class VmUserLogin
    {
        /// <summary>
        /// User identity, email or phone
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public String Password { get; set; }
    }
}
