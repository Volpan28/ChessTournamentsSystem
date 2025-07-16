
class SwissTournament : Tournament
{
    public SwissTournament(string id, string name) : base(id, name) { }

    public override HashSet<string> GeneratePairs()
    {
        HashSet<string> newPair = new HashSet<string>();
        HashSet<string> playersThatPlayed = new HashSet<string>();

        var playersList = Players.Values.OrderByDescending
            (p => PlayersPoints[p.Id]).ToList();

        for (int i = 0; i < playersList.Count() - 1; i++)
        {
            for (int j = i + 1; j < playersList.Count(); j++)
            {
                var player1 = playersList[i];
                var player2 = playersList[j];

                if (PlayersPoints[player1.Id] == PlayersPoints[player2.Id])
                {
                    string pairKey = string.Compare(player1.Id, player2.Id) < 0
                    ? $"{player1.Id}-{player2.Id}"
                    : $"{player2.Id}-{player1.Id}";

                    if (!PlayedPairs.Contains(pairKey))
                    {
                        newPair.Add(pairKey);

                        playersThatPlayed.Add(player1.Id);
                        playersThatPlayed.Add(player2.Id);
                    }
                }
            }
        }

        var playerNoPair = Players.Values.Where
            (player => !playersThatPlayed.Contains(player.Id)).FirstOrDefault();

        if (playerNoPair != null)
        {
            PlayersPoints[playerNoPair.Id] += 0.5f;
        }

        return newPair;
    }

    public override string GetTournamentInfo()
    {
        return $"Swiss Tournament {Name}, ID: {Id}, Players: {Players}";
    }
}