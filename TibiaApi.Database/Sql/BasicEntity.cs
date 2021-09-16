using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TibiaApi.Database.Sql
{
    public abstract class BasicEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }        
    }
}
