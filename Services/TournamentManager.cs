using System.Data.Common;

class TournamentManager : ITournamentManager
{
    private Dictionary<string, Tournament> tournaments = new();

    //глобальний словник усіх створених гравців.
    private Dictionary<string, Player> players = new();

    public enum TournamentType
    {
        RoundRobin = 1,
        Swiss = 2
    }

    public enum PlayerType
    {
        Player = 1,
        ProPlayer = 2
    }

    public Tournament CreateTournament(string id, string name, TournamentType type)
    {
        Tournament tournament;

        switch (type)
        {
            case TournamentType.RoundRobin:
                tournament = new RoundRobinTournament(id, name);
                break;

            case TournamentType.Swiss:
                tournament = new SwissTournament(id, name);
                break;

            default:
                throw new ArgumentException("Невідомий тип турніру.");
        }

        tournaments.Add(id, tournament);
        return tournament;
    }

    public Player CreatePlayerProfile(string id, string name, int rating, PlayerType type)
    {
        Player player;
        switch (type)
        {
            case PlayerType.Player:
                player = new Player(id, name, rating);
                break;

            case PlayerType.ProPlayer:
                player = new ProPlayer(id, name, rating);
                break;

            default:
                throw new ArgumentException("Невідомий тип гравця.");

        }
        players.Add(id, player);
        return player;
    }


    public void AddPlayerToTournament(string TournamentId, string PlayerId)
    {
        /*out означає, що метод змінить/поверне значення цієї змінної.
        var — компілятор сам виведе правильний тип. */

        if (tournaments.TryGetValue(TournamentId, out var tournament) &&
            players.TryGetValue(PlayerId, out var player))
        {
            tournament.AddPlayer(player);
        }
        else
        {
            Console.WriteLine("Турнір або гравець не знайдені.");
        }
    }

    public void RecordMatchResult(string TournamentId, string player1Id, string player2Id, MatchResult result)
    {
        if (!tournaments.ContainsKey(TournamentId))
        {
            Console.WriteLine("Не вдалось зробити запис матчу. Матчу з таким ID не існує.");
        }
        else if (!players.ContainsKey(player1Id) || !players.ContainsKey(player2Id))
        {
            Console.WriteLine("Один або обидва гравці не знайдені.");
        }
        else
        {
            tournaments[TournamentId].RecordMatch(player1Id, player2Id, result);
        }
    }

    public void GenerateNextRound(string tournamentId)
    {
        if (tournaments.TryGetValue(tournamentId, out var tournament))
        {
            tournament.GeneratePairs();

            tournament = tournaments[tournamentId];

            foreach (var (p1,p2) in tournament.NextRoundPairs)
            {
                Console.WriteLine($"{p1} проти {p2}");
            }
        }
        else
        {
            Console.WriteLine("Не вдалось зенерувати пари. Турніру з таким ID не існує.");
        }
    }
}