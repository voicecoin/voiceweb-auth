using EntityFrameworkCore.BootKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voiceweb.Auth.Core.DbTables
{
    [Table("Roles")]
    public class TRole : DbRecord, IDbRecord
    {
        public const String ADMIN_ROLE_ID = "214f29aa-40e5-4bf1-a74a-f202309f981d";
        public const String AUTH_ROLE_ID = "148b79c1-1feb-4f70-af40-3278d1963234";

        [Required]
        [StringLength(36)]
        public String Name { get; set; }

        [MaxLength(128)]
        public String Description { get; set; }
    }
}
