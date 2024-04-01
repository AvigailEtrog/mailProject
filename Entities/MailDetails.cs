using System.ComponentModel.DataAnnotations;

namespace mailProject._Entities
{
    public class MailDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
    }
}
