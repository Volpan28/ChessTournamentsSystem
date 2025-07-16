class TournamentManager : ITournamentManager
{
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
        switch (type)
        {
            case TournamentType.RoundRobin:
                return new RoundRobinTournament(id, name);

            case TournamentType.Swiss:
                return new SwissTournament(id, name);

            default:
                throw new ArgumentException("Невідомий тип турніру.");
        }
    }

    public Player CreatePlayerProfile(string id, string name, int rating, PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Player:
                return new Player(id, name, rating);

            case PlayerType.ProPlayer:
                return new ProPlayer(id, name, rating);

            default:
                throw new ArgumentException("Невідомий тип гравця.");
        }
    }


    public void AddPlayerToTournament(string TournamentId, string PlayerId, Player player)
    {
        
    }
    
}