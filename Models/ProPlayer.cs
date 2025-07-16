class ProPlayer : Player
{
    private int ratingBonus;

    public int RatingBonus { get; private set; }

    public ProPlayer(string id, string name, int rating) : base(id, name, rating)
    {
        this.RatingBonus = 15;
    }

    public override string GetPlayerInfo()
    {
        return $"Player: {Name}, ID: {Id}, Rating: {Rating + RatingBonus}, Matches: {MatchesPlayed}";
    }

    public override void UpdateRating(int newRating)
    {
        base.UpdateRating(newRating + ratingBonus);
    }
}