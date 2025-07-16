class Match
{
    private string player1Id;
    private string player2Id;
    private MatchResult result;

    public string Player1Id { get; private set; }
    public string Player2Id { get; private set; }
    public MatchResult Result { get; private set; }

    public Match(string player1Id, string player2Id, MatchResult result)
    {
        this.Player1Id = player1Id;
        this.Player2Id = player2Id;
        this.Result = result;
    }

    public virtual string GetMatchInfo()
    {
        return $"Match: {Player1Id} vs {Player2Id}, Result: {result}";
    }

}