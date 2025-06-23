// <copyright file="SeguidoresUsuarioResponse.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace PBAPP.Modelos.SeguidoresUsuario
{
    public class SeguidoresUsuarioResponse
    {
        public SeguidoresUsuarioResponse()
        {
            this.Result = new FollowResult();
        }

        [JsonPropertyName("result")]
        public FollowResult Result { get; set; }
    }
}
