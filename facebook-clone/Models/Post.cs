using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facebook_clone.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = "";  
        public DateTime Timestamp { get; set; }
        public List<UserProfile> Likes { get; set; } = new List<UserProfile>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}