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
    [Table("RolesOfUsers")]
    public class TRolesOfUser : DbRecord, IDbRecord
    {
        [StringLength(36)]
        public String UserId { get; set; }

        public TUser User { get; set; }

        [StringLength(36)]
        public String RoleId { get; set; }

        public TRole Role { get; set; }
    }
}
