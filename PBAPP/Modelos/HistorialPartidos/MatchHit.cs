using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchHit
    {
        public MatchHit()
        {
            this.Id = 0;
            this.MatchId = 0;
            this.UserId = 0;
            this.DisplayIdentity = string.Empty;
            this.Venue = string.Empty;
            this.Location = string.Empty;
            this.MatchScoreAdded = false;
            this.Tournament = string.Empty;
            this.League = string.Empty;
            this.EventDate = string.Empty;
            this.EventFormat = string.Empty;
            this.ScoreFormat = new ScoreFormat();
            this.Confirmed = false;
            this.Teams = new List<MatchTeam>();
            this.Created = DateTime.MinValue;
            this.Modified = DateTime.MinValue;
            this.EventName = string.Empty;
            this.MatchSource = string.Empty;
            this.ClubId = 0;
            this.LeagueId = 0;
            this.BracketId = 0;
            this.LeagueMatchId = 0;
            this.NoOfGames = 0;
            this.Status = string.Empty;
            this.MatchType = string.Empty;
            this.EloCalculated = false;
            this.Initialization = false;
            this.Validator = new MatchUser();
            this.Creator = new MatchUser();
            this.ClientId = 0;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("matchId")]
        public long MatchId { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("displayIdentity")]
        public string DisplayIdentity { get; set; }

        [JsonPropertyName("venue")]
        public string Venue { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("matchScoreAdded")]
        public bool MatchScoreAdded { get; set; }

        [JsonPropertyName("tournament")]
        public string Tournament { get; set; }

        [JsonPropertyName("league")]
        public string League { get; set; }

        [JsonPropertyName("eventDate")]
        public string EventDate { get; set; }

        [JsonPropertyName("eventFormat")]
        public string EventFormat { get; set; }

        [JsonPropertyName("scoreFormat")]
        public ScoreFormat ScoreFormat { get; set; }

        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }

        [JsonPropertyName("teams")]
        public List<MatchTeam> Teams { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        [JsonPropertyName("matchSource")]
        public string MatchSource { get; set; }

        [JsonPropertyName("clubId")]
        public long ClubId { get; set; }

        [JsonPropertyName("leagueId")]
        public long LeagueId { get; set; }

        [JsonPropertyName("bracketId")]
        public long BracketId { get; set; }

        [JsonPropertyName("leagueMatchId")]
        public long LeagueMatchId { get; set; }

        [JsonPropertyName("noOfGames")]
        public int NoOfGames { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("matchType")]
        public string MatchType { get; set; }

        [JsonPropertyName("eloCalculated")]
        public bool EloCalculated { get; set; }

        [JsonPropertyName("initialization")]
        public bool Initialization { get; set; }

        [JsonPropertyName("validator")]
        public MatchUser Validator { get; set; }

        [JsonPropertyName("creator")]
        public MatchUser Creator { get; set; }

        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
    }
}
