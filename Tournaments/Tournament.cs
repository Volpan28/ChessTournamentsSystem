abstract class Tournament
{
    private string id;
    private string name;
    //локальний словник гравців, які беруть участь у конкретному турнірі
    private Dictionary<string, Player> players;
    private List<Match> matches;
    private HashSet<string> playedPairs;
    private Dictionary<string, float> playersPoints;
    private List<List<(string Player1Id, string Player2Id)>> allRounds;
    protected List<(string, string)> nextRoundPairs;

    public string Id { get; private set; }
    public string Name { get; private set; }
    public Dictionary<string, Player> Players => players;
    public List<Match> Matches => matches;
    public HashSet<string> PlayedPairs => playedPairs;
    public Dictionary<string, float> PlayersPoints => playersPoints;
    public List<List<(string Player1Id, string Player2Id)>> AllRounds => allRounds;
    public List<(string, string)> NextRoundPairs => nextRoundPairs;

    public Tournament(string id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.players = new Dictionary<string, Player>();
        this.matches = new List<Match>();
        this.playedPairs = new HashSet<string>();
        this.playersPoints = new Dictionary<string, float>();
        this.allRounds = new List<List<(string Player1Id, string Player2Id)>>();
        this.nextRoundPairs = new List<(string, string)>();
    }

    public void AddPlayer(Player player)
    {
        players.Add(player.Id, player);
        playersPoints[player.Id] = 0;
    }

    public void RecordMatch(string player1Id, string player2Id, MatchResult result)
    {
        if (!players.ContainsKey(player1Id) || !players.ContainsKey(player2Id))
        {
            Console.WriteLine("Error: One or both player IDs not found.");
            return;
        }

        string pairKey = player1Id.CompareTo(player2Id) < 0 
            ? $"{player1Id}-{player2Id}" 
            : $"{player2Id}-{player1Id}";

        PlayedPairs.Add(pairKey);

        Player player1 = players[player1Id];
        Player player2 = players[player2Id];

        bool isPro1 = player1 is ProPlayer;
        bool isPro2 = player2 is ProPlayer;


        Match match = new Match(player1Id, player2Id, result);
        matches.Add(match);

        player1.IncrementMatches();
        player2.IncrementMatches();

        if (result == MatchResult.WinPlayer1)
        {
            player1.UpdateRating(player1.Rating + 10);
            player2.UpdateRating(player1.Rating - 10);

            playersPoints[player1.Id] += 1f;
        }
        else if (result == MatchResult.WinPlayer2)
        {
            player2.UpdateRating(player2.Rating + 10);
            player1.UpdateRating(player1.Rating - 10);

            playersPoints[player2.Id] += 1f;
        }
        else
        {
            player1.UpdateRating(player1.Rating + 1);
            player2.UpdateRating(player1.Rating + 1);

            playersPoints[player1.Id] += 0.5f;
            playersPoints[player1.Id] += 0.5f;
        }
    }

    public virtual string GetTournamentInfo()
    {
        return $"Tournament {Name}, ID: {Id}, Players: {Players}, Matches: {Matches}";
    }

    public abstract List<(string, string)> GeneratePairs();
}