using Microsoft.AspNetCore.Mvc;
using SportScore.API.Data;
using SportScore.API.Models;
using SportScore.API.Models.Dtos;
using SportScore.API.Repositories;
using SportsScorePredictor;

namespace SportScore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly IHistoricalScoresRepository _historicalScoresRepository;

        public SportController(IHistoricalScoresRepository historicalScoresRepository)
        {
            _historicalScoresRepository = historicalScoresRepository;
        }

        [HttpPost(Name = "addhistoricalscores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HistoricalScore>> CheckScoreAndSaveResult([FromBody] SportsDto sportsDto)
        {
            //var sportsDto = new VolleyballDto(nameOfTeam1, nameOfTeam2, scores, n);
            var item = await _historicalScoresRepository.CheckScoreAndSaveResultAsync(sportsDto);

            if (item == null)
                return BadRequest();                

            return Ok(item);
        }

        [HttpGet("{guid}", Name = "retrievehistoricalscores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HistoricalScore>> RetrieveHistoricalScores(Guid id)
        {
            var item = await _historicalScoresRepository.RetrieveHistoricalScoresAsync(id);

            if(item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpDelete("{guid}", Name = "deletehistoricalscores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteHistoricalScoresAsync(Guid id)
        {
            if(id == Guid.Empty)
                return BadRequest();

            return Ok(await _historicalScoresRepository.DeleteHistoricalScoresAsync(id));
        }
    }
}