using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voiceweb.Auth.Core.DbTables
{
    /// <summary>
    /// User authentication
    /// </summary>
    [Table("UsersAuths")]
    public class TUserAuth : DbRecord, IDbRecord
    {
        [StringLength(36)]
        public String UserId { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        [StringLength(64)]
        public String Salt { get; set; }

        [StringLength(32)]
        public String ActivationCode { get; set; }

        public Boolean IsActivated { get; set; }

        [ForeignKey("UserId")]
        public TUser User { get; set; }
    }
}
