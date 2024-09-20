using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facebook_clone.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ProfilePicture { get; set; } =String.Empty;
        public string CoverPicture { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty; 
        public string Bio { get; set; } = String.Empty;
        
        
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}