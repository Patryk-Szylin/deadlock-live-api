
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/matches/")]
public class LiveMatchController : Controller
{
    private readonly DeadlockService _deadlockService;
    private readonly LiveMatchTrackerService _matchTrackerService;
    private readonly LiveMatchEventStreamerService _eventStreamer;
    
    // Constructor to inject the DeadlockService
    public LiveMatchController(DeadlockService deadlockService, LiveMatchTrackerService matchTrackerService, LiveMatchEventStreamerService eventStreamer)
    {
        _deadlockService = deadlockService;
        _matchTrackerService = matchTrackerService;
        _eventStreamer = eventStreamer;
    }   
    
    // TODO: Add auth guard for API Keys
    /**
     * Initiates the process of hooking up to a live game and receive events
     */
    [HttpPost("{matchId}/watch")]
    public async Task<IActionResult> WatchLiveGame([FromRoute] string matchId)
    {
        if (await _matchTrackerService.IsMatchActiveAsync(matchId))
        {
            return Conflict("Match is already being watched.");
        }

        // Should be executed in callback function when we initiate the streaming process. Streaming task should allow for callback.
        await _matchTrackerService.StartMatchAsync(matchId);
        return Ok($"Started watching match {matchId}.");
    }
    
    [HttpPost("{matchId}/stop")]
    public async Task<IActionResult> StopMatch(string matchId)
    {
        if (!await _matchTrackerService.IsMatchActiveAsync(matchId))
        {
            return NotFound("Match is not currently being watched.");
        }

        // Should be executed in callback function for stream connection closed when we initiate the streaming process. Streaming task should allow for callback.
        await _matchTrackerService.StopMatchAsync(matchId);
        return Ok($"Stopped watching match {matchId}.");
    }
    
    [HttpPost("{matchId}/stream")]
    public async Task<IActionResult> StreamMatch(string matchId, CancellationToken cancellationToken)
    {
        await _eventStreamer.StreamEventsAsync(matchId, cancellationToken);
        return Ok($"Streaming events for match {matchId}");
    }

    [HttpGet]
    public IActionResult GetLiveMatches()
    {
        // TODO
        return Ok();
    }
}
