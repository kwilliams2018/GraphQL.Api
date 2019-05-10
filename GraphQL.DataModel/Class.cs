using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataModel
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type Type { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public string Name { get; set; }
    }
}
