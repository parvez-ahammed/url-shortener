namespace url_shortener.Models
{
    public class ShortUrl
    {

        public Guid ShortUrlId { get; set; } = Guid.NewGuid();

        public required string ShortCode { get; set; }


        public required string OriginalUrl { get; set; }


    }
}
