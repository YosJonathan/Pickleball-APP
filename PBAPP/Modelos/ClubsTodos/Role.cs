// <copyright file="Role.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace PBAPP.Modelos.ClubsTodos
{
    public class Role
    {
        public Role()
        {
            this.RoleId = 0;
            this.RoleName = string.Empty;
        }

        [JsonPropertyName("roleId")]
        public long RoleId { get; set; }

        [JsonPropertyName("role")]
        public string RoleName { get; set; }
    }
}
