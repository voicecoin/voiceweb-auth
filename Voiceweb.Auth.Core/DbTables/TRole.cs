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
        [Required]
        [StringLength(36)]
        public String Name { get; set; }

        [MaxLength(128)]
        public String Description { get; set; }
    }
}
