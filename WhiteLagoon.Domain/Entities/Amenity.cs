using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhiteLagoon.Domain.Entities
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Villa")]
        [Display(Name = "Villa")]

        public int VillaId { get; set; }

        [ValidateNever]
        public Villa Villa { get; set; } = null!;
    }
}
