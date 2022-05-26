namespace GiftSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Data.DataConstants;

    public class Transaction
    {
        public int Id { get; init; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Amount { get; init; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string RecipientName { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string SenderName { get; init; }

        [Required]
        public DateTime Date { get; init; }
    }
}
