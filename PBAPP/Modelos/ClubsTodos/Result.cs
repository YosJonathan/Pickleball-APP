// <copyright file="Result.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace PBAPP.Modelos.ClubsTodos
{
    public class Result
    {
        public Result()
        {
            this.ClubId = 0;
            this.ClubName = string.Empty;
            this.MediaUrl = string.Empty;
            this.ShortAddress = string.Empty;
            this.ClubMemberCount = 0;
            this.Created = DateTime.MinValue;
            this.Role = new Role();
        }

        [JsonPropertyName("clubId")]
        public long ClubId { get; set; }

        [JsonPropertyName("clubName")]
        public string ClubName { get; set; }

        [JsonPropertyName("mediaUrl")]
        public string MediaUrl { get; set; }

        [JsonPropertyName("shortAddress")]
        public string ShortAddress { get; set; }

        [JsonPropertyName("clubMemberCount")]
        public int ClubMemberCount { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
