using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobileapp.Models
{
    public class Mobile
    {
        [Key] public int Id { get; set; }
        [Required]
        public string? Name { get; set; }     
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }      
        public int IdCategory {  get; set; }
        public Category? Category { get; set; }
    }
}
