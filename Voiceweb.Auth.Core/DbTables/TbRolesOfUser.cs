using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voiceweb.Auth.Core.DbTables
{
    /// <summary>
    /// Roles of user
    /// </summary>
    [Table("Auth_RolesOfUsers")]
    public class TbRolesOfUser : DbRecord, IAuthDbRecord
    {
        [StringLength(36)]
        public String UserId { get; set; }

        public TbUser User { get; set; }

        [StringLength(36)]
        public String RoleId { get; set; }

        public TbRole Role { get; set; }
    }
}
