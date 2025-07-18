class RoundRobinTournament : Tournament
{
    public RoundRobinTournament(string id, string name) : base(id, name) { }
    public override List<(string, string)> GeneratePairs()
    {
        List<(string, string)> unplayedPairs = new List<(string, string)>();

        var playersList = Players.Values.ToList();

        for (int i = 0; i < playersList.Count() - 1; i++)
        {
            for (int j = i + 1; j < playersList.Count(); j++)
            {
                var player1 = playersList[i];
                var player2 = playersList[j];

                string pairKey = string.Compare(player1.Id, player2.Id) < 0
                    ? $"{player1.Id}-{player2.Id}"
                    : $"{player2.Id}-{player1.Id}";

                if (!PlayedPairs.Contains(pairKey))
                {
                    unplayedPairs.Add((player1.Id, player2.Id));
                }
            }
        }
        nextRoundPairs = unplayedPairs;

        return unplayedPairs;
    }

    public override string GetTournamentInfo()
    {
        return $"Round Robin Tournament {Name}, ID: {Id}, Players: {Players}";
    }
}