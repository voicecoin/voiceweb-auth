using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voiceweb.Auth.Core.DbTables
{
    /// <summary>
    /// User profile
    /// </summary>
    [Table("Users")]
    public class TUser : DbRecord, IDbRecord
    {
        [Required]
        [StringLength(64)]
        public String UserName { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [StringLength(32)]
        public String FirstName { get; set; }

        [StringLength(32)]
        public String LastName { get; set; }

        [MaxLength(256)]
        public String Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SignupDate { get; set; }

        [NotMapped]
        public String FullName { get { return $"{FirstName} {LastName}"; } }

        public List<TRolesOfUser> Roles { get; set; }

        public TUserAuth Authenticaiton { get; set; }

        public TUser()
        {
            SignupDate = DateTime.UtcNow;
        }
    }
}
