﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Identity.Models
{
    public class RefreshToken
    {
        public string? UserId { get; set; }

        public string? Token { get; set; }

        public string? JwtId { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }

    }
}