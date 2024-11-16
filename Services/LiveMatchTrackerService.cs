
using StackExchange.Redis;

/**
 * This service is responsible for tracking live matches and their status.
 * It uses Redis as a key-value store to keep track of active matches.
 */
public class LiveMatchTrackerService
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _redis;
    public LiveMatchTrackerService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task<bool> IsStreamActiveAsync(string matchId)
    {
        return await _database.KeyExistsAsync(GetStreamKey(matchId));
    }

    public async Task StartLiveGameAsync(string matchId)
    {
        await _database.StringSetAsync(GetStreamKey(matchId), "active", TimeSpan.FromHours(1));
    }

    public async Task StopMatchAsync(string matchId)
    {
        await _database.KeyDeleteAsync(GetStreamKey(matchId));
    }
    
    public async Task<IEnumerable<string>> GetAllActiveStreamsAsync()
    {
        var db = _redis.GetDatabase();
        var server = _redis.GetServer(_redis.GetEndPoints().First());

        // Query all keys matching active matches
        var keys = server.Keys(pattern: "match:*").Select(k => k.ToString());
        return keys.Select(k => k.Replace("match:", ""));
    }

    private static string GetStreamKey(string matchId) => $"match:{matchId}";
}
