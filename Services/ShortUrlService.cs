using Microsoft.AspNetCore.Mvc;
using url_shortener.DTOs;
using url_shortener.Models;
using url_shortener.Repositories;

namespace url_shortener.Services
{
    public class ShortUrlService
    {
        private readonly IShortUrlRepository _repository;
        private readonly string _domain = "http://localhost:5069/api/ShortUrl";
        public ShortUrlService(IShortUrlRepository repository)
        {
            _repository = repository;
        }

        public ShortUrlResponse CreateShortUrl([FromBody] CreateShortUrlRequest request)
        {
            var shortCode = Guid.NewGuid().ToString("N")[..6];
            var shortUrl = new ShortUrl
            {
                ShortCode = shortCode,
                OriginalUrl = request.OriginalUrl
            };

            var newShortUrl = _repository.Create(shortUrl);

            var data = new ShortUrlResponse
            {
                OriginalUrl = newShortUrl.OriginalUrl,
                ShortCode = newShortUrl.ShortCode,
                ShortUrl = $"{_domain}/{shortUrl.ShortCode}"
            };

            return data;
        }

        public ShortUrl? GetByShortCode(string shortCode)
        {
            var shortUrl = _repository.GetByShortCode(shortCode);
            return shortUrl;
        }

        public IEnumerable<ShortUrl> GetAll()
        {
            var shortUrls = _repository.GetAll();
            return shortUrls;
        }

        public bool UpdateOriginalUrl(string shortCode, string newOriginalUrl)
        {
            var updated = _repository.Update(shortCode, newOriginalUrl);
            return updated;
        }

        public bool DeleteShortUrl(string shortCode)
        {
            var deleted = _repository.Delete(shortCode);
            return deleted;
        }
    }
}
