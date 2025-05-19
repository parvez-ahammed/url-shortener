namespace url_shortener.DTOs
{
    public class UpdateShortUrlRequest
    {
        public required string NewOriginalUrl { get; set; }
    }
}
