namespace url_shortener.DTOs
{
    public class ShortUrlResponse
    {
        public required string ShortCode { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortUrl { get; set; }
    }
}
