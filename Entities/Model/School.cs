using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    [Table("school")]
    public class School
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
