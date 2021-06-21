using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Entities.Model
{
    [Table("Studens")]
    public class Studen
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
    }
}
