namespace url_shortener.DTOs
{
    public class CreateShortUrlRequest
    {
        public required string OriginalUrl { get; set; }
    }
}
