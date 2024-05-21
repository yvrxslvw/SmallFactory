﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("parts")]
    public class Part
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
