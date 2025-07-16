class Player
{
    private string id;
    private string name;
    private int rating;
    private int matchesPlayed;

    public string Id { get; private set; }
    public string Name { get; set; }
    public int Rating { get; private set; }
    public int MatchesPlayed { get; private set; }

    public Player(string id, string name, int rating)
    {
        this.Id = id;
        this.Name = name;
        this.Rating = rating;
        this.MatchesPlayed = 0;
    }


    public void IncrementMatches()
    {
        MatchesPlayed++;
    }
    public virtual void UpdateRating(int newRating)
    {
        Rating += newRating;
    }

    public virtual string GetPlayerInfo()
    {
        return $"Player: {name}, ID: {id}, Rating: {rating}, Matches: {matchesPlayed}";
    } 

}