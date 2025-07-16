interface ITournamentManager
{
    public Tournament CreateTournament(string id, string name, string type);
    public Player CreatePlayerProfile(string id, string name, int rating, int matchesPlayed);
    public void AddPlayerToTournament(string TournamentId, Player player);
    public void RecordMatchResult(string TournamentId, string player1Id, string player2Id, MatchResult result);
    public void GenerateNextRound(string tournamentId);
    public string SearchPlayers(string tournamentId, string keyword);
    public string GetTopPlayers(string tournamentId, int n);
    public void SaveTournamentToFile(string tournamentId, string filePath);
    public string LoadTournamentFromFile(string filePath);
}