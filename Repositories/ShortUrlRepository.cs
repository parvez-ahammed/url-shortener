using url_shortener.Models;

namespace url_shortener.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly List<ShortUrl> _urls = new();

        public ShortUrl Create(ShortUrl url)
        {
            _urls.Add(url);
            return url;
        }

        public ShortUrl? GetByShortCode(string shortCode)
        {
            var shortUrl = _urls.FirstOrDefault(x => x.ShortCode == shortCode);
            return shortUrl;
        }

        public IEnumerable<ShortUrl> GetAll()
        {
            return _urls;
        }

        public bool Update(string shortCode, string newOriginalUrl)
        {
            var url = _urls.FirstOrDefault(x => x.ShortCode == shortCode);
            if (url == null)
                return false;

            url.OriginalUrl = newOriginalUrl;
            return true;
        }

        public bool Delete(string shortCode)
        {
            var url = _urls.FirstOrDefault(x => x.ShortCode == shortCode);
            if (url == null)
                return false;

            _urls.Remove(url);
            return true;
        }
    }
}
