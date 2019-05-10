using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataModel
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type Type { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
