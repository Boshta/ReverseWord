using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversedWord.Service;

namespace ReverseWord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReverseController : ControllerBase
    {
        private readonly IReversedSentenceService _reversedSentenceService;

        public ReverseController(IReversedSentenceService reversedSentenceService)
        {
            _reversedSentenceService = reversedSentenceService;
        }

        [HttpPost]
        public async Task<ActionResult> ReverseSentence([FromBody] string request)
        {
            try
            {
                if (string.IsNullOrEmpty(request))
                {
                    return BadRequest();
                }

                var reversedSentence = await _reversedSentenceService.GetRversedSentence(request);

                return Ok(reversedSentence);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
