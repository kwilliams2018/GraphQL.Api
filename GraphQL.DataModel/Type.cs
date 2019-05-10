using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataModel
{
    [Table("Type")]
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
