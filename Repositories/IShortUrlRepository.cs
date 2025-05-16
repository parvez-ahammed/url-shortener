using url_shortener.Models;

namespace url_shortener.Repositories
{
    public interface IShortUrlRepository
    {
        ShortUrl Create(ShortUrl url);
        ShortUrl? GetByShortCode(string shortCode);
        IEnumerable<ShortUrl> GetAll();
        bool Update(string shortCode, string newOriginalUrl);
        bool Delete(string shortCode);
    }
}
