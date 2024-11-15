
using StackExchange.Redis;

public class LiveMatchTrackerService
{
    private readonly IDatabase _database;

    public LiveMatchTrackerService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public async Task<bool> IsMatchActiveAsync(string matchId)
    {
        return await _database.KeyExistsAsync(GetMatchKey(matchId));
    }

    public async Task StartMatchAsync(string matchId)
    {
        await _database.StringSetAsync(GetMatchKey(matchId), "active", TimeSpan.FromHours(1));
    }

    public async Task StopMatchAsync(string matchId)
    {
        await _database.KeyDeleteAsync(GetMatchKey(matchId));
    }

    private static string GetMatchKey(string matchId) => $"match:{matchId}";
}
