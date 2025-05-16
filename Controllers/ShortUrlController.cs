using Microsoft.AspNetCore.Mvc;
using url_shortener.DTOs;
using url_shortener.Models;
using url_shortener.Services;

namespace url_shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly ShortUrlService _shortUrlService;

        public ShortUrlController(ShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        // POST api/shorturl
        [HttpPost]
        public ActionResult<ShortUrlDTO> Create([FromBody] CreateShortUrlRequestDTO request)
        {
            if (!Uri.IsWellFormedUriString(request.OriginalUrl, UriKind.Absolute))
                return BadRequest("Invalid URL");

            var data = _shortUrlService.CreateShortUrl(request);

            return Ok(data);
        }

        // GET: api/shorturl
        [HttpGet]
        public ActionResult<IEnumerable<ShortUrl>> GetAll()
        {
            var data = _shortUrlService.GetAll();

            return Ok(data);
        }

        // GET api/shorturl/{shortCode}
        [HttpGet("{shortCode}")]
        public ActionResult RedirectToOriginal(string shortCode)
        {
            var url = _shortUrlService.GetByShortCode(shortCode);

            if (url == null)
                return NotFound("Short URL not found");

            var origianlUrl = url.OriginalUrl;

            return Redirect(origianlUrl);
        }


        [HttpPut("{shortcode}")]
        public IActionResult Update(string shortcode, [FromBody] string newOriginalUrl)
        {
            var updated = _shortUrlService.UpdateOriginalUrl(shortcode, newOriginalUrl);

            if (!updated)
                return NotFound("Short URL not found.");

            return NoContent();
        }

        [HttpDelete("{shortcode}")]
        public IActionResult Delete(string shortcode)
        {
            var deleted = _shortUrlService.DeleteShortUrl(shortcode);

            if (!deleted)
                return NotFound("Short URL not found.");

            return NoContent();
        }

    }
}
