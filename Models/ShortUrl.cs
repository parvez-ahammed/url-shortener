
using System.ComponentModel.DataAnnotations;

namespace url_shortener.Models
{
    public class ShortUrl
    {
        [Key]
        public Guid ShortUrlId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(10)]
        public required string ShortCode { get; set; }

        [Required]
        [Url]
        public required string OriginalUrl { get; set; }


    }
}
