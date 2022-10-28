using HomieGainz.ApplicationDb.Db.UserDb;
using Microsoft.Build.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomieGainz.ApplicationDb.Models.Users
{
    public class Friendship
    {
        public int Id { get; set; }

        [Required]
        public virtual User FromUser { get; set; }

        [Required]
        public virtual User ToFriend { get; set; }

        public bool Accepted { get; set; } = false;

    }
}
