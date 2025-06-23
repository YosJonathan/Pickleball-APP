// <copyright file="FollowResult.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace PBAPP.Modelos.SeguidoresUsuario
{
    public class FollowResult
    {
        public FollowResult()
        {
            this.Followers = 0;
            this.Followings = 0;
        }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("followings")]
        public int Followings { get; set; }
    }
}
