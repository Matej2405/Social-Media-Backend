using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facebook_clone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; } = null!;
    }
}