
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/matches/")]
public class LiveMatchController : Controller
{
    private readonly LiveStreamManager _manager;
    
    public LiveMatchController(LiveStreamManager manager)
    {
        _manager = manager;
    }   
    
    // TODO: Add auth guard for API Keys
    [HttpPost("{matchId}/start-stream")]
    public async Task<IActionResult> StartMatch(string matchId)
    {
        if (await _manager.IsStreamOpened(matchId))
        {
            return Conflict($"Match {matchId} is already being watched.");
        }

        await _manager.StartLiveStream(matchId);
        return Ok($"Started match {matchId}");
    }

    [HttpPost("{matchId}/stop-stream")]
    public async Task<IActionResult> StopStream(string matchId)
    {
        var isActive = await _manager.IsStreamOpened(matchId);
        if (!isActive)
        {
            return NotFound($"Match {matchId} is not being watched.");
        }

        _manager.StopStream(matchId);
        return Ok($"Stopped match {matchId}");
    }

    [HttpGet]
    public IActionResult GetLiveMatches()
    {
        // TODO
        return Ok();
    }
}
