namespace GiftSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    using static Data.DataConstants;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Credits { get; set; }
    }
}
