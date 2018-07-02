using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voiceweb.Auth.RestApi.ViewModels
{
    public class VmUserRegister
    {
        [Required]
        public String FullName { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        /// <summary>
        /// Invitation code
        /// </summary>
        public String InvitationCode { get; set; }
    }
}
