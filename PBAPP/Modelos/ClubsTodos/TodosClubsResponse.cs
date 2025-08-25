// <copyright file="TodosClubsResponse.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace PBAPP.Modelos.ClubsTodos
{
    public class TodosClubsResponse
    {
        public TodosClubsResponse()
        {
            this.Status = string.Empty;
            this.Results = new List<Result>();
        }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }
}
