using System.ComponentModel.DataAnnotations;

namespace mailProject._Entities
{
    public class MailDetails
    {
        [Required]
        public int MailId { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
    }
}
